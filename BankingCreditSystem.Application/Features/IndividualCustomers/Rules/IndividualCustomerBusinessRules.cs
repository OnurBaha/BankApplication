using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task NationalIdCannotBeDuplicatedWhenInserted(string nationalId)
    {
        bool exists = await _individualCustomerRepository.AnyAsync(c => c.NationalId == nationalId);
        if (exists)
            throw new Exception(IndividualCustomerMessages.NationalIdExists);
    }

    public async Task<IndividualCustomer> CheckIfCustomerExists(Guid id)
    {
        var customer = await _individualCustomerRepository.GetAsync(c => c.Id == id);
        if (customer == null)
            throw new Exception(IndividualCustomerMessages.CustomerNotFound);
        return customer;
    }
} 