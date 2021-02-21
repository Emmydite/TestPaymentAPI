using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentProcessor.API.Controllers;
using PaymentProcessor.API.Helpers;
using PaymentProcessor.API.Models;
using PaymentProcessor.API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessorTest
{
    [TestClass]
   public class PaymentUnitTest
    {


        [TestMethod]
        public void Test_CardvalidationPass()
        {
            
            DateTime expDate;
            var date = DateTime.TryParse("11/2021", out expDate);

            var payLoad = new PaymentRequestPayLoad
            {
                CreditCardNumber = "1298536475845982",
                ExpirationDate = expDate,
                SecurityCode = "234",
            };

            var cardVal = CardValidation.IsValidCreditCard(payLoad.CreditCardNumber, payLoad.ExpirationDate.ToString("MM/yyyy"));
            // Assert  
            Assert.AreEqual(true, cardVal);
        }

        [TestMethod]
        public void Test_CardvalidationFail()
        {

            DateTime expDate;
            var date = DateTime.TryParse("11/2021", out expDate);

            var payLoad = new PaymentRequestPayLoad
            {
                CreditCardNumber = "129853647584598",
                ExpirationDate = expDate,
                SecurityCode = "234",
            };

            var cardVal = CardValidation.IsValidCreditCard(payLoad.CreditCardNumber, payLoad.ExpirationDate.ToString("MM/yyyy"));
            // Assert  
            Assert.AreEqual(false, cardVal);
        }
    }


}
