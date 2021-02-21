using AutoMapper;
using PaymentProcessor.API.Models;
using PaymentProcessor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaymentRequestPayLoad, PaymentRequest>();
        }
    }
}
