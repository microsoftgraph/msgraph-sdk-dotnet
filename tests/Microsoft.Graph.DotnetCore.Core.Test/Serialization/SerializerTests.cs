// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph.DotnetCore.Core.Test.TestModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Serialization
{
    public class SerializerTests
    {
        private Serializer serializer;

        public SerializerTests()
        {
            this.serializer = new Serializer();
        }

        [Fact]
        public void AbstractClassDeserializationFailure()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";

            try
            {
                Assert.Throws<ServiceException>( () => this.serializer.DeserializeObject<AbstractClass>(stringToDeserialize));
            }
            catch (ServiceException exception)
            {
                Assert.True(exception.IsMatch(ErrorConstants.Codes.GeneralException));
                Assert.Equal(
                    string.Format(ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString, typeof(AbstractClass).FullName),
                    exception.Error.Message);

                throw;
            }
        }

        [Fact]
        public void DeserializeDerivedType()
        {
            var id = "id";
            var name = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"#microsoft.graph.dotnetCore.core.test.testModels.derivedTypeClass\", \"name\":\"{1}\"}}",
                id,
                name);

            var derivedType = this.serializer.DeserializeObject<AbstractEntityType>(stringToDeserialize) as DerivedTypeClass;

            Assert.NotNull(derivedType);
            Assert.Equal(id, derivedType.Id);
            Assert.Equal(name, derivedType.Name);
        }

        [Fact]
        public void DeserializeInvalidODataType()
        {
            var id = "id";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"invalid\", \"givenName\":\"{1}\"}}",
                id,
                givenName);

            var instance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.NotNull(instance);
            Assert.Equal(id, instance.Id);
            Assert.NotNull(instance.AdditionalData);
            Assert.Equal(givenName, instance.AdditionalData["givenName"] as string);
        }

        [Fact]
        public void DeserializeStream()
        {
            var id = "id";

            var stringToDeserialize = string.Format("{{\"id\":\"{0}\"}}", id);

            using (var serializedStream = new MemoryStream(Encoding.UTF8.GetBytes(stringToDeserialize)))
            {
                var instance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedStream);

                Assert.NotNull(instance);
                Assert.Equal(id, instance.Id);
                Assert.Null(instance.AdditionalData);
            }
        }

        [Fact]
        public void DeserializeUnknownEnumValue()
        {
            var enumValue = "newValue";
            var id = "id";

            var stringToDeserialize = string.Format(
                "{{\"enumType\":\"{0}\",\"id\":\"{1}\"}}",
                enumValue,
                id);

            var instance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.NotNull(instance);
            Assert.Equal(id, instance.Id);
            Assert.Null(instance.EnumType);
            Assert.NotNull(instance.AdditionalData);
            Assert.Equal(enumValue, instance.AdditionalData["enumType"] as string);
        }

        [Fact]
        public void DerivedTypeWithoutDefaultConstructor()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";

            try
            {
                Assert.Throws<ServiceException>(() => this.serializer.DeserializeObject<NoDefaultConstructor>(stringToDeserialize));
            }
            catch (ServiceException exception)
            {
                Assert.True(exception.IsMatch(ErrorConstants.Codes.GeneralException));
                Assert.Equal(
                    string.Format(
                        ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString,
                        typeof(NoDefaultConstructor).AssemblyQualifiedName),
                    exception.Error.Message);

                throw;
            }
        }

        [Fact]
        public void DeserializeDateEnumerableValue()
        {
            var now = DateTimeOffset.UtcNow;
            var tomorrow = now.AddDays(1);

            var stringToDeserialize = string.Format("{{\"dateCollection\":[\"{0}\",\"{1}\"]}}", now.ToString("yyyy-MM-dd"), tomorrow.ToString("yyyy-MM-dd"));

            var deserializedObject = this.serializer.DeserializeObject<DateTestClass>(stringToDeserialize);

            Assert.Equal(2, deserializedObject.DateCollection.Count());
            Assert.True(deserializedObject.DateCollection.Any(
                 date =>
                    date.Year == now.Year &&
                    date.Month == now.Month &&
                    date.Day == now.Day),
                "Now date not found.");

            Assert.True(deserializedObject.DateCollection.Any(
                date =>
                    date.Year == tomorrow.Year &&
                    date.Month == tomorrow.Month &&
                    date.Day == tomorrow.Day));
        }

        [Fact]
        public void DeserializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var stringToDeserialize = string.Format("{{\"nullableDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var dateClass = this.serializer.DeserializeObject<DateTestClass>(stringToDeserialize);

            Assert.Equal(now.Year, dateClass.NullableDate.Year);
            Assert.Equal(now.Month, dateClass.NullableDate.Month);
            Assert.Equal(now.Day, dateClass.NullableDate.Day);
        }

        [Fact]
        public void DeserializeInterface()
        {
            var collectionPage = new CollectionPageInstance
            {
                new DerivedTypeClass { Id = "id" }
            };

            var serializedString = this.serializer.SerializeObject(collectionPage);

            var deserializedPage = this.serializer.DeserializeObject<ICollectionPageInstance>(serializedString);
            Assert.IsType(typeof(CollectionPageInstance), deserializedPage);
            Assert.Equal(1, deserializedPage.Count);
            Assert.Equal("id", deserializedPage[0].Id);
        }

        [Fact]
        public void DeserializeInvalidTypeForDateConverter()
        {
            var stringToDeserialize = "{\"invalidType\":1}";

            try
            {
                 Assert.Throws<ServiceException>(() => this.serializer.DeserializeObject<DateTestClass>(stringToDeserialize));
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(ErrorConstants.Codes.GeneralException));
                Assert.Equal(ErrorConstants.Messages.UnableToDeserializeDate, serviceException.Error.Message);
                Assert.IsType(typeof(JsonSerializationException), serviceException.InnerException);

                throw;
            }
        }

        [Fact]
        public void NewAbstractDerivedClassInstance()
        {
            var entityId = "entityId";
            var additionalKey = "key";
            var additionalValue = "value";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"newtype\", \"{1}\":\"{2}\"}}",
                entityId,
                additionalKey,
                additionalValue);

            var instance = this.serializer.DeserializeObject<AbstractEntityType>(stringToDeserialize);

            Assert.NotNull(instance);
            Assert.Equal(entityId, instance.Id);
            Assert.NotNull(instance.AdditionalData);
            Assert.Equal(additionalValue, instance.AdditionalData[additionalKey] as string);
        }

        [Fact]
        public void SerializeAndDeserializeKnownEnumValue()
        {
            var instance = new DerivedTypeClass
            {
                Id = "id",
                EnumType = EnumType.Value,
            };

            var expectedSerializedStream = string.Format(
                "{{\"enumType\":\"{0}\",\"id\":\"{1}\"}}",
                "value",
                instance.Id);

            var serializedValue = this.serializer.SerializeObject(instance);

            Assert.Equal(expectedSerializedStream, serializedValue);

            var newInstance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedValue);

            Assert.NotNull(newInstance);
            Assert.Equal(instance.Id, instance.Id);
            Assert.Equal(EnumType.Value, instance.EnumType);
            Assert.Null(instance.AdditionalData);
        }

        [Fact]
        public void SerializeDateEnumerableValue()
        {
            var now = DateTimeOffset.UtcNow;
            var tomorrow = now.AddDays(1);

            var expectedSerializedString = string.Format("{{\"nullableDate\":null,\"dateCollection\":[\"{0}\",\"{1}\"]}}", now.ToString("yyyy-MM-dd"), tomorrow.ToString("yyyy-MM-dd"));

            var recurrence = new DateTestClass
            {
                DateCollection = new List<Date> { new Date(now.Year, now.Month, now.Day), new Date(tomorrow.Year, tomorrow.Month, tomorrow.Day) },
            };

            var serializedString = this.serializer.SerializeObject(recurrence);

            Assert.Equal(expectedSerializedString, serializedString);
        }

        [Fact]
        public void SerializeDateNullValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = "{\"nullableDate\":null}";

            var recurrence = new DateTestClass();

            var serializedString = this.serializer.SerializeObject(recurrence);

            Assert.Equal(expectedSerializedString, serializedString);
        }

        [Fact]
        public void SerializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = string.Format("{{\"nullableDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var date = new DateTestClass
            {
                NullableDate = new Date(now.Year, now.Month, now.Day),
            };

            var serializedString = this.serializer.SerializeObject(date);

            Assert.Equal(expectedSerializedString, serializedString);
        }

        [Fact]
        public void SerializeInvalidTypeForDateConverter()
        {
            var dateToSerialize = new DateTestClass
            {
                InvalidType = 1,
            };

            try
            {
                Assert.Throws<ServiceException>(() => this.serializer.SerializeObject(dateToSerialize));
            }
            catch (ServiceException serviceException)
            {
                Assert.True(serviceException.IsMatch(ErrorConstants.Codes.GeneralException));
                Assert.Equal(
                    ErrorConstants.Messages.InvalidTypeForDateConverter,
                    serviceException.Error.Message);

                throw;
            }
        }

        [Fact]
        public void VerifyTypeMappingCache()
        {
            // Clear the cache so it won't have mappings from previous tests.
            DerivedTypeConverter.TypeMappingCache.Clear();

            var id = "id";
            var derivedTypeClassTypeString = "microsoft.graph.dotnetCore.core.test.testModels.derivedTypeClass";
            var dateTestClassTypeString = "microsoft.graph.dotnetCore.core.test.testModels.dateTestClass";

            var deserializeExistingTypeString = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"#{1}\"}}",
                id,
                derivedTypeClassTypeString);

            var derivedType = this.serializer.DeserializeObject<AbstractEntityType>(deserializeExistingTypeString) as DerivedTypeClass;
            var derivedType2 = this.serializer.DeserializeObject<DerivedTypeClass>(deserializeExistingTypeString) as DerivedTypeClass;

            var deserializeUnknownTypeString = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"#unknown\"}}",
                id);

            var upcastType = this.serializer.DeserializeObject<DerivedTypeClass>(deserializeUnknownTypeString) as DerivedTypeClass;

            var dateTestTypeString = string.Format(
                "{{\"@odata.type\":\"#{1}\"}}",
                id,
                dateTestClassTypeString);

            var dateTestType = this.serializer.DeserializeObject<DateTestClass>(dateTestTypeString) as DateTestClass;

            Assert.NotNull(derivedType);
            Assert.NotNull(derivedType2);
            Assert.NotNull(upcastType);
            Assert.NotNull(dateTestType);

            Assert.Equal(3, DerivedTypeConverter.TypeMappingCache.Count);

            Assert.Equal(
                typeof(DerivedTypeClass),
                DerivedTypeConverter.TypeMappingCache[derivedTypeClassTypeString]);

            Assert.Equal(
                typeof(DerivedTypeClass),
                DerivedTypeConverter.TypeMappingCache["unknown"]);

            Assert.Equal(
                typeof(DateTestClass),
                DerivedTypeConverter.TypeMappingCache[dateTestClassTypeString]);
        }

        [Fact]
        public void SerializeDeserializeJson()
        {
            var expectedSerializedString = "{\"data\":{\"int\":42,\"float\":3.14,\"str\":\"dude\",\"bool\":true,\"null\":null,\"arr\":[\"sweet\",2.82,43,false]}}";

            JArray arr = new JArray();
            arr.Add("sweet");
            arr.Add(2.82);
            arr.Add(43);
            arr.Add(false);

            JObject obj = new JObject();
            obj["int"] = 42;
            obj["float"] = 3.14;
            obj["str"] = "dude";
            obj["bool"] = true;
            obj["null"] = null;
            obj["arr"] = arr;

            ClassWithJson jsCls = new ClassWithJson();
            jsCls.Data = obj;

            var s = this.serializer.SerializeObject(jsCls);
            Assert.Equal(s, expectedSerializedString);

            var parsedObj = this.serializer.DeserializeObject<ClassWithJson>(s);
            var jsObj = parsedObj.Data;

            Assert.Equal(jsObj.Type, JTokenType.Object);
            Assert.Equal(jsObj["int"].Type, JTokenType.Integer);
            Assert.Equal(jsObj["float"].Type, JTokenType.Float);
            Assert.Equal(jsObj["str"].Type, JTokenType.String);
            Assert.Equal(jsObj["bool"].Type, JTokenType.Boolean);
            Assert.Equal(jsObj["null"].Type, JTokenType.Null);
            Assert.Equal(jsObj["arr"].Type, JTokenType.Array);

            Assert.Equal(jsObj["int"], 42);
            Assert.Equal(jsObj["float"], 3.14);
            Assert.Equal(jsObj["str"], "dude");
            Assert.Equal(jsObj["bool"], true);
            Assert.Equal((jsObj["null"] as JValue).Value, null);

            var jsArr = jsObj["arr"] as JArray;
            Assert.NotNull(jsArr);
            Assert.Equal(jsArr.Count, 4);
            Assert.Equal(jsArr[0].Type, JTokenType.String);
            Assert.Equal(jsArr[1].Type, JTokenType.Float);
            Assert.Equal(jsArr[2].Type, JTokenType.Integer);
            Assert.Equal(jsArr[3].Type, JTokenType.Boolean);

            Assert.Equal(jsArr[0], "sweet");
            Assert.Equal(jsArr[1], 2.82);
            Assert.Equal(jsArr[2], 43);
            Assert.Equal(jsArr[3], false);
        }
    }
}
