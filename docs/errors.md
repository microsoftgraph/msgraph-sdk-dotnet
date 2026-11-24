Handling errors in the Microsoft Graph .NET Client Library
=====

Errors in the Microsoft Graph .NET Client Library behave like errors returned from the Microsoft Graph service. You can read more about them [here](https://learn.microsoft.com/en-us/graph/errors).

Anytime you make a request against the service there is the potential for an error. In the case of an error, the request will throw a `ODataError` exception that contains the service error details and can be handled as below.

```cs
try
{
    await graphServiceClient.Me.PatchAsync(user);
}
catch (ODataError odataError)
{
    Console.WriteLine(odataError.Error?.Code);
    Console.WriteLine(odataError.Error?.Message);
    throw;
}
```


## Checking the error status code

You can check the status code that caused the error as below.

```csharp
catch (ODataError odataError) when (odataError.ResponseStatusCode == (int)HttpStatusCode.NotFound)
{
        // Handle 404 status code
}
```

## Checking the error

There are a few different types of errors that can occur during a network call. These most common error codes are defined in [GraphErrorCode.cs](../src/Microsoft.Graph/Enums/GraphErrorCode.cs). These can be checked by matching with the error code value as below.

```csharp
catch (ODataError odataError) when (odataError.Error.Code.Equals(GraphErrorCode.AccessDenied.ToString(),StringComparison.OrdinalIgnoreCase))
{
        // Handle access denied error
}
```

Each error object has a `Message` property as well as code. This message is for debugging purposes and is not meant to be displayed to the user. Common error codes are defined in [GraphErrorCode.cs](../src/Microsoft.Graph/Enums/GraphErrorCode.cs).
