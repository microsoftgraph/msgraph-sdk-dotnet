---
title: "group: removeFavorite"
description: "Remove the group from the list of the current user's favorite groups. Supported for Microsoft 365 groups only."
ms.localizationpriority: medium
author: "psaffaie"
ms.prod: "groups"
doc_type: apiPageType
---

# group: removeFavorite

Namespace: microsoft.graph

Remove the group from the list of the current user's favorite groups. Supported for Microsoft 365 groups only.

## Permissions

One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

| Permission type                        | Permissions (from least to most privileged) |
| :------------------------------------- | :------------------------------------------ |
| Delegated (work or school account)     | Group.ReadWrite.All                         |
| Delegated (personal Microsoft account) | Not supported.                              |
| Application                            | Not supported.                              |

## HTTP request

<!-- { "blockType": "ignored" } -->

```http
POST /groups/{id}/removeFavorite
```

## Request headers

| Header        | Value                                                                                                                                             |
| :------------ | :------------------------------------------------------------------------------------------------------------------------------------------------ |
| Authorization | Bearer {token}. Required.                                                                                                                         |
| Prefer        | return=minimal. If minimal response header is included in the request header, then a successful response returns `204 No Content` code. Optional. |

## Request body

Do not supply a request body for this method.

## Response

If successful, this method returns `200 OK` response code. It does not return anything in the response body.

## Example

#### Request

The following is an example of the request.

# [HTTP](#tab/http)

<!-- {
  "blockType": "request",
  "name": "group_removefavorite"
}-->

```http
POST https://graph.microsoft.com/v1.0/groups/{id}/removeFavorite
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

await graphClient.Groups["{group-id}"]
	.RemoveFavorite()
	.Request()
	.PostAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response

The following is an example of the response.

<!-- {
  "blockType": "response"
} -->

```http
HTTP/1.1 200 OK
```

<!-- uuid: 8fcb5dbc-d5aa-4681-8e31-b001d5168d79
2015-10-25 14:57:30 UTC -->
<!-- {
  "type": "#page.annotation",
  "description": "group: removeFavorite",
  "keywords": "",
  "section": "documentation",
  "tocPath": "",
  "suppressions": [
  ]
}-->
