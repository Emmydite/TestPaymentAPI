using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PaymentProcessor.Domain.ProcessPaymentEnums;

namespace PaymentProcessor.API.Models
{
    public class PaymentStateModel
    {
        public Guid PaymentStateId { get; set; }
        public Guid PaymentId { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
