// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Net;
using System.Text;
using GameApiTools.Mihoyo;
using GameApiTools.Minecraft;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Models.MiHoYo;
using Newtonsoft.Json.Linq;

namespace Lab
{
    public static class Lab
    {
        private Dictionary<string, string> postsList = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            SignModels v1  = null;
            var uri = string.Format("{0}{1}", ApiConstant.VersionOptifineListAPiM, "1.16.5");
            SignTools v = new SignTools("DEVICEFP_SEED_TIME=1660639963073; DEVICEFP_SEED_ID=ce391c66d91a9088; _MHYUUID=da91110c-39d4-4843-8c9b-bcd7769bcd8b; DEVICEFP=38d7ead79fb81; login_uid=318173405; login_ticket=v1tTGFCZijfc0FMkYm4irkYigiybw2FqjQQKoitI");
            try
            {
                v1 = v.Send(ApiConstant.MiHoYoSignApi);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // foreach (var v2 in v1)
            // {
            //     Console.WriteLine($"{v2.FileName} - {v2.GameVersion}_{v2.Type}_{v2.Patch}");
            // }
            var v11= string.Format("{0}:{1}","用户名",v1.ReturnData.DataList[0].Nickname);
            var v2= string.Format("{0}:{1}","是否游玩的官服",v1.ReturnData.DataList[0].Isofficial);
            var v3= string.Format("{0}:{1}","当前世界等级",v1.ReturnData.DataList[0].Level);
            var v4= string.Format("{0}:{1}","游戏内Uid",v1.ReturnData.DataList[0].Uid);
            Console.WriteLine(v11);
            Console.WriteLine(v2);
            Console.WriteLine(v3);
            Console.WriteLine(v4);

            Console.ReadKey();
        }
        
        
        
        
        
        
        
        
        
        
        
        
        public static string Get_deviceid()
        {
            return Guid.NewGuid().ToString("D").Replace("-", "").ToUpper();
        }

        public static string Get_item(JToken raw_data)
        {
            string temp_Name = raw_data["name"].ToString();
            string temp_Cnt = raw_data["cnt"].ToString();
            return $"{temp_Name}x{temp_Cnt}";
        }
        
        
        
        
        public static bool enable_Config = true;
        public static int config_Version = 4;
        public static string mihoyobbs_Login_ticket = "";
        public static string mihoyobbs_Stuid = "";
        public static string mihoyobbs_Stoken = "";
        public static string mihoyobbs_Cookies = "";
 static
        public static bool bbs_Global = true;
        public static bool bbs_Signin = true;
        public static bool bbs_Signin_multi = true;
        public static ArrayList bbs_Signin_multi_list = new ArrayList();
        public static bool bbs_Read_posts = true;
        public static bool bbs_Like_posts = true;
        public static bool bbs_Unlike = true;
        public static bool bbs_Share = true;
        public static bool genshin_Auto_sign = true;
        public static bool honkai3rd_Auto_sign = false;

        public static JObject mihoyobbs_List;

        private static string config_name { get; set; }
        
