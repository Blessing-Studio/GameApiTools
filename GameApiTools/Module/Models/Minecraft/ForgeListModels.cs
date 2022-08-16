using Newtonsoft.Json;

namespace GameApiTools.Module.Models.Minecraft;

public class ForgeListModels
{
    /// <summary>
    /// Build构建号
    /// </summary>
    [JsonProperty("build")]
    public int Build { get; set; }

    /// <summary>
    /// Forge版本号
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; }
}