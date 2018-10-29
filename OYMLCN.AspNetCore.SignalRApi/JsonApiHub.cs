using Microsoft.AspNetCore.Mvc;
using OYMLCN.SignalRApi;
using System.Collections.Generic;

namespace OYMLCN.AspNetCore.SignalRApi
{
    /// <summary>
    /// Json接口通用
    /// </summary>
    [Produces("application/json")]
    public class JsonApiHub : Controller
    {
        private List<PartialResponse> RspList = new List<PartialResponse>();

        /// <summary>
        /// 部分结果
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        protected void PartialResponse(string name, params object[] data) => RspList.Add(new PartialResponse(name, data));
        /// <summary>
        /// 部分错误
        /// </summary>
        /// <param name="msg"></param>
        protected void PartialError(string msg) => RspList.Add(new PartialResponse(500, msg));
        /// <summary>
        /// 最终返回
        /// </summary>
        /// <returns></returns>
        protected JsonResult JsonApiResult => Json(new ResponseResult<PartialResponse[]>(RspList.ToArray()));
    }
}
