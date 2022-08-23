namespace GameApiTools.Module.Constants;

/// <summary>
/// 统一api常量表
/// </summary>
public class ApiConstant
{
    protected const string baseuriA = $"https://bmclapi2.bangbang93.com";
    protected const string baseuriB = $"https://download.mcbbs.net";
    internal const string ApiTakumi = @"https://api-takumi.mihoyo.com";
    internal const string ReferBaseUrl = @"https://webstatic.mihoyo.com/bbs/event/signin-ys/index.html";
    internal const string ActivityId = "e202009291139501";
    /// <summary>
    /// mc下载列表api（官方源）
    /// </summary>
    public const string MinecraftListAPi = "http://launchermeta.mojang.com/mc/game/version_manifest.json";
    /// <summary>
    /// mc下载列表api（BmclAPI源）
    /// </summary>
    public const string MinecraftListAPiB = "https://bmclapi2.bangbang93.com/mc/game/version_manifest_v2.json";
    /// <summary>
    /// mc下载列表api（McBBs源）
    /// </summary>
    public const string MinecraftListAPiM = "https://download.mcbbs.net/mc/game/version_manifest_v2.json";
    /// <summary>
    /// 获取Forge支持的minecraft版本的api(bmclapi源)
    /// </summary>
    public const string OnlyVersionForgeListAPiB = "https://bmclapi2.bangbang93.com/forge/minecraft";
    /// <summary>
    /// 获取Forge支持的minecraft版本的api(mcbbs源)
    /// </summary>
    public const string OnlyVersionForgeListAPiM = "https://download.mcbbs.net/forge/minecraft";
    /// <summary>
    ///  根据版本获取forge列表api(mcbbs源)
    /// </summary>
    public const string ForgeListAPiM = "https://download.mcbbs.net/forge/minecraft";
    /// <summary>
    ///  根据版本获取forge列表api(bmclapi源)
    /// </summary>
    public const string ForgeListAPiB = "https://bmclapi2.bangbang93.com/forge/minecraft/";
    /// <summary>
    ///  获取支持minecraft的forge的版本的id列表api(bmclapi源)
    /// </summary>
    public const string SupportForgeListB = "https://bmclapi2.bangbang93.com/forge/minecraft/";
    /// <summary>
    ///  获取支持minecraft的forge的版本的id列表api(mcbbs源)
    /// </summary>
    public const string SupportForgeListM = $"{baseuriB}/forge/minecraft/";
    /// <summary>
    ///  获取完整Optifine列表api(bmclapi源)
    /// </summary>
    public const string OptifineListAPiB = $"{baseuriA}/optifine/versionList";
    /// <summary>
    ///  获取完整Optifine列表api(mcbbs源)
    /// </summary>
    public const string OptifineListAPiM = $"{baseuriB}/optifine/versionList";
    /// <summary>
    ///  获取指定minecraft版本的Optifine列表api(bmclapi源)
    /// </summary>
    public const string VersionOptifineListAPiB = $"{baseuriA}/optifine/";
    /// <summary>
    ///  获取指定minecraft版本的Optifine列表api(mcbbs源)
    /// </summary>
    public const string VersionOptifineListAPiM = $"{baseuriB}/optifine/";
    /// <summary>
    ///  米游社登录api(需配合cookie使用)
    /// </summary>
    public const string MiHoYoSignApi = $"https://api-takumi.mihoyo.com/binding/api/getUserGameRolesByCookie?game_biz=hk4e_cn";
    /// <summary>
    ///  米游社获取签到列表api(无需配合cookie使用)
    /// </summary>
    public const string MiHoYoSignInApi = $"https://api-takumi.mihoyo.com/event/bbs_sign_reward/home?act_id=e202009291139501";
    /// <summary>
    ///  米游社表情包列表api
    /// </summary>
    public const string MiHoYoEmoticonApi = $"https://bbs-api.mihoyo.com/misc/api/emoticon_set";
}//