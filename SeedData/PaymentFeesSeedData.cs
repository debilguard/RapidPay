using RapidPay.Database;
using RapidPay.Models;
using System.Collections.Generic;

namespace RapidPay.SeedData
{
    public static class PaymentFeesSeedData
    {
        public static void AddPaymentFeesSeedData(RapidPayContext context)
        {
            var paymentFess = new List<PaymentFee> 
            { 
                new PaymentFee() { Id = 1, FeeAmount = 999.99m },
                 new PaymentFee() { Id = 2, FeeAmount = 1000.00m },
                  new PaymentFee() { Id = 3, FeeAmount = 1000.50m },
                   new PaymentFee() { Id = 4, FeeAmount = 2000.60m },
                    new PaymentFee() { Id = 5, FeeAmount = 3000.70m },
                     new PaymentFee() { Id = 6, FeeAmount = 4000.80m }
            };

            context.AddRange(paymentFess);
            context.SaveChanges(); 
        }
    }
}
