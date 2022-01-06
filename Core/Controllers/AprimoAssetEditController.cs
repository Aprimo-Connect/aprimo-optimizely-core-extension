using Aprimo.Opti.Core.Models;
using Aprimo.Opti.Core.Resolvers;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Text;

namespace Aprimo.Opti.Core.Controllers
{
    [TemplateDescriptor(
        Inherited = true,
        AvailableWithoutTag = false,
        Tags = new[] { RenderingTags.Edit, RenderingTags.Preview },
        TemplateTypeCategory = TemplateTypeCategories.MvcController)]
    public class AprimoAssetEditController : PartialContentComponent<AprimoAssetData>
    {
        private readonly UrlResolver urlResolver;

        private const string PermalinkTemplate = "https://{0}.dam.aprimo.com/dam/contentitems/{1}";

        private readonly IAprimoFieldPropertyResolver aprimoFieldPropertyResolver;

        public AprimoAssetEditController(UrlResolver urlResolver, IAprimoFieldPropertyResolver aprimoFieldPropertyResolver)
        {
            this.urlResolver = urlResolver;
            this.aprimoFieldPropertyResolver = aprimoFieldPropertyResolver;
        }

        protected override IViewComponentResult InvokeComponent(AprimoAssetData currentContent)
        {
            string aprimoUrl = string.Format(PermalinkTemplate, AprimoAPISettings.AprimoTenantId, currentContent.AssetId);
            StringBuilder sb = new("<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css\" integrity =\"sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We\" crossorigin=\"anonymous\">");
            sb.Append("<div class=\"container py-5\">");
            sb.Append("<div class=\"row\">");
            sb.Append("<div class=\"col-md-8\">");

            if (currentContent is IAprimoImage aprimoImageFile)
            {
                TagBuilder builder = new("img");
                builder.MergeAttribute("class", "img-fluid");
                builder.MergeAttribute("src", aprimoImageFile.PreviewUrl);
                sb.Append(builder.RenderSelfClosingTag());
            }

            sb.Append("</div>");
            sb.Append("<div class=\"col-md-4\">");

            TagBuilder dl = new("dl");
            dl.MergeAttribute("class", "row");
            dl.InnerHtml.AppendHtml(DescriptionList("Aprimo Id", currentContent.AssetId).ToString());

            TagBuilder aprimoLinkBuilder = new("a");
            aprimoLinkBuilder.InnerHtml.Append("View in Aprimo");
            aprimoLinkBuilder.MergeAttribute("href", aprimoUrl);
            aprimoLinkBuilder.MergeAttribute("target", "_blank");
            dl.InnerHtml.AppendHtml(DescriptionListWithHtml("Asset Url", aprimoLinkBuilder.ToString()).ToString());

            // Fields
            var fieldProperties = this.aprimoFieldPropertyResolver.Resolve(typeof(AprimoAssetData));
            if (fieldProperties.Any())
            {
                foreach (var fieldProperty in fieldProperties)
                {
                    if (currentContent[fieldProperty.Name] != null)
                    {
                        dl.InnerHtml.AppendHtml(DescriptionList(fieldProperty.Name, currentContent.GetPropertyValue(fieldProperty.Name)).ToString());
                    }
                }
            }

            sb.Append(dl.ToString());
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</div>");
            return base.Content(sb.ToString());
        }

        private StringBuilder DescriptionList(string title, string description)
        {
            var descriptionBuilder = new StringBuilder();

            TagBuilder dtBuilder = new("dt");
            dtBuilder.MergeAttribute("class", "col-sm-3");
            dtBuilder.InnerHtml.Append($"{title}:");
            descriptionBuilder.AppendLine(dtBuilder.ToString());

            TagBuilder ddBuilder = new("dd");
            ddBuilder.MergeAttribute("class", "col-sm-9");
            ddBuilder.InnerHtml.Append(description);
            descriptionBuilder.AppendLine(ddBuilder.ToString());
            return descriptionBuilder;
        }

        private StringBuilder DescriptionListWithHtml(string title, string description)
        {
            var descriptionBuilder = new StringBuilder();

            TagBuilder dtBuilder = new("dt");
            dtBuilder.MergeAttribute("class", "col-sm-3");
            dtBuilder.InnerHtml.Append($"{title}:");
            descriptionBuilder.AppendLine(dtBuilder.ToString());

            TagBuilder ddBuilder = new("dd");
            ddBuilder.MergeAttribute("class", "col-sm-9");
            ddBuilder.InnerHtml.AppendHtml(description);
            descriptionBuilder.AppendLine(ddBuilder.ToString());
            return descriptionBuilder;
        }

        private string GenerateUrl(string url, int width, int height)
        {
            var thumbUrl = UriUtil.AddQueryString(url, "width", width.ToString());
            thumbUrl = UriUtil.AddQueryString(thumbUrl, "height", height.ToString());
            return thumbUrl;
        }
    }
}