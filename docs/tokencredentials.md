# TokenCredentials Examples

This document is aimed at helping users of the Microsoft Graph .NET SDK to quickly be able to move their code from AuthProviders providers present in the deprecated [Microsoft.Graph.Auth](https://github.com/microsoftgraph/msgraph-sdk-dotnet-auth) package to using TokenCredential instances provided from Azure.Identity package.

## 1. InteractiveBrowserCredential

This credential class provides authentication through an interactive browser prompt and similar functionality to the **deprecated Interactive AuthProvider** and can be used as follows.

```cs
string[] scopes = {"User.Read"};

InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions() {
                ClientId = clientId
};
InteractiveBrowserCredential interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

GraphServiceClient graphClient = new GraphServiceClient(interactiveBrowserCredential, scopes); // you can pass the TokenCredential directly to the GraphServiceClient

User me = await graphClient.Me.GetAsync();
```

## 2. UsernamePasswordCredential

This credential class provides the [username/password authentication flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-authentication-flows#usernamepassword-ropc) and similar functionality to the **deprecated Username/password AuthProvider** and can be used as follows. 
Use this flow only when you cannot use any of the other OAuth flows.

```cs
string[] scopes = {"User.Read"};

UsernamePasswordCredential usernamePasswordCredential = new UsernamePasswordCredential("username@domain.com", "password", tenantId, clientId);

GraphServiceClient graphClient = new GraphServiceClient(usernamePasswordCredential, scopes); // you can pass the TokenCredential directly to the GraphServiceClient

User me = await graphClient.Me.GetAsync();
```


## 3. DeviceCodeCredential

This credential class provides the [device code authentication flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-authentication-flows#device-code) flow and similar use to the **deprecated Device code AuthProvider** and can be used as follows.
The device code flow enables sign in to devices by way of another device.

```cs
string[] scopes = {"User.Read"};

DeviceCodeCredentialOptions deviceCodeCredentialOptions = new DeviceCodeCredentialOptions()
{
    ClientId = clientId,
    DeviceCodeCallback = (info, cts) => {
        Console.WriteLine(info.Message); // prompts the user to sign-in
        return Task.CompletedTask;
    },
};
DeviceCodeCredential deviceCodeCredential = new DeviceCodeCredential(deviceCodeCredentialOptions);

GraphServiceClient graphClient = new GraphServiceClient(deviceCodeCredential, scopes);

User me = await graphClient.Me.GetAsync();
```

## 4. ClientSecretCredential

This credential class provides the [Client credentials authentication flow using an app secret](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-authentication-flows#client-credentials) a similar use to the **deprecated Client Credential AuthProvider** with the use of a client secret and can be used as follows.
The device code flow enables sign in to devices by way of another device.

```cs
string[] scopes = {"https://graph.microsoft.com/.default"};

ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret); 

GraphServiceClient graphClient = new GraphServiceClient(clientSecretCredential, scopes);

User me = await graphClient.Users["user-id"].GetAsync();
```

## 5. ClientCertificateCredential

This credential class provides the [Client credentials authentication flow using an certificate](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-authentication-flows#client-credentials) a similar use to the **deprecated Client Credential AuthProvider** with the use of a client certificate and can be used as follows.

```cs
string[] scopes = {"https://graph.microsoft.com/.default"};

ClientCertificateCredential clientCertificateCredential = new ClientCertificateCredential(tenantId, clientId, certificatePath);

// or pass instance of X509Certificate2
// ClientCertificateCredential clientCertificateCredential = new ClientCertificateCredential(tenantId, clientId, certificatePath);

GraphServiceClient graphClient = new GraphServiceClient(clientCertificateCredential, scopes);

User me = await graphClient.Users["user-id"].GetAsync();
```

## 6. AuthorizationCodeCredential

This credential class provides the [Authorization code authentication flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-authentication-flows#authorization-code) a similar use to the **Authorization code AuthProvider** with the use of a client secret and can be used as follows. The authorization code flow enables native and web apps to securely obtain tokens in the name of the user. 

```cs
string[] scopes = {"User.Read"};

AuthorizationCodeCredential authorizationCodeCredential = new AuthorizationCodeCredential(tenantId, clientId,  clientSecret, authCode);

GraphServiceClient graphClient = new GraphServiceClient(authorizationCodeCredential, scopes);

User me = await graphClient.Me.GetAsync();
```

# Other TokenCredentials

It is also useful to know that Azure.Identity provides other TokenCredentials that may be useful. These include.

## 1. EnvironmentCredential

This credential enables the used of defined environment variables to configure authentication. The environment variables used are as follows.

- AZURE_TENANT_ID -   The Azure Active Directory tenant(directory) ID.
- AZURE_CLIENT_ID -   The client(application) ID of an App Registration in the tenant.
- AZURE_CLIENT_SECRET	- A client secret that was generated for the App Registration.
- AZURE_CLIENT_CERTIFICATE_PATH - A path to certificate and private key pair in PEM or PFX format, which can authenticate the App Registration.
- AZURE_USERNAME -    The username, also known as upn, of an Azure Active Directory user account.
- AZURE_PASSWORD -    The password of the Azure Active Directory user account. Note this does not support accounts with MFA enabled.

Based on the environment variable defined, this credential ultimately uses a `ClientSecretCredential` or `UsernamePasswordCredential` to perform the authentication using these details.
```cs
string[] scopes = {"User.Read"};

EnvironmentCredential environmentCredential = new EnvironmentCredential();

GraphServiceClient graphClient = new GraphServiceClient(environmentCredential, scopes);

User me = await graphClient.Me.GetAsync();
```

## 2. ChainedTokenCredential

This credential class provides a way to chain TokenCredential instances to be used in the attempt of token acquisitions until one of the `getToken` methods of the TokenCredential instances returns a non-default AccessToken. An example is as shown below. In the example, the application will first attempt to check if it can get an AccessToken from the Environment and then use the interactive browser flow if it is unable to do so.

```cs
string[] scopes = {"User.Read"};

// initialize the EnvironmentCredential
EnvironmentCredential environmentCredential = new EnvironmentCredential();
// initialize the InteractiveBrowserCredentialOptions
InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions() {
                ClientId = clientId
};
InteractiveBrowserCredential myBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);
// chain the TokenCredentials
TokenCredential [] tokenCredentials = new TokenCredential[]{ environmentCredential , myBrowserCredential };
ChainedTokenCredential chainedTokenCredential = new ChainedTokenCredential(tokenCredentials);

GraphServiceClient graphClient = new GraphServiceClient(chainedTokenCredential, scopes);

User me = await graphClient.Me.GetAsync();
```


## Useful References

- [Graph API Permissions/Scopes](https://docs.microsoft.com/en-us/graph/permissions-reference)
- [Azure.Identity Library Reference Docs](https://docs.microsoft.com/en-us/dotnet/api/azure.identity?view=azure-dotnet)