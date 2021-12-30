using Aprimo.Opti.Core.Models.RestImpl;
using Aprimo.Opti.Core.Models.RestImpl.Search;
using Aprimo.Opti.Core.RestImpl.Requests;
using EPiServer.Core;

namespace Aprimo.Opti.Core.Services
{
    public interface IAprimoAssetService
    {
        Asset GetAsset(string id);

        AssetList SearchAsset(SearchRequest searchRequest);

        void AddOrUpdate(string id, AddUpdateRecordRequest record);

        void CreatePermalinkForAprimo(string id, ContentReference contentReference, ContentReference referenceContentLink);
    }
}