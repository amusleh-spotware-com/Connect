using Connect.Common;
using Connect.Protobuf;
using Connect.Protobuf.Models.Parameters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProtobufConsoleTesterApp
{
    internal class Program
    {
        private static string _appId;

        private static string _appSecret;

        private static string _accessToken;

        private static Client _client;

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Enter App ID");

            _appId = Console.ReadLine();

            Console.WriteLine("Enter App Secret");

            _appSecret = Console.ReadLine();

            Console.WriteLine("Enter Access Token");

            _accessToken = Console.ReadLine();

            _client = new Client();

            _client.Events.MessageReceivedEvent += Events_MessageReceivedEvent;
            _client.Events.ErrorEvent += Events_ErrorEvent;
            _client.Events.ListenerExceptionEvent += Events_ListenerExceptionEvent;

            Console.WriteLine("Connecting Client...");

            await _client.Connect(Mode.Live);

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Client successfully connected");

            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Sending App Auth Req...");

            Console.WriteLine("Please wait...");

            Console.WriteLine("--------------------------------------");

            var parameters = new AppAuthorizationRequestParameters
            {
                ClientId = _appId,
                ClientSecret = _appSecret,
            };

            await _client.SendMessage(MessagesFactory.CreateAppAuthorizationRequest(parameters));

            await Task.Delay(5000);

            Console.WriteLine("You should see the application auth response message before entering any command");

            GetCommand();
        }

        private static void Events_MessageReceivedEvent(object sender, ProtoMessage e)
        {
            Console.WriteLine($"MessageReceived:\n{e}");

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

        private async static void ProcessCommand(string command)
        {
            var commandSplit = command.Split(' ');

            switch (commandSplit[0].ToLowerInvariant())
            {
                case "help":
                    Console.WriteLine("For getting accounts list type: accountlist\n");
                    Console.WriteLine("For authorizing an account type: accountauth {Account ID}\n");
                    Console.WriteLine("For getting an account symbols list type (Account authorization is required): symbolslist {Account ID}\n");
                    Console.WriteLine("For subscribing to symbol(s) spot quotes type (Account authorization is required): subscribe symbolspot {Account ID} {Symbol ID,}\n");
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

            await Task.Delay(3000);

            GetCommand();
        }

        private static void ProcessSubscriptionCommand(string[] commandSplit)
        {
            switch (commandSplit[1].ToLowerInvariant())
            {
                case "symbolspot":
                    SubscribeToSymbolSpot(commandSplit);
                    break;

                default:
                    Console.WriteLine($"'{commandSplit[1]}' is not recognized as a subscription command, please use help command to get all available commands list");
                    break;
            }
        }

        private async static void SubscribeToSymbolSpot(string[] commandSplit)
        {
            var accountId = long.Parse(commandSplit[2]);

            Console.WriteLine("Subscribing to symbol spot event...");

            var parameters = new SpotsRequestParameters(ProtoOAPayloadType.PROTO_OA_SUBSCRIBE_SPOTS_REQ)
            {
                AccountId = accountId,
                SymbolIds = commandSplit.Skip(3).Select(iSymbolId => long.Parse(iSymbolId)).ToList()
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
                Token = _accessToken
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
                Token = _accessToken
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