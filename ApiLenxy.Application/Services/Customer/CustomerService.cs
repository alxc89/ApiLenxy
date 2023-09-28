using Api_Lenxy.Domain.Enums;
using ApiLenxy.Application.DTOs.Customer;
using ApiLenxy.Application.DTOs.Phone;
using ApiLenxy.Application.Services.Shared;
using ApiLenxy.Domain.Entites;
using ApiLenxy.Domain.Interfaces;
using ApiLenxy.Domain.Notifications;
using ApiLenxy.Domain.ValueObjects;
using AutoMapper;

namespace ApiLenxy.Application.Services.Customer;

public class CustomerService : Notification<EntityNotification>, ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
    }
    public async Task<ServiceResponse<CustomerDTO>> CreateCustomerAsync(CreateCustomerDTO createCustomerDTO)
    {
        #region gerando os vo's
        var name = new Name(createCustomerDTO.FirstName, createCustomerDTO.LastName);
        var document = new Document(createCustomerDTO.DocumentNumber, createCustomerDTO.DocumentType);
        var email = new Email(createCustomerDTO.Email);
        var birthDay = new BirthDay(createCustomerDTO.BirthDay);
        #endregion

        #region preenchendo as entidades
        var phone = new List<Phone>();
        if (createCustomerDTO.Phone is not null)
            foreach (var item in createCustomerDTO.Phone)
            {
                var phoneDTO = new Phone() { PhoneNumber = item.PhoneNumber };
                phone.Add(phoneDTO);
            }
        var address = new Address(createCustomerDTO.Address.ZipCode, createCustomerDTO.Address.State,
            createCustomerDTO.Address.City, createCustomerDTO.Address.Street, createCustomerDTO.Address.Number);

        var customer = new Domain.Entites.Customer(name, document, email, phone, birthDay, address);
        #endregion

        try
        {
            CustomerDTO newCustomer = await _customerRepository.InsertCustomerAsync(customer);
            return ServiceResponseHelper.Success(200, "Cliente salvo com sucesso!", newCustomer);
        }
        catch
        {
            return ServiceResponseHelper.Error<CustomerDTO>(500, "Erro interno!");
        }
    }

    public async Task<ServiceResponse<CustomerDTO>> DeleteAsync(Guid id)
    {
        var customer = await _customerRepository.GetCustomerById(id);
        if (customer == null)
            return ServiceResponseHelper.Error<CustomerDTO>(404, "Cliente não existe!");
        try
        {
            await _customerRepository.DeleteCustomerAsync(id);
            return ServiceResponseHelper.Success<CustomerDTO>(200, "Cliente Deletado com sucesso!");
        }
        catch
        {
            return ServiceResponseHelper.Error<CustomerDTO>(200, "Erro interno, não foi possível deletar o registro!");
        }
    }

    public async Task<ServiceResponse<CustomerDTO>> GetCustomerByIdAsync(Guid idCustomer)
    {
        var customer = await _customerRepository.GetCustomerById(idCustomer);
        CustomerDTO customerDTO = customer;

        if (customerDTO == null)
            return ServiceResponseHelper.Error<CustomerDTO>(401, "Cliente não existe!");

        return ServiceResponseHelper.Success(200, "Dados encontrados com sucesso!", customerDTO);
    }

    public async Task<ServiceResponse<CustomerDTO>> GetCustomersAsync()
    {
        var customers = await _customerRepository.GetCustomerAsync();
        List<CustomerDTO> customerDTO = new();
        foreach (var customer in customers)
            customerDTO.Add(customer);

        if (customerDTO.Count == 0)
            return ServiceResponseHelper.Error<CustomerDTO>(401, "Cliente não existe!");

        return ServiceResponseHelper.Success(200, "Dados encontrados com sucesso!", customerDTO);

    }

    public async Task<ServiceResponse<CustomerDTO>> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO)
    {
        Name name = new(updateCustomerDTO.FirstName, updateCustomerDTO.LastName);
        Document document = new(updateCustomerDTO.DocumentNumber, updateCustomerDTO.DocumentType);
        Email email = new(updateCustomerDTO.Email);
        BirthDay birth = new(updateCustomerDTO.BirthDay);

        List<Phone> phone = new();
        if (updateCustomerDTO.Phone is not null)
            foreach (var item in updateCustomerDTO.Phone)
            {
                Phone phoneUpdated = Phone.Update(item.Id, item.PhoneNumber, updateCustomerDTO.Id);
                phone.Add(phoneUpdated);
            }
        Address address = Address.Update(updateCustomerDTO.Address.Id, updateCustomerDTO.Address.ZipCode, updateCustomerDTO.Address.State,
            updateCustomerDTO.Address.City, updateCustomerDTO.Address.Street, updateCustomerDTO.Address.Number, updateCustomerDTO.Id);

        Domain.Entites.Customer customer = Domain.Entites.Customer.Update(updateCustomerDTO.Id, name, document, email, phone, birth, updateCustomerDTO.Status, address);
        var customerUpdate = await _customerRepository.UpdateCustomerAsync(customer);
        CustomerDTO customerDTO = customerUpdate;

        if (customerUpdate == null)
            return ServiceResponseHelper.Error<CustomerDTO>(404, "Dados não foram Atualizados!");
        return ServiceResponseHelper.Success(200, "Dados atualizados com sucesso!", customerDTO);
    }
}
