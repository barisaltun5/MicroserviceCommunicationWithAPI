using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Models.RequestModels
{
    public class OrderRequestModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
    }
}
