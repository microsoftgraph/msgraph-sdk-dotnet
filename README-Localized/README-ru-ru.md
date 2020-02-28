# Клиентская библиотека .NET Microsoft Graph

[![Состояние сборки](https://ci.appveyor.com/api/projects/status/m8qncaosr2ry4ks6/branch/master?svg=true)](https://ci.appveyor.com/project/MIchaelMainer/msgraph-sdk-dotnet/branch/master)
[![Версия NuGet](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

Интегрируйте [API Microsoft Graph](https://graph.microsoft.io) в свой
проект .NET!

Клиентская библиотека .NET Microsoft Graph предназначена для .NetStandard 1.1 и .Net Framework 4.5.

## Установка с помощью NuGet

Чтобы установить клиентскую библиотеку с помощью NuGet:

* Найдите `Microsoft.Graph` в библиотеке NuGet или
* Введите `Install-Package Microsoft.Graph` в консоли диспетчера пакетов.

## Начало работы

### 1. Регистрация приложения

Зарегистрируйте приложение для использования API Microsoft Graph с помощью [портала регистрации приложений Майкрософт](https://aka.ms/appregistrations).

### 2. Проверка подлинности для службы Microsoft Graph

В настоящее время в клиентской библиотеке .NET Microsoft Graph не реализованы какие-либо проверки подлинности по умолчанию.
Набор поставщиков предварительных версий проверок подлинности доступен в репозитории [msgraph-sdk-dotnet-auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth).
Вы также можете использовать встроенный класс **DelegateAuthenticationProvider** для проверки подлинности каждого запроса. Дополнительные сведения о классе `DelegateAuthenticationProvider` см. в [обзоре библиотеки](docs/overview.md).  

Рекомендуемая библиотека для проверки подлинности с использованием удостоверений Майкрософт (Azure AD) — [MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

Пример проверки подлинности приложения UWP с использованием конечной точки проверки подлинности версии 2 см. в статье [Библиотека Microsoft Graph UWP Connect](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library).

### 3. Создание клиентского объекта Microsoft Graph с поставщиком проверки подлинности

Экземпляр класса **GraphServiceClient** обрабатывает запросы на создание, отправляя их в API Microsoft Graph API и обрабатывая ответы.
Чтобы создать экземпляр этого класса,
требуется предоставить экземпляр
`IAuthenticationProvider`, который может проверять подлинность запросов к Microsoft Graph.

Дополнительные сведения об инициализации экземпляра клиента см. в [обзоре библиотеки](docs/overview.md)

### 4. Отправка запросов к graph

После завершения проверки подлинности и при наличии GraphServiceClient вы можете начать совершать вызовы в службу.
Запросы в SDK соответствуют формату синтаксиса
с применением REST интерфейса API Microsoft Graph.

Пример получения используемого по умолчанию диска пользователя:

```csharp
var drive = await graphClient.Me.Drive.Request().GetAsync();
```

`GetAsync` возвращает объект `Drive` в случае успеха и вызывает объект
`ServiceException` в случае ошибки.

Получение корневой папки на диске по умолчанию текущего пользователя:

```csharp
var rootItem = await graphClient.Me.Drive.Root.Request().GetAsync();
```

`GetAsync` возвращает объект `DriveItem` в случае успеха и вызывает объект
`ServiceException` в случае ошибки.

Общие сведения о конструкции пакета SDK см. в [обзоре](docs/overview.md).

Также доступны следующие примеры приложений:
* [пример Microsoft Graph UWP Connect](https://github.com/microsoftgraph/uwp-csharp-connect-sample)
* [пример фрагментов Microsoft Graph UWP](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)
* [пример Microsoft Graph MeetingBot для UWP](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)
* [пример Microsoft Graph Connect для ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-connect-sample)
* [пример фрагментов Microsoft Graph для ASP.NET 4.6](https://github.com/microsoftgraph/aspnet-snippets-sample)
* [библиотека фрагментов Microsoft Graph SDK для Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)
* [пример Microsoft Graph Connect для Xamarin Forms](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)
* [пример диспетчера собраний Microsoft Graph для Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)
* [пример диспетчера свойств Microsoft Graph для Xamarin Native](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)

## Документация и ресурсы

* [Обзор](docs/overview.md)
* [Коллекции](docs/collections.md)
* [Ошибки](docs/errors.md)
* [Заголовки](docs/headers.md)
* [API Microsoft Graph](https://graph.microsoft.io)
* [Заметки о выпуске](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)

## Примечания

Сначала установите NewtonSoft.Json, если хотите использовать более позднюю версию, чем NewtonSoft.Json 6.0.1. Например, вам потребуется сначала установить NewtonSoft.Json 9.0.1, если вы хотите использовать его для библиотеки с целью применения .NET Core со стандартом 1.0.

Установите System.Runtime.InteropServices.RuntimeInformation перед установкой Microsoft.Graph версии 1.3 и более поздней, если у вас возникла проблема с обновлением пакета для решения Xamarin. Вам также могут потребоваться обновленные ссылки на Microsoft.NETCore.UniversalWindowsPlatform для версии 5.2.2 и более поздней.

## Проблемы

Для просмотра и регистрации проблем см. раздел [проблем](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues).

Этот проект соответствует [Правилам поведения разработчиков открытого кода Майкрософт](https://opensource.microsoft.com/codeofconduct/). Дополнительные сведения см. в разделе [часто задаваемых вопросов о правилах поведения](https://opensource.microsoft.com/codeofconduct/faq/). Если у вас возникли вопросы или замечания, напишите нам по адресу [opencode@microsoft.com](mailto:opencode@microsoft.com).

## Другие ресурсы

* Пакет NuGet: [https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## Локальное создание библиотеки

Если вы собираетесь создать библиотеку в локальном расположении для добавления кода или выполнения тестов, вам потребуется выполнить следующие действия:

- Установить пакет SDK .NET Core (> 1.0)
- Выполнить команду `dotnet restore` из командной строки в каталоге пакета
- Выполнить команды `nuget restore` и `msbuild` из CLI или запустить сборку из Visual Studio, чтобы восстановить пакеты Nuget и создать проект

## Лицензия

© Корпорация Майкрософт. Все права защищены. Предоставляется по [лицензии](LICENSE.txt) MIT. Сведения о пакетах, указанных в NuGet, см. в разделе [Уведомления третьих лиц](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/master/THIRD%20PARTY%20NOTICES).
