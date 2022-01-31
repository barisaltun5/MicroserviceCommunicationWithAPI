using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Models.ResponseModels
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }
    }
}
