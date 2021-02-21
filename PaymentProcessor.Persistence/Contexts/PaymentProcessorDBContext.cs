using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Domain.Entities;
using PaymentProcessor.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.Persistence.Contexts
{
   public class PaymentProcessorDBContext : DbContext
    {
        public PaymentProcessorDBContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<PaymentRequest> paymentRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentRequestConfiguration());
        }
    }
}
