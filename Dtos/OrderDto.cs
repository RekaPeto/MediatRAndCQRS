namespace MediatRAndCQRS.Dtos
{
	public class OrderDto
	{
        public int Id { get; set; }
        public int CustomerId { get; internal set; }
		public int ProductId { get; internal set; }	
	}
}
