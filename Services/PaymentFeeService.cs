using Microsoft.Extensions.DependencyInjection;
using RapidPay.Models;
using RapidPay.Repositories.Interfaces;
using RapidPay.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class PaymentFeeService : IPaymentFeeService, IDisposable
    {
        private readonly IServiceScope _scope; 
        public PaymentFeeService(IServiceProvider serviceProvider)
        {
            _scope = serviceProvider.CreateScope();
        }

        public async Task<IEnumerable<PaymentFee>> CalculatePaymentFees()
        {
            var paymentFeeRepository = _scope.ServiceProvider.GetRequiredService<IPaymentFeeRepository>();
            var lastpaymentFeeAmount = await paymentFeeRepository.GetLastPaymentFee();
            var payments = await paymentFeeRepository.GetPaymentFees();
            var newFeeAmount = CalculateNewFeeAmount(lastpaymentFeeAmount);
            foreach (var payment in payments)
            {
                payment.FeeAmount = newFeeAmount;
            }
            return await paymentFeeRepository.CalculatePaymentFees(payments);
        } 
        private decimal CalculateNewFeeAmount(decimal lastAmountFee)
        {
            Random random = new Random();
            return Math.Round(Convert.ToDecimal((random.NextDouble() * (2 - 1) + 1)) * lastAmountFee,2);
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }
    }
}
