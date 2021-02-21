using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentProcessor.API.PaymentGateways;
using PaymentProcessor.API.Services;
using PaymentProcessor.Persistence.Contexts;
using PaymentProcessor.Persistence.Repositories;
using PaymentProcessor.Persistence.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.API
{
    public partial class Startup
    {
        public IServiceCollection ConfigureDIServices(IServiceCollection services)
        {

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<ICheapPaymentGateway, ICheapPaymentGateway>();
            services.AddTransient<IExpensivePaymentGateway, IExpensivePaymentGateway>();
            services.AddTransient<PremiumPaymentService, PremiumPaymentService>();
            services.AddTransient<DbContext, PaymentProcessorDBContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
