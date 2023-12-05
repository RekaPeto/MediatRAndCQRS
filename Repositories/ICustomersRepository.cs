
using MediatRAndCQRS.Dtos;

namespace MediatRAndCQRS.Repositories
{
	public interface ICustomersRepository
	{
		internal Task<CustomerDto> GetCustomerAsync(int customerId);

		internal Task<List<CustomerDto>> GetCustomersAsync();
	}
}
