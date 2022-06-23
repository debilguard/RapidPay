using RapidPay.Models;
using RapidPay.Repositories.Interfaces;
using RapidPay.Services.Interfaces;
using System.Threading.Tasks;

namespace RapidPay.Services
{
    public class CardService : ICardService
    {

        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<Card> GetBalanceCard(long cardNumber)
        {
            return  await _cardRepository.GetBalanceCard(cardNumber);
        }

        public async Task<Card> CreateCard(Card card)
        {
            return await _cardRepository.CreateCard(card);
        }

        public async Task<Card> PayCard(Card card)
        {
            return await _cardRepository.PayCard(card);
        }
    }
}
