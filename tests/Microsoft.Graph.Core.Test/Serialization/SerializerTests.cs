// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core.Test.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestModels;
    using Newtonsoft.Json;

    [TestClass]
    public class SerializerTests
    {
        private Serializer serializer;

        [TestInitialize]
        public void Setup()
        {
            this.serializer = new Serializer();
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void AbstractClassDeserializationFailure()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";

            try
            {
                this.serializer.DeserializeObject<AbstractClass>(stringToDeserialize);
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.IsMatch(ErrorConstants.Codes.GeneralException), "Unexpected error code thrown.");
                Assert.AreEqual(
                    string.Format(ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString, typeof(AbstractClass).FullName),
                    exception.Error.Message,
                    "Unexpected error message thrown.");

                throw;
            }
        }

        [TestMethod]
        public void DeserializeDerivedType()
        {
            var id = "id";
            var name = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"#microsoft.graph.core.test.testModels.derivedTypeClass\", \"name\":\"{1}\"}}",
                id,
                name);

            var derivedType = this.serializer.DeserializeObject<AbstractEntityType>(stringToDeserialize) as DerivedTypeClass;

            Assert.IsNotNull(derivedType, "Object not correctly deserialized.");
            Assert.AreEqual(id, derivedType.Id, "Unexpected ID initialized.");
            Assert.AreEqual(name, derivedType.Name, "Unexpected name initialized.");
        }

        [TestMethod]
        public void DeserializeInvalidODataType()
        {
            var id = "id";
            var givenName = "name";

            var stringToDeserialize = string.Format(
                "{{\"id\":\"{0}\", \"@odata.type\":\"invalid\", \"givenName\":\"{1}\"}}",
                id,
                givenName);

            var instance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.IsNotNull(instance, "Object not correctly deserialized.");
            Assert.AreEqual(id, instance.Id, "Unexpected ID initialized.");
            Assert.IsNotNull(instance.AdditionalData, "Additional data not initialized.");
            Assert.AreEqual(givenName, instance.AdditionalData["givenName"] as string, "Unexpected additional data initialized.");
        }

        [TestMethod]
        public void DeserializeStream()
        {
            var id = "id";

            var stringToDeserialize = string.Format("{{\"id\":\"{0}\"}}", id);

            using (var serializedStream = new MemoryStream(Encoding.UTF8.GetBytes(stringToDeserialize)))
            {
                var instance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedStream);

                Assert.IsNotNull(instance, "Object not correctly deserialized.");
                Assert.AreEqual(id, instance.Id, "Unexpected ID initialized.");
                Assert.IsNull(instance.AdditionalData, "Unexpected additional data initialized.");
            }
        }

        [TestMethod]
        public void DeserializeUnknownEnumValue()
        {
            var enumValue = "newValue";
            var id = "id";

            var stringToDeserialize = string.Format(
                "{{\"enumType\":\"{0}\",\"id\":\"{1}\"}}",
                enumValue,
                id);

            var instance = this.serializer.DeserializeObject<DerivedTypeClass>(stringToDeserialize);

            Assert.IsNotNull(instance, "Object not correctly deserialized.");
            Assert.AreEqual(id, instance.Id, "Unexpected ID initialized.");
            Assert.IsNull(instance.EnumType, "Unexpected EnumType initialized.");
            Assert.IsNotNull(instance.AdditionalData, "Additional data not initialized.");
            Assert.AreEqual(enumValue, instance.AdditionalData["enumType"] as string, "EnumType not set in additional data.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void DerivedTypeWithoutDefaultConstructor()
        {
            var stringToDeserialize = "{\"jsonKey\":\"jsonValue\"}";

            try
            {
                this.serializer.DeserializeObject<NoDefaultConstructor>(stringToDeserialize);
            }
            catch (ServiceException exception)
            {
                Assert.IsTrue(exception.IsMatch(ErrorConstants.Codes.GeneralException), "Unexpected error code thrown.");
                Assert.AreEqual(
                    string.Format(
                        ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString,
                        typeof(NoDefaultConstructor).AssemblyQualifiedName),
                    exception.Error.Message,
                    "Unexpected error message thrown.");

                throw;
            }
        }

        [TestMethod]
        public void DeserializeDateEnumerableValue()
        {
            var now = DateTimeOffset.UtcNow;
            var tomorrow = now.AddDays(1);

            var stringToDeserialize = string.Format("{{\"dateCollection\":[\"{0}\",\"{1}\"]}}", now.ToString("yyyy-MM-dd"), tomorrow.ToString("yyyy-MM-dd"));

            var deserializedObject = this.serializer.DeserializeObject<DateTestClass>(stringToDeserialize);

            Assert.AreEqual(2, deserializedObject.DateCollection.Count(), "Unexpected number of dates deserialized.");
            Assert.IsTrue(deserializedObject.DateCollection.Any(
                 date =>
                    date.Year == now.Year &&
                    date.Month == now.Month &&
                    date.Day == now.Day),
                "Now date not found.");

            Assert.IsTrue(deserializedObject.DateCollection.Any(
                date =>
                    date.Year == tomorrow.Year &&
                    date.Month == tomorrow.Month &&
                    date.Day == tomorrow.Day),
                "Tomorrow date not found.");
        }

        [TestMethod]
        public void DeserializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var stringToDeserialize = string.Format("{{\"nullableDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var dateClass = this.serializer.DeserializeObject<DateTestClass>(stringToDeserialize);
            
            Assert.AreEqual(now.Year, dateClass.NullableDate.Year, "Unexpected nullableDate year deserialized.");
            Assert.AreEqual(now.Month, dateClass.NullableDate.Month, "Unexpected nullableDate month deserialized.");
            Assert.AreEqual(now.Day, dateClass.NullableDate.Day, "Unexpected nullableDate day deserialized.");
        }

        [TestMethod]
        public void DeserializeInterface()
        {
            var collectionPage = new CollectionPageInstance
            {
                new DerivedTypeClass { Id = "id" }
            };

            var serializedString = this.serializer.SerializeObject(collectionPage);

            var deserializedPage = this.serializer.DeserializeObject<ICollectionPageInstance>(serializedString);

            Assert.IsInstanceOfType(deserializedPage, typeof(CollectionPageInstance), "Unexpected object deserialized.");
            Assert.AreEqual(1, deserializedPage.Count, "Unexpected page deserialized.");
            Assert.AreEqual("id", deserializedPage[0].Id, "Unexpected page item deserialized.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void DeserializeInvalidTypeForDateConverter()
        {
            var stringToDeserialize = "{\"invalidType\":1}";

            try
            {
                var date = this.serializer.DeserializeObject<DateTestClass>(stringToDeserialize);
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch(ErrorConstants.Codes.GeneralException), "Unexpected error code thrown.");
                Assert.AreEqual(ErrorConstants.Messages.UnableToDeserializeDate, serviceException.Error.Message, "Unexpected error message thrown.");
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(JsonSerializationException), "Unexpected inner exception thrown.");

                throw;
            }
        }

        [TestMethod]
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

            Assert.IsNotNull(instance, "Object not correctly deserialized.");
            Assert.AreEqual(entityId, instance.Id, "Unexpected ID initialized.");
            Assert.IsNotNull(instance.AdditionalData, "Additional data not initialized.");
            Assert.AreEqual(additionalValue, instance.AdditionalData[additionalKey] as string, "Unexpected additional data initialized.");
        }

        [TestMethod]
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

            Assert.AreEqual(expectedSerializedStream, serializedValue, "Unexpected value serialized.");

            var newInstance = this.serializer.DeserializeObject<DerivedTypeClass>(serializedValue);

            Assert.IsNotNull(newInstance, "Object not correctly deserialized.");
            Assert.AreEqual(instance.Id, instance.Id, "Unexpected ID initialized.");
            Assert.AreEqual(EnumType.Value, instance.EnumType, "Unexpected EnumType initialized.");
            Assert.IsNull(instance.AdditionalData, "Additional data initialized.");
        }

        [TestMethod]
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
            
            Assert.AreEqual(expectedSerializedString, serializedString, "Unexpected value serialized.");
        }

        [TestMethod]
        public void SerializeDateNullValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = "{\"nullableDate\":null}";

            var recurrence = new DateTestClass();

            var serializedString = this.serializer.SerializeObject(recurrence);

            Assert.AreEqual(expectedSerializedString, serializedString, "Unexpected value serialized.");
        }

        [TestMethod]
        public void SerializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = string.Format("{{\"nullableDate\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var date = new DateTestClass
            {
                NullableDate = new Date(now.Year, now.Month, now.Day),
            };

            var serializedString = this.serializer.SerializeObject(date);

            Assert.AreEqual(expectedSerializedString, serializedString, "Unexpected value serialized.");
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void SerializeInvalidTypeForDateConverter()
        {
            var dateToSerialize = new DateTestClass
            {
                InvalidType = 1,
            };

            try
            {
                var serializedString = this.serializer.SerializeObject(dateToSerialize);
            }
            catch (ServiceException serviceException)
            {
                Assert.IsTrue(serviceException.IsMatch(ErrorConstants.Codes.GeneralException), "Unexpected error code thrown.");
                Assert.AreEqual(
                    ErrorConstants.Messages.InvalidTypeForDateConverter,
                    serviceException.Error.Message,
                    "Unexpected error message thrown.");

                throw;
            }
        }

        [TestMethod]
        public void VerifyTypeMappingCache()
        {
            // Clear the cache so it won't have mappings from previous tests.
            DerivedTypeConverter.TypeMappingCache.Clear();

            var id = "id";
            var derivedTypeClassTypeString = "microsoft.graph.core.test.testModels.derivedTypeClass";
            var dateTestClassTypeString = "microsoft.graph.core.test.testModels.dateTestClass";

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

            Assert.IsNotNull(derivedType, "Unexpected instance returned for derived type instance.");
            Assert.IsNotNull(derivedType2, "Unexpected instance returned for derived type instance 2.");
            Assert.IsNotNull(upcastType, "Unexpected instance returned for up cast type.");
            Assert.IsNotNull(dateTestType, "Unexpected instance returned for date test type.");

            Assert.AreEqual(3, DerivedTypeConverter.TypeMappingCache.Count, "Unexpected number of entries in type mapping cache.");

            Assert.AreEqual(
                typeof(DerivedTypeClass),
                DerivedTypeConverter.TypeMappingCache[derivedTypeClassTypeString],
                "Unexpected type cached for {0}",
                derivedTypeClassTypeString);

            Assert.AreEqual(
                typeof(DerivedTypeClass),
                DerivedTypeConverter.TypeMappingCache["unknown"],
                "Unexpected type cached for {0}",
                derivedTypeClassTypeString);

            Assert.AreEqual(
                typeof(DateTestClass),
                DerivedTypeConverter.TypeMappingCache[dateTestClassTypeString],
                "Unexpected type cached for {0}",
                dateTestClassTypeString);
        }
    }
}
