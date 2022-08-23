using Newtonsoft.Json;

namespace GameApiTools.Module.Models.MiHoYo;

/// <summary>
/// 列表对象包装器
/// </summary>
/// <typeparam name="T"></typeparam>
public class ListModels<T>
{
    [JsonProperty("list")] public List<T>? List { get; set; }
}