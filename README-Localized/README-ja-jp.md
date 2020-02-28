# Microsoft Graph .NET クライアント ライブラリ

[![ビルドの状態](https://ci.appveyor.com/api/projects/status/m8qncaosr2ry4ks6/branch/master?svg=true)](https://ci.appveyor.com/project/MIchaelMainer/msgraph-sdk-dotnet/branch/master)
[![NuGet Version](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

[Microsoft Graph API](https://graph.microsoft.io) を
.NET プロジェクトに統合する。

Microsoft Graph .NET クライアント ライブラリは、NetStandard 1.1 および .Net Framework 4.5 を対象としています。

## NuGet 経由のインストール

NuGet 経由でクライアント ライブラリをインストールするには、

* NuGet ライブラリで `Microsoft.Graph` を検索するか、
* パッケージ マネージャー コンソールに `Install-Package Microsoft.Graph` と入力します。

## はじめに

### 1.アプリケーションを登録する

[Microsoft アプリケーション登録ポータル](https://aka.ms/appregistrations)を使用して、Microsoft Graph API を使用するアプリケーションを登録します。

### 2.Microsoft Graph サービスの認証

Microsoft Graph .NET クライアント ライブラリには現在、既定の認証の実装は含まれていません。[msgraph-sdk-dotnet-auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth)
リポジトリには、いくつかのプレビュー認証プロバイダーが用意されています。または、組み込みの
**DelegateAuthenticationProvider** クラスを使用して、各要求を認証できます。`DelegateAuthenticationProvider` の詳細については、「[ライブラリの概要](docs/overview.md)」を参照してください。  

Microsoft Identity (Azure AD) に対する認証での推奨ライブラリは、[MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet)です。

V2 認証エンドポイントを使用して UWP アプリを認証する例については、「[Microsoft Graph UWP Connect Library (Microsoft Graph UWP Connect ライブラリ)](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library)」を参照してください。

### 3.認証プロバイダーで Microsoft Graph クライアント オブジェクトを作成する

**GraphServiceClient** クラスのインスタンスは、要求を作成し、Microsoft Graph API にそれらを送信し、応答を処理します。
このクラスの新しいインスタンスを作成するには、
Microsoft Graph への要求を認証できる、
`IAuthenticationProvider` のインスタンスを提供する必要があります。

クライアント インスタンスの初期化の詳細については、「[ライブラリの概要](docs/overview.md)」を参照してください

### 4.Graph への要求を実行する

認証を完了して GraphServiceClient を取得したら、サービスの呼び出しを開始できます。
SDKの要求は、Microsoft Graph API の RESTful
構文の形式に従います。

たとえば、ユーザーの既定のドライブを取得するには、次の操作を行います。

```csharp
var drive = await graphClient.Me.Drive.Request().GetAsync();
```

`GetAsync` は、成功時には `Drive` オブジェクトを返し、エラー時には
`ServiceException` をスローします。

現在のユーザーの既定のドライブのルート フォルダを取得するには、次の操作を行います。

```csharp
var rootItem = await graphClient.Me.Drive.Root.Request().GetAsync();
```

`GetAsync` は、成功時には `DriveItem` オブジェクトを返し、エラー時には
`ServiceException` をスローします。

SDK の設計方法に関する一般的な概要については、「[概要](docs/overview.md)」を参照してください。

以下のサンプル アプリケーションも利用できます:
* 「[Microsoft Graph UWP Connect Sample (Microsoft Graph UWP Connect のサンプル)](https://github.com/microsoftgraph/uwp-csharp-connect-sample)」
* 「[Microsoft Graph UWP スニペット サンプル](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)」
* 「[UWP 用 Microsoft Graph MeetingBot サンプル](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)」
* 「[ASP.NET 4.6 用 Microsoft Graph Connect のサンプル](https://github.com/microsoftgraph/aspnet-connect-sample)」
* 「[ASP.NET 4.6 用 Microsoft Graph スニペットのサンプル](https://github.com/microsoftgraph/aspnet-snippets-sample)」
* 「[Xamarin.Forms 用 Microsoft Graph SDK スニペット ライブラリ](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)」
* 「[Xamarin Forms 用 Microsoft Graph Connect のサンプル](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)」
* 「[Microsoft Graph Meeting Manager Sample for Xamarin.Forms (Xamarin.Forms 用 Microsoft Graph Meeting Manager サンプル)](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)」
* 「[Xamarin Native 用の Microsoft Graph Property Manager のサンプル](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)」

## ドキュメントとリソース

* [概要](docs/overview.md)
* [コレクション](docs/collections.md)
* [エラー](docs/errors.md)
* [ヘッダー](docs/headers.md)
* [Microsoft Graph API](https://graph.microsoft.io)
* [リリース ノート](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)

## メモ

NewtonSoft.Json 6.0.1 より後のバージョンを使用する場合は、最初に　NewtonSoft.Json をインストールしてください。たとえば、.Net Core with standard1.0 を対象にしてライブラリにこれを使用する場合は、最初に NewtonSoft.Json 9.0.1 をインストールする必要があります。

Xamarin ソリューションのパッケージを更新するときに問題が発生した場合は、Microsoft.Graph >=1.3 をインストールする前に、System.Runtime.InteropServices.RuntimeInformation をインストールしてください。Microsoft.NETCore.UniversalWindowsPlatform to >=5.2.2 への参照の更新が必要な場合があります。

## 問題

問題を表示、記録するには、「[問題](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues)」 を参照してください。

このプロジェクトでは、[Microsoft Open Source Code of Conduct (Microsoft オープン ソース倫理規定)](https://opensource.microsoft.com/codeofconduct/) が採用されています。詳細については、「[Code of Conduct の FAQ (倫理規定の FAQ)](https://opensource.microsoft.com/codeofconduct/faq/)」を参照してください。また、その他の質問やコメントがあれば、[opencode@microsoft.com](mailto:opencode@microsoft.com) までお問い合わせください。

## その他のリソース

* NuGet パッケージ: [https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## ローカルでライブラリを作成する

コードの投稿やテストの実行を目的としてローカルでライブラリを作成する場合は、次のものが必要です。

- .NET Core SDK (> 1.0) をインストールする
- パッケージ ディレクトリ内のコマンド ラインから `dotnet restore` を実行する
- CLI から `NuGet の復元` および `MSBuild` を実行するか、Visual Studio からビルドを実行し、NuGet パッケージを復元して、プロジェクトをビルドする

## ライセンス

Copyright (c) Microsoft Corporation.All Rights Reserved.MIT [ライセンス](LICENSE.txt)に基づきライセンスされています。NuGet 経由で参照されたパッケージの詳細については、「[サード パーティについての通知](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/master/THIRD%20PARTY%20NOTICES)」 を参照してください。
