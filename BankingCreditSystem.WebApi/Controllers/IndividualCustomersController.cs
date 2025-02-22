using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;
using BankingCreditSystem.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers;

public class IndividualCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerRequest createIndividualCustomerRequest)
    {
        var command = new CreateIndividualCustomerCommand { Request = createIndividualCustomerRequest };
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetByIdIndividualCustomerQuery { Id = id };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PaginationParams paginationParams)
    {
        var query = new GetListIndividualCustomerQuery { PaginationParams = paginationParams };
        var result = await Mediator!.Send(query);
        return Ok(result);
    }
} 