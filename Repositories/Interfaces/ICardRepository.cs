using RapidPay.Models;
using System.Threading.Tasks;

namespace RapidPay.Repositories.Interfaces
{
    public interface ICardRepository
    {
        public Task<Card> CreateCard(Card card);
        public Task<Card> PayCard(Card card);
        public Task<Card> GetBalanceCard(long cardNumber);
    }
}
