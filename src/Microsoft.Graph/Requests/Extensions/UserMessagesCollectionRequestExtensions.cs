using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Graph
{
    public partial class UserMessagesCollectionRequest
    {
        public IUserMessagesCollectionRequest Search(string value)
        {
            this.QueryOptions.Add(new QueryOption("$search", value));
            return this;
        }
    }

    public partial interface IUserMessagesCollectionRequest
    {
        IUserMessagesCollectionRequest Search(string value);
    }
}
