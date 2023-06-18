namespace WebApplication_SchneiderElectric.Models
{
    public class SalesOrderItemProduct
    {
        public int ID { get; set; }
        public string SalesOrderItemID { get; set; } = string.Empty;
        public string ProductID { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string WorkOrderID { get; set; } = string.Empty;
    }
}
