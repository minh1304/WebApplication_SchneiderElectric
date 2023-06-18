namespace WebApplication_SchneiderElectric.Models
{
    public class OrderModel
    {
        public string SalesOrderID { get; set; } = string.Empty;
        public string SalesOrderItemID { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;
        public string WorkOrderID { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int OrderQuantity { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
