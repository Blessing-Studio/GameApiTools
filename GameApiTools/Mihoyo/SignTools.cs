using System.Net;
using System.Text;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Interface;
using GameApiTools.Module.Models.MiHoYo;
using Newtonsoft.Json;

namespace GameApiTools.Mihoyo;
/// <summary>
/// 米游社登录工具类
/// </summary>
public class SignTools : IHttpSend,IApiSend<SignModels>
{
    readonly string _cookie;

    public SignTools(string cookie) => _cookie = cookie;

    public string HttpGet(string uri)
    {
        string result = "";
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
        req.Headers.Add("Cookie", _cookie);
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Stream stream = resp.GetResponseStream();
        try
        {
            //获取内容
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            throw new WebException($"请求错误 {ex.Message}");
        }
        finally
        {
            //释放资源
            stream.Close();
        }
        return result;
    }

    public string HttpPost(string uri,string postheader)
    {
        HttpWebRequest req;
        string result = "";
        try
        {
            req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "POST";
            req.ContentType = "application/json";
            req.Headers.Add("Cookie",_cookie);
            byte[] data = Encoding.UTF8.GetBytes(postheader);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
                stream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "  -  " + ex.GetType());
        }

        return result;
    }

    public SignModels Send(string? gametype = ApiConstant.MiHoYoSignApi)
    {
        return SendAsync(gametype).Result;
    }

    public async Task<SignModels> SendAsync(string? gametype = ApiConstant.MiHoYoSignApi)
    {
#pragma warning disable CS8603
        return await Task.Run((() =>
        {
            var json = SendJson(gametype);
            var deserialize = JsonConvert.DeserializeObject<SignModels>(json);
            if (deserialize.Returncode is -100 && deserialize.ReturnMessage is "登录失效，请重新登录" &&
                deserialize.ReturnData is null)
                throw new NullReferenceException($"淦，返回码为-100，可能是你的cookie失效了，详细的返回信息：{deserialize.ReturnMessage}");
            return deserialize;
        }));
#pragma warning restore CS8603
    }

    public string SendJson(string? gametype = ApiConstant.MiHoYoSignApi)
    {
        return HttpGet(gametype);
    }
}