using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentProcessor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.Persistence.Configurations
{
    public class PaymentRequestConfiguration : IEntityTypeConfiguration<PaymentRequest>
    {
        public void Configure(EntityTypeBuilder<PaymentRequest> builder)
        {
            builder.HasKey(e => e.PaymentId);
            builder.Property(e => e.CreditCardNumber).IsRequired();
            builder.Property(e => e.CardHolder).IsRequired();
            builder.Property(e => e.ExpirationDate).IsRequired();
            builder.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18, 2)");

        }
    }
}
