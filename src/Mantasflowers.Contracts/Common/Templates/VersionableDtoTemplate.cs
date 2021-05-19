using Newtonsoft.Json;

namespace Mantasflowers.Contracts.Common
{
    public abstract class VersionableDtoTemplate
    {
        [JsonIgnore]
        public byte[] RowVersion { get; set; }
    }
}