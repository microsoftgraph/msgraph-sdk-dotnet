# Reading unknown JSON properties from Microsoft Graph models

The SDK stores response properties that are not represented by a generated model property in `AdditionalData`. In the Kiota based v5 SDK, JSON arrays and objects in this dictionary are represented by Kiota `UntypedNode` types, not `System.Text.Json.JsonElement`. Code that tests an additional-data value with `value is JsonElement` will therefore skip the value.

For example, group delta responses can include the `members@delta` annotation. The following snippet processes the `members@delta` annotation for every group in one response page. It is not a complete delta-sync loop: follow every `@odata.nextLink`, process each page successfully, and persist the final `@odata.deltaLink` only after all changes have been applied:

```csharp
using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;

foreach (var group in deltaResponse.Value ?? Enumerable.Empty<Group>())
{
    if (!group.AdditionalData.TryGetValue("members@delta", out var value) ||
        value is not UntypedArray members)
    {
        continue;
    }
    foreach (var node in members.GetValue())
    {
        if (node is not UntypedObject member)
        {
            continue;
        }

        var properties = member.GetValue();
        if (!properties.TryGetValue("id", out var idNode) ||
            idNode is not UntypedString id)
        {
            continue;
        }

        var memberId = id.GetValue();
        var isRemoved = properties.ContainsKey("@removed");

        // Use memberId and isRemoved to apply the delta.
    }
}
```

Treat `@removed` as a marker: its presence means the member was removed. Delta consumers should apply additions and removals idempotently and persist the returned delta link only after successfully applying the page.

The concrete value types are `UntypedArray`, `UntypedObject`, and `UntypedString` from Kiota abstractions. Avoid serializing the SDK model with `System.Text.Json.JsonSerializer` to inspect these values; that serializer does not define the Kiota `UntypedNode` representation.
