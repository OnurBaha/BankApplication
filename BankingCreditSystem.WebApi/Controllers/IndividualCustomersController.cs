using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;
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

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerRequest updateIndividualCustomerRequest)
    {
        var command = new UpdateIndividualCustomerCommand { Request = updateIndividualCustomerRequest };
        var result = await Mediator!.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteIndividualCustomerCommand { Id = id };
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