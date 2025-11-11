// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Graph.Models;
    using Microsoft.Kiota.Abstractions;
    using Microsoft.Kiota.Abstractions.Serialization;
    using Microsoft.Kiota.Serialization.Json;

    public class ModelSerializationTests
    {
        public ModelSerializationTests()
        {
            SerializationWriterFactoryRegistry.DefaultInstance.ContentTypeAssociatedFactories["application/json"] = new JsonSerializationWriterFactory();
            ParseNodeFactoryRegistry.DefaultInstance.ContentTypeAssociatedFactories["application/json"] = new JsonParseNodeFactory();
        }

        [Fact]
        public async Task DeserializeDerivedType()
        {
            var userId = "userId";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"microsoft.graph.user\", \"givenName\":\"{1}\"}}",
                userId,
                givenName);

            var user = await KiotaJsonSerializer.DeserializeAsync<User>(stringToDeserialize);
            
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            Assert.Equal(givenName, user.GivenName);
        }

        [Fact]
        public async Task DeserializeInvalidODataType()
        {
            var directoryObjectId = "directoryObjectId";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"invalid\", \"givenName\":\"{1}\"}}",
                directoryObjectId,
                givenName);

            var directoryObject = await KiotaJsonSerializer.DeserializeAsync<DirectoryObject>(stringToDeserialize);
            
            Assert.NotNull(directoryObject);
            Assert.Equal(directoryObjectId, directoryObject.Id);
            Assert.NotNull(directoryObject.AdditionalData);
            Assert.Equal(givenName, directoryObject.AdditionalData["givenName"].ToString());
        }

        [Fact]
        public async Task DeserializeUnknownEnumValue()
        {
            var enumValue = "newValue";
            var bodyContent = "bodyContent";

            var stringToDeserialize = string.Format(
                "{{\"contentType\":\"{1}\",\"content\":\"{0}\"}}",
                bodyContent,
                enumValue);

            var itemBody = await KiotaJsonSerializer.DeserializeAsync<ItemBody>(stringToDeserialize);

            Assert.NotNull(itemBody);
            Assert.Equal(bodyContent, itemBody.Content);
            Assert.Null(itemBody.ContentType);
            Assert.NotNull(itemBody.AdditionalData);
        }

        [Fact]
        public async Task DeserializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var stringToDeserialize = string.Format("{{\"startDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var recurrenceRange = await KiotaJsonSerializer.DeserializeAsync<RecurrenceRange>(stringToDeserialize);
            
            Assert.Equal(now.Year, recurrenceRange.StartDate.Value.Year);
            Assert.Equal(now.Month, recurrenceRange.StartDate.Value.Month);
            Assert.Equal(now.Day, recurrenceRange.StartDate.Value.Day);
        }

        [Fact]
        public async Task NewAbstractEntityDerivedClassInstance()
        {
            var entityId = "entityId";
            var additionalKey = "key";
            var additionalValue = "value";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"newentity\", \"{1}\":\"{2}\"}}",
                entityId,
                additionalKey,
                additionalValue);

            var entity = await KiotaJsonSerializer.DeserializeAsync<Entity>(stringToDeserialize);

            Assert.NotNull(entity);
            Assert.Equal(entityId, entity.Id);
            Assert.NotNull(entity.AdditionalData);
            Assert.Equal(additionalValue, entity.AdditionalData[additionalKey].ToString());
        }

        [Fact]
        public async Task SerializeAndDeserializeKnownEnumValue()
        {
            var itemBody = new ItemBody
            {
                OdataType = "microsoft.graph.itemBody",
                Content = "bodyContent",
                ContentType = BodyType.Text,
            };

            var expectedSerializedStream = string.Format(
                "{{\"content\":\"{0}\",\"contentType\":\"{1}\",\"@odata.type\":\"microsoft.graph.itemBody\"}}",
                itemBody.Content,
                "text");

            // Serialize=
            var serializedString = await KiotaJsonSerializer.SerializeAsStringAsync(itemBody);

            //Assert
            Assert.Equal(expectedSerializedStream, serializedString);

            // De serialize
            var newItemBody = await KiotaJsonSerializer.DeserializeAsync<ItemBody>(serializedString);

            Assert.NotNull(newItemBody);
            Assert.Equal(itemBody.Content, itemBody.Content);
            Assert.Equal(BodyType.Text, itemBody.ContentType);
            Assert.NotNull(itemBody.AdditionalData);
        }

        [Fact]
        public async Task SerializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = string.Format("{{\"startDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var recurrence = new RecurrenceRange
            {
                StartDate = new Date(now.Year, now.Month, now.Day),
            };

            var serializedString = await KiotaJsonSerializer.SerializeAsStringAsync(recurrence);

            // Assert
            Assert.Equal(expectedSerializedString, serializedString);
        }
        [Fact]
        public async Task TestEtagHelper()
        {
            var userId = "userId";
            var testEtag = "testEtag";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"microsoft.graph.user\", \"@odata.etag\":\"{1}\"}}",
                userId,
                testEtag);

            var user = await KiotaJsonSerializer.DeserializeAsync<Entity>(stringToDeserialize);
            
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            //Assert.Equal(testEtag, user.GetEtag());
        }
        [Fact]
        public async Task TestPlannerAssigmentSerialization()
        {
            var planTask = new PlannerTask
            {
                PlanId = "PLAN_ID",
                BucketId = "BUCKET_ID",
                Title = "My Planner Task",
                Assignments = new PlannerAssignments
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        {"USER_ID", new PlannerAssignment()}
                    }
                }
            };

            string expectedSerializedString = "{\"assignments\":{\"USER_ID\":{\"@odata.type\":\"#microsoft.graph.plannerAssignment\",\"orderHint\":\"!\"}},\"bucketId\":\"BUCKET_ID\",\"planId\":\"PLAN_ID\",\"title\":\"My Planner Task\"}";

            // Assert
            var serializedString = await KiotaJsonSerializer.SerializeAsStringAsync(planTask);
            Assert.Equal(expectedSerializedString, serializedString);
        }
        
        [Fact]
        public async Task TestChangeNoticationCollectionDeserialization()
        {
            var json = @"{
                ""value"": [
                    {
                        ""changeType"": ""updated"",
                        ""subscriptionId"": ""c224ac82-d3f3-4079-80ed-b6cd355e0f56"",
                        ""resource"": ""external"",
                        ""clientState"": null,
                        ""resourceData"": {
                            ""@odata.type"": ""#Microsoft.Graph.connector"",
                            ""@odata.id"": ""external"",
                            ""id"": ""cf6c33ae-e462-41c8-928b-88a8dd410f23"",
                            ""state"": ""enabled"",
                            ""connectorsTicket"": ""eyJhbGciOiJIU...""
                        },
                        ""subscriptionExpirationDateTime"": ""2023-09-20T20:39:46.8577199+00:00"",
                        ""tenantId"": ""cf6c33ae-e462-41c8-928b-88a8dd410f23""
                    }
                ],
                ""validationTokens"": [
                    ""eyJ0eXAiOiJKV1...""
                ]
            }";
            
            var changeNotifications = await KiotaJsonSerializer.DeserializeAsync<ChangeNotificationCollection>(json, CancellationToken.None);
            
            Assert.NotNull(changeNotifications.Value);
            Assert.Single(changeNotifications.Value);
            Assert.NotNull(changeNotifications.ValidationTokens);
            Assert.Single(changeNotifications.ValidationTokens);
        }
    }
}
