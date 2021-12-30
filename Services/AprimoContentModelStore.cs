using Aprimo.Opti.Core.Models;
using EPiServer.Cms.Shell.UI.Rest;
using EPiServer.Cms.Shell.UI.Rest.Models;
using EPiServer.ServiceLocation;
using System.Collections.Specialized;
using System.Linq;

namespace Aprimo.Opti.Core.Services
{
    [ServiceConfiguration(ServiceType = typeof(AprimoContentModelStore))]
    public class AprimoContentModelStore
    {
        private readonly IContentStoreModelCreator contentStoreModelCreator;

        public AprimoContentModelStore(IContentStoreModelCreator contentStoreModelCreator)
        {
            this.contentStoreModelCreator = contentStoreModelCreator;
        }

        public ContentDataStoreModel Create(AprimoAssetData assetData)
        {
            DefaultQueryParameters queryParameters = new DefaultQueryParameters
            {
                TypeIdentifiers = Enumerable.Empty<string>(),
                AllParameters = new NameValueCollection(0)
            };
            return this.contentStoreModelCreator.CreateContentDataStoreModel<ContentDataStoreModel>(assetData, queryParameters);
        }
    }
}