namespace ManageOrders00.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurName { get; set; }

        public Order Order { get; set; }
    }
}
