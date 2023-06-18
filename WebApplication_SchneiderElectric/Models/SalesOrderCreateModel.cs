using System.ComponentModel.DataAnnotations;

namespace WebApplication_SchneiderElectric.Models
{
    public class SalesOrderCreateModel
    {
        [Required(ErrorMessage = "Please select a product.")]
        public string ProductID { get; set; }

        [Required(ErrorMessage = "Please enter the order quantity.")]
        public decimal? OrderQuantity { get; set; }

        [Required(ErrorMessage = "Please enter the order status.")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "Please enter the timestamp.")]
        public DateTime? Timestamp { get; set; }
    }

}
