---
title: "List serviceConfigurationRecords"
description: "Retrieves a list of domainDnsRecord objects needed to enable services for the domain."
author: "adimitui"
ms.localizationpriority: medium
ms.prod: "directory-management"
doc_type: apiPageType
---

# List serviceConfigurationRecords

Namespace: microsoft.graph

Retrieves a list of [domainDnsRecord](../resources/domaindnsrecord.md) objects needed to enable services for the domain.

Use the returned list to add records to the zone file of the domain. This can be done through the domain registrar or DNS server configuration.

## Permissions

One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).


|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Domain.Read.All, Domain.ReadWrite.All   |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | Domain.Read.All, Domain.ReadWrite.All |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
GET /domains/{id}/serviceConfigurationRecords
```

## Optional query parameters

This method supports the [OData Query Parameters](/graph/query-parameters) to help customize the response.

## Request headers

| Name      |Description|
|:----------|:----------|
| Authorization  | Bearer {token}. Required. |
| Content-Type  | application/json |

## Request body

Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and collection of [domainDnsRecord](../resources/domaindnsrecord.md) objects in the response body.

## Example
##### Request


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get_serviceconfigurationrecords"
}-->
```msgraph-interactive
GET https://graph.microsoft.com/v1.0/domains/{domain-name}/serviceConfigurationRecords
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var serviceConfigurationRecords = await graphClient.Domains["{domain-id}"].ServiceConfigurationRecords
	.Request()
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

