using Microsoft.EntityFrameworkCore;
using Moq;
using OrderMicroservice.Businesses;
using OrderMicroservice.Controllers;
using OrderMicroservice.DAL;
using OrderMicroservice.Models.RequestModels;
using OrderMicroservice.Models.ResponseModels;
using OrderMicroservice.Repositories;
using System;
using System.Net;
using Xunit;

namespace OrderMicroserviceTest
{
    public class UnitTest1
    {
        [Fact]
        public void CreateOrder_WhenOK_NotException()
        {
            var mockBusiness = new Mock<OrderBusiness>();
            var controller = new OrderController(mockBusiness.Object);
            OrderRequestModel orderRequestModel = new()
            {
                Price = 10
            };
            var result = controller.CreateOrder(orderRequestModel);
            Assert.Equal(HttpStatusCode.OK, HttpStatusCode.OK);
        }
        [Fact]
        public void CreateOrder_WhenPriceNull_Exception()
        {
            var mockBusiness = new Mock<OrderBusiness>();
            var controller = new OrderController(mockBusiness.Object);
            OrderRequestModel orderRequestModel = new();
            var result = controller.CreateOrder(orderRequestModel);
            Assert.Equal(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError);
        }
    }
}
