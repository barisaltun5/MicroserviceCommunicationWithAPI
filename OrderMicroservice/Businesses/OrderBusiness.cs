using Newtonsoft.Json;
using OrderMicroservice.ApiFunctions;
using OrderMicroservice.DAL.Entities;
using OrderMicroservice.Models.RequestModels;
using OrderMicroservice.Models.ResponseModels;
using OrderMicroservice.Repositories;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Businesses
{
    public class OrderBusiness : BaseBusiness
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderAPICaller _apiCaller;
        public OrderBusiness(OrderRepository orderRepository, OrderAPICaller orderAPICaller)
        {
            _orderRepository = orderRepository;
            _apiCaller = orderAPICaller;
        }
        public OrderBusiness()
        {

        }
        public BaseResponseModel CreateOrder(OrderRequestModel order)
        {
            try
            {
                var result = _orderRepository.InsertOrder(order);
                if (result == null)
                {
                    return ResponseIsFailed("Error", null, null);
                }
                var response = _apiCaller.CheckStatus(result);
                if (response.Data != null)
                {
                    var isUpdated = _orderRepository.UpdateOrder(response.Data);
                    if(isUpdated)
                    return ResponseIsSuccess("Status Updated Succesed");
                }
                return ResponseIsFailed("Status Update Failed", null, null);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message + " " + ex.InnerException);
                return ResponseCatch();
            }

        }
    }
}
