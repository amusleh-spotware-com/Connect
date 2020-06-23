using Connect.Common.Enums;
using Connect.Oauth.Factories;
using Connect.Oauth.Models;
using Connect.Protobuf;
using Connect.Protobuf.Helpers;
using Google.Protobuf;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProtobufConsoleTesterApp
{
    internal class Program
    {
        private static App _app;

        private static Token _token;

        private static Client _client;

        private static async Task Main()
        {
            Console.Write("Enter App ID: ");

            string appId = Console.ReadLine();

            Console.Write("Enter App Secret: ");

            string appSecret = Console.ReadLine();

            Console.Write("Enter App Redirect URL: ");

            string redirectUrl = Console.ReadLine();

            _app = new App(appId, appSecret, redirectUrl);

            Console.Write("Enter Connection Mode (Live or Demo): ");

            string connectionMode = Console.ReadLine();

            var mode = (Mode)Enum.Parse(typeof(Mode), connectionMode, true);

            var auth = new Auth(_app, mode: mode);

            System.Diagnostics.Process.Start(auth.AuthUri.ToString());

            ShowDashLine();

            Console.WriteLine("Follow the authentication steps on your browser, then copy the authentication code from redirect" +
                " URL and paste it here.");

            Console.WriteLine("The authentication code is at the end of redirect URL and it starts after '?code=' parameter.");

            ShowDashLine();

            Console.Write("Enter Authentication Code: ");

            string code = Console.ReadLine();

            AuthCode authCode = new AuthCode(code, _app);

            _token = TokenFactory.GetToken(authCode);

            Console.WriteLine("Access token generated");

            ShowDashLine();

            _client = new Client();

            _client.Events.MessageReceivedEvent += Events_MessageReceivedEvent;
            _client.Events.ErrorEvent += Events_ErrorEvent;
            _client.Events.ListenerExceptionEvent += Events_ListenerExceptionEvent;

            Console.WriteLine("Connecting Client...");

            await _client.Connect(mode);

            ShowDashLine();

            Console.WriteLine("Client successfully connected");

            ShowDashLine();

            Console.WriteLine("Sending App Auth Req...");

            Console.WriteLine("Please wait...");

            ShowDashLine();

            var applicationAuthReq = new ProtoOAApplicationAuthReq
            {
                ClientId = _app.ClientId,
                ClientSecret = _app.Secret,
            };

            var protoMessage = ProtoMessageGenerator.GetProtoMessage(ProtoOAPayloadType.ProtoOaApplicationAuthReq,
                applicationAuthReq.ToByteString());

            await _client.SendMessage(protoMessage);

            await Task.Delay(5000);

            Console.WriteLine("You should see the application auth response message before entering any command");

            Console.WriteLine("For commands list and description use 'help' command");

            ShowDashLine();

            GetCommand();
        }

        private static void Events_MessageReceivedEvent(object sender, ProtoMessage e)
        {
            if (e.PayloadType == (int)ProtoPayloadType.HeartbeatEvent)
            {
                return;
            }

            Console.WriteLine($"MessageReceived:\n{e.GetTextPresentation()}");

            ShowDashLine();
        }

        private static void Events_ListenerExceptionEvent(object sender, Exception ex)
        {
            Console.WriteLine($"ListenerExceptionEvent");
            Console.WriteLine($"Exception\n: {ex}");

            ShowDashLine();
        }

        private static void Events_ErrorEvent(object sender, ProtoOAErrorRes e)
        {
            Console.WriteLine($"Error:\n{e}");

            ShowDashLine();
        }

        private static void ProcessCommand(string command)
        {
            var commandSplit = command.Split(' ');
            try
            {
                switch (commandSplit[0].ToLowerInvariant())
                {
                    case "help":
                        Console.WriteLine("For getting accounts list type: accountlist\n");
                        Console.WriteLine("For authorizing an account type: accountauth {Account ID}\n");
                        Console.WriteLine("For getting an account symbols list type (Requires account authorization): symbolslist {Account ID}\n");
                        Console.WriteLine("For subscribing to symbol(s) spot quotes type (Requires account authorization): subscribe spot {Account ID} {Symbol ID,}\n");
                        Console.WriteLine("For subscribing to symbol(s) trend bar type (Requires account authorization and spot subscription): subscribe trendbar {Period} {Account ID} {Symbol ID}\n");
                        Console.WriteLine("For trend bar period parameter, you can use these values:");

                        Enum.GetValues(typeof(ProtoOATrendbarPeriod)).Cast<ProtoOATrendbarPeriod>().ToList()
                            .ForEach(iTrenBarPeriod => Console.WriteLine(iTrenBarPeriod));

                        break;

                    case "accountlist":
                        AccountListRequest();
                        break;

                    case "accountauth":
                        AccountAuthRequest(commandSplit);
                        break;

                    case "symbolslist":
                        SymbolListRequest(commandSplit);
                        break;

                    case "subscribe":
                        ProcessSubscriptionCommand(commandSplit);
                        break;

                    default:
                        Console.WriteLine($"'{command}' is not recognized as a command, please use help command to get all available commands list");
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    Console.WriteLine(ex);
                }
                else
                {
                    throw;
                }
            }

            Task.Delay(3000).Wait();

            GetCommand();
        }

        private static void ProcessSubscriptionCommand(string[] commandSplit)
        {
            switch (commandSplit[1].ToLowerInvariant())
            {
                case "spot":
                    SubscribeToSymbolSpot(commandSplit);
                    break;

                case "trendbar":
                    SubscribeToSymbolTrendBar(commandSplit);
                    break;

                default:
                    Console.WriteLine($"'{commandSplit[1]}' is not recognized as a subscription command, please use help command to get all available commands list");
                    break;
            }
        }

        private async static void SubscribeToSymbolTrendBar(string[] commandSplit)
        {
            Console.WriteLine("Subscribing to symbol trend bar event...");

            var subscribeLiveTrendbarReq = new ProtoOASubscribeLiveTrendbarReq()
            {
                Period = (ProtoOATrendbarPeriod)Enum.Parse(typeof(ProtoOATrendbarPeriod), commandSplit[2], true),
                CtidTraderAccountId = long.Parse(commandSplit[3]),
                SymbolId = long.Parse(commandSplit[4]),
            };

            var message = ProtoMessageGenerator.GetProtoMessage(ProtoOAPayloadType.ProtoOaSubscribeLiveTrendbarReq,
                subscribeLiveTrendbarReq.ToByteString());

            await _client.SendMessage(message);
        }

        private async static void SubscribeToSymbolSpot(string[] commandSplit)
        {
            Console.WriteLine("Subscribing to symbol spot event...");

            var subscribeSpotsReq = new ProtoOASubscribeSpotsReq()
            {
                CtidTraderAccountId = long.Parse(commandSplit[2]),
            };

            subscribeSpotsReq.SymbolId.AddRange(commandSplit.Skip(3).Select(iSymbolId => long.Parse(iSymbolId)));

            var message = ProtoMessageGenerator.GetProtoMessage(ProtoOAPayloadType.ProtoOaSubscribeSpotsReq,
                subscribeSpotsReq.ToByteString());

            await _client.SendMessage(message);
        }

        private async static void SymbolListRequest(string[] commandSplit)
        {
            var accountId = long.Parse(commandSplit[1]);

            Console.WriteLine("Sending symbols list req...");

            var symbolsListReq = new ProtoOASymbolsListReq
            {
                CtidTraderAccountId = accountId,
            };

            var message = ProtoMessageGenerator.GetProtoMessage(ProtoOAPayloadType.ProtoOaSymbolsListReq,
                symbolsListReq.ToByteString());

            await _client.SendMessage(message);
        }

        private async static void AccountListRequest()
        {
            Console.WriteLine("Sending account list req...");

            var accountListByAccessTokenReq = new ProtoOAGetAccountListByAccessTokenReq
            {
                AccessToken = _token.AccessToken,
            };

            var message = ProtoMessageGenerator.GetProtoMessage(ProtoOAPayloadType.ProtoOaGetAccountsByAccessTokenReq,
                accountListByAccessTokenReq.ToByteString());

            await _client.SendMessage(message);
        }

        private async static void AccountAuthRequest(string[] commandSplit)
        {
            var accountId = long.Parse(commandSplit[1]);

            Console.WriteLine("Sending account auth req...");

            var accountAuthReq = new ProtoOAAccountAuthReq
            {
                CtidTraderAccountId = accountId,
                AccessToken = _token.AccessToken
            };

            var message = ProtoMessageGenerator.GetProtoMessage(ProtoOAPayloadType.ProtoOaAccountAuthReq,
                accountAuthReq.ToByteString());

            await _client.SendMessage(message);
        }

        private static void GetCommand()
        {
            Console.Write("Enter command: ");

            string command = Console.ReadLine();

            ProcessCommand(command);
        }

        private static void ShowDashLine() => Console.WriteLine("--------------------------------------------------");
    }
}