---
title: "Remove a member"
description: "Use this API to remove a member (user, group, or device) from an administrative unit."
author: "DougKirschner"
ms.localizationpriority: medium
ms.prod: "directory-management"
doc_type: apiPageType
---

# Remove a member

Namespace: microsoft.graph

Use this API to remove a member (user, group, or device) from an administrative unit.

## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).


|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | AdministrativeUnit.ReadWrite.All    |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | AdministrativeUnit.ReadWrite.All |

To remove a member from an administrative unit, the calling principal must be assigned one of the following [Azure AD roles](/azure/active-directory/roles/permissions-reference):

* Privileged Role Administrator
* Global Administrator

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
DELETE /directory/administrativeUnits/{id}/members/{id}/$ref
```
## Request headers
| Name      |Description|
|:----------|:----------|
| Authorization  | Bearer {token}. Required. |

## Request body
Do not supply a request body for this method.

## Response

If successful, this method returns `204 No Content` response code. It does not return anything in the response body.

## Example
### Request
The following is an example of the request. In the example below, `{id1}` represents the identifier for the target administrative unit, and `{id2}` represents the unique identifier for the member user, group, or device to be removed from the target administrative unit. 


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "delete_administrativeunit_members"
} -->
```msgraph-interactive
DELETE https://graph.microsoft.com/v1.0/directory/administrativeUnits/{id1}/members/{id2}/$ref
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

await graphClient.Directory.AdministrativeUnits["{administrativeUnit-id}"].Members["{directoryObject-id}"].Reference
	.Request()
	.DeleteAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

### Response
Here is an example of the response.

<!-- {
  "blockType": "response",
  "truncated": true
} -->
```http
HTTP/1.1 204 No Content
```
