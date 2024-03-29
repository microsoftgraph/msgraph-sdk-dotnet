---
title: "contact: delta"
description: "Get a set of contacts that have been added, deleted, or updated in a specified folder."
ms.localizationpriority: medium
author: "kevinbellinger"
ms.prod: "outlook"
doc_type: apiPageType
---

# contact: delta

Namespace: microsoft.graph

Get a set of contacts that have been added, deleted, or updated in a specified folder.

A **delta** function call for contacts in a folder is similar to a GET request, except that by appropriately 
applying [state tokens](/graph/delta-query-overview) in one or more of these calls, 
you can query for incremental changes in the contacts in 
that folder. This allows you to maintain and synchronize a local store of a user's contacts without 
having to fetch the entire set of contacts from the server every time.  

## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Contacts.Read, Contacts.ReadWrite    |
|Delegated (personal Microsoft account) | Contacts.Read, Contacts.ReadWrite    |
|Application | Contacts.Read, Contacts.ReadWrite |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
GET /me/contactFolders/{id}/contacts/delta
GET /users/{id}/contactFolders/{id}/contacts/delta
```

## Query parameters

Tracking changes in contacts incurs a round of one or more **delta** function calls. If you use any query parameter 
(other than `$deltatoken` and `$skiptoken`), you must specify 
it in the initial **delta** request. Microsoft Graph automatically encodes any specified parameters 
into the token portion of the `@odata.nextLink` or `@odata.deltaLink` URL provided in the response. You only need to specify any desired query parameters once upfront. 
In subsequent requests, simply copy and apply the `@odata.nextLink` or `@odata.deltaLink` URL from the previous response, as that URL already 
includes the encoded, desired parameters.

| Query parameter	   | Type	|Description|
|:---------------|:--------|:----------|
| $deltatoken | string | A [state token](/graph/delta-query-overview) returned in the `@odata.deltaLink` URL of the previous **delta** function call for the same contact collection, indicating the completion of that round of change tracking. Save and apply the entire `@odata.deltaLink` URL including this token in the first request of the next round of change tracking for that collection.|
| $skiptoken | string | A [state token](/graph/delta-query-overview) returned in the `@odata.nextLink` URL of the previous **delta** function call, indicating there are further changes to be tracked in the same contact collection. |

### OData query parameters

- You can use a `$select` query parameter as in any GET request to specify only the properties your need for best performance. The 
_id_ property is always returned. 


## Request headers
| Name       | Type | Description |
|:---------------|:----------|:----------|
| Authorization  | string  | Bearer {token}. Required. |
| Content-Type  | string  | application/json. Required. |
| Prefer | string  | odata.maxpagesize={x}. Optional. |

## Response

If successful, this method returns a `200 OK` response code and [contact](../resources/contact.md) collection object in the response body.

## Example
##### Request
The following example shows how to make a single **delta** function call, use the `$select` parameter to get only 
each contact's **displayName** property, and limit the maximum number of contacts 
in the response body to 2.

To track changes in the contacts in a folder, you would make one or more **delta** function calls, with 
appropriate state tokens, to get the set of incremental changes since the last delta query. 

You can find a similar example that shows how to use the state tokens to track changes in the messages of a mail folder: 
[Get incremental changes to messages in a folder](/graph/delta-query-messages). The main differences
between tracking contacts and tracking messages in a folder are in the delta query request URLs, and the query responses 
returning **contact** rather than **message** collections.
 

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "contact_delta"
}-->
```msgraph-interactive
GET https://graph.microsoft.com/v1.0/me/contactFolders/{id}/contacts/delta?$select=displayName
Prefer: odata.maxpagesize=2
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var delta = await graphClient.Me.ContactFolders["{contactFolder-id}"].Contacts
	.Delta()
	.Request()
	.Header("Prefer","odata.maxpagesize=2")
	.Select("displayName")
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

