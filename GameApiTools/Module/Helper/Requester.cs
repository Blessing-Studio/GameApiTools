using System.Net;
using System.Text;
using GameApiTools.Module.Constants;
using GameApiTools.Module.Models;
using GameApiTools.Module.Models.MiHoYo;
using Newtonsoft.Json;

namespace GameApiTools.Module.Helper;

    /// <summary>
    /// MiHoYo API 专用请求器
    /// 同一个 <see cref="Requester"/> 若使用一代动态密钥不能长时间使用
    /// </summary>
    public class Requester
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use.
        private static readonly Lazy<HttpClient> LazyHttpClient = new(() => new() { Timeout = Timeout.InfiniteTimeSpan });
        private static readonly Lazy<HttpClient> LazyGZipCompressionHttpClient = new(() =>
        {
            return new(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
            })
            {
                Timeout = Timeout.InfiniteTimeSpan,
            };
        });

        /// <summary>
        /// 构造一个新的 <see cref="Requester"/> 对象
        /// </summary>
        public Requester()
        {
        }

        /// <summary>
        /// 构造一个新的 <see cref="Requester"/> 对象
        /// </summary>
        /// <param name="headers">请求头</param>
        public Requester(RequestOptions headers)
        {
            Headers = headers;
        }

        /// <summary>
        /// 构造一个新的 <see cref="Requester"/> 对象
        /// </summary>
        /// <param name="headers">请求头</param>
        /// <param name="useGZipCompression">使用GZip压缩</param>
        public Requester(RequestOptions headers, bool useGZipCompression)
        {
            Headers = headers;
            UseGZipCompression = useGZipCompression;
        }

        /// <summary>
        /// 响应失败回调
        /// </summary>
        public static Action<System.Exception, string, string>? ResponseFailedAction { get; set; }

        /// <summary>
        /// 请求头
        /// </summary>
        public RequestOptions Headers { get; set; } = new RequestOptions();

        /// <summary>
        /// 使用GZip压缩
        /// </summary>
        public bool UseGZipCompression { get; }

        /// <summary>
        /// 使用授权头
        /// </summary>
        public bool UseAuthToken { get; set; }

        /// <summary>
        /// 验证令牌
        /// </summary>
        public string? AuthToken { get; set; }

        /// <summary>
        /// GET 操作
        /// </summary>
        /// <typeparam name="TResult">返回的类类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>响应</returns>
        public async Task<ResponseModels<TResult>?> GetAsync<TResult>(string? url, CancellationToken cancellationToken = default)
        {
            return url is null
                ? null
                : await RequestAsync<TResult>(
                    client => new RequestInfo("GET", url, () => client.GetAsync(url, cancellationToken)),
                    cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <summary>
        /// POST 操作
        /// </summary>
        /// <typeparam name="TResult">返回的类类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="data">要发送的.NET（匿名）对象</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>响应</returns>
        public async Task<ResponseModels<TResult>?> PostAsync<TResult>(string? url, object data, CancellationToken cancellationToken = default)
        {
            string dataString = data.ToString();
            return url is null
                ? null
                : await RequestAsync<TResult>(
                    client => new RequestInfo("POST", url, () => client.PostAsync(url, new StringContent(dataString), cancellationToken)),
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// POST 操作,Content-Type
        /// </summary>
        /// <typeparam name="TResult">返回的类类型</typeparam>
        /// <param name="url">地址</param>
        /// <param name="data">要发送的.NET（匿名）对象</param>
        /// <param name="contentType">内容类型</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>响应</returns>
        public async Task<ResponseModels<TResult>?> PostAsync<TResult>(string? url, object data, string contentType, CancellationToken cancellationToken = default)
        {
            string dataString = data.ToString();
            return url is null
                ? null
                : await RequestAsync<TResult>(
                    client => new RequestInfo("POST", url, () => client.PostAsync(url, new StringContent(dataString, Encoding.UTF8, contentType), cancellationToken)),
                    cancellationToken)
                .ConfigureAwait(false);
        }

        private async Task<ResponseModels<TResult>?> RequestAsync<TResult>(Func<HttpClient, RequestInfo> requestFunc, CancellationToken cancellationToken = default)
        {
            RequestInfo? info = null;

            HttpClient client = UseGZipCompression
                ? LazyGZipCompressionHttpClient.Value
                : LazyHttpClient.Value;

            client.DefaultRequestHeaders.Clear();

            if (UseAuthToken)
            {
                client.DefaultRequestHeaders.Authorization = new("Bearer", AuthToken);
            }

            foreach ((string name, string value) in Headers)
            {
                client.DefaultRequestHeaders.Add(name, value);
            }

            info = requestFunc(client);

            try
            {
                HttpResponseMessage response = await info.RequestAsyncFunc.Invoke()
                    .ConfigureAwait(false);
                HttpContent content = response.Content;
                string contentString = await content.ReadAsStringAsync(cancellationToken)
                    .ConfigureAwait(false);
            Console.WriteLine(contentString);
                return JsonConvert.DeserializeObject<ResponseModels<TResult>>(contentString);
            }
            catch (System.Exception ex)
            {
                string httpMethod = $"[{info?.Method} {info?.Url.Split('?')[0]}]";
                ResponseFailedAction?.Invoke(ex, httpMethod, "failed");
                Console.WriteLine("Cnm");
                return ResponseModels<TResult>.CreateFail($"{ex.Message}");
            }
        }
    }