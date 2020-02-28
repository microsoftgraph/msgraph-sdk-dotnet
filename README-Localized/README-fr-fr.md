# Bibliothèque cliente .NET Microsoft Graph

[![État de la build](https://ci.appveyor.com/api/projects/status/m8qncaosr2ry4ks6/branch/master?svg=true)](https://ci.appveyor.com/project/MIchaelMainer/msgraph-sdk-dotnet/branch/master)
[![version NuGet](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

Intégrez l'[API Microsoft Graph](https://graph.microsoft.io)
dans votre projet .NET !

Cibles de la bibliothèque cliente Microsoft Graph .NET. NetStandard 1.1 et .NET Framework 4.5.

## Installation via NuGet

Installation de la bibliothèque cliente via NuGet :

* Recherchez `Microsoft.Graph` dans la bibliothèque NuGet, ou
* Tapez `Installe-package Microsoft.Graph` dans la console du Gestionnaire de package.

## Prise en main

### 1. Inscription de votre application

Vous devez inscrire votre application dans le [Portail d’inscription des applications de Microsoft](https://aka.ms/appregistrations) pour utiliser l'API Microsoft Graph.

### 2. S'authentifier au service de Microsoft Graph

La bibliothèque client Microsoft Graph .NET n'inclut pas actuellement les implémentations d'authentification par défaut.
Une liste de fournisseurs d'authentification en préversion est disponible dans le référentiel [msgraph-sdk-dotnet-auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth).
Vous pouvez également utiliser la classe intégrée **DelegateAuthenticationProvider** pour authentifier chaque demande. Pour plus d’informations sur `DelegateAuthenticationProvider`, consultez la [présentation de la bibliothèque](docs/overview.md).  

La bibliothèque recommandée pour l’authentification auprès de Microsoft Identity (Azure AD) est [MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

Pour obtenir un exemple d’authentification d’une application UWP utilisant le point de terminaison d’authentification V2, voir la [Bibliothèque de connexion Microsoft Graph UWP](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library).

### 3. Créer un objet client Microsoft Graph avec un fournisseur d’authentification

Une instance de la classe **GraphServiceClient** gère la création de demandes en les envoyant vers l’API Microsoft Graph et en traitant les réponses.
Pour créer une nouvelle instance de cette classe,
vous devez fournir une instance
`IAuthenticationProvider` pouvant authentifier les demandes adressées à Microsoft Graph.

Pour plus d’informations sur l’initialisation d’une instance client, voir la [présentation de la bibliothèque](docs/overview.md)

### 4. Formuler des demandes auprès du Graph

Lorsque vous avez terminé l'authentification et que vous disposez de GraphServiceClient, vous pouvez effectuer des appels vers le service.
Les demandes dans le kit de développement logiciel
respectent le format de la syntaxe RESTful de l’API Microsoft Graph.

Par exemple, pour récupérer le lecteur par défaut d’un utilisateur :

```csharp
var drive = await graphClient.Me.Drive.Request().GetAsync();
```

`GetAsync` renvoie un objet `Drive` en cas de réussite,
et lève une `ServiceException` en cas d’erreur.

Obtenir le dossier racine du lecteur par défaut de l’utilisateur actuel :

```csharp
var rootItem = await graphClient.Me.Drive.Root.Request().GetAsync();
```

`GetAsync` renvoie un objet `DriveItem` en cas de réussite,
et lève une `ServiceException` en cas d’erreur.

Pour obtenir une vue générale sur la conception du kit de développement logiciel, voir [vue d’ensemble](docs/overview.md).

Les exemples d’applications suivantes sont également disponibles :
* [Exemple de connexion Microsoft Graph UWP](https://github.com/microsoftgraph/uwp-csharp-connect-sample)
* [Petits exemples Microsoft Graph UWP](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)
* [Exemple Microsoft Graph MeetingBot pour UWP](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)
* [Exemple de connexion Microsoft Graph pour ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-connect-sample)
* [Petits exemples Microsoft Graph pour ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-snippets-sample)
* [Bibliothèque d’extraits Microsoft Graph SDK pour Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)
* [Exemple de connexion Microsoft Graph pour Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)
* [Exemple de gestionnaire de réunions Microsoft Graph pour Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)
* [Exemple de gestionnaire de propriétés Microsoft Graph pour Xamarin Native](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)

## Documentation et ressources

* [Vue d'ensemble](docs/overview.md)
* [Collections](docs/collections.md)
* [Erreurs](docs/errors.md)
* [En-têtes](docs/headers.md)
* [API Microsoft Graph](https://graph.microsoft.io)
* [Notes de publication](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)

## Remarques

Installez NewtonSoft.Json tout d’abord si vous voulez utiliser une version ultérieure à NewtonSoft.json 6.0.1. Par exemple, vous devez installer NewtonSoft.json 9.0.1 au préalable si vous voulez l'utiliser pour la bibliothèque tout en ciblant .Net Core avec standard1.0.

Installez System.Runtime.InteropServices.RuntimeInformation avant d'installer Microsoft.Graph >=1.3 si vous rencontrez un problème lors de la mise à jour de package d'une solution Xamarin. Vous devrez peut-être également mettre à jour les références sur Microsoft.NETCore.UniversalWindowsPlatform vers > = 5.2.2.

## Problèmes

Pour afficher ou enregistrer des problèmes, voir [problèmes](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues).

Ce projet a adopté le [Code de conduite Open Source de Microsoft](https://opensource.microsoft.com/codeofconduct/). Pour en savoir plus, reportez-vous à la [FAQ relative au code de conduite](https://opensource.microsoft.com/codeofconduct/faq/) ou contactez [opencode@microsoft.com](mailto:opencode@microsoft.com) pour toute question ou tout commentaire.

## Autres ressources

* Package NuGet : [https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## Création d’une bibliothèque locale

Si vous envisagez de créer la bibliothèque localement à des fins de codes de contribution ou d’exécution de tests, vous devez :

- Installer le .NET Core SDK (> 1.0)
- Exécuter `dotnet restore` à partir de la ligne de commande dans le répertoire de votre package
- Exécuter `nuget restore` et `msbuild` à partir de l'interface de ligne de commande (CLI) ou exécutez la Build à partir de Visual Studio pour restaurer les packages Nuget et créer le projet

## Licence

Copyright (c) Microsoft Corporation. Tous droits réservés. Sous [licence MIT](LICENSE.txt). Pour plus d'informations sur les packages référencés via NuGet, voir les [Notifications tierces](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/master/THIRD%20PARTY%20NOTICES).
