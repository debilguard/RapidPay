using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Database;
using RapidPay.Services.Interfaces;
using System.Threading.Tasks;

namespace RapidPay.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentFeesController : ControllerBase
    { 
        private readonly IPaymentFeeService _paymentFeeService;
        public PaymentFeesController(IPaymentFeeService paymentFeeService)
        {
            _paymentFeeService = paymentFeeService; 
        }
 
        [HttpGet("CalculatePaymentFees")]
        public async Task<IActionResult> CalculatePaymentFees()
        {
            return Ok(await _paymentFeeService.CalculatePaymentFees());
        }
    }
}
