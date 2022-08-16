using Newtonsoft.Json;

namespace GameApiTools.Module.Models.Minecraft;
//    //{"_id":"5ccc81bf871d9b9623c127cc","mcversion":"1.13.2","patch":"E7","type":"HD_U","__v":0,"filename":"OptiFine_1.13.2_HD_U_E7.jar"}
public class OptifineListModels
{
    /// <summary>
    /// Optifine的，额，应该是hash
    /// <example>5ccc81bf871d9b9623c127cc</example>
    /// </summary>
    [JsonProperty("_id")]
    public string Id { get; set; }
    /// <summary>
    /// 当前Optifine所支持的minecraft版本
    /// <example>1.13.2</example>
    /// </summary>
    [JsonProperty("mcversion")]
    public string GameVersion { get; set; } 
    /// <summary>
    /// Optifine的补丁
    /// <example>E7</example>
    /// </summary>
    [JsonProperty("patch")]
    public string Patch { get; set; }
    /// <summary>
    /// Optifine类型
    /// <example>HD_U</example>
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }
    /// <summary>
    /// O无用
    /// <example>"__v":0</example>
    /// </summary>
    [JsonProperty("__v")]
    public string v { get; set; }
    /// <summary>
    /// Optifine的文件名
    /// <example>OptiFine_1.13.2_HD_U_E7.jar</example>
    /// </summary>
    [JsonProperty("filename")]
    public string FileName { get; set; }
}