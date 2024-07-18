using Company.Business.Dto.Customer;

namespace Company.Business.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<ReadCustomerDto>> GetAllCustomersAsync();
        Task<ReadCustomerDto> GetCustomerByIdAsync(int id);
        Task Add(AddCustomerDto customerDto);
        //  Task UpdateCustomerAsync(int id, ReadCustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
        Task UpdateCustomerAsync(int id, ReadCustomerDto customerDto);
    }
}
