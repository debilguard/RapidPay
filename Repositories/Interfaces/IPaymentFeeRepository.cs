using RapidPay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPay.Repositories.Interfaces
{
    public interface IPaymentFeeRepository
    {
        public Task<IEnumerable<PaymentFee>> CalculatePaymentFees(IEnumerable<PaymentFee> paymentFees);
        public Task<decimal> GetLastPaymentFee();

        public Task<IEnumerable<PaymentFee>> GetPaymentFees();
    }
}
