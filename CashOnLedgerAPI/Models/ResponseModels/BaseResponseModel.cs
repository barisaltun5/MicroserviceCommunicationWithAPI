using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Models.ResponseModels
{
    public class BaseResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object? StatusCode { get; set; } = HttpStatusCode.OK;
        public object Data { get; set; }
    }
    public class BaseResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object? StatusCode { get; set; } = HttpStatusCode.OK;
        public T Data { get; set; }
    }
    public class MessageModel
    {
        public string Message { get; set; }
    }
}
