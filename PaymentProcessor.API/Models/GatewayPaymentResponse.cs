using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.API.Models
{
    public class GatewayPaymentResponse
    {
            public string Status { get; set; }
            public string Message { get; set; }
    }
}
