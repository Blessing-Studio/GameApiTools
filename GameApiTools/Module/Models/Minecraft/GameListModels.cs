using Newtonsoft.Json;

namespace GameApiTools.Module.Models.Minecraft;

/// <summary>
/// minecraft下载列表返回模型
/// </summary>
public class GameListModels
{
    /// <summary>
    /// 最新版本信息
    /// </summary>
    [JsonProperty("latest")]
    public Latest  LatestVersion{ get; set; }
    /// <summary>
    ///  所有版本信息
    /// </summary>
    [JsonProperty("versions")]
    public List <VersionsItem>  AllVersion { get; set; } 
}

public class Latest
{
    /// <summary>
    /// 最新正式版
    /// </summary>
    [JsonProperty("release")]
    public string Release { get; set; }
    /// <summary>
    /// 最新快照版
    /// </summary>
    [JsonProperty("snapshot")]
    public string Snapshot { get; set; }
}
 
public class VersionsItem
{
    /// <summary>
    /// 版本Id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
    /// <summary>
    /// 版本类型
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }
    /// <summary>
    /// 版本json链接
    /// </summary>
    [JsonProperty("url")]
    public string Jsonurl { get; set; }
    /// <summary>
    /// 时间
    /// </summary>
    [JsonProperty("time")]
    public string Time { get; set; }
    /// <summary>
    /// 发布时间
    /// </summary>
    [JsonProperty("releaseTime")]
    public string ReleaseTime { get; set; }
}
