using CashOnLedgerAPI.Models.RequestModels;
using CashOnLedgerAPI.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Services
{
    public class HomeService : BaseService
    {
        protected readonly string _BASE_URL;
        protected readonly string _API_TOKEN;
        public HomeService()
        {
            resource = "/payment";
        }
        public BaseResponseModel<Payment> CheckStatus(OrderRequestModel model)
        {
            var request = Request(RestSharp.Method.POST, "create", model);
            var result = Response<Payment>(request);
            return result;
        }
    }
}
