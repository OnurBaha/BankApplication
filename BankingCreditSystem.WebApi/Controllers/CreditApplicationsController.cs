using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Application.Features.CreditApplications.Commands;
using BankingCreditSystem.Application.Features.CreditApplications.Queries;
using BankingCreditSystem.Application.Features.CreditApplications.Commands.Create;
using BankingCreditSystem.Application.Features.CreditApplications.Queries.GetListByCustomer;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditApplicationCommand createCreditApplicationCommand)
        {
            var result = await Mediator.Send(createCreditApplicationCommand);
            return Created("", result);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetListByCustomer(
            [FromRoute] Guid customerId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetListByCustomerCreditApplicationQuery 
            { 
                CustomerId = customerId,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
} 