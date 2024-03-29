---
title: "List definitions"
description: "Get a list of the accessReviewScheduleDefinition objects and their properties."
author: "jyothig123"
ms.localizationpriority: medium
ms.prod: "governance"
doc_type: apiPageType
---

# List definitions
Namespace: microsoft.graph

Get a list of the [accessReviewScheduleDefinition](../resources/accessreviewscheduledefinition.md) objects and their properties.

## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type|Permissions (from least to most privileged)|
|:---|:---|
|Delegated (work or school account)|AccessReview.Read.All, AccessReview.ReadWrite.All|
|Delegated (personal Microsoft account)|Not supported.|
|Application|AccessReview.Read.All, AccessReview.ReadWrite.All|

 The signed-in user must also be in a directory role that permits them to read an access review. See access review [role and application permission authorization checks](../resources/accessreviewsv2-overview.md#role-and-application-permission-authorization-checks).

## HTTP request

To list all your accessReviewScheduleDefinitions:
<!-- { "blockType": "ignored" } -->
```http
GET /identityGovernance/accessReviews/definitions
```

## Optional query parameters
This method supports the `$select`, `$top`, `$skip`,`$orderBy`, and `$filter` OData query parameters to help customize the response. For general information, see [OData query parameters](/graph/query-parameters).

The default page size for this API is 100 **accessReviewScheduleDefinition** objects. To improve efficiency and avoid timeouts due to large result sets, apply pagination using the `$skip` and `$top` query parameters. For more information, see [Paging Microsoft Graph data in your app](/graph/paging).

### Use the $filter query parameter

The `$filter` query parameter with the `contains` operator is supported on the **scope** property of **accessReviewScheduleDefinition**. Use the following format for the request:

```http
/identityGovernance/accessReviews/definitions?$filter=contains(scope/microsoft.graph.accessReviewQueryScope/query, '{object}')
```

The value of `{object}` can be one of the following:

|Value|Description|
|:---     |:---       |
|`/groups`  |List every accessReviewScheduleDefinition on individual groups (excludes definitions scoped to all Microsoft 365 groups with guest users).|
|`/groups/{group id}`  |List every accessReviewScheduleDefinition on a specific group (excludes definitions scoped to all Microsoft 365 groups with guest users).|
|`./members`  |List every accessReviewScheduleDefinition scoped to all Microsoft 365 groups with guest users.|
|`accessPackageAssignments`  |List every accessReviewScheduleDefinition on an access package.|
|`roleAssignmentScheduleInstances`  |List every accessReviewScheduleDefinition for principals that are assigned to a privileged role.|

The `$filter` query parameter is not supported on **accessReviewInactiveUserQueryScope** or **principalResourceMembershipScope**.
## Request headers
|Name|Description|
|:---|:---|
|Authorization|Bearer {token}. Required.|

## Request body
Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and a collection of [accessReviewScheduleDefinition](../resources/accessreviewscheduledefinition.md) objects in the response body.

## Examples

### Example 1: List the first one hundred access review definitions

#### Request


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "list_accessReviewScheduleDefinition"
}-->
```
GET https://graph.microsoft.com/v1.0/identityGovernance/accessReviews/definitions?$top=100&$skip=0
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var definitions = await graphClient.IdentityGovernance.AccessReviews.Definitions
	.Request()
	.Skip(0)
	.Top(100)
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response
>**Note:** The response object shown here might be shortened for readability.
<!-- {
  "blockType": "response",
  "truncated": true,
  "@odata.type": "microsoft.graph.accessReviewScheduleDefinition",
  "isCollection": "true"
} -->
```http
HTTP/1.1 200 OK
Content-type: application/json

