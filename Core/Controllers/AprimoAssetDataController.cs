using Aprimo.Opti.Core.Models;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Aprimo.Opti.Core.Controllers
{
    [TemplateDescriptor(AvailableWithoutTag = true, Inherited = true)]
    public class AprimoAssetDataController : PartialContentComponent<AprimoAssetData>
    {
        protected override IViewComponentResult InvokeComponent(AprimoAssetData currentContent) =>
            View(currentContent);
    }
}