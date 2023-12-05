using MediatRAndCQRS.Dtos;

namespace MediatRAndCQRS.Repositories
{
	public class CustomerRepository : ICustomersRepository
	{
		Task<CustomerDto> ICustomersRepository.GetCustomerAsync(int customerId)
		{
			throw new NotImplementedException();
		}

		Task<List<CustomerDto>> ICustomersRepository.GetCustomersAsync()
		{
			throw new NotImplementedException();
		}
	}
}
