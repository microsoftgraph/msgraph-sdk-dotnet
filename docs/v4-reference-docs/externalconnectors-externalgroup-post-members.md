---
title: "Create identity"
description: "Create a new member as an identity resource in an externalGroup."
author: "sacampbe"
ms.localizationpriority: medium
ms.prod: "search"
doc_type: apiPageType
---

# Create identity
Namespace: microsoft.graph.externalConnectors



Create an [identity](../resources/externalconnectors-identity.md) resource for a new member in an [externalGroup](../resources/externalconnectors-externalgroup.md).

## Permissions

One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

| Permission type                        | Permissions (from least to most privileged) |
|:---------------------------------------|:--------------------------------------------|
| Delegated (work or school account)     | ExternalItem.ReadWrite.OwnedBy, ExternalItem.ReadWrite.All |
| Delegated (personal Microsoft account) | Not supported                               |
| Application                            | ExternalItem.ReadWrite.OwnedBy, ExternalItem.ReadWrite.All |

## HTTP request

<!-- {
  "blockType": "ignored"
}
-->
``` http
POST /external/connections/{connectionsId}/groups/{externalGroupId}/members
```

## Request headers

| Name          | Description                 |
|:--------------|:----------------------------|
| Authorization | Bearer {token}. Required.   |
| Content-Type  | application/json. Required. |

## Request body

In the request body, supply a JSON representation of the **identity** object.

You can specify the following properties when creating an **identity** resource for a member in an **externalGroup**.

| Property       | Type                    | Description                                              |
|:---------------|:------------------------|:---------------------------------------------------------|
| id             | String                  | The unique `id` of the member. It would be the **objectId** in case of Azure Active Directory users or groups and the **externalGroupId** in case of external groups. Required.                                    |
| type           | microsoft.graph.externalConnectors.identityType | The type of member added to the external group. Possible values are: `user`,`group`, `externalGroup`. Required. |


## Response

If successful, this method returns a `201 Created` response code and an **identity** object in the response body.

## Examples

### Example 1: Add an Azure Active Directory user as a member

#### Request


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "create_aad_user_identity_from_group",
  "sampleKeys": ["31bea3d537902000", "contosohr"]
}
-->

``` http
POST https://graph.microsoft.com/v1.0/external/connections/contosohr/groups/31bea3d537902000/members
Content-Type: application/json

{
  "id": "e811976d-83df-4cbd-8b9b-5215b18aa874",
  "type": "user"
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var identity = new Microsoft.Graph.ExternalConnectors.Identity
{
	Id = "e811976d-83df-4cbd-8b9b-5215b18aa874",
	Type = Microsoft.Graph.ExternalConnectors.IdentityType.User
};

await graphClient.External.Connections["{externalConnectors.externalConnection-id}"].Groups["{externalConnectors.externalGroup-id}"].Members
	.Request()
	.AddAsync(identity);

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response

<!-- {
  "blockType": "response",
  "truncated": true,
  "@odata.type": "microsoft.graph.externalConnectors.identity"
}
-->

``` http
HTTP/1.1 201 Created
Content-Type: application/json

{
  "id": "e811976d-83df-4cbd-8b9b-5215b18aa874",
  "type": "user"
}
```

### Example 2: Add an Azure Active Directory group as a member

#### Request


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "create_aad_group_identity_from_group",
  "sampleKeys": ["31bea3d537902000", "contosohr"]
}
-->

``` http
POST https://graph.microsoft.com/v1.0/external/connections/contosohr/groups/31bea3d537902000/members
Content-Type: application/json

{
  "id": "e5477431-1038-484e-bf69-1dfedb97a110",
  "type": "group"
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var identity = new Microsoft.Graph.ExternalConnectors.Identity
{
	Id = "e5477431-1038-484e-bf69-1dfedb97a110",
	Type = Microsoft.Graph.ExternalConnectors.IdentityType.Group
};

await graphClient.External.Connections["{externalConnectors.externalConnection-id}"].Groups["{externalConnectors.externalGroup-id}"].Members
	.Request()
	.AddAsync(identity);

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response

<!-- {
  "blockType": "response",
  "truncated": true,
  "@odata.type": "microsoft.graph.externalConnectors.identity"
}
-->

``` http
HTTP/1.1 201 Created
Content-Type: application/json

{
  "id": "e5477431-1038-484e-bf69-1dfedb97a110",
  "type": "group"
}
```

### Example 3: Add another external group as a member

#### Request


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "create_external_group_identity_from_group",
  "sampleKeys": ["31bea3d537902000", "contosohr"]
}
-->

``` http
POST https://graph.microsoft.com/v1.0/external/connections/contosohr/groups/31bea3d537902000/members
Content-Type: application/json

{
  "id": "1431b9c38ee647f6a",
  "type": "externalGroup",
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var identity = new Microsoft.Graph.ExternalConnectors.Identity
{
	Id = "1431b9c38ee647f6a",
	Type = Microsoft.Graph.ExternalConnectors.IdentityType.ExternalGroup
};

await graphClient.External.Connections["{externalConnectors.externalConnection-id}"].Groups["{externalConnectors.externalGroup-id}"].Members
	.Request()
	.AddAsync(identity);

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response

<!-- {
  "blockType": "response",
  "truncated": true,
  "@odata.type": "microsoft.graph.externalConnectors.identity"
}
-->

``` http
HTTP/1.1 201 Created
Content-Type: application/json

{
  "id": "14m1b9c38qe647f6a",
  "type": "externalGroup"
}
```
