using System.Net;
using System.Text;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Interface;
using GameApiTools.Module.Models.Minecraft;
using Newtonsoft.Json;

namespace GameApiTools.Minecraft;

public class OptifineListTools : IApiSend<List<OptifineListModels>>,IHttpSend,IApiListSend<List<OptifineListModels>>
{
    /// <summary>
    /// 获取指定版本号下的所有optifine
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public List<OptifineListModels> Send(string? gametype = ApiConstant.VersionOptifineListAPiM +"1.12.2")
    {
        return SendAsync(gametype).Result;
    }

    public async Task<List<OptifineListModels>> SendAsync(string? gametype = ApiConstant.VersionOptifineListAPiM+"1.12.2")
    {
#pragma warning disable CS8603
        return await Task.Run((() =>
        {
            var json = SendJson(gametype);
            var v = JsonConvert.DeserializeObject<List<OptifineListModels>>(json);
            return v;
        }));
#pragma warning restore CS8603
    }

    public string SendJson(string? gametype)
    {
        return HttpGet(gametype);
    }

    public List<OptifineListModels> ListSend(string? gametype = ApiConstant.OptifineListAPiM)
    {
        return ListSendAsync(gametype).Result;
    }

    public async Task<List<OptifineListModels>> ListSendAsync(string? gametype = ApiConstant.OptifineListAPiM)
    {
#pragma warning disable CS8603
        return await Task.Run((() =>
        {
            var json = SendJson(gametype);
            var v = JsonConvert.DeserializeObject<List<OptifineListModels>>(json);
            return v;
        }));
#pragma warning restore CS8603
    }
    
    public string HttpGet(string uri)
    {
        HttpClient hc = new HttpClient();
        var v = hc.GetStringAsync(uri).Result;
        return v;
    }
    
    public string HttpPost(string uri,string postheader)
    {
        string result = "";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
        req.Method = "POST";
        req.ContentType = "application/json";
        byte[] data = Encoding.UTF8.GetBytes(postheader);
        req.ContentLength = data.Length;
        using (Stream reqStream = req.GetRequestStream())
        {
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();
        }
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream stream = resp.GetResponseStream();
        // 获取响应内容
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            result = reader.ReadToEnd();
        }
        return result;
    }
}