{
    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#identityGovernance/accessReviews/definitions",
    "@odata.count": 1,
    "value": [
        {
            "id": "98dcebed-c7f6-46f4-bcf3-4a3fccdb3e2a",
            "displayName": "Access Review",
            "scope": {
                "@odata.type": "#microsoft.graph.accessReviewQueryScope",
                "query": "/groups/119cc181-22f0-4e18-8537-264e7524ee0b/transitiveMembers",
                "queryType": "MicrosoftGraph"
            },
            "instanceEnumerationScope": {
                "@odata.type": "#microsoft.graph.accessReviewQueryScope",
                "query": "/groups/119cc181-22f0-4e18-8537-264e7524ee0b",
                "queryType": "MicrosoftGraph"
            },
            "reviewers": [
                {
                    "query": "./manager",
                    "queryType": "MicrosoftGraph",
                    "queryRoot": "decisions"
                }
            ],
            "settings": {
                "mailNotificationsEnabled": true,
                "reminderNotificationsEnabled": true,
                "justificationRequiredOnApproval": true,
                "defaultDecisionEnabled": false,
                "defaultDecision": "None",
                "instanceDurationInDays": 0,
                "autoApplyDecisionsEnabled": false,
                "recommendationsEnabled": true,
                "recurrence": {
                    "pattern": {
                        "type": "weekly",
                        "interval": 1,
                        "month": 0,
                        "dayOfMonth": 0,
                        "daysOfWeek": [],
                        "firstDayOfWeek": "sunday",
                        "index": "first"
                    },
                    "range": {
                        "type": "numbered",
                        "numberOfOccurrences": 0,
                        "recurrenceTimeZone": null,
                        "startDate": "2020-09-11",
                        "endDate": "9999-12-31"
                    }
                }
            }
        }
    ]
}
```

### Example 2: Retrieve all access review definitions scoped to all Microsoft 365 groups in a tenant

#### Request
The following example shows a request to retrieve all the access review series scoped to all Microsoft 365 groups in a tenant.


# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "list_accessReviewScheduleDefinition_allgroups"
}-->
```msgraph-interactive
GET https://graph.microsoft.com/v1.0/identityGovernance/accessReviews/definitions?$filter=contains(scope/microsoft.graph.accessReviewQueryScope/query, './members')
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var definitions = await graphClient.IdentityGovernance.AccessReviews.Definitions
	.Request()
	.Filter("contains(scope/microsoft.graph.accessReviewQueryScope/query, './members')")
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

#### Response
>**Note:** The response object shown here might be shortened for readability.
<!-- {
  "blockType": "response",
  "truncated": true,
  "@odata.type": "microsoft.graph.accessReviewScheduleDefinition",
  "isCollection": "true"
} -->
```http
HTTP/1.1 200 OK
Content-type: application/json

{
    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#identityGovernance/accessReviews/definitions",
    "@odata.count": 1,
    "value": [
        {
            "id": "cc701697-762c-439a-81f5-f58d680fde76",
            "displayName": "Review guest access across Microsoft 365 groups",
            "status": "InProgress",
            "scope": {
                "@odata.type": "#microsoft.graph.accessReviewQueryScope",
                "query": "./members/microsoft.graph.user/?$count=true&$filter=(userType eq 'Guest')",
                "queryType": "MicrosoftGraph"
            },
            "instanceEnumerationScope": {
                "@odata.type": "#microsoft.graph.accessReviewQueryScope",
                "query": "/groups?$filter=(groupTypes/any(c:c+eq+'Unified'))&$count=true",
                "queryType": "MicrosoftGraph"
            },
            "reviewers": [
                {
                    "query": "./manager",
                    "queryType": "MicrosoftGraph",
                    "queryRoot": "decisions"
                }
            ],
            "settings": {
                "mailNotificationsEnabled": true,
                "reminderNotificationsEnabled": true,
                "justificationRequiredOnApproval": true,
                "defaultDecisionEnabled": true,
                "defaultDecision": "Recommendation",
                "instanceDurationInDays": 25,
                "autoApplyDecisionsEnabled": true,
                "recommendationsEnabled": true,
                "recurrence": {
                    "pattern": {
                        "type": "absoluteMonthly",
                        "interval": 3,
                        "month": 0,
                        "dayOfMonth": 0,
                        "daysOfWeek": [],
                        "firstDayOfWeek": "sunday",
                        "index": "first"
                    },
                    "range": {
                        "type": "numbered",
                        "numberOfOccurrences": 0,
                        "recurrenceTimeZone": null,
                        "startDate": "2021-04-27",
                        "endDate": "9999-12-31"
                    }
                },
                "applyActions": [
                    {
                        "@odata.type": "#microsoft.graph.removeAccessApplyAction"
                    }
                ]
            },
            "instances": []
        }
    ]
}

```
