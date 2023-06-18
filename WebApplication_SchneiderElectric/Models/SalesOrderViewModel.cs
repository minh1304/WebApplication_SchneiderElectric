namespace WebApplication_SchneiderElectric.Models
{
    public class SalesOrderViewModel
    {
        public string SalesOrder { get; set; }
        public string SalesOrderItem { get; set; }
        public string ProductID { get; set; }
        public string WorkOrder { get; set; }
        public string ProductDescription { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
