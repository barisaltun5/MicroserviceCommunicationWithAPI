using Moq;
using PaymentMicroservice.Businesses;
using PaymentMicroservice.Controllers;
using PaymentMicroservice.Models.RequestModels;
using System;
using System.Net;
using Xunit;

namespace PaymentMicroserviceTest
{
    public class PaymentControllerTest
    {
        [Fact]
        public void CreatePayment_WhenOK_NotException()
        {
            var mockBusiness = new Mock<PaymentBusiness>();
            var controller = new PaymentController(mockBusiness.Object);
            Order orderRequestModel = new()
            {
                Id = 10,
                Status = PaymentMicroservice.Models.Enums.PaymentStatus.Waiting,
                CreatedAt = DateTime.Now,
                Price = 13,
                UpdatedAt = null
            };
            var result = controller.CreatePayment(orderRequestModel);
            Assert.Equal(HttpStatusCode.OK, HttpStatusCode.OK);
        }
        [Fact]
        public void CreatePayment_WhenRequestModelNull_Exception()
        {
            var mockBusiness = new Mock<PaymentBusiness>();
            var controller = new PaymentController(mockBusiness.Object);
            var result = controller.CreatePayment(null);
            Assert.Equal(HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError);
        }
    }
}
