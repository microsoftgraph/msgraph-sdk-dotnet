---
title: "user: findMeetingTimes"
description: "Suggest meeting times and locations based on organizer and attendee availability, and time or location constraints specified as parameters."
ms.localizationpriority: high
author: "vrod9429"
ms.prod: "outlook"
doc_type: apiPageType
---

# user: findMeetingTimes

Namespace: microsoft.graph

Suggest meeting times and locations based on organizer and attendee availability, and time or location constraints specified as parameters.

If **findMeetingTimes** cannot return any meeting suggestions, the response would indicate a reason in the **emptySuggestionsReason** property. 
Based on this value, you can better adjust the parameters and call **findMeetingTimes** again.

The algorithm used to suggest meeting times and locations undergoes fine-tuning from time to time. In scenarios like test environments where the input parameters and calendar data remain static, expect that the suggested results may differ over time.


## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Calendars.Read.Shared, Calendars.ReadWrite.Shared    |
|Delegated (personal Microsoft account) | Not supported.    |
|Application | Not supported. |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
POST /me/findMeetingTimes
POST /users/{id|userPrincipalName}/findMeetingTimes
```
## Request headers
| Name       | Value|
|:---------------|:----------|
| Authorization  | Bearer {token}. Required. |
| Prefer: outlook.timezone | A string representing a specific time zone for the response, for example, "Pacific Standard Time". Optional. UTC is used if this header is not specified.|

## Request body
All the supported parameters are listed below. Depending on your scenario, specify a JSON object for each of the necessary parameters in the request body. 


| Parameter	   | Type	|Description|
|:---------------|:--------|:----------|
|attendees|[attendeeBase](../resources/attendeebase.md) collection|A collection of attendees or resources for the meeting. Since findMeetingTimes assumes that any attendee who is a person is always required, specify `required` for a person and `resource` for a resource in the corresponding **type** property. An empty collection causes **findMeetingTimes** to look for free time slots for only the organizer. Optional.|
|isOrganizerOptional|Edm.Boolean|Specify `True` if the organizer doesn't necessarily have to attend. The default is `false`. Optional.|
|locationConstraint|[locationConstraint](../resources/locationconstraint.md)|The organizer's requirements about the meeting location, such as whether a suggestion for a meeting location is required, or there are specific locations only where the meeting can take place. Optional.|
|maxCandidates|Edm.Int32|The maximum number of meeting time suggestions to be returned. Optional.|
|meetingDuration|Edm.Duration|The length of the meeting, denoted in [ISO8601](https://www.iso.org/iso/iso8601) format. For example, 1 hour is denoted as 'PT1H', where 'P' is the duration designator, 'T' is the time designator, and 'H' is the hour designator. Use M to indicate minutes for the duration; for example, 2 hours and 30 minutes would be 'PT2H30M'. If no meeting duration is specified, **findMeetingTimes** uses the default of 30 minutes. Optional.|
|minimumAttendeePercentage|Edm.Double| The minimum required [confidence](#the-confidence-of-a-meeting-suggestion) for a time slot to be returned in the response. It is a % value ranging from 0 to 100. Optional.|
|returnSuggestionReasons|Edm.Boolean|Specify `True` to return a reason for each meeting suggestion in the **suggestionReason** property. The default is `false` to not return that property. Optional.|
|timeConstraint|[timeConstraint](../resources/timeconstraint.md)|Any time restrictions for a meeting, which can include the nature of the meeting (**activityDomain** property) and possible meeting time periods (**timeSlots** property). **findMeetingTimes** assumes **activityDomain** as `work` if you don't specify this parameter. Optional.|

The following table describes the **activityDomain** restrictions you can further specify in the **timeConstraint** parameter.

|activityDomain value|Suggestions for meeting times|
|:-----|:-----|
|work| Suggestions are within the user's work hours which are defined in the user’s calendar configuration and can be customized by the user or administrator. The default work hours are Monday to Friday, 8am to 5pm in the time zone set for the mailbox. This is the default value if no **activityDomain** is specified. |
|personal| Suggestions are within the user's work hours, and Saturday and Sunday. The default is Monday to Sunday, 8am to 5pm, in the time zone setting for the mailbox.|
|unrestricted | Suggestions can be from all hours of a day, all days of a week.|
|unknown | Do not use this value as it will be deprecated in the future. Currently behaves the same as `work`. Change any existing code to use `work`, `personal` or `unrestricted` as appropriate.


Based on the specified parameters,**findMeetingTimes** checks the free/busy status in the primary calendars of the organizer and attendees. The action 
calculates the best possible meeting times, and returns any meeting suggestions.

## Response

If successful, this method returns `200 OK` response code and a [meetingTimeSuggestionsResult](../resources/meetingtimesuggestionsresult.md) in the response body. 

A **meetingTimeSuggestionsResult** includes a collection of meeting suggestions and an **emptySuggestionsReason** property. Each suggestion is defined 
as a [meetingTimeSuggestion](../resources/meetingtimesuggestion.md), with attendees having on the average a confidence level of 50% to attend, 
or a specific % that you have specified in the **minimumAttendeePercentage** parameter. 

By default, each meeting time suggestion is returned in UTC. 

If **findMeetingTimes** cannot return any meeting suggestions, the response would indicate a reason in the **emptySuggestionsReason** property. 
Based on this value, you can better adjust the parameters and call **findMeetingTimes** again.

### The confidence of a meeting suggestion

The **confidence** property of a **meetingTimeSuggestion** ranges from 0% to 100%, and represents the chance that all the attendees attend the meeting, 
based on each of their individual free/busy status:

- For each attendee, a free status for a specified meeting time period corresponds to 100% chance of attendance, unknown status 49%, and busy status 0%.
- The confidence of a meeting time suggestion is computed by averaging the chance of attendance over all the attendees specified for that meeting.
- You can use the **minimumAttendeePercentage** optional parameter for **findMeetingTimes** to specify only meeting time suggestions of at least 
certain confidence level should be returned. For example, you can specify a **minimumAttendeePercentage** of 80% if you want only 
suggestions that have an 80% chance or more that all the attendees are attending. If you do not specify **minimumAttendeePercentage**, 
**findMeetingTimes** assumes a value of 50%.
- If there are multiple meeting time suggestions, the **findMeetingTimes** action first orders the suggestions by their computed confidence value from 
high to low. If there are suggestions with the same confidence, the action then orders these suggestions chronologically.

As an example, if a meeting time suggestion involves 3 attendees with the following free/busy status:

|**Attendee**|**Free/busy status**|**% Chance of attendance**|
|:-----|:-----|:-----|
|Dana | Free | 100% |
|John | Unknown | 49% |
|Samantha | Busy | 0% |

Then the confidence of the meeting time suggestion, which is the average chance of attendance, is (100% + 49% + 0%)/3 = 49.66%.

If you specify a **minimumAttendeePercentage** of 80% in a **findMeetingTimes** operation, because 49.66% < 80%, the operation will not suggest this time in the response.

## Example

The following example shows how to find time to meet at a pre-determined location, and request a reason for each suggestion, by specifying the following parameters in the request body:

- **attendees**
- **locationConstraint**
- **timeConstraint**
- **isOrganizerOptional**
- **meetingDuration**
- **returnSuggestionReasons**
- **minimumAttendeePercentage**

By setting the **returnSuggestionReasons** parameter, you also get an explanation in the **suggestionReason** property for each suggestion, if **findMeetingTimes** returns any suggestion.

Notice that the request specifies time in the PST time zone. By default, the response returns meeting time suggestions in UTC. You can use the `Prefer: outlook.timezone` request header to specify PST as well for the time values in the response.

##### Request
Here is the example request.

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "user_findmeetingtimes"
}-->
```http
POST https://graph.microsoft.com/v1.0/me/findMeetingTimes
Prefer: outlook.timezone="Pacific Standard Time"
Content-Type: application/json

