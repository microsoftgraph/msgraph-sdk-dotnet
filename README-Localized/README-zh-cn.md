# Microsoft Graph .NET 客户端库

[![生成状态](https://ci.appveyor.com/api/projects/status/m8qncaosr2ry4ks6/branch/master?svg=true)](https://ci.appveyor.com/project/MIchaelMainer/msgraph-sdk-dotnet/branch/master)
[![NuGet 版本](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

将 [Microsoft Graph API](https://graph.microsoft.io) 集成到你的
.NET 项目中！

Microsoft Graph .NET 客户端库面向 .NetStandard 1.1 和 .Net Framework 4.5。

## 通过 NuGet 安装

若要通过 NuGet 安装客户端库：

* 在 NuGet 库中搜索 `Microsoft.Graph`，或者
* 在包管理器控制台中键入 `Install-Package Microsoft.Graph`。

## 入门

### 1.注册应用程序

使用 [Microsoft 应用程序注册门户](https://aka.ms/appregistrations)注册你的应用程序以使用 Microsoft Graph API。

### 2.Microsoft Graph 服务身份验证

Microsoft Graph .NET 客户端库当前不包含任何默认身份验证实现。[msgraph-sdk-dotnet-auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth)
存储库中提供了一组预览版身份验证提供程序。或者，你可以使用内置的
**DelegateAuthenticationProvider** 类对每个请求进行身份验证。有关 `DelegateAuthenticationProvider` 的详细信息，请参阅[库概述](docs/overview.md)。  

推荐用于根据 Microsoft 标识 (Azure AD) 进行身份验证的库是 [MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet)。

有关使用 V2 身份验证终结点对 UWP 应用进行身份验证的示例，请参阅 [Microsoft Graph UWP Connect 库](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library)。

### 3.使用身份验证提供程序创建 Microsoft Graph 客户端对象

**GraphServiceClient** 类的一个实例会处理生成请求，将这些请求发送到 Microsoft Graph API，并处理响应。
若要创建此类的新实例，
需要提供
`IAuthenticationProvider` 的实例，可用于对提供给 Microsoft Graph 的请求进行身份验证。

有关初始化客户端实例的详细信息，请参阅[库概述](docs/overview.md)

### 4.对图形发出请求

完成身份验证并有 GraphServiceClient 后，即可开始对服务进行调用。
该 SDK 中的请求遵循 Microsoft Graph API
的 REST 风格语法的格式。

例如，若要检索用户的默认驱动器：

```csharp
var drive = await graphClient.Me.Drive.Request().GetAsync();
```

`GetAsync` 将在成功时返回一个 `Drive` 对象，
而在出现错误时引发 `ServiceException`。

若要获取当前用户的默认驱动器的根文件夹：

```csharp
var rootItem = await graphClient.Me.Drive.Root.Request().GetAsync();
```

`GetAsync` 将在成功时返回一个 `DriveItem` 对象，
而在出现错误时引发 `ServiceException`。

有关该 SDK 的设计方式的一般性概述，请参阅[概述](docs/overview.md)。

还可以使用以下示例应用程序：
* [Microsoft Graph UWP Connect 示例](https://github.com/microsoftgraph/uwp-csharp-connect-sample)
* [Microsoft Graph UWP 代码段示例](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)
* [适用于 UWP 的 Microsoft Graph MeetingBot 示例](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)
* [适用于 ASP.NET 4.6 的 Microsoft Graph Connect 示例](https://github.com/microsoftgraph/aspnet-connect-sample)
* [适用于 ASP.NET 4.6 的 Microsoft Graph 代码段示例](https://github.com/microsoftgraph/aspnet-snippets-sample)
* [适用于 Xamarin.Forms 的 Microsoft Graph SDK 代码段库](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)
* [适用于 Xamarin Forms 的 Microsoft Graph Connect 示例](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)
* [适用于 Xamarin.Forms 的 Microsoft Graph Meeting Manager 示例](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)
* [适用于 Xamarin Native 的 Microsoft Graph Property Manager 示例](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)

## 文档和资源

* [概述](docs/overview.md)
* [集合](docs/collections.md)
* [错误](docs/errors.md)
* [标头](docs/headers.md)
* [Microsoft Graph API](https://graph.microsoft.io)
* [发行说明](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)

## 注意

如果要使用高于 NewtonSoft.Json 6.0.1 的版本，请先安装 NewtonSoft.Json。例如，如果要在以 .Net Core（采用标准 1.0）为目标时使用此库，则需要先安装 NewtonSoft.Json 9.0.1。

如果在更新 Xamarin 解决方案的包时遇到问题，请在安装 Microsoft.Graph 1.3 或更高版本之前先安装 System.Runtime.InteropServices.RuntimeInformation。你可能还需要将对 Microsoft.NETCore.UniversalWindowsPlatform 的引用也更新为 5.2.2 或更高版本。

## 问题

若要查看或记录问题，请参阅[问题](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues)。

此项目已采用 [Microsoft 开放源代码行为准则](https://opensource.microsoft.com/codeofconduct/)。有关详细信息，请参阅[行为准则 FAQ](https://opensource.microsoft.com/codeofconduct/faq/)。如有其他任何问题或意见，也可联系 [opencode@microsoft.com](mailto:opencode@microsoft.com)。

## 其他资源

* NuGet 包：[https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## 在本地生成库

如果你出于提供代码或运行测试的目的而在本地构建库，则需要：

- 安装 .NET Core SDK (> 1.0)
- 从程序包目录的命令行运行 `dotnet restore`
- 从 CLI 运行 `nuget restore` 和 `msbuild`，或从 Visual Studio 运行构建，以还原 Nuget 程序包并构建项目

## 许可证

版权所有 (c) Microsoft Corporation。保留所有权利。在 MIT [许可证](LICENSE.txt)下获得许可。有关通过 NuGet 引用的程序包的信息，请参阅[第三方声明](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/master/THIRD%20PARTY%20NOTICES)。
