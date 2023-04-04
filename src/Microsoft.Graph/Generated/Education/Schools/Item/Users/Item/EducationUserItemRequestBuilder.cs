using Microsoft.Graph.Education.Schools.Item.Users.Item.Ref;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace Microsoft.Graph.Education.Schools.Item.Users.Item {
    /// <summary>
    /// Builds and executes requests for operations under \education\schools\{educationSchool-id}\users\{educationUser-id}
    /// </summary>
    public class EducationUserItemRequestBuilder : BaseRequestBuilder {
        /// <summary>Provides operations to manage the collection of educationRoot entities.</summary>
        public RefRequestBuilder Ref { get =>
            new RefRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new EducationUserItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public EducationUserItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/education/schools/{educationSchool%2Did}/users/{educationUser%2Did}", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new EducationUserItemRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public EducationUserItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/education/schools/{educationSchool%2Did}/users/{educationUser%2Did}", rawUrl) {
        }
    }
}
