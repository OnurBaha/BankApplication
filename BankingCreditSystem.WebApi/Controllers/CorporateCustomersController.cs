using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCorporateCustomerRequest request)
    {
        CreateCorporateCustomerCommand command = new() { Request = request };
        CreatedCorporateCustomerResponse response = await Mediator.Send(command);
        return Created("", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerRequest request)
    {
        UpdateCorporateCustomerCommand command = new() { Request = request };
        UpdatedCorporateCustomerResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCorporateCustomerCommand command = new() { Id = id };
        DeletedCorporateCustomerResponse response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateCustomerQuery query = new() { Id = id };
        CorporateCustomerResponse response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PaginationParams paginationParams)
    {
        GetListCorporateCustomerQuery query = new() { PaginationParams = paginationParams };
        Paginate<CorporateCustomerResponse> response = await Mediator.Send(query);
        return Ok(response);
    }
} 