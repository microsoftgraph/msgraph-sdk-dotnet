using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Graph
{
    /// <summary>
    /// Helper class to extract $select parameters from strongly-typed expressions.
    /// </summary>
    public static class ExtractSelectHelper
    {
        /// <summary>
        /// Extract referenced memebers of the type T from the given expression as a list of strings to pass to the $select operator
        /// </summary>
        /// <param name="selectExpression">The expression to search</param>
        /// <returns>A list of strings or null</returns>
        public static string ExtractMembers<T>(Expression<Func<T, object>> selectExpression)
        {
            if (selectExpression == null)
            {
                throw new ArgumentNullException(nameof(selectExpression));
            }

            // Search s => s.Foo
            MemberExpression memberExpression = selectExpression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            
            // Search s => new { Foo = s.Foo, bar = s.Bar }
            NewExpression newExpression  = selectExpression.Body as NewExpression;
            if (newExpression != null)
            {
                // Search only for direct members of the lambda's parameter
                var members = from m in newExpression.Arguments.OfType<MemberExpression>()
                    where m.Expression is ParameterExpression && m.Member.DeclaringType == typeof (T)
                    select m.Member.Name;
                return string.Join(",", members);
            }

            return null;
        }
    }
}