using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.Domain
{
   public class ProcessPaymentEnums
    {
        public enum PaymentStatus
        {
            Processed = 1,
            Pending = 2,
            Failed = 3
        }

        public enum PaymentProviders
        {
            IExpensivePaymentGateway = 1,
            ICheapPaymentGateway = 2
        }
    }
}
