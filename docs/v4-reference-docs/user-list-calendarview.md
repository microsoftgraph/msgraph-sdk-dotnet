---
title: "List calendarView"
description: "Get the occurrences, exceptions, and single instances of events in a calendar view defined by a time range, from the user's default calendar, "
ms.localizationpriority: high
doc_type: apiPageType
author: "iamgirishck"
ms.prod: "outlook"
---

# List calendarView

Namespace: microsoft.graph

Get the occurrences, exceptions, and single instances of events in a calendar view defined by a time range, from the user's default calendar,
or from some other calendar of the user's.
## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Calendars.Read, Calendars.ReadWrite    |
|Delegated (personal Microsoft account) | Calendars.Read, Calendars.ReadWrite    |
|Application | Calendars.Read, Calendars.ReadWrite |

## HTTP request

A user's default [calendar](../resources/calendar.md).
<!-- { "blockType": "ignored" } -->
```http
GET /me/calendar/calendarView?startDateTime={start_datetime}&endDateTime={end_datetime}
GET /users/{id | userPrincipalName}/calendarView?startDateTime={start_datetime}&endDateTime={end_datetime}
```

A user's [calendar](../resources/calendar.md) in the default [calendarGroup](../resources/calendargroup.md).
<!-- { "blockType": "ignored" } -->
```http
GET /me/calendars/{id}/calendarView?startDateTime={start_datetime}&endDateTime={end_datetime}
GET /users/{id | userPrincipalName}/calendars/{id}/calendarView?startDateTime={start_datetime}&endDateTime={end_datetime}
```

A user's [calendar](../resources/calendar.md) in a specific [calendarGroup](../resources/calendargroup.md).
<!-- { "blockType": "ignored" } -->
```http
GET /me/calendarGroups/{id}/calendars/{id}/calendarView?startDateTime={start_datetime}&endDateTime={end_datetime}
GET /users/{id | userPrincipalName}/calendarGroups/{id}/calendars/{id}/calendarView?startDateTime={start_datetime}&endDateTime={end_datetime}
```

## Query parameters

In the request URL, provide the following required query parameters with values.

| Parameter     | Type   | Description                                                                                                            |
|:--------------|:-------|:-----------------------------------------------------------------------------------------------------------------------|
| startDateTime | String | The start date and time of the time range, represented in ISO 8601 format. For example, "2019-11-08T19:00:00-08:00". |
| endDateTime   | String | The end date and time of the time range, represented in ISO 8601 format. For example, "2019-11-08T20:00:00-08:00".   |

The values of `startDateTime` and `endDateTime` are interpreted using the timezone offset specified in the value and are not impacted by the value of the `Prefer: outlook.timezone` header if present. If no timezone offset is included in the value, it is interpreted as UTC.

This method also supports some of the [OData Query Parameters](/graph/query-parameters) to help customize the response.

> [!NOTE]
> The **createdDateTime** and **lastModifiedDateTime** properties of [event](../resources/event.md) do not support `$select`. To get their values, simply query on **calendarView** without applying `$select`.

## Request headers
| Name       | Type | Description |
|:---------------|:--------|:--------|
| Authorization  | string | Bearer {token}. Required.  |
| Prefer: outlook.timezone  | string | Use this to specify the time zone for start and end times in the response. If not specified, those time values are returned in UTC. Optional. |
| Prefer: outlook.body-content-type | string | The format of the **body** property to be returned in. Values can be "text" or "html". A `Preference-Applied` header is returned as confirmation if this `Prefer` header is specified. If the header is not specified, the **body** property is returned in HTML format. Optional. |

## Request body
Do not supply a request body for this method.

## Response

If successful, this method returns a `200 OK` response code and collection of [event](../resources/event.md) objects in the response body.
## Example
##### Request
Here is an example of the request.

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "user_get_calendarview"
}-->
```msgraph-interactive
GET https://graph.microsoft.com/v1.0/me/calendarView?startDateTime=2020-01-01T19:00:00-08:00&endDateTime=2020-01-02T19:00:00-08:00
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var queryOptions = new List<QueryOption>()
{
	new QueryOption("startDateTime", "2020-01-01T19:00:00-08:00"),
	new QueryOption("endDateTime", "2020-01-02T19:00:00-08:00")
};

var calendarView = await graphClient.Me.CalendarView
	.Request( queryOptions )
	.GetAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

