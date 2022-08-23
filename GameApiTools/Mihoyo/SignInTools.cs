using GameApiTools.Module.Constants;
using GameApiTools.Module.Helper;
using GameApiTools.Module.Models.MiHoYo;

namespace GameApiTools.Mihoyo;

/// <summary>
/// 签到工具类
/// </summary>
public class SignInTools
{
            private static readonly string Referer =
            $"{ApiConstant.ReferBaseUrl}?bbs_auth_required=true&act_id={ApiConstant.ActivityId}&utm_source=bbs&utm_medium=mys&utm_campaign=icon";

        private readonly string cookie;

        public SignInTools(string cookie)=> this.cookie = cookie;
        /// <summary>
        /// 签到通用请求器
        /// </summary>
        private Requester SignInRequester
        {
            get
            {
                return new(new RequestOptions
                {
                    {"DS", DynamicSecretProvider.Create() },
                    {"x-rpc-app_version", DynamicSecretProvider.AppVersion },
                    {"User-Agent", RequestOptions.CommonUA2281 },
                    {"x-rpc-device_id", RequestOptions.DeviceId },
                    {"Accept", RequestOptions.Json },
                    {"x-rpc-client_type", "5" },
                    {"Referer", Referer },
                    {"Cookie", cookie },
                    {"X-Requested-With", RequestOptions.Hyperion }
                });
            }
        }

        /// <summary>
        /// 获取当前签到信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<SignInInfo?> GetSignInInfoAsync(UserGameRole role, CancellationToken cancellationToken = default)
        {
            Requester requester = new(new RequestOptions
            {
                {"Accept", RequestOptions.Json },
                {"User-Agent",RequestOptions.CommonUA2101 },
                {"x-rpc-device_id", RequestOptions.DeviceId },
                {"Referer", Referer },
                {"Cookie", cookie },
                {"X-Requested-With", RequestOptions.Hyperion }
            });
            string query = $"act_id={ApiConstant.ActivityId}&region={role.Region}&uid={role.GameUid}";
            ResponseModels<SignInInfo>? resp = await requester
                .GetAsync<SignInInfo>($"{ApiConstant.ApiTakumi}/event/bbs_sign_reward/info?{query}", cancellationToken)
                .ConfigureAwait(false);
            return resp?.Data;
        }

        /// <summary>
        /// 获取当前补签信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<ReSignInfo?> GetReSignInfoAsync(UserGameRole role, CancellationToken cancellationToken = default)
        {
            Requester requester = new(new RequestOptions
            {
                {"Accept", RequestOptions.Json },
                {"User-Agent",RequestOptions.CommonUA2101 },
                {"Referer", Referer },
                {"Cookie", cookie },
                {"X-Requested-With", RequestOptions.Hyperion }
            });
            string query = $"act_id={ApiConstant.ActivityId}&region={role.Region}&uid={role.GameUid}";
            ResponseModels<ReSignInfo>? resp = await requester
                .GetAsync<ReSignInfo>($"{ApiConstant.ApiTakumi}/event/bbs_sign_reward/resign_info?{query}", cancellationToken)
                .ConfigureAwait(false);
            return resp?.Data;
        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<(bool IsOk, string Result)> SignInAsync(UserGameRole role, CancellationToken cancellationToken = default)
        {
            var data = new { act_id = ApiConstant.ActivityId, region = role.Region, uid = role.GameUid };
            Requester requester = SignInRequester;
            ResponseModels<SignInResult>? resp = await requester
                .PostAsync<SignInResult>($"{ApiConstant.ApiTakumi}/event/bbs_sign_reward/sign", data, cancellationToken)
                .ConfigureAwait(false);

            if (resp == null)
            {
                return (false, "请求失败");
            }
            else
            {
                if (resp.Data == null)
                {
                    return resp.ReturnCode switch
                    {
                        0 => (true, "签到成功"),
                        -5003 => (true, resp.Message!),
                        _ => (false, resp.Message!),
                    };
                }
                else
                {
                    if (resp.Data.RiskCode == 0 && resp.Data.Success == 0)
                    {
                        return (true, "签到成功");
                    }
                    else
                    {
                        return (false, $"[RiskCode: {resp.Data.RiskCode} | Success: {resp.Data.Success}] 账号受到风控!");
                    }
                }
            }
        }

        /// <summary>
        /// 补签
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<string> ReSignAsync(UserGameRole role, CancellationToken cancellationToken = default)
        {
            var data = new { act_id = ApiConstant.ActivityId, region = role.Region, uid = role.GameUid };
            Requester requester = SignInRequester;
            ResponseModels<SignInResult>? resp = await requester
                .PostAsync<SignInResult>($"{ApiConstant.ApiTakumi}/event/bbs_sign_reward/resign", data, cancellationToken)
                .ConfigureAwait(false);
            return resp is null ? "签到失败" : resp.Message ?? "签到成功";
        }
}