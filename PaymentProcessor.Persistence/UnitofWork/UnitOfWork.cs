using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Persistence.Contexts;
using PaymentProcessor.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Persistence.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private  DbContext _context;
        public IPaymentRepository PaymentRequests { get; }


        public UnitOfWork(DbContext context,
               IPaymentRepository PaymentRequestRepo
               )
        {
            _context = context;
            PaymentRequests = PaymentRequestRepo;
        }

        public async Task Complete()
        {
            //await _context.SaveChangesAsync();
            await PaymentRequests.SaveAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
