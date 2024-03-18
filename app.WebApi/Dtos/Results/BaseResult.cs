using Newtonsoft.Json;

namespace app.WebApi.Dtos.Results
{
    public class BaseResult
    {
        [JsonProperty(Order = -2)]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}