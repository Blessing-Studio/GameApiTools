namespace GameApiTools.Module.Interface;

/// <summary>
/// 网络操作工具统一工具类
/// </summary>
interface IHttpSend
{
    /// <summary>
    /// Http get请求方法
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
     string HttpGet(string uri);
    /// <summary>
    /// Http Post请求方法
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
     string HttpPost(string uri,string postheader);
}