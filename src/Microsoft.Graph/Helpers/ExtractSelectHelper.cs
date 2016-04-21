using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Graph
{
    /// <summary>
    /// Helper class to extract $select parameters from strongly-typed expressions.
    /// </summary>
    public static class ExpressionExtractHelper
    {
        /// <summary>
        /// Extract referenced members of the type T from the given expression as a list of strings
        /// </summary>
        /// <param name="expression">The expression to search</param>
        /// <param name="error">Message about what's wrong with the expression if return value is null</param>
        /// <returns>A list of strings or null</returns>
        public static string ExtractMembers<T>(Expression<Func<T, object>> expression, out string error)
        {
            error = null;
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            // Search s => s.Foo
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            
            // Search s => new { Foo = s.Foo, bar = s.Bar }
            NewExpression newExpression  = expression.Body as NewExpression;
            if (newExpression != null)
            {
                if (newExpression.Arguments == null || newExpression.Arguments.Count == 0)
                {
                    error = "Lambda expression must provide initializer for new anonymous type.";
                    return null;
                }
                if (newExpression.Arguments.Any(a =>
                {
                    var memberArgument = a as MemberExpression;
                    return memberArgument == null ||
                           !(memberArgument.Expression is ParameterExpression) ||
                           memberArgument.Member.DeclaringType != typeof (T);
                }))
                {
                    error = $"Anonymous type in lambda expression may only be initialized with direct members of {nameof(T)}";
                    return null;
                }
                if (newExpression.Arguments.Any(a =>
                {
                    var memberArgument = a as MemberExpression;
                    return memberArgument == null ||
                           !(memberArgument.Expression is ParameterExpression) ||
                           memberArgument.Member.DeclaringType != typeof(T);
                }))
                {
                    error = $"Anonymous type in lambda expression may only be initialized with direct members of {nameof(T)}";
                    return null;
                }

                // Search only for direct members of the lambda's parameter
                // Should already be validated above, but doesn't hurt to be sure.
                var members = from m in newExpression.Arguments.OfType<MemberExpression>()
                    where m.Expression is ParameterExpression && m.Member.DeclaringType == typeof (T)
                    select m.Member.Name;
                return string.Join(",", members);
            }
            error = "Unrecognized lambda expression.";
            return null;
        }
    }
}