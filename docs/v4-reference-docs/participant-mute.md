---
title: "participant: mute"
description: "Mute a specific participant in the call."
author: "mkhribech"
ms.localizationpriority: medium
ms.prod: "cloud-communications"
doc_type: apiPageType
---

# participant: mute

Namespace: microsoft.graph

Mute a specific participant in the call.

This is a server mute, meaning that the server will drop all audio packets for this participant, even if the participant continues to stream audio.

For more information about how to handle mute operations, see [muteParticipantOperation](../resources/muteParticipantoperation.md).

> **Note:** This method is only supported for group calls.

## Permissions

| Permission type | Permissions (from least to most privileged) |
| :-------------- | :------------------------------------------ |
| Delegated (work or school account)     | Not Supported        |
| Delegated (personal Microsoft account) | Not Supported        |
| Application     | Calls.JoinGroupCallsasGuest.All or Calls.JoinGroupCalls.All |

## HTTP request
<!-- { "blockType": "ignored" } -->
```http
POST /communications/calls/{id}/participants/{id}/mute
```

## Request headers
| Name          | Description               |
|:--------------|:--------------------------|
| Authorization | Bearer {token}. Required. |
| Content-type  | application/json. Required.|

## Request body
In the request body, provide a JSON object with the following parameters.

| Parameter      | Type    |Description|
|:---------------|:--------|:----------|
|clientContext|String|Unique Client Context string. Max limit is 256 chars.|

## Response
If successful, this method returns a `200 OK` response code and a [muteParticipantOperation](../resources/muteParticipantoperation.md) object in the response body.

>**Note:** When this API returns a successful response, all participants will receive a roster update.

## Example - Mute specific participant
The following example shows how to call this API.

##### Request
The following example shows the request.

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "name": "participant-mute"
}-->
```http
POST https://graph.microsoft.com/v1.0/communications/calls/57dab8b1-894c-409a-b240-bd8beae78896/participants/2765eb15-01f8-47c6-b12b-c32111a4a86f/mute
Content-Type: application/json

{
  "clientContext": "d45324c1-fcb5-430a-902c-f20af696537c"
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var clientContext = "d45324c1-fcb5-430a-902c-f20af696537c";

await graphClient.Communications.Calls["{call-id}"].Participants["{participant-id}"]
	.Mute(clientContext)
	.Request()
	.PostAsync();

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

