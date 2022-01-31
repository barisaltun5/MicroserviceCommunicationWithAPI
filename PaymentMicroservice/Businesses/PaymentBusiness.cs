using PaymentMicroservice.Models.RequestModels;
using PaymentMicroservice.Models.ResponseModels;
using PaymentMicroservice.Repositories;
using System;

namespace PaymentMicroservice.Businesses
{
    public class PaymentBusiness : BaseBusiness
    {
        private readonly PaymentRepository _paymentRepository;
        public PaymentBusiness(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public PaymentBusiness()
        {
            //for moq 
        }
        public BaseResponseModel CreatePayment(Order order)
        {
            try
            {
                var result = _paymentRepository.InsertPayment(order);
                if (result == null)
                {
                    return ResponseIsFailed("Error", null, null);
                }
                    return ResponseIsSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message + " " + ex.InnerException);
                return ResponseCatch();
            }
        }
    }
}
