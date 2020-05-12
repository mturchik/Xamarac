using Newtonsoft.Json;

namespace Xamarac.ViewModels
{
    public class ChuckQuote
    {
        [JsonProperty("value")]
        public string Saying { get; set; }
    }
}