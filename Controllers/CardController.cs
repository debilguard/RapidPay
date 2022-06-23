using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Models;
using RapidPay.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [Authorize]
    [Route("api/[controller]")] 
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService; 
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCard([FromBody] Card card)
        { 
            return Ok(await _cardService.CreateCard(card));
        }

        [HttpPut("PayCard")]
        public async Task<IActionResult> PayCard([FromBody] Card card)
        { 
            return Ok(await _cardService.PayCard(card));
        }

        [HttpGet("GetBalance/{cardNumber}")]
        public async Task<IActionResult> GetBalance(
            [FromRoute]
            [RegularExpression("[0-9]{15}", ErrorMessage = "Card number should contains 15 digits")]

        long cardNumber)
        { 
            return Ok(await _cardService.GetBalanceCard(cardNumber));
        }
    }
}
