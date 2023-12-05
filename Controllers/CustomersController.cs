using MediatRAndCQRS.Dtos;
using MediatRAndCQRS.Mapping;
using MediatRAndCQRS.Repositories;
using MediatRAndCQRS.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MediatRAndCQRS.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomersController : ControllerBase
	{
		//private readonly ILogger<OrdersController> _logger;
		private readonly ICustomersRepository _customersRepository;
		private readonly IOrdersRepository _ordersRepository;
		private readonly IMapper _mapper;

        public CustomersController(ICustomersRepository customersRepository, IOrdersRepository ordersRepository, IMapper mapper)
        {
			_customersRepository = customersRepository;
			_ordersRepository = ordersRepository;
			_mapper = mapper;
        }

		[HttpGet("")]
        public async Task<IActionResult> GetCustomers()
		{
			var customerDtos = await _customersRepository.GetCustomersAsync();
			var customerResponse = _mapper.MapCustomerDtoToCustomerResponse(customerDtos);
			return Ok(customerResponse);
		}

		[HttpGet("{customerId}")]
		public async Task<IActionResult> GetCustomer(int customerId, ICustomersRepository _customersRepository)
		{
			CustomerDto customerDto = await _customersRepository.GetCustomerAsync(customerId);

			if (customerDto == null)
			{
				return NotFound();
			}

			var customerResponse = _mapper.MapCustomerDtoToCustomerResponse(customerDto);
			return Ok(customerResponse);
		}


		[HttpGet("{customerId}/orders")]
		public async Task<IActionResult> GetCustomerOrders(int customerId)
		{
			var orders = await _ordersRepository.GetOrdersAsync();
			var customerOrders = orders.Where(x => x.CustomerId == customerId).ToList();
			var customerOrderResponse = new CustomerOrderResponse
			{
				CustomerId = customerId,
				Orders = _mapper.MapOrderDtosToOrderResponses(customerOrders)
			};

			return Ok(customerOrderResponse);
		}
	}
}
