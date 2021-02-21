using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PaymentProcessor.Domain.ProcessPaymentEnums;

namespace PaymentProcessor.API.Models
{
    public class PaymentRequestPayLoad
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
