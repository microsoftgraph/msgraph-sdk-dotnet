# Microsoft Graph .NET Client Library

[![Validate Pull Request](https://github.com/microsoftgraph/msgraph-sdk-dotnet/actions/workflows/validatePullRequest.yml/badge.svg)](https://github.com/microsoftgraph/msgraph-sdk-dotnet/actions/workflows/validatePullRequest.yml)
[![NuGet Version](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

Integrate the [Microsoft Graph API](https://graph.microsoft.com) into your .NET project!

The Microsoft Graph .NET Client Library targets .NetStandard 2.0.

## Installation via NuGet

To install the client library via NuGet:

* Search for `Microsoft.Graph` in the NuGet Library, or
* Type `Install-Package Microsoft.Graph` into the Package Manager Console.

## Getting started

### 1. Register your application

Register your application to use Microsoft Graph API using the [Microsoft Application Registration Portal](https://aka.ms/appregistrations).

### 2. Authenticate for the Microsoft Graph service

The Microsoft Graph .NET Client Library supports the use of TokenCredential classes in the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) library.

You can read more about available Credential classes [here](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/identity-readme#key-concepts) and examples on how to quickly setup TokenCredential instances can be found [here](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/tokencredentials.md).

The recommended library for authenticating against Microsoft Identity (Azure AD) is [MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

For an example of authenticating a UWP app using the V2 Authentication Endpoint, see the [Microsoft Graph UWP Connect Library](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library).

### 3. Create a Microsoft Graph client object with an authentication provider

An instance of the **GraphServiceClient** class handles building requests,
sending them to Microsoft Graph API, and processing the responses. To create a
new instance of this class, you need to provide an instance of
`IAuthenticationProvider` which can authenticate requests to Microsoft Graph.

For more information on initializing a client instance, see the [library overview](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/overview.md)

### 4. Make requests to the graph

Once you have completed authentication and have a GraphServiceClient, you can
begin to make calls to the service. The requests in the SDK follow the format
of the Microsoft Graph API's RESTful syntax.

For example, to retrieve a user's default drive:

```csharp
var drive = await graphClient.Me.Drive.GetAsync();
```

`GetAsync` will return a `Drive` object on success and throw a
`ApiException` on error.

To get the current user's root folder of their default drive:

```csharp
// Get the user's driveId
var drive = await graphClient.Me.Drive.GetAsync();
var userDriveId = drive.Id;
// use the driveId to get the root drive
var rootItem = await graphClient.Drives[userDriveId].Root.GetAsync();
```

`GetAsync` will return a `DriveItem` object on success and throw a
`ApiException` on error.

For a general overview of how the SDK is designed, see [overview](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/overview.md).

The following sample applications are also available:
* [Microsoft Graph UWP Connect Sample](https://github.com/microsoftgraph/uwp-csharp-connect-sample)
* [Microsoft Graph UWP Snippets Sample](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)
* [Microsoft Graph MeetingBot sample for UWP](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)
* [Microsoft Graph Connect Sample for ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-connect-sample)
* [Microsoft Graph Snippets Sample for ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-snippets-sample)
* [Microsoft Graph SDK Snippets Library for Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)
* [Microsoft Graph Connect Sample for Xamarin Forms](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)
* [Microsoft Graph Meeting Manager Sample for Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)
* [Microsoft Graph Property Manager Sample for Xamarin Native](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)

## Documentation and resources

* [Overview](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/overview.md)
* [Collections](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/collections.md)
* [Errors](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/errors.md)
* [Headers](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/headers.md)
* [Microsoft Graph API](https://graph.microsoft.com)
* [Release notes](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)
* [Blog - Microsoft Graph .NET SDK updates 3/16/20](https://developer.microsoft.com/en-us/graph/blogs/microsoft-graph-net-sdk-updates/)

## Notes

### Upgrading from v1

Between 1.x and 3.x there were some minor possibly breaking changes:

 * .NET Standard minimum version bumped from `netStandard1.3` to `netstandard2.0`
 * .NET Framework minimum version bumped from `net45` to `net461`
 * a change in enum order for `GiphyRatingType`
 * `ParticipantInfo` became `InvitationParticipantInfo`
 * `CallRecordRequestBody` became `CallRecordResponseRequestBody`

### Upgrading to v4

Between 3.x and 4.x there were some major breaking changes:

 * .NET Standard minimum version bumped from `netStandard1.3` to `netstandard2.0`
 * .NET Framework minimum version bumped from `net45` to `net462`
 * Replacing Newtosoft.Json with System.Text.Json
 * Upgrading Microsoft.Graph.Core dependency to version 2.0.0

View the upgrade guide [here](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/upgrade-to-v4.md).


### Upgrading to v5

Between 4.x and 5.x there were several major breaking changes as the SDK now uses Kiota for code generation.

View the upgrade guide [here](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/docs/upgrade-to-v5.md).

## Issues

To view or log issues, see [issues](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Other resources

* NuGet Package: [https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## Building library locally

If you are looking to build the library locally for the purposes of contributing code or running tests, you will need to:

- Have the .NET Core SDK (> 1.0) installed
- Run `dotnet restore` from the command line in your package directory
- Run `nuget restore` and `msbuild` from CLI or run Build from Visual Studio to restore Nuget packages and build the project

> Due to long file names you may need to run `git config --system core.longpaths true` before cloning the repo to your system.

> Additionally for Windows OS, set the value of the parameter `HKLM\SYSTEM\CurrentControlSet\Control\FileSystem` `LongPathsEnabled` to `1`, before opening the solution in VS

## License

Copyright (c) Microsoft Corporation. All Rights Reserved. Licensed under the MIT [license](LICENSE.txt). See [Third Party Notices](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/main/THIRD%20PARTY%20NOTICES) for information on the packages referenced via NuGet.
