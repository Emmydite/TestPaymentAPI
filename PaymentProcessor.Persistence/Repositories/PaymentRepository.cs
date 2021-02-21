using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Domain.Entities;
using PaymentProcessor.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Persistence.Repositories
{
   public class PaymentRepository : Repository<PaymentRequest>, IPaymentRepository
    {
        public PaymentRepository(DbContext context) : base(context)
        {

        }

    }
}
