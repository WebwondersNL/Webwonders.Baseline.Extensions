using System.Linq.Expressions;
using System.Reflection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Extensions;

namespace Webwonders.Framework.Extensions;

public class PublishedContentExtensions
{
    public virtual TResult? ValueWithFallback<TContent, TResult>(TContent input,
        IPublishedValueFallback publishedValueFallback, Expression<Func<TContent, TResult>> expr, Fallback fallback)
        where TContent : IPublishedElement
    {
        if (expr == null)
        {
            throw new ArgumentNullException(nameof(expr));
        }

        if (expr.Body is MemberExpression memberExpression)
        {
            string propertyName = memberExpression.Member.Name;
            PropertyInfo? propertyType = input.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            ImplementPropertyTypeAttribute? attribute = propertyType?.GetCustomAttribute<ImplementPropertyTypeAttribute>();
            
            var value = input.Value(publishedValueFallback, attribute?.Alias!, fallback: fallback);
            
            if (value != null)
            {
                return (TResult)value;
            }
        }
        
        return default;
    }
}