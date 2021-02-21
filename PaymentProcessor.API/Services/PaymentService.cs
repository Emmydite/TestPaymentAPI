using AutoMapper;
using PaymentProcessor.API.Helpers;
using PaymentProcessor.API.Models;
using PaymentProcessor.API.PaymentGateways;
using PaymentProcessor.Domain.Entities;
using PaymentProcessor.Persistence.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.API.Services
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ICheapPaymentGateway _iCheap;
        private readonly IExpensivePaymentGateway _iExpen;
        private readonly PremiumPaymentService _premium;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, 
            ICheapPaymentGateway cheapPaymentGateway,
            IExpensivePaymentGateway expensivePaymentGateway,
            PremiumPaymentService premiumPaymentService,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _iCheap = cheapPaymentGateway;
            _iExpen = expensivePaymentGateway;
            _premium = premiumPaymentService;
            _mapper = mapper;
        }

        public async Task<ResponseObject> ProcessPayMent(PaymentRequestPayLoad payLoad)
        {
            try
            {
                var respObj = new ResponseObject();

                if (payLoad != null)
                {

                        if(payLoad.Amount < 20)
                        {
                        // process with ICheapPaymentGateway
                        var resp = await _iCheap.InitiatePayment(payLoad);
                        if(resp.Status == "00" && resp.Message == "Successful")
                        {
                            var payloadReq = new PaymentRequestPayLoad
                            {
                                CreditCardNumber = payLoad.CreditCardNumber,
                                CardHolder = payLoad.CardHolder,
                                ExpirationDate = payLoad.ExpirationDate,
                                SecurityCode = payLoad.SecurityCode,
                                Amount = payLoad.Amount,
                                PaymentState = Domain.ProcessPaymentEnums.PaymentStatus.Processed
                            };

                             var mappedReq = _mapper.Map<PaymentRequest>(payloadReq);
                             await _unitOfWork.PaymentRequests.Add(mappedReq);
                             await _unitOfWork.Complete();

                            respObj.Code = ResponseCodes.Ok;
                            respObj.Message = "Successfull";

                            return respObj;
                        }
                        else
                        {
                            var payloadReq = new PaymentRequestPayLoad
                            {
                                CreditCardNumber = payLoad.CreditCardNumber,
                                CardHolder = payLoad.CardHolder,
                                ExpirationDate = payLoad.ExpirationDate,
                                SecurityCode = payLoad.SecurityCode,
                                Amount = payLoad.Amount,
                                PaymentState = Domain.ProcessPaymentEnums.PaymentStatus.Failed
                            };

                            var mappedReq = _mapper.Map<PaymentRequest>(payloadReq);
                            await _unitOfWork.PaymentRequests.Add(mappedReq);
                            await _unitOfWork.Complete();

                            respObj.Code = ResponseCodes.InvalidRequest;
                            respObj.Message = "Invalid Request";

                            return respObj;
                        }

                        }

                        if (payLoad.Amount > 20 && payLoad.Amount <= 500)
                        {
                        // process with IExpensivePaymentGateway 
                        var res = await _iExpen.InitiatePayment(payLoad);
                        if (res.Status == "00" && res.Message == "Successful")
                        {
                            var payloadReq = new PaymentRequestPayLoad
                            {
                                CreditCardNumber = payLoad.CreditCardNumber,
                                CardHolder = payLoad.CardHolder,
                                ExpirationDate = payLoad.ExpirationDate,
                                SecurityCode = payLoad.SecurityCode,
                                Amount = payLoad.Amount,
                                PaymentState = Domain.ProcessPaymentEnums.PaymentStatus.Processed
                            };

                            var mappedReq = _mapper.Map<PaymentRequest>(payloadReq);
                            await _unitOfWork.PaymentRequests.Add(mappedReq);
                            await _unitOfWork.Complete();

                            respObj.Code = ResponseCodes.Ok;
                            respObj.Message = "Successfull";

                            return respObj;
                        }
                        else
                        {
                            var payloadReq = new PaymentRequestPayLoad
                            {
                                CreditCardNumber = payLoad.CreditCardNumber,
                                CardHolder = payLoad.CardHolder,
                                ExpirationDate = payLoad.ExpirationDate,
                                SecurityCode = payLoad.SecurityCode,
                                Amount = payLoad.Amount,
                                PaymentState = Domain.ProcessPaymentEnums.PaymentStatus.Failed
                            };

                            var mappedReq = _mapper.Map<PaymentRequest>(payloadReq);
                            await _unitOfWork.PaymentRequests.Add(mappedReq);
                            await _unitOfWork.Complete();

                            respObj.Code = ResponseCodes.InvalidRequest;
                            respObj.Message = "Invalid Request";

                            return respObj;
                        }

                    }


                        if (payLoad.Amount > 500)
                        {
                        // process with PremiumPaymentService 
                        var premRes = await _premium.InitiatePayment(payLoad);
                        if (premRes.Status == "00" && premRes.Message == "Successful")
                        {
                            var payloadReq = new PaymentRequestPayLoad
                            {
                                CreditCardNumber = payLoad.CreditCardNumber,
                                CardHolder = payLoad.CardHolder,
                                ExpirationDate = payLoad.ExpirationDate,
                                SecurityCode = payLoad.SecurityCode,
                                Amount = payLoad.Amount,
                                PaymentState = Domain.ProcessPaymentEnums.PaymentStatus.Processed
                            };

                            var mappedReq = _mapper.Map<PaymentRequest>(payloadReq);
                            await _unitOfWork.PaymentRequests.Add(mappedReq);
                            await _unitOfWork.Complete();

                            respObj.Code = ResponseCodes.Ok;
                            respObj.Message = "Successfull";

                            return respObj;
                        }
                        else
                        {
                            var payloadReq = new PaymentRequestPayLoad
                            {
                                CreditCardNumber = payLoad.CreditCardNumber,
                                CardHolder = payLoad.CardHolder,
                                ExpirationDate = payLoad.ExpirationDate,
                                SecurityCode = payLoad.SecurityCode,
                                Amount = payLoad.Amount,
                                PaymentState = Domain.ProcessPaymentEnums.PaymentStatus.Failed
                            };

                            var mappedReq = _mapper.Map<PaymentRequest>(payloadReq);
                            await _unitOfWork.PaymentRequests.Add(mappedReq);
                            await _unitOfWork.Complete();

                            respObj.Code = ResponseCodes.InvalidRequest;
                            respObj.Message = "Invalid Request";

                            return respObj;
                        }
                    }
                }

                respObj.Code = ResponseCodes.InvalidRequest;
                respObj.Message = "Invalid Request";

                return respObj;
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }
    }
}
