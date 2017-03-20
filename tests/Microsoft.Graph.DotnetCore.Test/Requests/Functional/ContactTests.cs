// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    public class ContactTests : GraphTestBase
    {
        // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/singlevaluelegacyextendedproperty_post_singlevalueextendedproperties
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ContactsSetGetSingleExtendedProperty()
        {
            try
            {
                var contact = new Contact();
                contact.GivenName = "_Tom" + Guid.NewGuid().ToString();

                var customProperty = new SingleValueLegacyExtendedProperty();
                var namespaceGuid = "f5939744-0f22-4f03-b33c-f18a8acfa20b";
                var mapiPropertyType = "String";
                var propertyName = "CustomProperty";
                var propertyId = $"{mapiPropertyType} {{{namespaceGuid}}} Name {propertyName}";
                customProperty.Id = propertyId;
                customProperty.Value = "My custom property value";

                var extendedValueCollection = new ContactSingleValueExtendedPropertiesCollectionPage();
                extendedValueCollection.Add(customProperty);

                contact.SingleValueExtendedProperties = extendedValueCollection;

                // This results in a call to the service. It adds a contact with the extended property set on it.
                var partiallySyncdContact = await graphClient.Me.Contacts.Request().AddAsync(contact);

                Assert.NotNull(partiallySyncdContact.Id);

                // This results in a call to the service. It gets the contact with the extended property.
                // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/singlevaluelegacyextendedproperty_get
                var syncdContact = await graphClient.Me.Contacts[partiallySyncdContact.Id].Request().Expand($"singleValueExtendedProperties($filter=id eq '{propertyId}')").GetAsync();

                Assert.NotNull(syncdContact.SingleValueExtendedProperties);

            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }
    }
}
