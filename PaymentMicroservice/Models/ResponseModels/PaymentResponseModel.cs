﻿using PaymentMicroservice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroservice.Models.ResponseModels
{
    public class PaymentResponseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
