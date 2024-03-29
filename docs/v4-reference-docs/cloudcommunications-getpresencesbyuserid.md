---
title: "cloudCommunications: getPresencesByUserId"
description: "Get the presence information for multiple users."
author: "mkhribech"
ms.localizationpriority: medium
doc_type: apiPageType
ms.prod: "cloud-communications"
---

# cloudCommunications: getPresencesByUserId

Namespace: microsoft.graph

Get the [presence](../resources/presence.md) information for multiple users.

## Permissions
One of the following permissions is required to call these APIs. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

| Permission type | Permissions (from least to most privileged)                  |
| :-------------- | :----------------------------------------------------------- |
| Delegated (work or school account)     | Presence.Read.All                         |
| Delegated (personal Microsoft account) | Not Supported.                         |
| Application                            | Not Supported.                                  |

> **Note:**
> * Maximum of 650 user IDs are supported per API request.
> * The maximum request rate of this API is 1500 API requests in a 30 second period, per application per tenant.

## HTTP Request
<!-- { "blockType": "ignored" } -->
```http
POST /communications/getPresencesByUserId
```

## Request Headers
| Name          | Description               |
|:--------------|:--------------------------|
| Authorization | Bearer {token}. Required. |
|Content-type | application/json. Required. |


## Request body

In the request body, provide a JSON object with the following parameter.

| Parameter      | Type    |Description|
|:---------------|:--------|:----------|
|ids|String collection|The user object IDs.|

## Response

If successful, this method returns a `200 OK` response code and a collection of [presence](../resources/presence.md) objects in the response body.


## Examples

### Request
The following example shows a request.


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get-presence-multiple-users"
}-->

```http
POST https://graph.microsoft.com/v1.0/communications/getPresencesByUserId
Content-Type: application/json

{
	"ids": ["fa8bf3dc-eca7-46b7-bad1-db199b62afc3", "66825e03-7ef5-42da-9069-724602c31f6b"]
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var ids = new List<String>()
{
	"fa8bf3dc-eca7-46b7-bad1-db199b62afc3",
	"66825e03-7ef5-42da-9069-724602c31f6b"
};

await graphClient.Communications
	.GetPresencesByUserId(ids)
	.Request()
	.PostAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

### Response
The following example shows the response.

> **Note:** The response objects might be shortened for readability. All the properties will be returned from an actual call.

<!-- {
  "blockType": "response",
  "name": "get-presence-multiple-users",
  "truncated": "true",
  "@odata.type": "microsoft.graph.presence"
}-->

```http
HTTP/1.1 200 OK
Content-Type: application/json
Content-Length: 1574

{
	"value": [{
			"id": "fa8bf3dc-eca7-46b7-bad1-db199b62afc3",
			"availability": "Busy",
			"activity": "InAMeeting"
		},
		{
			"id": "66825e03-7ef5-42da-9069-724602c31f6b",
			"availability": "Away",
			"activity": "Away"
		}
	]
}
```

<!-- uuid: 8fcb5dbc-d5aa-4681-8e31-b001d5168d79
2015-10-25 14:57:30 UTC -->
<!--
{
  "type": "#page.annotation",
  "description": "List Presence Information",
  "keywords": "",
  "section": "documentation",
  "tocPath": "",
  "suppressions": [
  ]
}
-->


