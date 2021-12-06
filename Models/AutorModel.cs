using Newtonsoft.Json;

namespace BookStoreApi.Models
{
    public class AutorModel
    {
        [JsonProperty("id")]
        public int IdAutora { get; set; }

        [JsonProperty("autor")]
        public string ImeAutora { get; set; }

        public string PrezimeAutora { get; set; } 
    }
}
