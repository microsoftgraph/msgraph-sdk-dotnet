---
title: "Add attachment"
description: "Use this API to add an attachment to a message. "
author: "abheek-das"
ms.localizationpriority: medium
ms.prod: "outlook"
doc_type: apiPageType
---

# Add attachment

Namespace: microsoft.graph

Use this API to add an [attachment](../resources/attachment.md) to a message. 

An attachment can be one of the following types:

* A file ([fileAttachment](../resources/fileattachment.md) resource).
* An item (contact, event or message, represented by an [itemAttachment](../resources/itemattachment.md) resource).
* A link to a file ([referenceAttachment](../resources/referenceattachment.md) resource).

All these types of attachment resources are derived from the [attachment](../resources/attachment.md)
resource. 

You can add an attachment to an existing message by posting to its attachments collection, or you can 
add an attachment to a message that is being [created and sent on the fly](../api/user-sendmail.md).

This operation limits the size of the attachment you can add to under 3 MB.
## Permissions
One of the following permissions is required to call this API. To learn more, including how to choose permissions, see [Permissions](/graph/permissions-reference).

|Permission type      | Permissions (from least to most privileged)              |
|:--------------------|:---------------------------------------------------------|
|Delegated (work or school account) | Mail.ReadWrite    |
|Delegated (personal Microsoft account) | Mail.ReadWrite    |
|Application | Mail.ReadWrite |

## HTTP request
<!-- { "blockType": "ignored" } -->
Attachments for a [message](../resources/message.md) in a user's mailbox.
```http
POST /me/messages/{id}/attachments
POST /users/{id | userPrincipalName}/messages/{id}/attachments
```
Attachments for a [message](../resources/message.md) contained in a top level [mailFolder](../resources/mailfolder.md) in a user's mailbox.
```http
POST /me/mailFolders/{id}/messages/{id}/attachments
POST /users/{id | userPrincipalName}/mailFolders/{id}/messages/{id}/attachments
```
Attachments for a [message](../resources/message.md) contained in a child folder of a [mailFolder](../resources/mailfolder.md) in a user's mailbox.  The
example below shows one level of nesting, but a message can be located in a child of a child and so on.
```http
POST /me/mailFolders/{id}/childFolders/{id}/.../messages/{id}/attachments/{id}
POST /users/{id | userPrincipalName}/mailFolders/{id}/childFolders/{id}/messages/{id}/attachments/{id}
```
## Request headers
| Name       | Type | Description|
|:---------------|:--------|:----------|
| Authorization  | string  | Bearer {token}. Required. |
| Content-Type | string  | Nature of the data in the body of an entity. Required. |

## Request body
In the request body, supply a JSON representation of [Attachment](../resources/attachment.md) object.

## Response

If successful, this method returns `201 Created` response code and [Attachment](../resources/attachment.md) object in the response body.

## Example (file attachment)

##### Request
Here is an example of the request.

# [HTTP](#tab/http)
<!-- {
  "blockType": "request",
  "sampleKeys": ["AAMkpsDRVK"],
  "name": "create_file_attachment_from_message_v1"
}-->
```http
POST https://graph.microsoft.com/v1.0/me/messages/AAMkpsDRVK/attachments
Content-type: application/json

{
  "@odata.type": "#microsoft.graph.fileAttachment",
  "name": "smile",
  "contentBytes": "R0lGODdhEAYEAA7"
}
```

# [C#](#tab/csharp)

```csharp

GraphServiceClient graphClient = new GraphServiceClient( authProvider );

var attachment = new FileAttachment
{
	Name = "smile",
	ContentBytes = Convert.FromBase64String("R0lGODdhEAYEAA7")
};

await graphClient.Me.Messages["{message-id}"].Attachments
	.Request()
	.AddAsync(attachment);

```


 For details about how to [add the SDK](/graph/sdks/sdk-installation) to your project and [create an authProvider](/graph/sdks/choose-authentication-providers) instance, see the [SDK documentation](/graph/sdks/sdks-overview).

