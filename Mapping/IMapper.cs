
namespace MediatRAndCQRS.Mapping
{
	public interface IMapper
	{
		internal object MapCustomerDtoToCustomerResponse(object customerDto);

		internal object MapOrderDtosToOrderResponses(object customerOrders);
	}
}
