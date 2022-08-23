using Newtonsoft.Json;

namespace GameApiTools.Module.Models.MiHoYo;

/// <summary>
/// 表情包返回模型
/// </summary>
public class EmoticonModels
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("icon")]
    public string Icon { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("sort_order")]
    public int SortOrder { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("num")]
    public int Num { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("list")]
    public List <ListItem> List { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("updated_at")]
    public int UpdatedAt { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("is_available")]
    public bool IsAvailable { get; set; }
}

public class ListItem
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("icon")]
    public string Icon { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("sort_order")]
    public int SortOrder { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("num")]
    public int Num { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("updated_at")]
    public int UpdatedAt { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("is_available")]
    public bool IsAvailable { get; set; }
}


internal class Data5
{
    /// <summary>
    /// 
    /// </summary>
    public List <EmoticonModels> list { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string recently_emoticon { get; set; } = null;
}
 
internal class Root
{
    /// <summary>
    /// 
    /// </summary>
    public int retcode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string message { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Data5 data { get; set; }
}