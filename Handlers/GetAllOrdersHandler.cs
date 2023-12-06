using MediatR;
using MediatRAndCQRS.Mapping;
using MediatRAndCQRS.Queries;
using MediatRAndCQRS.Repositories;
using MediatRAndCQRS.Responses;

namespace MediatRAndCQRS.Handlers
{

	public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderResponse>>
	{
		private readonly IOrdersRepository _orderRepository;
		private readonly IMapper _mapper;

        public GetAllOrdersHandler(IOrdersRepository orderRepository, IMapper mapper)
        {
			_orderRepository = orderRepository;
			_mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
		{
			var orders = await _orderRepository.GetOrdersAsync();
			return (List<OrderResponse>)_mapper.MapOrderDtosToOrderResponses(orders);
		}
	}
}
