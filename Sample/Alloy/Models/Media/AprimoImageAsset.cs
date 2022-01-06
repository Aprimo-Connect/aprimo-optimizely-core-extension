using Aprimo.Opti.Core.Models;
using Aprimo.Opti.Core.Attributes;
using EPiServer.DataAnnotations;

namespace AlloyTemplates.Models.Media
{
    [ContentType(DisplayName = "Aprimo Image File", GUID = "5420194f-16ae-46d2-8f3a-0c682d232581", Description = "Respresents aprimo image asset", Order = 1)]
    [AprimoAssetDescriptor(ExtensionString = "jpg,jpeg,png,tif,tiff,gif")]
    public class AprimoImageAsset : AprimoImageData
    {
        [AprimoTransform(Auto = "webp", Width = "400", Crop = "16:9")]
        public virtual string Teaser { get; set; }

        [AprimoFieldName("Alt")]
        public virtual string AltText { get; set; }

        [AprimoTransform(Auto = "webp", Width = "800", Crop = "16:9")]
        public virtual string JumboTronImage { get; set; }

        [AprimoTransform(Auto = "webp", Width = "770", Crop = "16:9")]
        public virtual string WideImage { get; set; }
    }
}