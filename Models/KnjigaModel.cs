using Newtonsoft.Json;

namespace BookStoreApi.Models
{
    public class KnjigaModel
    {
        [JsonProperty("id")]
        public int KnjigaId { get; set; }
        [JsonProperty("knjiga")]
        public string NazivKnjige { get; set; }
        public int CenaKnjige { get; set; }
        public int ZanrId { get; set; }
        public int AutorId { get; set; }
    }
}
