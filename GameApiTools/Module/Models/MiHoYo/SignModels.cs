using Newtonsoft.Json;

namespace GameApiTools.Module.Models.MiHoYo;
/// <summary>
/// 登录返回模型
/// </summary>
public class SignModels
{
    /// <summary>
    /// 返回码
    /// </summary>
    [JsonProperty("retcode")]
    public int Returncode { get; set; }
    /// <summary>
    /// 返回的信息
    /// </summary>
    [JsonProperty("message")]
    public string ReturnMessage { get; set; }
    /// <summary>
    /// 返回的数据信息
    /// </summary>
    [JsonProperty("data")]
    public Return ReturnData { get; set; }
}

public class Return
{
    /// <summary>
    /// 返回的玩家数据信息
    /// </summary>
    [JsonProperty("list")]
    public List<DataReturn> DataList{ get; set; }
}

public class DataReturn
{
    /// <summary>
    /// 无用，建议别用
    /// </summary>
    [JsonProperty("game_biz")]
    public string GameBiz { get; set; }
    /// <summary>
    /// 服务器类型
    /// </summary>
    [JsonProperty("region")]
    public string Region { get; set; }
    /// <summary>
    /// 游戏里的Uid
    /// </summary>
    [JsonProperty("game_uid")]
    public string Uid { get; set; }
    /// <summary>
    /// 昵称
    /// </summary>
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    /// <summary>
    /// 等级
    /// </summary>
    [JsonProperty("level")]
    public int Level { get; set; }
    /// <summary>
    /// 被选择
    /// </summary>
    [JsonProperty("is_chosen")]
    public string Ischosen { get; set; }
    /// <summary>
    /// 服务器名
    /// </summary>
    [JsonProperty("region_name")]
    public string RegionName { get; set; }
    /// <summary>
    /// 游戏账户是否是官服
    /// </summary>
    [JsonProperty("is_official")]
    public string Isofficial { get; set; }
}
//{"retcode":0,"message":"OK","data":{"list":[{"game_biz":"hk4e_cn","region":"cn_gf01","game_uid":"211543117","nickname":"西路小","level":7,"is_chosen":false,"region_name":"天空岛","is_official":true}]}}