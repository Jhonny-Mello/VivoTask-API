using Newtonsoft.Json;

namespace Shared_Razor_Components.FundamentalModels
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        [JsonProperty("errors")]
        public string[] Errors { get; set; } = [];
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }
}
