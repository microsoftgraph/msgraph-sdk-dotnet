---
title: "Get installed app in team"
description: "Get an app installed in team."
author: "AkJo"
ms.localizationpriority: medium
ms.prod: "microsoft-teams"
doc_type: apiPageType
---

# Get installed app in team

Namespace: microsoft.graph

Retrieve the [app](../resources/teamsappinstallation.md) installed in the specified [team](../resources/team.md).

## Permissions

One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | TeamsAppInstallation.ReadWriteSelfForTeam, TeamsAppInstallation.ReadForUser, TeamsAppInstallation.ReadForTeam, TeamsAppInstallation.ReadWriteForTeam, Group.Read.All**, Group.ReadWrite.All**, Directory.Read.All**, Directory.ReadWrite.All** |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | TeamsAppInstallation.Read.Group*, TeamsAppInstallation.ReadWriteSelfForTeam.All, TeamsAppInstallation.ReadForTeam.All, TeamsAppInstallation.ReadWriteForTeam.All, Group.Read.All**, Group.ReadWrite.All**, Directory.Read.All**, Directory.ReadWrite.All** |


<!-- markdownlint-disable MD041-->


> **Note**:
> - Permissions marked with * use [resource-specific consent](/microsoftteams/platform/graph-api/rsc/resource-specific-consent).
> - Permissions marked with ** are supported only for backward compatibility. We recommend that you update your solutions to use an alternative permission listed in the previous table and avoid using these permissions going forward.
## HTTP request

<!-- { "blockType": "ignored" } -->

```http
GET /teams/{id}/installedApps/{id}
```

## Request headers

| Header       | Value |
|:---------------|:--------|
| Authorization  | Bearer {token}. Required.  |

## Request body

Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and a [teamsAppInstallation](../resources/teamsappinstallation.md) object in the response body.

## Examples

### Example 1: Get the installed app

#### Request

The following is an example of the request.


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get_installed_teams_apps",
  "sampleKeys": ["02bd9fd6-8f93-4758-87c3-1fb73740a315", "MDJiZDlmZDYtOGY5My00NzU4LTg3YzMtMWZiNzM3NDBhMzE1IyMwZDgyMGVjZC1kZWYyLTQyOTctYWRhZC03ODA1NmNkZTdjNzg="]
}-->

```msgraph-interactive
GET https://graph.microsoft.com/v1.0/teams/02bd9fd6-8f93-4758-87c3-1fb73740a315/installedApps/MDJiZDlmZDYtOGY5My00NzU4LTg3YzMtMWZiNzM3NDBhMzE1IyMwZDgyMGVjZC1kZWYyLTQyOTctYWRhZC03ODA1NmNkZTdjNzg=
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var teamsAppInstallation = await graphClient.Teams["{team-id}"].InstalledApps["{teamsAppInstallation-id}"]
	.Request()
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response

The following is an example of the response.
>**Note:** The response object shown here might be shortened for readability.
<!-- {
  "blockType": "response",
  "name": "get_installed_teams_apps",
  "truncated": true,
  "@odata.type": "microsoft.graph.teamsAppInstallation",
  "isCollection": false
} -->

```http
HTTP/1.1 200 OK
Content-type: application/json

{
  "value": [
    {
      "id": "id-value"
    }
  ]
}
```

### Example 2: Get the names and other details of the installed app

#### Requests

The following is an example of the request.


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "get_installed_teams_apps_expand"
}-->

```msgraph-interactive
GET https://graph.microsoft.com/v1.0/teams/{id}/installedApps/{id}?$expand=teamsAppDefinition
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var teamsAppInstallation = await graphClient.Teams["{team-id}"].InstalledApps["{teamsAppInstallation-id}"]
	.Request()
	.Expand("teamsAppDefinition")
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response

The following is an example of the response.

>**Note:** The response object shown here might be shortened for readability.
<!-- {
  "blockType": "response",
  "name": "get_installed_teams_apps_expand",
  "truncated": true,
  "@odata.type": "microsoft.graph.teamsAppInstallation",
  "isCollection": false
} -->

```http
HTTP/1.1 200 OK
Content-type: application/json

{
    "value": [
        {
            "id": "NjRiOWM3NDYtYjE1NS00MDQyLThkNDctOTQxYmQzODE2ODFiIyMwZDgyMGVjZC1kZWYyLTQyOTctYWRhZC03ODA1NmNkZTdjNzg=",
            "teamsAppDefinition": {
                "id": "MGQ4MjBlY2QtZGVmMi00Mjk3LWFkYWQtNzgwNTZjZGU3Yzc4IyMxLjAuMA==",
                "teamsAppId": "0d820ecd-def2-4297-adad-78056cde7c78",
                "displayName": "OneNote",
                "version": "1.0.0"
            }
        }
  ]
}
```

<!-- uuid: 8fcb5dbc-d5aa-4681-8e31-b001d5168d79
2015-10-25 14:57:30 UTC -->
<!-- {
  "type": "#page.annotation",
  "description": "List owners",
  "keywords": "",
  "section": "documentation",
  "tocPath": "",
  "suppressions": [
  ]
}-->
