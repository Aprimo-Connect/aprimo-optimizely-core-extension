using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using AlloyTemplates.Controllers;
using AlloyTemplates.Models.Blocks;
using AlloyTemplates.Models.Pages;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using AlloyTemplates.Models.Media;

namespace AlloyTemplates.Business.Rendering
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        public const string BlockFolder = "~/Views/Shared/Blocks/";

        public const string PagePartialsFolder = "~/Views/Shared/PagePartials/";

        public const string MediaPartialsFolder = "~/Views/Shared/MediaPartials/";

        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            //Disable DefaultPageController for page types that shouldn't have any renderer as pages
            if (args.ItemToRender is IContainerPage && args.SelectedTemplate != null && args.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            {
                args.SelectedTemplate = null;
            }
        }

        /// <summary>
        /// Registers renderers/templates which are not automatically discovered,
        /// i.e. partial views whose names does not match a content type's name.
        /// </summary>
        /// <remarks>
        /// Using only partial views instead of controllers for blocks and page partials
        /// has performance benefits as they will only require calls to RenderPartial instead of
        /// RenderAction for controllers.
        /// Registering partial views as templates this way also enables specifying tags and
        /// that a template supports all types inheriting from the content type/model type.
        /// </remarks>
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(JumbotronBlock), new TemplateModel
            {
                Name = "JumbotronBlockWide",
                Tags = new[] { Global.ContentAreaTags.FullWidth },
                AvailableWithoutTag = false,
            });

            viewTemplateModelRegistrator.Add(typeof(TeaserBlock), new TemplateModel
            {
                Name = "TeaserBlockWide",
                Tags = new[] { Global.ContentAreaTags.TwoThirdsWidth, Global.ContentAreaTags.FullWidth },
                AvailableWithoutTag = false,
            });

            viewTemplateModelRegistrator.Add(typeof(SitePageData), new TemplateModel
            {
                Name = "Page",
                Inherit = true,
                AvailableWithoutTag = true,
                Path = PagePartialPath("Page.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(SitePageData), new TemplateModel
            {
                Name = "PageWide",
                Inherit = true,
                Tags = new[] { Global.ContentAreaTags.TwoThirdsWidth, Global.ContentAreaTags.FullWidth },
                AvailableWithoutTag = false,
                Path = PagePartialPath("PageWide.cshtml")
            });

            // Adds additional width to Images
            viewTemplateModelRegistrator.Add(typeof(AprimoImageAsset), new TemplateModel
            {
                Name = "AprimoImageAssetWide",
                Inherit = true,
                Tags = new[] { Global.ContentAreaTags.TwoThirdsWidth, Global.ContentAreaTags.FullWidth },
                AvailableWithoutTag = false,
                Path = MediaPartialPath("AprimoImageAssetWide.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ContactPage), new TemplateModel
            {
                Name = "ContactPageWide",
                Tags = new[] { Global.ContentAreaTags.TwoThirdsWidth, Global.ContentAreaTags.FullWidth },
                AvailableWithoutTag = false,
            });

            viewTemplateModelRegistrator.Add(typeof(IContentData), new TemplateModel
            {
                Name = "NoRenderer",
                Inherit = true,
                Tags = new[] { Global.ContentAreaTags.NoRenderer },
                AvailableWithoutTag = false,
                Path = BlockPath("NoRenderer.cshtml")
            });
        }

        private static string BlockPath(string fileName)
        {
            return string.Format("{0}{1}", BlockFolder, fileName);
        }

        private static string PagePartialPath(string fileName)
        {
            return string.Format("{0}{1}", PagePartialsFolder, fileName);
        }

        private static string MediaPartialPath(string fileName)
        {
            return string.Format("{0}{1}", PagePartialsFolder, fileName);
        }
    }
}