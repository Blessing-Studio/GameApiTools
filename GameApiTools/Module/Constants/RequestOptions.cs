namespace GameApiTools.Module.Constants;

public class RequestOptions : Dictionary<string, string>
{
    public const string CommonUA2101 = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBS/2.10.1";
    public const string CommonUA2111 = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBS/2.11.1";

    /// <summary>
    /// 支持更新的DS2算法
    /// </summary>
    public const string CommonUA2331 = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBS/2.34.1";

    /// <summary>
    /// 支持签到DS
    /// </summary>
    public const string CommonUA2281 = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) miHoYoBBS/2.28.1";

    public static readonly string DeviceId = Guid.NewGuid().ToString("D");
    public const string Json = "application/json";
    public const string Hyperion = "com.mihoyo.hyperion";
}