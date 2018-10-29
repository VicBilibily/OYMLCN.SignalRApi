using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace OYMLCN.SignalRApi
{
    /// <summary>
    /// JsonApiClient
    /// </summary>
    public partial class JsonApiClient
    {
        private string HubUrl;
        /// <summary>
        /// 全局连接
        /// </summary>
        public readonly HttpClient HttpClient;
        /// <summary>
        /// 全局Cookie
        /// </summary>
        public readonly CookieContainer CookieContainer;

        private readonly Dictionary<int, Action<ResponseResult<PartialResponse[]>>> ResponseHandlers;
        private readonly Dictionary<int, Action<PartialResponse>> PartialErrorHandlers;
        private readonly Dictionary<string, Action<PartialResponse>> PartialHandlers;
        /// <summary>
        /// JsonApi方法封装
        /// </summary>
        /// <param name="hubUrl">通讯Url</param>
        /// <param name="timeout">请求超时(秒)</param>
        public JsonApiClient(string hubUrl, double timeout = 10)
        {
            HubUrl = hubUrl;
            CookieContainer = new CookieContainer();
            HttpClient = new HttpClient(new HttpClientHandler
            {
                CookieContainer = CookieContainer,
                UseCookies = true,
            })
            {
                Timeout = TimeSpan.FromSeconds(timeout)
            };
            ResponseHandlers = new Dictionary<int, Action<ResponseResult<PartialResponse[]>>>();
            PartialErrorHandlers = new Dictionary<int, Action<PartialResponse>>();
            PartialHandlers = new Dictionary<string, Action<PartialResponse>>();
        }

        //public async Task<ResponseResult<T>> GetAsync<T>(string url)
        //{
        //    return await HttpClient
        //        .GetStringAsync(url)
        //        .ContinueWith((rsp) =>
        //        {
        //            return rsp.Result.DeserializeJsonToObject<ResponseResult<T>>();
        //        });
        //}

        //public async Task<ResponseResult<T>> PostAsync<T>(string url, object obj) where T : class
        //{
        //    return await await HttpClient
        //        .PostAsync(url, new StringContent(obj.ToJsonString(), Encoding.UTF8, "application/json"))
        //        .ContinueWith((rsp) =>
        //        {
        //            return rsp.Result.Content.ReadAsStringAsync().ContinueWith((str) =>
        //            {
        //                return str.Result.DeserializeJsonToObject<ResponseResult<T>>();
        //            });
        //        });
        //}

        //public async Task<ResponseResult<T>> PutAsync<T>(string url, object obj) where T : class
        //{
        //    return await await HttpClient
        //        .PutAsync(url, new StringContent(obj.ToJsonString(), Encoding.UTF8, "application/json"))
        //        .ContinueWith((rsp) =>
        //        {
        //            return rsp.Result.Content.ReadAsStringAsync().ContinueWith((str) =>
        //            {
        //                return str.Result.DeserializeJsonToObject<ResponseResult<T>>();
        //            });
        //        });
        //}

        //public async Task<ResponseResult<T>> DeleteAsync<T>(string url) where T : class
        //{
        //    return await await HttpClient
        //        .DeleteAsync(url)
        //        .ContinueWith((rsp) =>
        //        {
        //            return rsp.Result.Content.ReadAsStringAsync().ContinueWith((str) =>
        //            {
        //                return str.Result.DeserializeJsonToObject<ResponseResult<T>>();
        //            });
        //        });
        //}

    }
}
