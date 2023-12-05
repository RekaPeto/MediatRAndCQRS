namespace MediatRAndCQRS.Responses
{
	public class CustomerOrderResponse
	{
		public int CustomerId { get; set; }
		public object Orders { get; set; }
	}
}
