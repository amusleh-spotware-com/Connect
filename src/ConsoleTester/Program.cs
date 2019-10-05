using Connect.Common.Enums;
using Connect.Oauth.Factories;
using Connect.Oauth.Models;
using Connect.Protobuf;
using Connect.Protobuf.Helpers;
using Connect.Protobuf.Models.Parameters;
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

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Enter App ID");

            string appId = Console.ReadLine();

            Console.WriteLine("Enter App Secret");

            string appSecret = Console.ReadLine();

            Console.WriteLine("Enter App Redirect URL");

            string redirectUrl = Console.ReadLine();

            _app = new App(appId, appSecret, redirectUrl);

            Console.WriteLine("Enter Authentication Code");

            string code = Console.ReadLine();

            AuthCode authCode = new AuthCode(code, _app);

            _token = TokenFactory.GetToken(authCode);

            _client = new Client();

            _client.Events.MessageReceivedEvent += Events_MessageReceivedEvent;
            _client.Events.ErrorEvent += Events_ErrorEvent;
            _client.Events.ListenerExceptionEvent += Events_ListenerExceptionEvent;

            Console.WriteLine("Enter Connection Mode (Live or Sandbox)");

            string connectionMode = Console.ReadLine();

            Mode mode = (Mode)Enum.Parse(typeof(Mode), connectionMode, true);

            Console.WriteLine("Connecting Client...");

            await _client.Connect(mode);

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Client successfully connected");

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Sending App Auth Req...");

            Console.WriteLine("Please wait...");

            Console.WriteLine("--------------------------------------");

            var parameters = new AppAuthorizationRequestParameters
            {
                ClientId = _app.ClientId,
                ClientSecret = _app.Secret,
            };

            await _client.SendMessage(MessagesFactory.CreateAppAuthorizationRequest(parameters));

            await Task.Delay(5000);

            Console.WriteLine("You should see the application auth response message before entering any command");

            GetCommand();
        }

        private static void Events_MessageReceivedEvent(object sender, ProtoMessage e)
        {
            if (e.PayloadType == (int)ProtoPayloadType.HEARTBEAT_EVENT)
            {
                return;
            }

            Console.WriteLine($"MessageReceived:\n{e.GetTextPresentation()}");

            Console.WriteLine("--------------------------------------");
        }

        private static void Events_ListenerExceptionEvent(object sender, Exception ex)
        {
            Console.WriteLine($"ListenerExceptionEvent");
            Console.WriteLine($"Exception\n: {ex}");

            Console.WriteLine("--------------------------------------");
        }

        private static void Events_ErrorEvent(object sender, ProtoOAErrorRes e)
        {
            Console.WriteLine($"Error:\n{e}");

            Console.WriteLine("--------------------------------------");
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

            var parameters = new LiveTrendbarRequestParameters(ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_LIVE_TRENDBAR_REQ)
            {
                Period = (ProtoOATrendbarPeriod)Enum.Parse(typeof(ProtoOATrendbarPeriod), commandSplit[2], true),
                AccountId = long.Parse(commandSplit[3]),
                SymbolId = long.Parse(commandSplit[4]),
            };

            await _client.SendMessage(MessagesFactory.CreateSubscribeForLiveTrendbarRequest(parameters));
        }

        private async static void SubscribeToSymbolSpot(string[] commandSplit)
        {
            Console.WriteLine("Subscribing to symbol spot event...");

            var parameters = new SpotsRequestParameters(ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ)
            {
                AccountId = long.Parse(commandSplit[2]),
                SymbolIds = commandSplit.Skip(3).Select(iSymbolId => long.Parse(iSymbolId)).ToList(),
            };

            await _client.SendMessage(MessagesFactory.CreateSubscribeForSpotsRequest(parameters));
        }

        private async static void SymbolListRequest(string[] commandSplit)
        {
            var accountId = long.Parse(commandSplit[1]);

            Console.WriteLine("Sending symbols list req...");

            var parameters = new SymbolsListRequestParameters
            {
                AccountId = accountId,
            };

            await _client.SendMessage(MessagesFactory.CreateSymbolsListRequest(parameters));
        }

        private async static void AccountListRequest()
        {
            Console.WriteLine("Sending account list req...");

            var parameters = new AccountListRequestParameters
            {
                Token = _token.AccessToken,
            };

            await _client.SendMessage(MessagesFactory.CreateAccountListRequest(parameters));
        }

        private async static void AccountAuthRequest(string[] commandSplit)
        {
            var accountId = long.Parse(commandSplit[1]);

            Console.WriteLine("Sending account auth req...");

            var parameters = new AccountAuthorizationRequestParameters
            {
                AccountId = accountId,
                Token = _token.AccessToken
            };

            await _client.SendMessage(MessagesFactory.CreateAccountAuthorizationRequest(parameters));
        }

        private static void GetCommand()
        {
            Console.WriteLine("Enter command, example: help");

            string command = Console.ReadLine();

            ProcessCommand(command);
        }
    }
}