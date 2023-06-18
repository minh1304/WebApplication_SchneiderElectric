using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication_SchneiderElectric.Utility;

namespace WebApplication_SchneiderElectric.Models
{
    public class OrderDataAccessLayer
    {
        string connectionString = ConnectionString.CName;
        public IEnumerable<SalesOrderViewModel> GetAllOrder()
        {
            List<SalesOrderViewModel> lstData = new List<SalesOrderViewModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetSalesOrderDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    SalesOrderViewModel data = new SalesOrderViewModel();

                    data.SalesOrder = rdr["SalesOrderID"].ToString();
                    data.SalesOrderItem = rdr["SalesOrderItemID"].ToString();
                    data.ProductID = rdr["ProductID"].ToString();
                    data.WorkOrder = rdr["WorkOrderID"].ToString();
                    data.ProductDescription = rdr["ProductDescription"].ToString();
                    data.OrderQuantity = Convert.ToInt32(rdr["Quantity"]);
                    data.OrderStatus = rdr["OrderStatus"].ToString();
                    data.Timestamp = Convert.ToDateTime(rdr["Timestamp"]);

                    lstData.Add(data);
                }
                con.Close();
            }
            return lstData;
        }

        public void AddOrder(string productID, decimal? quantity, string orderStatus, DateTime? timestamp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddOrderData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào stored procedure
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@OrderStatus", orderStatus);
                cmd.Parameters.AddWithValue("@Timestamp", timestamp);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteOrder(string SalesOrderID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteOrderBySalesOrderID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào stored procedure
                cmd.Parameters.AddWithValue("@SalesOrderID", SalesOrderID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


    }
}
