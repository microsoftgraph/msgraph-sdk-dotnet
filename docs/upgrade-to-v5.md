# Microsoft Graph .NET SDK v5 changelog and upgrade guide

The purpose of this document is to outline any breaking change and migration work SDK users might run into while upgrading to the v5 of the SDK.

## Overview
V5 of the Microsoft Graph .NET SDK moves to the new code generator [Kiota](https://github.com/microsoft/kiota) to provide a better user experience for the SDK users as well as a number of new features made possible by these changes.

## Breaking changes

The following section lists out the breaking changes requiring code changes from SDK users.

### Namespaces/Usings changes

The types in the sdk are now organized into namespaces reflecting their usage as compared to all types being present in the single `Microsoft.Graph` namespace and therefore makes it easier to consume multiple libraries(e.g v1.0 and beta) in the same application.

This therefore comes with the following changes, 
- The v1.0 service library uses `Microsoft.Graph` as its root namespace. 
- The beta service library uses `Microsoft.Graph.Beta` as its root namespace.
- Model types are now in the  `Microsoft.Graph.Models`/`Microsoft.Graph.Beta.Models` namespaces.
- RequestBuilder and RequestBody types reside in namespaces relative to the path they are calling. e.g. The `SendMailPostRequestBody` type will reside in the `Microsoft.Graph.Beta.Me.SendMail/Microsoft.Graph.Me.SendMail` namespace if you are sending a mail via the `client.Me.SendMail.PostAsync(sendMailPostRequestBody)` path using the request builders

### Authentication

The `GraphServiceClient` constructor accepts instances of `TokenCredential` from Azure.Identity similar to previous library version as follows

```cs
var interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);
var graphServiceClient = new GraphServiceClient(interactiveBrowserCredential);
```

In place of the DelegateAuthenticationProvider, custom authentication flows can be done creating an implementation of [IAccessTokenProvider](https://github.com/microsoft/kiota-abstractions-dotnet/blob/main/src/authentication/IAccessTokenProvider.cs), and using with the [BaseBearerTokenAuthenticationProvider](https://github.com/microsoft/kiota-abstractions-dotnet/blob/main/src/authentication/BaseBearerTokenAuthenticationProvider.cs) from the Kiota abstractions as follows

```cs
public class TokenProvider : IAccessTokenProvider
{
    public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
        CancellationToken cancellationToken = default)
    {
        var token = "token";
        // get the token and return it in your own way
        return Task.FromResult(token);
    }

    public AllowedHostsValidator AllowedHostsValidator { get; }
}
```

Then create the `GraphServiceClient` as follows

```cs
var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider());
var graphServiceClient = new GraphServiceClient(authenticationProvider);
```

> Authentication using the graph client is no longer handled in the HttpClient middleware pipeline. Therefore, using the `GraphServiceClient(httpClient)` constructor will assume that the passed httpClient has already been configured to handle authentication in its pipeline. 
Otherwise, passing an instance of `IAuthenticationProvider` to the constructor (`GraphServiceClient(httpClient, authenticationProvider)`) will make authenticated requests if the passed HttpClient is not already configured.

### Use of `RequestInformation` from Kiota in place of `IBaseRequest`
The `RequestInformation` class is now used to represent requests in the SDK and the `IBaseRequest` is dropped. Using the fluent API, you can always get an instance of the `RequestInformation` as follows.

```cs
// Get the requestInformation to make a GET request
var requestInformation = graphServiceClient
                         .DirectoryObjects
                         .ToGetRequestInformation();

// Get the requestInformation to make a POST request
var directoryObject = new DirectoryObject()
{
    Id = Guid.NewGuid().ToString()
};
var requestInformation = graphServiceClient
                            .DirectoryObjects
                            .ToPostRequestInformation(directoryObject);
```

### Removal of `Request()` from the fluent API

In previous versions, of the SDK, calls involved the calling of `Request()` in the request API as follows

```cs
var user = await graphServiceClient
    .Me
    .Request()  // this is removed
    .GetAsync();
```

A similar call in the V5 will have the `Request()` section removed to be called as below.

```cs
var user = await graphServiceClient
    .Me
    .GetAsync();
```

### Request executor methods

V5 of the SDK simplifies the request methods to simply reflect the HTTP methods being used. This therefore means that 
- `UpdateAsync()` methods are now `PatchAsync()`
- `AddAsync()` methods are now `PostAsync()`

### Headers
To pass headers, the `HeaderOption` class is no longer used. Headers are added using the `requestConfiguration` modifier as follows

```cs
var user = await graphServiceClient
    .Users["{user-id}"]
    .GetAsync(requestConfiguration => requestConfiguration.Headers.Add("ConsistencyLevel","eventual"));
```

### Query Parameter Options
To pass query Options, the `QueryOption` class is no longer used. Query options are set using the `requestConfiguration` modifier as follows

```cs
var user = await graphServiceClient
    .Users["{user-id}"]
    .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Select = new string[] { "id", "createdDateTime"});
```

Example with multiple parameters

```cs
var groups = await graphServiceClient
    .Groups
    .GetAsync(requestConfiguration =>
    {
        requestConfiguration.QueryParameters.Select = new string[] { "id", "createdDateTime","displayName"};
        requestConfiguration.QueryParameters.Expand = new string[] { "members" };
        requestConfiguration.QueryParameters.Filter = "startswith(displayName%2C+'J')";
    });
```

### Per-Request Options
To pass per-request options to the default http middleware to configure actions like redirects and retries, this can be done using the `requestConfiguration` by adding an `IRequestOption` instance to the `Options` collection. For example, adding a `RetryHandlerOption` instance to configure the retry handler option as below.

```cs

var retryHandlerOption = new RetryHandlerOption
{
    MaxRetry = 7,
    ShouldRetry = (delay,attempt,message) => true
};
var user = await graphClient.Me.GetAsync(requestConfiguration => requestConfiguration.Options.Add(retryHandlerOption));
```

Other `IRequestOption` instances provided by default include the following and their source can be found [here](https://github.com/microsoft/kiota-http-dotnet/tree/main/src/Middleware/Options)

- `RetryHandlerOption` - for configuring the retry handler to customise request retries
- `RedirectHandlerOption` - for configuring the redirect handler to customise request redirects
- `ChaosHandlerOption` - for configuring the chaos handler to customise simulated chaos when testing with mock responses

### Native Response Object
The per-request options object can be used to obtain the native `HttpReponseMessage` from the request to override the default response handling of the request builders using the `ResponseHandlerOption` as below. This can be used in scenarios where one wished to access the native response object or customize the response handling by creating and passing an instance of [IResponseHandler](https://github.com/microsoft/kiota-abstractions-dotnet/blob/main/src/IResponseHandler.cs).

```cs
var nativeResponseHandler = new NativeResponseHandler();
await graphClient.Me.GetAsync(requestConfiguration => requestConfiguration.Options.Add(new ResponseHandlerOption(){ ResponseHandler = nativeResponseHandler }));

var responseMessage = nativeResponseHandler.Value as HttpResponseMessage;

```

### Collections

Querying for collections are done as follows and resembles the response from API.

```cs
var usersResponse = await graphServiceClient
    .Users
    .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Select = new string[] { "id", "createdDateTime"});

List<User> userList = usersResponse.Value;
```

### PageIterator
To iterate through page collections, use the pageIterator as follows

```cs
var usersResponse = await graphServiceClient
    .Users
    .GetAsync(requestConfiguration => { 
        requestConfiguration.QueryParameters.Select = new string[] { "id", "createdDateTime" }; 
        requestConfiguration.QueryParameters.Top = 1; 
        });

var userList = new List<User>();
var pageIterator = PageIterator<User,UserCollectionResponse>.CreatePageIterator(graphServiceClient,usersResponse, (user) => { userList.Add(user); return true; });

await pageIterator.IterateAsync();

```

### Error handling
Errors and exceptions from the new generated version will be exception classed derived from the [ApiException](https://github.com/microsoft/kiota-abstractions-dotnet/blob/8a136e509c7a71ef889643f047938bdbc3c752be/src/ApiException.cs#L11) class from the Kiota abstrations library. 
Typically, this will be an instance of [OdataError](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/6d1a78fe1ca7d883667b5f231395651e24581653/src/Microsoft.Graph/Generated/Models/ODataErrors/ODataError.cs#L9) and can be handled as below.

```cs
try
{
    await graphServiceClient.Me.PatchAsync(user);
}
catch (ODataError odataError)
{
    Console.WriteLine(odataError.Error.Code);
    Console.WriteLine(odataError.Error.Message);
    throw;
}
```

### Drive Item paths

The current CSDL to OpenAPI conversion process avoids generation of redundant paths which impacts request builders for driveItems. To mitigate this 
paths should be available through alternative paths as documented in the reference documentation as seen [here](https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0&tabs=http#http-request). 

Examples of using alternative paths are as shown below.

1. List children from a user's drive.

```cs
// Get the user's driveId
var driveItem = await graphServiceClient.Me.Drive.GetAsync();
var userDriveId = driveItem.Id;
// List children in the drive
var children = await graphServiceClient.Drives[userDriveId].Items["itemId"].Children.GetAsync();
```

> NOTE: /drive/root is a shorthand for /drive/items/root so the `itemId` can be replaced with `root` to make a call to get the root folder.

```
// List children in the root drive
var children = await graphServiceClient.Drives[userDriveId].Items["root"].Children.GetAsync();
```

2. List children from a site's drive.

```cs
// Get the site's driveId
var driveItem = await graphServiceClient.Sites["site-id"].Drive.GetAsync();
var siteDriveId = driveItem.Id;
// List children in the drive
var children = await graphServiceClient.Drives[siteDriveId].Items["itemId"].Children.GetAsync();
```

3. List children from a groups's drive.

```cs
// Get the group's driveId
var driveItem = await graphServiceClient.Groups["group-id"].Drive.GetAsync();
var groupDriveId = driveItem.Id;
// List children in the drive
var children = await graphServiceClient.Drives[groupDriveId].Items["itemId"].Children.GetAsync();
```

#### Upload a small file with conflictBehavior set

To upload a small file (remember the size should not exceed 4mb according to the [docs](https://learn.microsoft.com/en-us/graph/api/driveitem-put-content?view=graph-rest-1.0&tabs=http)) and at the same time, set the `conflictBehavior` [instance attribute](https://learn.microsoft.com/en-us/graph/api/resources/driveitem?view=graph-rest-1.0#instance-attributes) you'll need to do it this way:

```cs
var requestInformation = graphClient.Drives[drive.Id.ToString()].Root.ItemWithPath("MediaMeta.xml").Content.ToPutRequestInformation(file);
requestInformation.URI = new Uri(requestInformation.URI.OriginalString +"?@microsoft.graph.conflictBehavior=rename");

var result = await graphClient.RequestAdapter.SendAsync<DriveItem>(requestInformation, DriveItem.CreateFromDiscriminatorValue);
```

To [upload large files](https://learn.microsoft.com/en-us/graph/sdks/large-file-upload?view=graph-rest-1.0&tabs=csharp#upload-large-file-to-onedrive), the method is slightly different.

## New Features

### Backing Store
The backing store allows multiple things like dirty tracking of changes, making it possible to get an object from the API, update a property, send that object back with only the changed property and not the full objects.

This has the added advantage in that SDK user can simply get an object from the API and set a property to null and send back the object without having to use known workarounds where setting properties to null would require to be placed in the additionalData bag.

```cs
// get the object
var @event = await graphServiceClient
    .Me.Events["event-id"]
    .GetAsync();

// the backing store will keep track that the property change and send the updated value.
@event.Recurrence = null;// set to null 

// update the object
await graphServiceClient.Me.Events["event-id"]
    .PatchAsync(@event);
```

### Use of Parameter objects calling Odata functions/actions
To add parameters to an odata action, the SDK uses parameter objects rather than using function overloads to reduce likelihood of the SDK shpping breaking changes.
In the v4 SDK, calling a function/action would look like this.

```cs
//var message = ....
//var saveToSentItems = ...

await graphClient.Me
	.SendMail(message,saveToSentItems)
	.Request()
	.PostAsync();
```

This changes to 

```cs
//var message = ....
//var saveToSentItems = ...

var body = new Microsoft.Graph.Me.SendMail.SendMailPostRequestBody
{
    Message = message,
    SaveToSentItems = saveToSentItems
};

await graphServiceClient.Me
    .SendMail
    .PostAsync(body);
```

### Batch Requests

Apart from passing instances of `HttpRequestMessage`, batch requests support the passing of `RequestInformation` instances as follows.

```cs
var requestInformation = graphServiceClient
                         .Users
                         .ToGetRequestInformation();

// create the batch request
var batchRequestContent = new BatchRequestContent(graphServiceClient);
// add one or more steps (up to 20, or check below)
var requestStepId = await batchRequestContent.AddBatchRequestStepAsync(requestInformation);

// send and get back response
var batchResponseContent = await graphServiceClient.Batch.PostAsync(batchRequestContent);

var usersResponse = await batchResponseContent.GetResponseByIdAsync<UserCollectionResponse>(requestStepId);
List<User> userList = usersResponse.Value;

```

Find failing responses (and retry)

```cs
var statusCodes = await batchResponseContent.GetResponsesStatusCodesAsync();
// all the responses are successfull?
var allReponsesSuccessFull = statusCodes.Any( x => !BatchResponseContent.IsSuccessStatusCode(x.Value));
// the responses with a 
var rateLimitedResponses = statusCodes.Where(x => x.Value == (HttpStatusCode)429);
// maybe retry those rate limited?
var retryBatch = batchRequestContent.NewBatchWithFailedRequests(rateLimitedResponses);
var retryResponse = await graphServiceClient.Batch.PostAsync(retryBatch);
```

Automatically manage batch size with `BatchRequestContentCollection`.
The sample above uses the `BatchRequestContent` which has a limit of max. 20 combined requests. This means you'll need to manage the batch size yourself if you go beyond the batch limit of 20 requests.

```csharp
// Replace BatchRequestContent with BatchRequestContentCollection and you're good to go.
var batchRequestContent = new BatchRequestContentCollection(graphServiceClient);

// or with a set batch size
// var batchRequestContent = new BatchRequestContentCollection(graphServiceClient, 4);

// Add "unlimited" requests, but don't use "DependsOn", you cannot be sure they will be in the same request and thus fail.
var requestStepId = await batchRequestContent.AddBatchRequestStepAsync(requestInformation);

// Execute the request like before and use the response like before.
```

Using batched requests can make your code a lot faster, if you need to query several endpoints at once or if you're creating/deleting a lot of items at the same time. Check out the [sample code](https://github.com/svrooij/msgraph-sdk-dotnet-batching/tree/main/sample/BatchClient) in this [repository](https://github.com/svrooij/msgraph-sdk-dotnet-batching/) for a complete sample on batching and experience yourself how much faster your application can process those requests.

### Support for $count in request builders

The request builders are now enriched with `Count` sections where applicable to enable the use of the $count segment

```cs
var count = await graphServiceClient.Users.Count.GetAsync(requestConfiguration => requestConfiguration.Headers.Add("ConsistencyLevel","eventual"));
```

This addresses the workarounds that SDK users had to make in order to call $count which looked as follows in previous SDK versions(ref [here](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/875))

```cs
string requestUrl = graphClient.Users.AppendSegmentToRequestUrl("$count");
Option [] options = new Option[] { new HeaderOption("ConsistencyLevel", "eventual") };
HttpResponseMessage responseMessage = await new UserRequest(requestUrl, graphClient, options)
                                        .SendRequestAsync(null,CancellationToken.None);
string userCount = await responseMessage.Content.ReadAsStringAsync();
```

### Support for OData Casts in request builders

The request builders are now enriched with segments to enable requesting a specific type in the event an API endpoint supports the odata cast functionality.

An example is fetching the members of a group who are of the type `User` which would be done as below.

```cs
var usersInGroup = await graphServiceClient.Groups["group-id"].Members.GraphUser.GetAsync();
```

Similarly, members of the group of type `Application` would be done as below.

```cs
var applicationsInGroup = await graphServiceClient.Groups["group-id"].Members.GraphApplication.GetAsync();
```
