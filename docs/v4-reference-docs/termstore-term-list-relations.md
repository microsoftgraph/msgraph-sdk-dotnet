---
title: "List relations"
description: "Get the relations from the relations navigation property."
author: vishriv
ms.localizationpriority: medium
ms.prod: sites-and-lists
doc_type: apiPageType
---

# List relations
Namespace: microsoft.graph.termStore

Get the different relation of a [term] or [set] from the relations navigation property.

## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type|Permissions (from least to most privileged)|
|:---|:---|
|Delegated (work or school account) |TermStore.Read.All, TermStore.ReadWrite.All |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | Not supported. |


## HTTP request

<!-- {
  "blockType": "ignored"
}
-->
``` http
GET sites/{site-id}/termStore/sets/{set-id}/relations
GET sites/{site-id}/termStore/sets/{set-id}/terms/{term-id}/relations
```

## Optional query parameters
This method supports some of the OData query parameters to help customize the response. For general information, see [OData query parameters](/graph/query-parameters).

## Request headers
|Name|Description|
|:---|:---|
|Authorization|Bearer {token}. Required.|

## Request body
Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and a collection of [microsoft.graph.termStore.relation](../resources/termstore-relation.md) objects in the response body.

## Examples

### Request


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get_relation",
  "sampleKeys": ["microsoft.sharepoint.com,b9b0bc03-cbc4-40d2-aba9-2c9dd9821ddf,6a742cee-9216-4db5-8046-13a595684e74", "874be29c-35c8-4295-b3f8-ca2400c966c3"]
}-->

``` http
GET https://graph.microsoft.com/v1.0/sites/microsoft.sharepoint.com,b9b0bc03-cbc4-40d2-aba9-2c9dd9821ddf,6a742cee-9216-4db5-8046-13a595684e74/termStore/sets/874be29c-35c8-4295-b3f8-ca2400c966c3/relations
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var relations = await graphClient.Sites["{site-id}"].TermStore.Sets["{termStore.set-id}"].Relations
	.Request()
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

### Response
>**Note:** The response object shown here might be shortened for readability.
<!-- {
  "blockType": "response",
  "truncated": true,
  "@odata.type": "microsoft.graph.termStore.relation",
  "isCollection": true
}-->

``` http
HTTP/1.1 200 OK
Content-Type: application/json

{
  "value": [
    {
      "id": "052c749c-749c-052c-9c74-2c059c742c05",
      "relationship": "pin"
    }
  ]
}
```


[set]: ../resources/termstore-set.md
[term]: ../resources/termstore-term.md
[microsoft.graph.termStore.relation]: ../resources/termstore-relation.md


<!--
{
  "type": "#page.annotation",
  "description": "Create a pinned term entity in termStore",
  "keywords": "term,termStore",
  "section": "documentation",
  "tocPath": "termStore/term list relations",
  "suppressions": [
  ]
}
-->


