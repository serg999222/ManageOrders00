using System.ComponentModel.DataAnnotations;

namespace ManageOrders00.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Обов'язкове поле")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Обов'язкове поле")]
        public string CustomerSurName { get; set; }

    }
}
