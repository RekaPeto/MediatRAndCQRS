using MediatRAndCQRS.Mapping;
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

		public OrdersController(ILogger<OrdersController> logger, IOrdersRepository ordersRepository, IMapper mapper)
		{
			_logger = logger;
			_ordersRepository = ordersRepository;
			_mapper = mapper;
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
			var orders = await _ordersRepository.GetOrdersAsync();
			var orderResponses = _mapper.MapOrderDtosToOrderResponses(orders);
			return Ok(orderResponses);
		}
    }
}
