using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Webwonders.Baseline.Extensions.Composers
{
    public class WebwondersFrameworkExtensionsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.Configure<HtmlTagReplacementOptions>(
                builder.Config.GetSection("HtmlTagReplacements")
            );

            builder.Services.AddTransient<StringExtensions>();
            builder.Services.AddTransient<PublishedContentExtensions>();
        }
    }
}
