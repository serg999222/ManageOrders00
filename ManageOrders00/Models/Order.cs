using System.ComponentModel.DataAnnotations;

namespace ManageOrders00.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OrderReleaseDate { get; set; }

        public ICollection<Position>? Positions { get; set; }

        public Customer? Customer { get; set; }

        




    }
}
