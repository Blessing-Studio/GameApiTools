using System.Net;
using System.Text;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Exception;
using GameApiTools.Module.Interface;
using GameApiTools.Module.Models.Minecraft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameApiTools.Minecraft;

public class ForgeListTools : IApiSend<List<string>>,IHttpSend,IApiListSend<List<ForgeListModels>>
{
    /// <summary>
    /// 获取api返回的所有支持forge的minecraft版本
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public List<string> Send(string? gametype = ApiConstant.SupportForgeListB)
    {
        return SendAsync(gametype).Result;
    }
    /// <summary>
    /// 异步获取api返回的所有支持forge的minecraft版本
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public async Task<List<string>> SendAsync(string? gametype = ApiConstant.SupportForgeListB)
    {
#pragma warning disable CS8603
        return await Task.Run((() =>
        {
            string str = this.HttpGet("https://bmclapi2.bangbang93.com/forge/minecraft");
            if (str == null)
                throw new System.Exception("forge所支持的minecraft版本列表拉取失败！");
            return JsonConvert.DeserializeObject<List<string>>(str);
        }));
#pragma warning restore CS8603
    }
    public string SendJson(string? gametype)
    {
        return HttpGet(gametype);
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
    /// <summary>
    /// 根据版本获取forge列表api(mcbbs源)
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public List<ForgeListModels> ListSend(string? gametype = ApiConstant.ForgeListAPiM+"/1.12.2")
    {
        return ListSendAsync(gametype).Result;
    }
    /// <summary>
    /// (异步)根据版本获取forge列表api
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    /// <exception cref="SelectedTypeNotFoundException"></exception>
    public async Task<List<ForgeListModels>> ListSendAsync(string? gametype = ApiConstant.ForgeListAPiM+"/1.12.2")
    {
        string str2 = "";
        return await Task.Run((async () =>
        {
            var json = HttpGet(gametype);
            var e = JsonConvert.DeserializeObject<List<ForgeListModels>>(json);
            return e;
        }));
    }
}