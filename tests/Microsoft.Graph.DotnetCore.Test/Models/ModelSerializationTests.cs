// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Models
{
    public class ModelSerializationTests
    {
        private Serializer serializer;

        public ModelSerializationTests()
        {
            this.serializer = new Serializer();
        }

        [Fact]
        public void DeserializeDerivedType()
        {
            var userId = "userId";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"microsoft.graph.user\", \"givenName\":\"{1}\"}}",
                userId,
                givenName);

            var user = this.serializer.DeserializeObject<DirectoryObject>(stringToDeserialize) as User;

            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
            Assert.Equal(givenName, user.GivenName);
        }

        [Fact]
        public void DeserializeInvalidODataType()
        {
            var directoryObjectId = "directoryObjectId";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"invalid\", \"givenName\":\"{1}\"}}",
                directoryObjectId,
                givenName);

            var directoryObject = this.serializer.DeserializeObject<DirectoryObject>(stringToDeserialize);

            Assert.NotNull(directoryObject);
            Assert.Equal(directoryObjectId, directoryObject.Id);
            Assert.NotNull(directoryObject.AdditionalData);
            Assert.Equal(givenName, directoryObject.AdditionalData["givenName"] as string);
        }

        [Fact]
        public void DeserializeUnknownEnumValue()
        {
            var enumValue = "newValue";
            var bodyContent = "bodyContent";

            var stringToDeserialize = string.Format(
                "{{\"contentType\":\"{1}\",\"content\":\"{0}\"}}",
                bodyContent,
                enumValue);

            var itemBody = this.serializer.DeserializeObject<ItemBody>(stringToDeserialize);

            Assert.NotNull(itemBody);
            Assert.Equal(bodyContent, itemBody.Content);
            Assert.Null(itemBody.ContentType);
            Assert.NotNull(itemBody.AdditionalData);
            Assert.Equal(enumValue, itemBody.AdditionalData["contentType"] as string);
        }

        [Fact]
        public void DeserializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var stringToDeserialize = string.Format("{{\"startDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var recurrenceRange = this.serializer.DeserializeObject<RecurrenceRange>(stringToDeserialize);

            Assert.Equal(now.Year, recurrenceRange.StartDate.Year);
            Assert.Equal(now.Month, recurrenceRange.StartDate.Month);
            Assert.Equal(now.Day, recurrenceRange.StartDate.Day);
        }

        [Fact]
        public void DeserializeInterface()
        {
            var driveItemChildrenCollectionPage = new DriveItemChildrenCollectionPage
            {
                new DriveItem { Id = "id" },
            };

            var serializedString = this.serializer.SerializeObject(driveItemChildrenCollectionPage);

            var deserializedPage = this.serializer.DeserializeObject<IDriveItemChildrenCollectionPage>(serializedString);

            Assert.IsType(typeof(DriveItemChildrenCollectionPage), deserializedPage);
            Assert.Equal(1, deserializedPage.Count);
            Assert.Equal("id", deserializedPage[0].Id);
        }

        [Fact]
        public void NewAbstractEntityDerivedClassInstance()
        {
            var entityId = "entityId";
            var additionalKey = "key";
            var additionalValue = "value";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"newentity\", \"{1}\":\"{2}\"}}",
                entityId,
                additionalKey,
                additionalValue);

            var entity = this.serializer.DeserializeObject<Entity>(stringToDeserialize);

            Assert.NotNull(entity);
            Assert.Equal(entityId, entity.Id);
            Assert.NotNull(entity.AdditionalData);
            Assert.Equal(additionalValue, entity.AdditionalData[additionalKey] as string);
        }

        [Fact]
        public void SerializeAndDeserializeKnownEnumValue()
        {
            var itemBody = new ItemBody
            {
                Content = "bodyContent",
                ContentType = BodyType.Text,
            };

            var expectedSerializedStream = string.Format(
                "{{\"contentType\":\"{1}\",\"content\":\"{0}\"}}",
                itemBody.Content,
                "text");

            var serializedValue = this.serializer.SerializeObject(itemBody);

            Assert.Equal(expectedSerializedStream, serializedValue);

            var newItemBody = this.serializer.DeserializeObject<ItemBody>(serializedValue);

            Assert.NotNull(newItemBody);
            Assert.Equal(itemBody.Content, itemBody.Content);
            Assert.Equal(BodyType.Text, itemBody.ContentType);
            Assert.Null(itemBody.AdditionalData);
        }

        [Fact]
        public void SerializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = string.Format("{{\"startDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var recurrence = new RecurrenceRange
            {
                StartDate = new Date(now.Year, now.Month, now.Day),
            };

            var serializedString = this.serializer.SerializeObject(recurrence);

            Assert.Equal(expectedSerializedString, serializedString);
        }
    }
}
