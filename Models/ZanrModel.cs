using Newtonsoft.Json;

namespace BookStoreApi.Models
{
    public class ZanrModel
    {
        [JsonProperty("id")]
        public int IdZanra { get; set; }

        [JsonProperty("zanr")]
        public string ZanrNaziv { get; set; }
    }
}
