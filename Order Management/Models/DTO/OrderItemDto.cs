namespace Order_Management.Models.DTO
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
