using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageOrders00.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Обов'язкове поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжмна строки має бути від 2 до 50 символів")]
        public string? ProductName { get; set; }
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Довжмна строки має бути від 2 до 50 символів")]
        public string? ProductDescription { get; set; }
        [Required(ErrorMessage = "Обов'язкове поле")]

        [Range(0,100000)]
        public double Price { get; set; }   








    }
}
