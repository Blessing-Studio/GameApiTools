namespace GameApiTools.Module.Interface;

public interface IApiListSend<T>
{
    /// <summary>
    /// 接收并序列化api返回的json
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public T ListSend(string? gametype);
    /// <summary>
    /// 异步接收并序列化api返回的json
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public Task<T> ListSendAsync(string? gametype); 
}