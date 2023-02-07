using System.ComponentModel.DataAnnotations;

namespace ManageOrders00.Models
{
    public class Position
    {
        public int PositionId { get; set; }

        public int OrderId { get; set; }

        [Display(Name = "Виберіть товар")]
        
        public int ProductId { get; set; }

        [Display(Name ="Кількість")]
        [Required]
        [Range(1,1000)]
        public int ProductCount { get; set; }

        public Order? Order { get; set; }

        public Product? Product { get; set; }




    }
}
