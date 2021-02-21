using PaymentProcessor.API.Helpers;
using PaymentProcessor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.API.PaymentGateways
{
    public class PremiumPaymentService
    {

        public async Task<GatewayPaymentResponse> InitiatePayment(PaymentRequestPayLoad payLoad)
        {
            //Validate card
            var isValidCard = CardValidation.IsValidCreditCard(payLoad.CreditCardNumber, payLoad.ExpirationDate.ToString());

            //check for positive amount
            var isPositive = payLoad.Amount > 0;

            if (isValidCard && isPositive)
            {
                payLoad.CreditCardNumber = payLoad.CreditCardNumber.Replace("-", "").Trim();

                var cardObj = new PaymentRequestPayLoad
                {
                    CreditCardNumber = payLoad.CreditCardNumber,
                    CardHolder = payLoad.CardHolder,
                    ExpirationDate = payLoad.ExpirationDate,
                    SecurityCode = payLoad.SecurityCode,
                    Amount = payLoad.Amount
                };

                //send payload to provider endpoint 
                //And deserialize response

                var response = new GatewayPaymentResponse
                {
                    Status = "00",
                    Message = "Successful"
                };

                return response;
            }
            else
            {
                var response = new GatewayPaymentResponse
                {
                    Status = "02",
                    Message = "Failed"
                };

                return response;
            }
        }
    }
}
