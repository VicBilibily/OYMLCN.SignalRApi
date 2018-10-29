#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
using Newtonsoft.Json.Linq;
using OYMLCN.Extensions;

namespace OYMLCN.SignalRApi
{
    /// <summary>
    /// 接口回应基础信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResult<T>
    {
        /// <summary>
        /// 基础信息
        /// </summary>
        public ResponseResult() { }
        /// <summary>
        /// 基础信息
        /// </summary>
        /// <param name="data"></param>
        public ResponseResult(T data) => this.data = data;
        /// <summary>
        /// 返回码
        /// </summary>
        public int code { get; set; } = 0;
        /// <summary>
        /// 请求源
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }
    }

    /// <summary>
    /// 基础消息
    /// </summary>
    public class ResponseResult : ResponseResult<object> { }

    /// <summary>
    /// 部分响应
    /// </summary>
    public class PartialResponse
    {
        /// <summary>
        /// 部分响应
        /// </summary>
        public PartialResponse() { }
        /// <summary>
        /// 部分响应
        /// </summary>
        /// <param name="name">部分名称</param>
        /// <param name="data">部分数据</param>
        public PartialResponse(string name, object[] data)
        {
            this.name = name;
            this.data = data;
        }
        /// <summary>
        /// 部分错误
        /// </summary>
        /// <param name="code">错误码</param>
        /// <param name="msg">错误消息</param>
        public PartialResponse(int code = 500, string msg = "Unknown Error")
        {
            this.code = code;
            this.msg = msg;
        }

        /// <summary>
        /// 响应名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 相应代码
        /// </summary>
        public int code { get; set; } = 0;
    }

    /// <summary>
    /// 部分响应
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public class PartialResponse<T1> : PartialResponse
    {
        /// <summary>
        /// 转构数据
        /// </summary>
        /// <param name="rsp"></param>
        public PartialResponse(PartialResponse rsp)
        {
            name = rsp.name;
            data = rsp.data;
            msg = rsp.msg;
            code = rsp.code;
        }
        /// <summary>
        /// 转换数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        protected T ParseToType<T>(object args)
        {
            try
            {
                if (args is T)
                    return (T)args;
                else
                    return args.ToString().DeserializeJsonToObject<T>();
            }
            catch
            {
                return default(T);
            }
        }
        protected JArray jArray => data as JArray;
        public T1 GetT1 => ParseToType<T1>(jArray[0]);
    }
    public class PartialResponse<T1, T2> : PartialResponse<T1>
    {
        public PartialResponse(PartialResponse rsp) : base(rsp) { }
        public T2 GetT2 => ParseToType<T2>(jArray[1]);
    }
    public class PartialResponse<T1, T2, T3> : PartialResponse<T1, T2>
    {
        public PartialResponse(PartialResponse rsp) : base(rsp) { }
        public T3 GetT3 => ParseToType<T3>(jArray[2]);
    }
    public class PartialResponse<T1, T2, T3, T4> : PartialResponse<T1, T2, T3>
    {
        public PartialResponse(PartialResponse rsp) : base(rsp) { }
        public T4 GetT4 => ParseToType<T4>(jArray[3]);
    }
    public class PartialResponse<T1, T2, T3, T4, T5> : PartialResponse<T1, T2, T3, T4>
    {
        public PartialResponse(PartialResponse rsp) : base(rsp) { }
        public T5 GetT5 => ParseToType<T5>(jArray[4]);
    }
    public class PartialResponse<T1, T2, T3, T4, T5, T6> : PartialResponse<T1, T2, T3, T4, T5>
    {
        public PartialResponse(PartialResponse rsp) : base(rsp) { }
        public T6 GetT6 => ParseToType<T6>(jArray[5]);
    }
}
