# Biblioteca de Clientes do .NET do Microsoft Graph

[![Status de criação](https://ci.appveyor.com/api/projects/status/m8qncaosr2ry4ks6/branch/master?svg=true)](https://ci.appveyor.com/project/MIchaelMainer/msgraph-sdk-dotnet/branch/master)
[![Versão do NuGet](https://buildstats.info/nuget/Microsoft.Graph)](https://www.nuget.org/packages/Microsoft.Graph/)

Integre a [API do Microsoft Graph](https://graph.microsoft.io) ao seu
projeto .NET!

A Biblioteca de Clientes do .NET do Microsoft Graph se destina ao .NetStandard 1.1 e ao .Net Framework 4.5.

## Instalação via NuGet

Para instalar a biblioteca de cliente por meio do NuGet:

* Pesquise `Microsoft. Graph` na biblioteca do NuGet ou
* Digite `Install-Package Microsoft.Graph` no Console do Gerenciador de Pacotes.

## Introdução

### 1. Registre seu aplicativo

Registre seu aplicativo na API do Microsoft Graph usando o [Portal de Registro de Aplicativos da Microsoft](https://aka.ms/appregistrations).

### 2. Autentique o serviço do Microsoft Graph

Atualmente a biblioteca de clientes do Microsoft Graph .NET não inclui nenhuma implementação de autenticação padrão.
Há um conjunto de provedores de autenticação prévia disponível no repositório [msgraph-sdk-dotnet-auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth).
Como alternativa, você pode usar a classe interna **DelegateAuthenticationProvider** para autenticar cada solicitação. Confira mais informações sobre `DelegateAuthenticationProvider` na [visão geral da biblioteca](docs/overview.md).  

A biblioteca recomendada para autenticação no Microsoft Identidade (Azure AD) é [MSAL](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

Para acessar um exemplo de autenticação de um aplicativo UWP usando o Ponto de Extremidade de Autenticação V2, confira a [Biblioteca de Conexão do UWP ao Microsoft Graph](https://github.com/OfficeDev/Microsoft-Graph-UWP-Connect-Library).

### 3. Criar um objeto cliente do Microsoft Graph com um provedor de autenticação

Uma instância da classe **GraphServiceClient** manipula solicitações de criação, enviando-as à API do Microsoft Graph e processando as respostas.
Para criar uma nova instância dessa classe,
você precisa fornecer uma instância de
`IAuthenticationProvider` que possa autenticar solicitações para o Microsoft Graph.

Confira mais informações sobre a inicialização de uma instância de cliente na [visão geral da biblioteca](docs/overview.md)

### 4. Fazer solicitações ao Graph

Depois de concluir a autenticação e ter um GraphServiceClient, você pode começar a fazer chamadas para o serviço.
As solicitações no SDK seguem o formato da sintaxe RESTful
da API do Microsoft Graph.

Por exemplo, para recuperar a unidade padrão de um usuário:

```csharp
var drive = await graphClient.Me.Drive.Request().GetAsync();
```

`GetAsync` retornará o objeto `Drive` em caso de êxito e emitirá uma
`ServiceException` em caso de erro.

Para obter a pasta raiz das unidades padrão do usuário atual:

```csharp
var rootItem = await graphClient.Me.Drive.Root.Request().GetAsync();
```

`GetAsync` retornará o objeto `DriveItem` em caso de êxito e emitirá uma
`ServiceException` em caso de erro.

Confira como o SDK foi desenvolvido na [visão geral](docs/overview.md).

Os seguintes aplicativos de exemplo também estão disponíveis:
* [Exemplo de Conexão do UWP com o Microsoft Graph,](https://github.com/microsoftgraph/uwp-csharp-connect-sample)
* [Exemplo de Trechos de Códigos do UXP no Microsoft Graph](https://github.com/microsoftgraph/uwp-csharp-snippets-sample)
* [Exemplo do MeetingBot para UWP no Microsoft Graph](https://github.com/microsoftgraph/uwp-csharp-meetingbot-sample)
* [Exemplo de Conexão do ASP.NET 4.6 com o Microsoft Graph](https://github.com/microsoftgraph/aspnet-connect-sample)
* [Exemplo de Trechos de Códigos do ASP.NET 4.6 no Microsoft Graph](https://github.com/microsoftgraph/aspnet-snippets-sample)
* [Biblioteca de Trechos de Códigos do SDK do Xamarin.Forms no Microsoft Graph](https://github.com/microsoftgraph/xamarin-csharp-snippets-sample)
* [Exemplo de Conexão do Microsoft Graph com o Xamarin Forms](https://github.com/microsoftgraph/xamarin-csharp-connect-sample)
* [Exemplo de Gerenciador de Reuniões do Microsoft Graph para Xamarin.Forms](https://github.com/microsoftgraph/xamarin-csharp-meetingmanager-sample)
* [Exemplo de Gerenciador de Propriedades do Microsoft Graph para Xamarin Nativo](https://github.com/microsoftgraph/xamarin-csharp-propertymanager-sample)

## Documentação e recursos

* [Visão Geral](docs/overview.md)
* [Coleções](docs/collections.md)
* [Erros](docs/errors.md)
* [Cabeçalhos](docs/headers.md)
* [API do Microsoft Graph](https://graph.microsoft.io)
* [Notas de versão](https://github.com/microsoftgraph/msgraph-sdk-dotnet/releases)

## Observações

Instale o NewtonSoft.json primeiro caso queira usar uma versão posterior à NewtonSoft.Json 6.0.1. Por exemplo, você precisará instalar o NewtonSoft.Json 9.0.1 primeiro se quiser usá-lo nessa biblioteca enquanto visa o .NET Core com o padrão 1.0.

Instale System.Runtime.InteropServices.RuntimeInformation antes de instalar o Microsoft.Graph 1.3 e versões posteriores se você estiver com problemas para atualizar o pacote de uma solução do Xamarin. Talvez você também precise de referências atualizadas para Microsoft.NETCore.UniversalWindowsPlatform 5.2.2 e versões posteriores.

## Problemas

Confira [problemas](https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues) para exibir ou registrar problemas.

Este projeto adotou o [Código de Conduta de Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/).  Para saber mais, confira as [Perguntas frequentes sobre o Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/) ou entre em contato pelo [opencode@microsoft.com](mailto:opencode@microsoft.com) se tiver outras dúvidas ou comentários.

## Outros recursos

* Pacote NuGet: [https://www.nuget.org/packages/Microsoft.Graph](https://www.nuget.org/packages/Microsoft.Graph)

## Construindo a biblioteca local

Se você quiser construir uma biblioteca local a fim de colaborar em códigos ou testes em execução, você precisará do seguinte:

- Ter o SDK do .NET Core (> 1.0) instalado
- Executar o `dotnet restore` na linha de comando do diretório do pacote
- Executar `nuget restore` e `msbuild` da CLI ou executar o Build do Visual Studio para restaurar pacotes NuGet e compilar o projeto

## Licença

Copyright (c) Microsoft Corporation. Todos os direitos reservados. Licenciada sob a [Licença](LICENSE.txt) do MIT. Confira as informações sobre os pacotes de referência via NuGet nos [Avisos a Terceiros](https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/master/THIRD%20PARTY%20NOTICES).
