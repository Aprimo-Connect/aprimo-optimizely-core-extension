using Aprimo.Opti.Core.Models;
using EPiServer.Shell;

namespace Aprimo.Opti.Core.Descriptors
{
    [UIDescriptorRegistration]
    public class AprimoAssetUIDescriptor : UIDescriptor<AprimoAssetData>, IEditorDropBehavior
    {
        public EditorDropBehavior EditorDropBehaviour { get; set; }

        public AprimoAssetUIDescriptor()
            : base("epi-iconObjectContainerFetchContent")
        {
            EditorDropBehaviour = EditorDropBehavior.CreateLink;
            DefaultView = CmsViewNames.PreviewView;
        }
    }
}