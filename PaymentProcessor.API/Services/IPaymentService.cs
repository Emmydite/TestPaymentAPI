using PaymentProcessor.API.Helpers;
using PaymentProcessor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.API.Services
{
    public interface IPaymentService
    {
        Task<ResponseObject> ProcessPayMent(PaymentRequestPayLoad payLoad);
    }
}
