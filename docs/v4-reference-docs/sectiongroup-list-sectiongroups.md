---
title: "List sectionGroups"
description: "Retrieve a list of section groups from the specified section group."
ms.localizationpriority: medium
author: "jewan-microsoft"
ms.prod: "onenote"
doc_type: apiPageType
---

# List sectionGroups

Namespace: microsoft.graph

Retrieve a list of [section groups](../resources/sectiongroup.md) from the specified section group.
## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Notes.Create, Notes.Read, Notes.ReadWrite, Notes.Read.All, Notes.ReadWrite.All    |
|Delegated (personal Microsoft account) | Notes.Create, Notes.Read, Notes.ReadWrite    |
|Application | Notes.Read.All, Notes.ReadWrite.All |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
GET /me/onenote/sectionGroups/{id}/sectionGroups
GET /users/{id | userPrincipalName}/onenote/sectionGroups/{id}/sectionGroups
GET /groups/{id}/onenote/sectionGroups/{id}/sectionGroups
GET /sites/{id}/onenote/sectionGroups/{id}/sectionGroups
```
## Optional query parameters
This method supports the [OData Query Parameters](/graph/query-parameters) to help customize the response.

The default sort order is `name asc`.

The default query expands `parentNotebook` and selects its `id`, `displayName`, and `self` properties. Valid `expand` values for section groups are `sections`, `sectionGroups`, `parentNotebook`, and `parentSectionGroup`.

## Request headers
| Name       | Type | Description|
|:-----------|:------|:----------|
| Authorization  | string  | Bearer {token}. Required. |
| Accept | string | `application/json` |

## Request body
Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and a collection of [sectionGroup](../resources/sectiongroup.md) objects in the response body.
## Example
##### Request
Here is an example of the request.

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get_sectiongroups"
}-->
```msgraph-interactive
GET https://graph.microsoft.com/v1.0/me/onenote/sectionGroups/{id}/sectionGroups
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var sectionGroups = await graphClient.Me.Onenote.SectionGroups["{sectionGroup-id}"].SectionGroups
	.Request()
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

