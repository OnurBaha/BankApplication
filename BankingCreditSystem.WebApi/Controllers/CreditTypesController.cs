using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Application.Features.CreditTypes.Commands.Create;
using BankingCreditSystem.Application.Features.CreditTypes.Queries.GetList;
using BankingCreditSystem.Domain.Enums;

namespace BankingCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCreditTypeCommand createCreditTypeCommand)
    {
        var result = await Mediator.Send(createCreditTypeCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] int pageIndex = 0,
        [FromQuery] int pageSize = 10,
        [FromQuery] CustomerType? customerType = null)
    {
        var query = new GetListCreditTypeQuery 
        { 
            PageIndex = pageIndex,
            PageSize = pageSize,
            CustomerType = customerType
        };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
} 