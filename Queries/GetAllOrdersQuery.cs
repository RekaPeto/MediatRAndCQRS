using MediatR;
using MediatRAndCQRS.Responses;

namespace MediatRAndCQRS.Queries
{
	public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
	{
	}
}
