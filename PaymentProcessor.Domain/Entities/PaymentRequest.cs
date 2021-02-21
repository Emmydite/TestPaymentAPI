using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PaymentProcessor.Domain.ProcessPaymentEnums;

namespace PaymentProcessor.Domain.Entities
{
   public class PaymentRequest
    {
        public Guid PaymentId { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public PaymentStatus PaymentState { get; set; }
    }
}