{ 
  "attendees": [ 
    { 
      "type": "required",  
      "emailAddress": { 
        "name": "Alex Wilbur",
        "address": "alexw@contoso.onmicrosoft.com" 
      } 
    }
  ],  
  "locationConstraint": { 
    "isRequired": false,  
    "suggestLocation": false,  
    "locations": [ 
      { 
        "resolveAvailability": false,
        "displayName": "Conf room Hood" 
      } 
    ] 
  },  
  "timeConstraint": {
    "activityDomain":"work", 
    "timeSlots": [ 
      { 
        "start": { 
          "dateTime": "2019-04-16T09:00:00",  
          "timeZone": "Pacific Standard Time" 
        },  
        "end": { 
          "dateTime": "2019-04-18T17:00:00",  
          "timeZone": "Pacific Standard Time" 
        } 
      } 
    ] 
  },  
  "isOrganizerOptional": "false",
  "meetingDuration": "PT1H",
  "returnSuggestionReasons": "true",
  "minimumAttendeePercentage": "100"
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var attendees = new List<AttendeeBase>()
{
	new AttendeeBase
	{
		Type = AttendeeType.Required,
		EmailAddress = new EmailAddress
		{
			Name = "Alex Wilbur",
			Address = "alexw@contoso.onmicrosoft.com"
		}
	}
};

var locationConstraint = new LocationConstraint
{
	IsRequired = false,
	SuggestLocation = false,
	Locations = new List<LocationConstraintItem>()
	{
		new LocationConstraintItem
		{
			ResolveAvailability = false,
			DisplayName = "Conf room Hood"
		}
	}
};

var timeConstraint = new TimeConstraint
{
	ActivityDomain = ActivityDomain.Work,
	TimeSlots = new List<TimeSlot>()
	{
		new TimeSlot
		{
			Start = new DateTimeTimeZone
			{
				DateTime = "2019-04-16T09:00:00",
				TimeZone = "Pacific Standard Time"
			},
			End = new DateTimeTimeZone
			{
				DateTime = "2019-04-18T17:00:00",
				TimeZone = "Pacific Standard Time"
			}
		}
	}
};

var isOrganizerOptional = false;

var meetingDuration = new Duration("PT1H");

var returnSuggestionReasons = true;

var minimumAttendeePercentage = (double)100;

await graphClient.Me
	.FindMeetingTimes(attendees,locationConstraint,timeConstraint,meetingDuration,null,isOrganizerOptional,returnSuggestionReasons,minimumAttendeePercentage)
	.Request()
	.Header("Prefer","outlook.timezone=\"Pacific Standard Time\"")
	.PostAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

