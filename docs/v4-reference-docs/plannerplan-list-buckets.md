---
title: "List buckets"
description: "Retrieve a list of **plannerbucket** objects contained by a plannerPlan object."
ms.localizationpriority: medium
author: "TarkanSevilmis"
ms.prod: "planner"
doc_type: apiPageType
---

# List buckets

Namespace: microsoft.graph

Retrieve a list of [plannerBucket](../resources/plannerbucket.md) objects contained by a [plannerPlan](../resources/plannerplan.md) object.
## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Tasks.Read, Tasks.ReadWrite, Group.Read.All, Group.ReadWrite.All    |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | Tasks.Read.All, Tasks.ReadWrite.All |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
GET /planner/plans/{plan-id}/buckets
```

## Request headers
| Name      |Description|
|:----------|:----------|
| Authorization  | Bearer {token}. Required. |

## Request body
Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and a collection of [plannerBucket](../resources/plannerbucket.md) objects in the response body.

This method can return any of the [HTTP status codes](/graph/errors). The most common errors that apps should handle for this method are the 403 and 404 responses. For more information about these errors, see [Common Planner error conditions](../resources/planner-overview.md#common-planner-error-conditions).
## Example
##### Request
Here is an example of the request.

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get_buckets_2"
}-->
```msgraph-interactive
GET https://graph.microsoft.com/v1.0/planner/plans/{plan-id}/buckets
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var buckets = await graphClient.Planner.Plans["{plannerPlan-id}"].Buckets
	.Request()
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

