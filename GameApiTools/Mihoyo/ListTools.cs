using System.Threading.Channels;
using GameApiTools.Module.Interface;
using System;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Models.MiHoYo;
using Newtonsoft.Json;

namespace GameApiTools.Mihoyo;

public class ListTools :  IHttpSend,IApiSend<SignInListModels>,IApiListSend<List<EmoticonModels>>
{
    public string HttpGet(string uri)
    {
        HttpClient hc = new HttpClient();
        return hc.GetStringAsync(uri).Result;
    }
    
    public string HttpPost(string uri, string postheader)
    {
        return "Post";
    }

    public SignInListModels Send(string? gametype = ApiConstant.MiHoYoSignInApi)
    {
        return SendAsync(gametype).Result;
    }

    public async Task<SignInListModels> SendAsync(string? gametype = ApiConstant.MiHoYoSignInApi)
    {
        return await Task.Run(() =>
        {
            if (gametype is not ApiConstant.MiHoYoSignInApi)
                throw new ArgumentException("错误的api，亦或是此方法不适用的api");
            var json = SendJson(gametype);
            var v = JsonConvert.DeserializeObject<SignInListModels>(json);
            if (v is null || json is null)
                throw new NullReferenceException("哎嘿，数据返回值为空");
            return v;
        });
    }

    public string SendJson(string? gametype)
    {
        return HttpGet(gametype);
    }
    /// <summary>
    /// 表情包列表拉取方法
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    public List<EmoticonModels> ListSend(string? gametype)
    {
        return ListSendAsync(gametype).Result;
    }

    /// <summary>
    /// 表情包列表异步拉取方法
    /// </summary>
    /// <param name="gametype"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public async Task<List<EmoticonModels>> ListSendAsync(string? gametype)
    {
        return await Task.Run((() =>
        {
            List<EmoticonModels> em = new();
            var json = SendJson(gametype);
            var refs = JsonConvert.DeserializeObject<Root>(json);
            foreach (var i in refs.data.list)
                em.Add(i);
                if (refs is null || json is null)
                throw new NullReferenceException("哎嘿，数据返回值为空");
            return em;
        }));
    }
}