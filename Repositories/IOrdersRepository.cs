
using MediatRAndCQRS.Dtos;

namespace MediatRAndCQRS.Repositories
{
	public interface IOrdersRepository
	{
		internal Task<IEnumerable<OrderDto>> GetOrdersAsync();

		internal Task GetOrdersAsync(Guid orderId);

		internal Task<OrderDto> GetOrderAsync(Guid orderId);

		internal Task CreateOrdersAsync(object customerId, object productId);

		internal Task<OrderDto> CreateOrderAsync(string customerId, string productId);
	}
}
