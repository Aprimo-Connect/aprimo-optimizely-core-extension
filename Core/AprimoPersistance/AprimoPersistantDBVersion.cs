using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System.Linq;

namespace Aprimo.Opti.Core.AprimoPersistance
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true, StoreName = "AprimoPersistantDBVersion")]
    public class AprimoPersistantDBVersion
    {
        public Identity Id { get; set; }

        public string DBVersion { get; set; }

        public void Save()
        {
            var store = typeof(AprimoPersistantDBVersion).GetStore();
            store.Save(this);
        }

        public static AprimoPersistantDBVersion Get()
        {
            var store = typeof(AprimoPersistantDBVersion).GetStore();
            return store.Items<AprimoPersistantDBVersion>()
                .FirstOrDefault();
        }
    }
}