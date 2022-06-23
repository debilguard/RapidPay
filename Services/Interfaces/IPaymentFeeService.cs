using RapidPay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapidPay.Services.Interfaces
{
    public interface IPaymentFeeService
    {
        public Task<IEnumerable<PaymentFee>> CalculatePaymentFees();
    }
}
