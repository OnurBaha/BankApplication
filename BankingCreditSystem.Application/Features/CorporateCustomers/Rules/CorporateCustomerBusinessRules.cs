using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task TaxNumberCannotBeDuplicatedWhenInserted(string taxNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.TaxNumber == taxNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.TaxNumberExists);
    }

    public async Task CompanyRegistrationNumberCannotBeDuplicatedWhenInserted(string registrationNumber)
    {
        bool exists = await _corporateCustomerRepository.AnyAsync(c => c.CompanyRegistrationNumber == registrationNumber);
        if (exists)
            throw new Exception(CorporateCustomerMessages.CompanyRegistrationNumberExists);
    }

    public async Task<CorporateCustomer> CheckIfCustomerExists(Guid id)
    {
        var customer = await _corporateCustomerRepository.GetAsync(c => c.Id == id);
        if (customer == null)
            throw new Exception(CorporateCustomerMessages.CustomerNotFound);
        return customer;
    }
} 