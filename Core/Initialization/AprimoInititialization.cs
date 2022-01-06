using Aprimo.Opti.Core;
using Aprimo.Opti.Core.Services;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace Aprimo.Opti.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class AprimoInititialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            context.Locate.Advanced.GetInstance<AprimoContentAssetResolver>()
                .Initialize(context.Locate.Advanced.GetInstance<ContentTypeModelRepository>());

            context.Locate.Advanced.GetInstance<IAprimoAssetPersistantService>()
                .CheckDBConsistancy(AprimoConstants.DBVersion);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}