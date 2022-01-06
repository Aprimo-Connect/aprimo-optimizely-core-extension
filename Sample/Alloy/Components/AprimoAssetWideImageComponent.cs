using AlloyTemplates.Models.Media;
using AlloyTemplates.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTemplates.Controllers
{
    /// <summary>
    /// Controller for the image file.
    /// </summary>
    [TemplateDescriptor(Inherited = false, AvailableWithoutTag = false, Tags = new[] { Global.ContentAreaTags.TwoThirdsWidth, Global.ContentAreaTags.FullWidth }, ModelType = typeof(AprimoImageAsset), TemplateTypeCategory = EPiServer.Framework.Web.TemplateTypeCategories.MvcPartialComponent)]
    public class AprimoAssetWideImageComponent : PartialContentComponent<AprimoImageAsset>
    {
        /// <summary>
        /// The index action for the image file. Creates the view model and renders the view.
        /// </summary>
        /// <param name="currentContent">The current image file.</param>
        protected override IViewComponentResult InvokeComponent(AprimoImageAsset currentContent)
        {
            var model = new ImageViewModel
            {
                Url = currentContent.WideImage,
                Name = currentContent.Name,
                Copyright = currentContent.AltText
            };

            return View(model);
        }
    }
}