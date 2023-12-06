using MediatR;
using MediatRAndCQRS.Mapping;
using MediatRAndCQRS.Queries;
using MediatRAndCQRS.Repositories;
using MediatRAndCQRS.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MediatRAndCQRS.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly ILogger<OrdersController> _logger;
		private readonly IOrdersRepository _ordersRepository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public OrdersController(ILogger<OrdersController> logger, IOrdersRepository ordersRepository, IMapper mapper, IMediator mediator)
		{
			_logger = logger;
			_ordersRepository = ordersRepository;
			_mapper = mapper;
			_mediator = mediator;
		}

		[HttpPost("")]
		public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderRequest request)
		{
			var order = await _ordersRepository.CreateOrderAsync(request.CustomerId, request.ProductId);
			_logger.LogInformation($"Create order for customer: {order.CustomerId} for product: {order.ProductId}");

			var orderResponse = _mapper.MapOrderDtosToOrderResponses(order);
			return CreatedAtAction("GetOrder", new { orderId = order.Id }, orderResponse);
		}

		[HttpGet("{orderId}")]
		public async Task<IActionResult> GetOrder(Guid orderId)
		{
			var order = await _ordersRepository.GetOrderAsync(orderId);

			if (order == null)
			{
				return NotFound();
			}

			var orderResponse = _mapper.MapOrderDtosToOrderResponses(order);
			return Ok(orderResponse);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllOrders()
		{
			var query = new GetAllOrdersQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}
    }
}
