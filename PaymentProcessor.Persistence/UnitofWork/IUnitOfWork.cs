using PaymentProcessor.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Persistence.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPaymentRepository PaymentRequests { get; }
        Task Complete();
    }
}
