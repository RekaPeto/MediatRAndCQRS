namespace MediatRAndCQRS.Mapping
{
	public class Mapper : IMapper
	{
		object IMapper.MapCustomerDtoToCustomerResponse(object customerDto)
		{
			throw new NotImplementedException();
		}

		object IMapper.MapOrderDtosToOrderResponses(object customerOrders)
		{
			throw new NotImplementedException();
		}
	}
}
