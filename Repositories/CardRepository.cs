using RapidPay.Database;
using RapidPay.Models;
using RapidPay.Repositories.Interfaces;
using System.Threading.Tasks;

namespace RapidPay.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly RapidPayContext _context;
        public CardRepository(RapidPayContext context)
        {
            _context = context;
        }
        public async Task<Card> GetBalanceCard(long cardNumber)
        {
            return await _context.Card
                         .FindAsync(cardNumber);                  
        }

        public async Task<Card> CreateCard(Card card)
        {
            _context.Card.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> PayCard(Card card)
        { 
            _context.Update(card);
            await _context.SaveChangesAsync();
            return card;
        }
    }
}
