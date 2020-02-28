# Biblioteca cliente .NET de Microsoft Graph

[![Estado de la compilación](https://ci.appveyor.com/api/projects/status/m8qncaosr2ry4ks6/branch/master?svg=true)](https://ci.appveyor.com/project/MIchaelMainer/msgraph-sdk-dotnet/branch/master)
[![Versión de NuGet](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

¡Integre la [API de Microsoft Graph](https://graph.microsoft.io) en su
proyecto de .NET!

La biblioteca cliente .NET de Microsoft Graph se dirige a .NetStandard 1.1 y .NET Framework 4.5.

## Instalación mediante NuGet

Para instalar la biblioteca cliente a través de NuGet:

* Busque `Microsoft.Graph` en la biblioteca NuGet o
* Escriba `Install-Package Microsoft.Graph` en la Consola del Administrador de paquetes.

## Introducción

### 1. Registrar la aplicación

Registre su aplicación para usar la API de Microsoft Graph con el [Portal de registro de aplicaciones de Microsoft](https://aka.ms/appregistrations).

### 2. Autenticarse para el servicio de Microsoft Graph

La Biblioteca cliente .NET de Microsoft Graph no incluye actualmente ninguna implementación de autenticación predeterminada.
Hay un conjunto de proveedores de autenticación preliminar disponibles en el repositorio [msgraph-sdk-dotnet-auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth). Como alternativa, puede usar la clase integrada **DelegateAuthenticationProvider** para autenticar cada solicitud.
Para obtener más información sobre `DelegateAuthenticationProvider`, vea la [información general de la biblioteca](docs/overview.md).  

La biblioteca recomendada para autenticar la Identidad de Microsoft (Azure AD) es [MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

Para ver un ejemplo de cómo autenticar una aplicación para UWP con el extremo de autenticación V2, vea la [Biblioteca de conexión UWP de Microsoft Graph](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library).

### 3. Crear un objeto de cliente de Microsoft Graph con un proveedor de autenticación

Una instancia de la clase **GraphServiceClient** controla las solicitudes de creación, su envío a la API de Microsoft Graph y el procesamiento de las respuestas.
Para crear una nueva instancia de esta clase,
tiene que proporcionar una instancia de
`IAuthenticationProvider` que pueda autenticar solicitudes en Microsoft Graph.

Para obtener más información sobre la inicialización de una instancia de cliente, vea la [información general de la biblioteca](docs/overview.md)

### 4. Realizar solicitudes a Graph

Una vez que haya completado la autenticación y tenga un GraphServiceClient, puede empezar a realizar llamadas al servicio.
Las solicitudes en el SDK siguen
el formato de la sintaxis RESTful de la API de Microsoft Graph.

Por ejemplo, para recuperar la unidad predeterminada de un usuario:

```csharp
var drive = await graphClient.Me.Drive.Request().GetAsync();
```

`GetAsync` devolverá un objeto `Drive` en caso de éxito y
producirá un `ServiceException` en caso de error.

Para obtener la carpeta raíz del usuario actual de la unidad predeterminada:

```csharp
var rootItem = await graphClient.Me.Drive.Root.Request().GetAsync();
```

`GetAsync` devolverá un `DriveItem` en caso de éxito y producirá un
`ServiceException` en caso de error.

Para obtener información general sobre cómo está diseñado el SDK, vea [información general](docs/overview.md).

Las aplicaciones de ejemplo siguientes también están disponibles:
* [Ejemplo de conexión UWP de Microsoft Graph](https://github.com/microsoftgraph/uwp-csharp-connect-sample)
* [Ejemplo de fragmentos de código UWP para Microsoft Graph](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)
* [Ejemplo de MeetingBot de Microsoft Graph para UWP ](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)
* [Ejemplo de conexión de Microsoft Graph para ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-connect-sample)
* [Ejemplo de fragmentos de Microsoft Graph para ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-snippets-sample)
* [Biblioteca de fragmentos de Microsoft Graph SDK para Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)
* [Ejemplo de conexión de Microsoft Graph para Xamarin Forms](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)
* [Ejemplo del Administrador de reuniones de Microsoft Graph para Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)
* [Ejemplo del Administrador de propiedad de Microsoft Graph para Xamarin Native](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)

## Documentación y recursos

* [Información general](docs/overview.md)
* [Colecciones](docs/collections.md)
* [Errores](docs/errors.md)
* [Encabezados](docs/headers.md)
* [API de Microsoft Graph](https://graph.microsoft.io)
* [Notas de la versión](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)

## Notas

Si desea usar una versión mayor que NewtonSoft.Json 6.0.1, instale primero NewtonSoft.Json. Por ejemplo, primero tendrá que instalar NewtonSoft.Json 9.0.1, si desea usar esto en la biblioteca mientras dirige .Net Core con standard1.0.

Instale System.Runtime.InteropServices.RuntimeInformation antes de instalar Microsoft Graph >= 1.3, si tiene un problema al actualizar el paquete para una solución Xamarin. Es posible que también tenga que actualizar las referencias a Microsoft.NETCore.UniversalWindowsPlatform para >=5.2.2.

## Problemas

Para ver o registrar problemas, consulte [problemas](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues).

Este proyecto ha adoptado el [Código de conducta de código abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/). Para obtener más información, vea [Preguntas frecuentes sobre el código de conducta](https://opensource.microsoft.com/codeofconduct/faq/) o póngase en contacto con [opencode@microsoft.com](mailto:opencode@microsoft.com) si tiene otras preguntas o comentarios.

## Otros recursos

* Paquete NuGet: [https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## Creación local de la biblioteca

Si está pensando en crear la biblioteca de forma local con el fin de contribuir al código o ejecutar pruebas, tendrá que:

- Tener instalado el SDK de .NET Core (> 1.0)
- Ejecutar `dotnet restore` desde la línea de comandos en el directorio de paquetes
- Ejecutar `nuget restore` y `msbuild` desde CLI o ejecutar Crear desde Visual Studio para restaurar paquetes de Nuget y crear el proyecto

## Licencia

Copyright (c) Microsoft Corporation. Reservados todos los derechos. Publicado bajo la [licencia](LICENSE.txt) MIT. Consulte [Avisos de terceros](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/master/THIRD%20PARTY%20NOTICES) para obtener información sobre los paquetes a los que se hace referencia mediante NuGet.
