namespace ManageOrders00.Models
{
    public class Position
    {
        public int PositionId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int ProductCount { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }




    }
}
