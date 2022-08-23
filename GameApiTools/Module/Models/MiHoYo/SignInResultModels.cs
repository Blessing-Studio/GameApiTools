using Newtonsoft.Json;

namespace GameApiTools.Module.Models.MiHoYo;

public class SignInResult
{
    /// <summary>
    /// 通常是 ""
    /// </summary>
    [JsonProperty("code")]
    public string? Code { get; set; }

    /// <summary>
    /// 通常是 0
    /// </summary>
    [JsonProperty("risk_code")]
    public int RiskCode { get; set; }

    /// <summary>
    /// 通常是 ""
    /// </summary>
    [JsonProperty("gt")]
    public string Gt { get; set; } = default!;

    /// <summary>
    /// 通常是 ""
    /// </summary>
    [JsonProperty("challenge")]
    public string Challenge { get; set; } = default!;

    /// <summary>
    /// 通常是 1
    /// </summary>
    [JsonProperty("success")]
    public int Success { get; set; }
}
