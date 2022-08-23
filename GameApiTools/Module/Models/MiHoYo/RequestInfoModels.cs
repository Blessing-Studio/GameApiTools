namespace GameApiTools.Module.Models;

public record RequestInfo
{
    public RequestInfo(string method, string url, Func<Task<HttpResponseMessage>> httpResponseMessage)
    {
        Method = method;
        Url = url;
        RequestAsyncFunc = httpResponseMessage;
    }

    public string Method { get; set; }
    public string Url { get; set; }
    public Func<Task<HttpResponseMessage>> RequestAsyncFunc { get; set; }
}