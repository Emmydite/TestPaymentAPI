using PaymentProcessor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.Persistence.Repositories
{
    public interface IPaymentRepository : IRepository<PaymentRequest>
    {

    }
}