        private static string path { get; set; }
        // 米游社的Salt
        public static string mihoyobbs_Salt = "fd3ykrh7o1j54g581upo1tvpam0dsgtf";
        public static string mihoyobbs_Salt_web = "14bmu1mz0yuljprsfgpvjh3ju2ni468r";
        public static string mihoyobbs_Salt_web_old = "h8w582wxwgqvahcdkpvdhbh2w9casgfl";
        //米游社的版本
        public static string mihoyobbs_Version = "2.7.0"; //Slat和Version相互对应
        public static string mihoyobbs_Version_old = "2.3.0";
        //米游社的客户端类型
        public static string mihoyobbs_Client_type = "2"; //1为ios 2为安卓
        public static string mihoyobbs_Client_type_web = "5"; //4为pc web 5为mobile web
        //米游社的分区列表
        //米游社的API列表
        public static string bbs_Cookieurl = "https://webapi.account.mihoyo.com/Api/cookie_accountinfo_by_loginticket?login_ticket={0}";
        public static string bbs_Cookieurl2 = "https://api-takumi.mihoyo.com/auth/api/getMultiTokenByLoginTicket?login_ticket={0}&token_types=3&uid={1}";
        public static string bbs_Taskslist = "https://bbs-api.mihoyo.com/apihub/sapi/getUserMissionsState"; //获取任务列表
        public static string bbs_Signurl = "https://bbs-api.mihoyo.com/apihub/sapi/signIn?gids={0}";  // post
        public static string bbs_Listurl = "https://bbs-api.mihoyo.com/post/api/getForumPostList?forum_id={0}&is_good=false&is_hot=false&page_size=20&sort_type=1";
        public static string bbs_Detailurl = "https://bbs-api.mihoyo.com/post/api/getPostFull?post_id={0}";
        public static string bbs_Shareurl = "https://bbs-api.mihoyo.com/apihub/api/getShareConf?entity_id={0}&entity_type=1";
        public static string bbs_Likeurl = "https://bbs-api.mihoyo.com/apihub/sapi/upvotePost";  // post json 

        //Config Load之后run里面进行列表的选择
        public static ArrayList mihoyobbs_List_Use = new ArrayList();
        
        private void Getlist()
        {
            Console.WriteLine("正在获取帖子列表......");
            string rawdata = http_Get1(String.Format(bbs_Listurl, mihoyobbs_List[mihoyobbs_List_Use[0].ToString()]["forumId"].ToString()));
            //Console.WriteLine(rawdata);
            JObject jobject = JObject.Parse(rawdata);
            for (int i = 1; i <= 5; i++)
            {
                this.postsList.Add(jobject["data"]["list"][i]["post"]["post_id"].ToString(), jobject["data"]["list"][i]["post"]["subject"].ToString());
            }
            Console.WriteLine($"已获取{this.postsList.Count}个帖子");
        }
        
                public static string http_Get1(string url)
        {
            //初始化缓存
            HttpWebRequest req = null;
            HttpWebResponse res = null;

            string content = string.Empty;

            try
            {
                //Header
                req = WebRequest.CreateHttp(url);
                req.Method = "GET";

                req.UserAgent = "okhttp/4.8.0";
                req.Headers.Add("DS", Get_ds(false, false));
                req.Headers.Add("cookie", $"stuid={mihoyobbs_Stuid};stoken={mihoyobbs_Stoken}");
                req.Headers.Add("x-rpc-client_type", mihoyobbs_Client_type);
                req.Headers.Add("x-rpc-app_version", mihoyobbs_Version);
                req.Headers.Add("x-rpc-sys_version", "6.0.1");
                req.Headers.Add("x-rpc-channel", "mihoyo");
                req.Headers.Add("x-rpc-device_id", Get_deviceid());
                req.Headers.Add("x-rpc-device_name", CreateRandomString(new Random().Next(1, 10)));
                req.Headers.Add("x-rpc-device_model", "Mi 10");
                req.Headers.Add("Referer", "https://app.mihoyo.com");
                req.Headers.Add("Host", "bbs-api.mihoyo.com");
                //req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                //req.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,en-US;q=0.8");

            }
            catch (Exception e)
            {
                Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
            }

            try
            {
                res = req.GetResponse() as HttpWebResponse;

                if (!(res.StatusCode.ToString() == "OK"))
                {
                    Console.WriteLine("数据获取错误,错误码:" + res.StatusCode.ToString());
                    return "Error";
                }

                StreamReader streamReader = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                content = streamReader.ReadToEnd();
                //Console.WriteLine(content);

                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
            }

            return null;

        }
                
                public static string CreateRandomString(int length)
                {
                    StringBuilder builder = new StringBuilder(length);

                    const string randomStringTemplate = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    Random random = new Random();
                    for (int i = 0; i < length; i++)
                    {
                        int pos = random.Next(0, randomStringTemplate.Length);
                        builder.Append(randomStringTemplate[pos]);
                    }

                    return builder.ToString();
                }
    }
}
