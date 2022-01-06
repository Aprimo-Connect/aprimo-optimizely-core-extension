using Newtonsoft.Json;

namespace Aprimo.Opti.Core.Models.RestImpl.Fields
{
    public partial class FieldLinks
    {
        [JsonProperty("self")]
        public Self Self { get; set; }

        [JsonProperty("definition")]
        public Definition Definition { get; set; }
    }
}