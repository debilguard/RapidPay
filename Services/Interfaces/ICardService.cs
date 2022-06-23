using RapidPay.Models;
using System.Threading.Tasks;

namespace RapidPay.Services.Interfaces
{
    public interface ICardService
    {
        public Task<Card> CreateCard(Card card);
        public Task<Card> PayCard(Card card);
        public Task<Card> GetBalanceCard(long cardNumber);
    }
}
