---
title: "Uninstall app for user"
description: "Uninstall an app from the personal scope of the specified user."
author: "akjo"
doc_type: "apiPageType"
ms.localizationpriority: medium
ms.prod: "microsoft-teams"
---

# Uninstall app for user

Namespace: microsoft.graph

Uninstall an [app](../resources/teamsappinstallation.md) from the personal scope of the specified [user](../resources/user.md).

>**Note:** This API works differently in one or more national clouds. For details, see [Implementation differences in national clouds](/graph/teamwork-national-cloud-differences). 

## Permissions

One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | TeamsAppInstallation.ReadWriteSelfForUser, TeamsAppInstallation.ReadWriteForUser |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | TeamsAppInstallation.ReadWriteSelfForUser.All, TeamsAppInstallation.ReadWriteForUser.All |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
DELETE /users/{user-id | user-principal-name}/teamwork/installedApps/{app-installation-id}
```

## Request headers

| Header       | Value |
|:---------------|:--------|
| Authorization  | Bearer {token}. Required.  |

## Request body

Do not supply a request body for this method.

## Response

If successful, this method returns a `204 No Content` response code. It does not return anything in the response body.

## Example

### Request

The following is an example of the request.


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "user_delete_teamsApp",
  "sampleKeys": ["5b649834-7412-4cce-9e69-176e95a394f5", "NWI2NDk4MzQtNzQxMi00Y2NlLTllNjktMTc2ZTk1YTM5NGY1IyNhNmI2MzM2NS0zMWE0LTRmNDMtOTJlYy03MTBiNzE1NTdhZjk"]
}-->

```http
DELETE https://graph.microsoft.com/v1.0/users/5b649834-7412-4cce-9e69-176e95a394f5/teamwork/installedApps/NWI2NDk4MzQtNzQxMi00Y2NlLTllNjktMTc2ZTk1YTM5NGY1IyNhNmI2MzM2NS0zMWE0LTRmNDMtOTJlYy03MTBiNzE1NTdhZjk
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

await graphClient.Users["{user-id}"].Teamwork.InstalledApps["{userScopeTeamsAppInstallation-id}"]
	.Request()
	.DeleteAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

### Response

The following is an example of the response.

<!-- {
  "blockType": "response",
  "truncated": true
} -->

```http
HTTP/1.1 204 No Content
```

<!-- uuid: 8fcb5dbc-d5aa-4681-8e31-b001d5168d79
2015-10-25 14:57:30 UTC -->
<!-- {
  "type": "#page.annotation",
  "description": "User delete teamsAppInstallations,
  "keywords": "",
  "section": "documentation",
  "tocPath": ""
}-->
