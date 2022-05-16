using Newtonsoft.Json;

namespace API.Models
{
    public class ApiResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("data")]
        public object Data { get; set; }

        public ApiResult(string status, string message = null, object data = null)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}