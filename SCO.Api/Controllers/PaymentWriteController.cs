using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCO.Application.Commands;
using SCO.Contracts.Responses.Payment;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCO.Api.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentWriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentWriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<int> CreatePayment([FromBody] Guid orderId)
        {
            var result = _mediator.Send(new StartPaymentCommand(orderId));

            return await Task.FromResult(result.Result.PaymentStatus);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
