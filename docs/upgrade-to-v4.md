# Microsoft Graph .NET SDK v4 changelog and upgrade guide

The purpose of this document is to outline any breaking change and migration work SDK users might run into while upgrading to the v4 of the SDK.

## Breaking changes

To improve the development experience provided by the SDK, it was necessary to make the following breaking changes in addition to the changes listed in the migration guide below:

 * .NET Standard minimum version bumped from `netstandard1.3` to `netstandard2.0`
 * .NET Framework minimum version bumped from `net45` to `net462`
 * Replacing Newtonsoft.Json dependency with System.Text.Json for serialization/de-serialization
 * Upgrading Microsoft.Graph.Core dependency to version 2.0.0

## Upgrade guide for breaking changes

The following section lists out the breaking changes requiring code changes from SDK users.

### System.Text.Json replaces Newtonsoft.Json

Updating to the latest version of the library involves the migration from [Newtonsoft.Json](https://www.newtonsoft.com/json) to System.Text.Json. You can always read more about the differences between the two libraries [here](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to?pivots=dotnet-5-0#table-of-differences-between-newtonsoftjson-and-systemtextjson).

From the SDK developer experience, these are the main changes to look out for when upgrading.

1. Object types and function parameters using Newtonsoft's JToken are now replaced by System.Text.Json's JsonDocument.

  For example, the code sample :-

```cs
GraphServiceClient graphClient = new GraphServiceClient( authProvider );

int index = 5;

JToken values = JToken.Parse("[[1,2,3],[4,5,6]]");

await graphClient.Me.Drive.Items["{id}"].Workbook.Tables["{id|name}"].Rows
	.Add(index,values)
	.Request()
	.PostAsync();
```

  would change to :-

```cs
GraphServiceClient graphClient = new GraphServiceClient( authProvider );

int index = 5;

JsonDocument values = JsonDocument.Parse("[[1,2,3],[4,5,6]]");

await graphClient.Me.Drive.Items["{id}"].Workbook.Tables["{id|name}"].Rows
	.Add(index,values)
	.Request()
	.PostAsync();
```

2. Objects present in the AdditionalData bag are now of type JsonElement from System.Text.Json rather than Newtonsoft's derivatives of JToken(i.e JArray, String or JObject)

You can always infer if the JsonElement is an array/string/boolean/object from the [ValueKind](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonvaluekind?view=net-5.0) property and then call a relevant method to get the value (e.g [GetString()](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonelement.getstring?view=net-5.0#System_Text_Json_JsonElement_GetString) or [ToString()](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonelement.tostring?view=net-5.0#System_Text_Json_JsonElement_ToString) if you have inferred the element is a string.)

You can find other relevant JsonElement methods [here](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonelement?view=net-5.0#methods).

3. System.Text.Json enforces stricter json standards than Newtonsoft (e.g. trailing commas and comments are not allowed). 

In the event a user would like to use this, you can check out the guide [here](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-invalid-json?pivots=dotnet-5-0) and use it to override the current default serializer options.

For example:-
```cs
// Add extra options
var options = new JsonSerializerOptions
{
    ReadCommentHandling = JsonCommentHandling.Skip,
    AllowTrailingCommas = true,
};

Serializer serializer = new Serializer(options);
IResponseHandler responseHandler = new ResponseHandler(serializer); // Our Response Handler with custom Serializer

User me = await graphClient.Me.Request()
                .WithResponseHandler(responseHandler)
                .GetAsync();
```

### IBaseRequest now takes IResponseHandler as a member

The `IBaseRequest` interface now has a new member of type `IResponseHandler`. Any existing code that derives from it will now have to take this into consideration.

### Method property in IBaseRequest is of type enum from string.

The `Method` property in the `IBaseRequest` interface now is of type enum. Any existing code that derives from it will now have to take this into consideration by changing the string values to the enum values provided now provided in the library.

### HTTP Status Code and Headers are not placed into the AdditionalData

Since the HTTP status code and response headers are now available through the [GraphResponse](#graph-response) object, the default response handler will no longer put this information into the AdditionalData property bag. This is to allow for a better user experience and better performance on deserialization of the response payload.

### GraphServiceClient no longer implements the IGraphServiceClient

The `IGraphServiceClient` interface is not really an interface because it continues to change with metadata changes. This makes it not ideal to mock or inherit. The interface has therefore been removed and no longer exists.

To alleviate challenges brought about by using mocking frameworks(such Moq), the properties/methods of the `GraphServiceClient` have been made virtual. 
Therefore, one should be able to mock and mock and write tests in a fashion similar to the example below :-

```cs
// Arrange
var mockAuthProvider = new Mock<IAuthenticationProvider>();
var mockHttpProvider = new Mock<IHttpProvider>();
var mockGraphClient = new Mock<GraphServiceClient>(mockAuthProvider.Object, mockHttpProvider.Object);

ManagedDevice md = new ManagedDevice
{
    Id = "1",
    DeviceCategory = new DeviceCategory()
    {
        Description = "Sample Description"
    }
};

// setup the calls
mockGraphClient.Setup(g => g.DeviceManagement.ManagedDevices["1"].Request().GetAsync(CancellationToken.None)).Returns(Task.Run(() => md)).Verifiable();

// Act
var graphClient = mockGraphClient.Object;
var device = await graphClient.DeviceManagement.ManagedDevices["1"].Request().GetAsync(CancellationToken.None);

// Assert
Assert.Equal("1",device.Id);
```

## New capabilities

### Azure Identity

The Microsoft Graph library now supports the use of TokenCredential classes in the Azure.Identity library through the new `TokenCredentialAuthProvider`.

You can read more about available Credential classes [here](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/identity-readme#key-concepts) and this is encouraged to be used in place of the `Microsoft.Graph.Auth` package.

For example, rather than using the [Interactive provider](https://docs.microsoft.com/en-us/graph/sdks/choose-authentication-providers?tabs=CS#InteractiveProvider) from the `Microsoft.Graph.Auth` package, one could use the [InteractiveBrowserCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet) class from `Azure.Identity` as follows.

#### Example using Microsoft.Graph.Auth

```cs
string[] scopes = {"User.Read"};

IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
            .Create(clientId)
            .Build();

InteractiveAuthenticationProvider authProvider = new InteractiveAuthenticationProvider(publicClientApplication, scopes);

GraphServiceClient graphClient = new GraphServiceClient(authProvider);

User me = await graphClient.Me.Request()
                .GetAsync();
```

#### Example using TokenCredential class

```cs
string[] scopes = {"User.Read"};

InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions() {
                ClientId = clientId
};
InteractiveBrowserCredential interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

GraphServiceClient graphClient = new GraphServiceClient(myBrowserCredential, scopes); // you can pass the TokenCredential directly to the GraphServiceClient

User me = await graphClient.Me.Request()
                .GetAsync();
```

You can check out examples on how to quickly setup other TokenCredential instances [here](tokencredentials.md).

### Microsoft Identity Web
Although this version supports Azure Identity, for Web/API scenarios, we encourage you to use the [Microsoft.Identity.Web](https://github.com/AzureAD/microsoft-identity-web) library. Check the [Wiki](https://github.com/AzureAD/microsoft-identity-web/wiki) section to get more information. 

For example, here is a sample of a [WebApp calling Graph](https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/tree/master/2-WebApp-graph-user), and here is a sample of a [Web API calling Graph](https://github.com/Azure-Samples/active-directory-dotnet-native-aspnetcore-v2/tree/master/2.%20Web%20API%20now%20calls%20Microsoft%20Graph)

### Graph Response

To enable SDK users to have easier access to response information like response headers and status codes, we have introduced the GraphResponse object which also involves the following new methods being added which correspond to the existing API methods.

* `GetResponseAsync(): : GraphResponse<T>`
* `AddResponseAsync(NewObject: Entity) : GraphResponse<T>`
* `CreateResponseAsync(NewObject: Entity) : GraphResponse<T>`
* `PostResponseAsync(NewObject: Entity) : GraphResponse<T>`
* `UpdateResponseAsync(UpdatedObject: Entity) : GraphResponse<T>`
* `PutResponseAsync(UpdatedObject: Entity) : GraphResponse<T>`
* `DeleteResponseAsync() : GraphResponse`  (no generic here) 

Essentially, using the fluent APIs of the service libraries should remain the same as follows
```cs
User me = await graphClient.Me.Request()
                .GetAsync();
```

However, should you choose to want access to response headers and status codes a user can now do this.

```cs
GraphResponse<User> userResponse = await graphClient.Me.Request()
                                        .GetResponseAsync();

// Get the status code
HttpStatusCode status = userResponse.StatusCode;
// Get the headers
HttpResponseHeaders headers = userResponse.HttpHeaders;
// Get the user object using inbuilt serializer
User me = await userResponse.GetResponseObjectAsync();
``` 

If you choose you can even deserialize the response in your own custom way as follows.

1. Use a custom IResponseHandler
```cs
ISerializer serializer = new CustomSerializer(); // Custom Serializer
IResponseHandler responseHandler = new ResponseHandler(serializer); // Our Response Handler with custom Serializer

var patchUser = new User()
{
    DisplayName = "Graph User"
};

GraphResponse<User> graphResponse = await graphServiceClient.Me.Request()
                                                    .WithResponseHandler(responseHandler) // customized response handler
                                                    .UpdateWithGraphResponseAsync<User>(patchUser, cancellationToken); // response with no serialization

User user = graphResponse.GetResponseObjectAsync(); // calls the Response Handler with custom serializer
```

2. Read the response and deserialize it.(Example using Newtonsoft)

```cs
GraphResponse<User> userResponse = await graphClient.Me.Request()
                .GetResponseAsync();

JsonSerializer serializer = new JsonSerializer(); // Custom serializer

using (StreamReader sr = new StreamReader(userResponse.Content.ReadAsStreamAsync()))
using (JsonTextReader jsonTextReader = new JsonTextReader(sr))
{
    User deserializedProduct = serializer.Deserialize(jsonTextReader);
}

```

### Added support for encrypted content for rich notifications

The SDK now includes native support to decrypt resource data in rich notifications payloads. 
When creating a subscription, the user can now simply use the `AddPublicEncryptionCertificate` method to add the certificate to use for encryption/decryption.

```cs
// create a subscription to listen to new and edited teams messages sent 
var subscription = new Subscription
{
    ChangeType = "created,updated",
    IncludeResourceData = true,
    NotificationUrl = _config.Ngrok + "/api/notifications",
    Resource = "/teams/getAllMessages",
    ExpirationDateTime = DateTime.UtcNow.AddMinutes(5),
    ClientState = "SecretClientState",
    EncryptionCertificateId = "my-custom-id",
};

// Load a X509Certificate in to the subscription object.
subscription.AddPublicEncryptionCertificate(this._certificate);

var newSubscription = await graphServiceClient
    .Subscriptions
    .Request()
    .AddAsync(subscription);
```

Once the subscription is created, one can now use the `AreTokensValid` function to validate tokens and the `DecryptAsync` function to decrypt the encrypted content on the notification payload. 
An example controller listening for notifications could look as follows

```cs
public async Task<ActionResult<string>> Post([FromQuery] string validationToken = null)
{
    // handle validation
    if (!string.IsNullOrEmpty(validationToken))
    {
        Console.WriteLine($"Received Token: '{validationToken}'");
        return Ok(validationToken);
    }
    var graphServiceClient = GetGraphClient();
    var myTenantIds = new Guid[] { new Guid(_config.TenantId) };
    var myAppIds = new Guid[] { new Guid(_config.AppId) };
    
    // handle notifications
    var content = await new StreamReader(Request.Body).ReadToEndAsync();
    var collection = graphServiceClient.HttpProvider.Serializer.DeserializeObject<ChangeNotificationCollection>(content);
    
    // validate the tokens
    var areTokensValid = await collection.AreTokensValid(myTenantIds, myAppIds);
    foreach (var changeNotification in collection.Value)
    {
        // Decrypt the encryptedContent
        var attachedChatMessage = await changeNotification.EncryptedContent.DecryptAsync<ChatMessage>((id, thumbprint) => Task.FromResult(this._certificate));
        if (areTokensValid)
        {
            // handle the decrypted object infromation
            Console.WriteLine($"Message time: {attachedChatMessage.CreatedDateTime}");
            Console.WriteLine($"Message from: {attachedChatMessage.From?.User?.DisplayName}");
            Console.WriteLine($"Message content: {attachedChatMessage.Body.Content}");
            Console.WriteLine();
        }
    }
    return Ok();
}
```
To learn more about rich notifications, you can read about the topic [here](https://docs.microsoft.com/en-us/graph/webhooks-with-resource-data).

## Bug fixes

### @odata.type is no longer specified by default for all types

In version 3 of the SDK, all the generated types had the @odata.type property set which led to the serialization of the property to cause errors as seen in the several issues( #909, #560, #283). This would mean that SDK users would need to have to make workarounds as below.

```cs
await _graphServiceClient
        .TrustFramework
        .KeySets
        .Request()
        .AddAsync(new TrustFrameworkKeySet()
        {
            Id = keySetId,
            ODataType = null    // Work around needed
        });
```

To mitigate this, the odata.type parameter is now set only in instances where we will need to do type disambiguation. These include,

1. When type derives from an abstract type
2. When one of its base types is referenced as the type for a property in another type (except if the base is entity).
3. When one of its base types is referenced as the type in an odata action in another type (except if the base is entity).

## Remarks about this guide

This guide is written to be as exhaustive as possible, it is possible that we forgot to mention some breaking changes. If you experience breaking changes in your upgrade process that are not already listed in this guide, please open an issue or a pull request to add any information that might be missing.
