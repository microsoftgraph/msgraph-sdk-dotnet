Microsoft Graph .NET Client Library Overview
=====

The Microsoft Graph .NET Client Library is made up of 6 major components:

* A client object
* An authentication provider
* An HTTP provider + serializer
* Request builder objects
* Request objects
* Property bag object model classes for serialization and deserialization

The library is designed to be highly extensible. This overview covers basic scenarios but many of the individual components can be replaced with custom implementations.

## GraphServiceClient

To begin making requests with the library, you will need to initialize a **GraphServiceClient** instance for building and sending requests.

### GraphServiceClientConstructor

| Parameter                                      | Required?      | Default Value                                    |
|:-----------------------------------------------|:---------------|:-------------------------------------------------|
|`IAuthenticationProvider` authenticationProvider| Yes            | n/a                                              |

## IAuthenticationProvider

The authentication provider is responsible for authenticating requests before sending them to the service. The Microsoft Graph .NET Client Library doesn't implement any authentication by default. Instead, you will need to retrieve access tokens for the service via the authentication library of your choice or by coding against one of the authentication endpoints directly. Please [read here](https://docs.microsoft.com/en-us/graph/auth/) for more details about authenticating the Microsoft Graph service.

You can also read about authentication with Kiota generated clients [here](https://learn.microsoft.com/en-us/openapi/kiota/authentication?tabs=csharp)

## Resource model

Microsoft Graph service resource are represented by property bag model classes of the same name in the client library. For example, the [user resource](https://docs.microsoft.com/en-us/graph/api/resources/users) is represented by the [user class](../src/Microsoft.Graph/Generated/model/User.cs) in the client library. Each of these model classes contain properties that represent the properties of the resources they represent.

These classes are used for serializing and deserializing the resources in requests to the service. They do not contain any logic to issue requests.

The resource model classes are generated based on the $metadata description of the service.

## Requests

To make requests against the service, you'll need to build a request using the request builders of the client. The request builder patterns are intended to mirror the REST API pattern.

### 1. Request builders

You get the first request builder from the `GraphServiceClient` object. For example, to get a request builder for the /me navigation you call:

|Task       | SDK                    | URL                            |
|:----------|:----------------------:|:-------------------------------|
|Get me     | graphServiceClient.Me  | GET graph.microsoft.com/v1.0/me|
 
The call will return a `UserRequestBuilder` object. From Me you can continue to chain the request builders.

The [Microsoft Graph API documentation](https://docs.microsoft.com/en-us/graph/api/overview) has more details about the full functionality of the API.


### 2. Request calls

To get /me/calendar you call:

``` csharp
var calendar = await graphServiceClient
    .Me
    .Calendar
    .GetAsync();
```

Any errors while building or sending a request will bubble up as an `ApiException`. See [errors](/docs/errors.md) for more information on errors.

## Query options

If you only want to retrieve certain properties of a resource you can select them. Here's how to get only the ID of the me object:

``` csharp
var user = await graphServiceClient
    .Me
    .GetAsync( requestConfiguration => requestConfiguration.QueryParameters.Select = new string[] { "id"});
```

All properties other than `Id` will be null on the returned user object.

Expand, Skip, Top, OrderBy, and Filter are also supported via the client library when supported by the Microsoft Graph service for the request type.

## Collections

Please see [collections](/docs/collections.md) for details on collections and paging.
