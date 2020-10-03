# Connect

This is a .NET Standard library for interacting with Spotware Connect API, it allows you yo easily interact with Spotware Connect API and perform all kind of trading operations on your cTrader trading accounts.

The library makes it very easy to get an access token, by generating the authentication URL and all necessary things, you just have to use the generated authentication URL and then after you authorized you have to provide back to the library the authentication code, and it will give you a token object which has both access token and refresh token.

The Connect library come with compiled files of Open API proto files, so you don't have to compile the files by your self, in case you want to there is an instruction at the end of this readme file, the files are compiled by Protobuf 3 not 2 so you can use this library on your .NET Core apps.

Spotware Connect API uses Google Protobuf protocol to exchange data between client and server, and if you aren't experienced with it you will have hard time figuring out how to implement it on your .NET app, the Connect library hides all the complexities of Protobuf and allows you to easily and quickly use the API through observable streams.

The library uses Rx observable streams to return back the data from API, it will handle everything related to reading/writing of Network streams on the backend.

You can access all available streams through "Streams" property of client, there is a stream for each API event and response message.

Once you consumed the data you can easily unsubscribe from stream by disposing its IDisposable object, which was returned after you called stream subscribe method.

For sending messages you have to first construct the request messages by creating an instance of Connect API protobuf messages which are implemented on the library and then use the Client object SendMessage method to sent the request.

## Installation

Install <a href="https://www.nuget.org/packages/Connect.Oauth/">Connect.Oauth</a> and <a href="https://www.nuget.org/packages/Connect.Protobuf/">Connect.Protobuf</a> Nuget packages on your .NET app:

```
Install-Package Connect.Oauth
Install-Package Connect.Protobuf
```

## Authentication (Connect.Oauth)

To use the Spotware Connect API you have to have an activated API application, which you can create at: <a href="https://connect.spotware.com/">https://connect.spotware.com/</a>

After your application got activated, create an "App" class instance and give it your application credentials:

```c# 
App app = new App(appId, appSecret, redirectUrl);
```

Then create an "Auth" object:

```c#
Auth auth = new Auth(app, mode: mode);
```

Auth class constructor gets three arguments, the first one is an app object which is required, the two other are optional:

* Scope: The authentication scope, default is trading
* Mode: Either live if you are using the client for live trading accounts or demo for demo trading accounts

After you created the "Auth" object, you can get the authentication URL via its "AuthUri" property, open this URL on a browser to get an authentication code.

Once you opened the URL on your browser you will see Spotware login page, login and select the accounts that you want to authorize, then it will redirects you to your provided redirect URL, the authentication code will be appended to the end of redirect URL, ex:

```https://redirect_url.com/?code=here_will_be_the_code```

You need this code to generate an access token.

To generate an access token with authentication code, create an "AuthCode" object:

```c#
AuthCode authCode = new AuthCode(auth_code, _app);
```

Then use "TokenFactory" to get a token:

```c#
Token token = TokenFactory.GetToken(authCode);
```

Now you have a token, the token object has these properties:

* Access Token: This is the token that you will use to send requests to API
* Refresh Token: This is the token that you will use to get a new token when your current token expires, this token will never expire
* ExpiresIn: A DateTimeOffset object that gives you the expiry time of token
* ErrorCode: If the token generation was not successful, you can use this property to get the error code
* ErrorDescription: The error description
* Mode: The token mode, either live or demo

If your token expired you can refresh it by sending a ProtoOARefreshTokenReq.

## Sending/Receiving Messages (Connect.Protobuf)

Now that you have an access token you can start interacting with API, first create a client object:

```c#
Client client = new Client();
```

Then connect the client, you must pass the mode (live or demo) to the connect method:

```c#
await client.Connect(Mode.Demo);
```

Once connected the first thing you should do is authorizing your Connect Application:

```c#    
var applicationAuthReq = new ProtoOAApplicationAuthReq
{
  ClientId = app.ClientId,
  ClientSecret = app.Secret,
};

await client.SendMessage(applicationAuthReq, ProtoOAPayloadType.ProtoOaApplicationAuthReq);
```

Once the authentication request sent to server, you will receive back an auth reponse, to get the auth response you can subscribe to ApplicationAuthResponse stream before sending the request message:

```c#  

var disposable = client.Streams.ApplicationAuthResponseStream.Subscribe(ApplicationAuthResponseStream);

private void ApplicationAuthResponseStream(StreamMessage<ProtoOAApplicationAuthRes> message)
{

}
```

After you application got authenticated you can start sending request messages or subscriptions to market data, to receive the requests responses you can use the "Client.Streams", for a complete working example please check the <a href="https://github.com/afhacker/Connect/tree/master/src/ConsoleTester">Console Tester</a> application.

## Keeping Connection Alive

You don't have to send any heartbeat request, the client itself automatically send heartbeat requests based on your latest message sent time and it keeps the connection alive until you call client dispose method.

## Disposing Client

When you finsihed working with client you must call either Dispose or DisposeAsync method, or put the client inside a using block, otherwise the connection will remain open.

## Compiling Proto Files

If you are using this library it came with compiled proto files of Spotware Open API and we do our best to keep the files update, in case there was a new version of proto files available and we weren't updated the files in library you can clone the library and compile the new proto files, then replace the library proto files with your compiled ones, the message files are located at Protobuf project inside Messages directory.

For compiling the proto files there is a guide available on Spotware Open API documentation but that is out dated and if you compile the files by following their instruction you will endup with Protobuf 2.0 which is old version and not supported anymore by Google, the new Protobuf 3 compiler can compile the old version files, Open API uses 2.0 but you can use the new version compiler and benifit from all the new features of version 3.

If you use the old version compiled files then you can't use .NET Core, because the Google Protobuf 2 .NET library is only available for .NET framework.

We recommend you to use our compiling instruction instead of Spotware documentation instruction, this instruction is for Windows and you can follow the Google standard instruction on Protobuf documentation if you are using Linux.

1. Download the proto files from Spotware provided link/repo
2. Download the Google Protobuf latest version from <a href="https://github.com/protocolbuffers/protobuf/releases">here</a>
3. Extract the Google Protobuf, there will be a "bin" folder, copy the ".proto" files there
4. Open "CMD", go to bin folder location, and type:

```
protoc --csharp_out=. ./proto_file_name.proto
```
Instead of "proto_file_name.proto" you have to provide each of the proto files names, you have to execute this command for each proto file.

After executing the command there will be a ".cs" file for the proto file, you can use those files instead of library default message files.

Don't forget to update the library Google Protobuf library to the version that you used for compiling the proto files, otherwise you will see lots of errors and you will not be able to build the project.

## Dependencies

* <a href="https://github.com/protocolbuffers/protobuf">protobuf</a>
* <a href="https://github.com/JamesNK/Newtonsoft.Json">Newtonsoft.Json</a>
* <a href="https://github.com/restsharp/RestSharp">RestSharp</a>
* <a href="https://github.com/dotnet/reactive">Reactive</a>

## Licence

Connect is licenced under the [MIT licence](licence.md).
