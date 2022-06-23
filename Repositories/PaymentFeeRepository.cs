using Microsoft.EntityFrameworkCore;
using RapidPay.Database;
using RapidPay.Models;
using RapidPay.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPay.Repositories
{
    public class PaymentFeeRepository : IPaymentFeeRepository
    {
        private readonly RapidPayContext  _context;

        public PaymentFeeRepository(RapidPayContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentFee>> CalculatePaymentFees(IEnumerable<PaymentFee> paymentFees)
        {
            await _context.AddRangeAsync(paymentFees);
            return paymentFees;
        }  

        public async Task<decimal> GetLastPaymentFee()
        {
            return await GetLastPaymentAmount();
        }

        public async Task<IEnumerable<PaymentFee>> GetPaymentFees()
        {
            return await _context.PaymentsFee
                          .ToListAsync();
        }

        private Task<decimal> GetLastPaymentAmount()
        {
            var lastFee = _context.PaymentsFee
                              .LastOrDefault();

            return Task.FromResult(lastFee.FeeAmount);
        }
    }
}
