using System.Net;
using System.Text;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Exception;
using GameApiTools.Module.Interface;
using GameApiTools.Module.Models.Minecraft;
using Newtonsoft.Json;
namespace GameApiTools.Minecraft;

/// <summary>
/// 
/// </summary>
public class GameListTools : IApiSend<GameListModels>,IHttpSend
{
    public GameListModels Send(string? gametype)
    {
        return SendAsync(gametype).Result;
    }

    public Task<GameListModels> SendAsync(string? gametype)
    {
#pragma warning disable CS8619
        return Task.Run(() =>
        {
            if (gametype != ApiConstant.MinecraftListAPi && gametype != ApiConstant.MinecraftListAPiB && gametype != ApiConstant.MinecraftListAPiM)
                throw new SelectedTypeNotFoundException(
                    "获取json失败，这个异常是你选择的api类型不适合这个方法导致的，你可以查询ApiConstant这个常量表选择对应的api！");
            var v = SendJson(gametype);
            var list = JsonConvert.DeserializeObject<GameListModels>(v);
            if (list is null)
                throw new System.NullReferenceException("此api返回null！"); 
            return list;
        });
#pragma warning restore CS8619
    }
    
    /// <summary>
    /// 只接收正式版
    /// </summary>
    /// <returns>只包含正式版的集合</returns>
    public List<VersionsItem> OnlySendRelease(string? type)
    {
        var list = new List<VersionsItem>();
        var v = Send(type);
        foreach (var V in v.AllVersion)
        {
            if (V.Type is "release")
            {
                list.Add(new VersionsItem()
                {
                    Id = V.Id,
                    Type = V.Type,
                    Jsonurl = V.Jsonurl,
                    Time = V.Time,
                    ReleaseTime = V.ReleaseTime,
                });
            }
        }

        return list;
    }
    
    /// <summary>
    /// 只接收快照版
    /// </summary>
    /// <returns>只包含快照版的集合</returns>
    public List<VersionsItem> OnlySendSnapshot(string? type)
    {
        var list = new List<VersionsItem>();
        var v = Send(type);
        foreach (var V in v.AllVersion)
        {
            if (V.Type is "snapshot")
            {
                list.Add(new VersionsItem()
                {
                    Id = V.Id,
                    Type = V.Type,
                    Jsonurl = V.Jsonurl,
                    Time = V.Time,
                    ReleaseTime = V.ReleaseTime,
                });
            }
        }

        return list;
    }
    
    /// <summary>
    /// 只接收远古版
    /// </summary>
    /// <returns>只包含远古版的集合</returns>
    public List<VersionsItem> OnlySendOld(string? type)
    {
        var list = new List<VersionsItem>();
        var v = Send(type);
        foreach (var V in v.AllVersion)
        {
            if (V.Type is "old_alpha")
            {
                list.Add(new VersionsItem()
                {
                    Id = V.Id,
                    Type = V.Type,
                    Jsonurl = V.Jsonurl,
                    Time = V.Time,
                    ReleaseTime = V.ReleaseTime,
                });
            }
        }

        return list;
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
}