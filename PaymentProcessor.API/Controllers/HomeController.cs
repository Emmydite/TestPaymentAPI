using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessor.API.Helpers;
using PaymentProcessor.API.Models;
using PaymentProcessor.API.Services;

namespace PaymentProcessor.API.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IPaymentService _paymentService;
        public HomeController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            return View("Home");
        }

        [HttpPost]
        [Route("api/pay")]
        public async Task<IActionResult> Pay(PaymentRequestPayLoad payLoad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _paymentService.ProcessPayMent(payLoad);

                    return Ok(res);
                }
                else
                {
                    var resp = new ResponseObject
                    {
                        Code = ResponseCodes.InvalidRequest,
                        Message = "Invalid Request"
                    };
                    return BadRequest(resp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
