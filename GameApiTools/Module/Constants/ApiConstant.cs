namespace GameApiTools.Module.Constants;

/// <summary>
/// 统一api常量表
/// </summary>
public class ApiConstant
{
    protected const string baseuriA = $"https://bmclapi2.bangbang93.com";
    protected const string baseuriB = $"https://download.mcbbs.net";
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

}//