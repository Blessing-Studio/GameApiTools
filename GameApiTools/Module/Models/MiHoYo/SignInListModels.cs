using Newtonsoft.Json;

namespace GameApiTools.Module.Models.MiHoYo;

/// <summary>
/// 签到列表返回模型
/// </summary>
public class SignInListModels
{
    /// <summary>
    /// 返回码
    /// </summary>
    [JsonProperty("retcode")]
    public int Retcode { get; set; }
    /// <summary>
    /// 返回信息
    /// </summary>
    [JsonProperty("message")]
    public string Retmessage { get; set; }
    /// <summary>
    /// 返回数据
    /// </summary>
    [JsonProperty("data")]
    public Data RetData { get; set; }
}

public class Data
{
    /// <summary>
    /// 当前月份 
    /// </summary>
    [JsonProperty("month")]
    public int Month { get; set; }
    /// <summary>
    /// 具体信息列表 
    /// </summary>
    [JsonProperty("awards")]
    public List<MainList> Awards { get; set; }
}

public class MainList
{
    /// <summary>
    /// 图标
    /// </summary>
    [JsonProperty("icon")]
    public string Icon { get; set; }
    /// <summary>
    /// 奖励名
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// 我不到啊
    /// </summary>
    [JsonProperty("cnt")]
    public string Cnt { get; set; }
}