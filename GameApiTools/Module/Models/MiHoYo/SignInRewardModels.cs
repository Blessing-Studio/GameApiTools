using Newtonsoft.Json;

namespace GameApiTools.Module.Models.MiHoYo;

public class SignInReward
{
    /// <summary>
    /// 月份
    /// </summary>
    [JsonProperty("month")] public string? Month { get; set; }
    [JsonProperty("awards")] public List<SignInAward>? Awards { get; set; }
}

public class SignInAward
{
    [JsonProperty("icon")] public string? Icon { get; set; }
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("cnt")] public string? Count { get; set; }
}