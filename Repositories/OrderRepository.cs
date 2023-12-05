using MediatRAndCQRS.Dtos;

namespace MediatRAndCQRS.Repositories
{
	public class OrderRepository : IOrdersRepository
	{
		Task<OrderDto> IOrdersRepository.CreateOrderAsync(string customerId, string productId)
		{
			throw new NotImplementedException();
		}

		Task IOrdersRepository.CreateOrdersAsync(object customerId, object productId)
		{
			throw new NotImplementedException();
		}

		Task<OrderDto> IOrdersRepository.GetOrderAsync(Guid orderId)
		{
			throw new NotImplementedException();
		}

		Task<IEnumerable<OrderDto>> IOrdersRepository.GetOrdersAsync()
		{
			throw new NotImplementedException();
		}

		Task IOrdersRepository.GetOrdersAsync(Guid orderId)
		{
			throw new NotImplementedException();
		}
	}
}
