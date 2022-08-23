namespace GameApiTools.Module.Interface;

/// <summary>
/// 统一api方法接收接口
/// </summary>
public interface IApiSend<T>
{
    /// <summary>
    /// 接收并序列化api返回的json
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public T Send(string? gametype);
    /// <summary>
    /// 异步接收并序列化api返回的json
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public Task<T> SendAsync(string? gametype); 
    /// <summary>
    /// 接收api返回的json(请不要瞎吉尔调用这个方法，你调了也没啥用)
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public string SendJson(string? gametype);
}