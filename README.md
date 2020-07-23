# Connect

This a .NET Standard library for interacting with Spotware Connect API, it allows you yo easily interact with Spotware Connect API and perform all kind of trading operations on your cTrader trading accounts.

The library makes it very easy to get an access token, by generating the authentication URL and all necessary things, you just have to use the generated authentication URL and then after you authorized you have to provide back to the library the authentication code, and it will give you a token object which has both access token and refresh token.

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

Once you opened the URL on your browser you will Spotware login page, login and select the accounts that you want to authorize, then it will redirects you to your provided redirect URL, the authentication code will be appended to the end of redirect URL, ex:

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
* Mode: The token mdoe, either live or demo

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

## Dependencies

* <a href="https://github.com/protocolbuffers/protobuf">protobuf</a>
* <a href="https://github.com/JamesNK/Newtonsoft.Json">Newtonsoft.Json</a>
* <a href="https://github.com/restsharp/RestSharp">RestSharp</a>
* <a href="https://github.com/dotnet/reactive">Reactive</a>

## Licence

Connect is licenced under the [MIT licence](licence.md).
