using OrderMicroservice.Models.RequestModels;
using OrderMicroservice.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroservice.ApiFunctions
{
    public class OrderAPICaller : BaseAPICaller
    {
        public OrderAPICaller()
        {
            resource = "/api";
        }
        public BaseResponseModel<Payment> CheckStatus(OrderResponseModel model)
        {
            var request = Request(RestSharp.Method.POST, "orderstatus", model);
            var result = Response<Payment>(request);
            return result;
        }
    }
}
