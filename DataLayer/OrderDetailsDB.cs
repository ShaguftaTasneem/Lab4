using BusinessLayer;
using System;
using System.Data.SqlClient;

namespace DataLayer
{
    public class OrderDetailsDB  // Class OrderDetailsDB
    {
        public static OrderDetails GetOrderDetailsDB(string ID)
        {
            SqlConnection connection = Northwind.GetConnection();    //Connction is estabilished
            OrderDetails od = new OrderDetails();  //Object Creation

            try

            {
                string sql = " SELECT [OrderID] ,[ProductID],[UnitPrice],[Quantity],[Discount] FROM[Northwind].[dbo].[Order Details] WHERE[OrderID] = @OrderID";  // Selects the Data from the NorthWind

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@OrderID", ID);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);  // Declares the reader and Reads all the required data

                while (reader.Read())
                {


                    od.ProductID =Convert.ToString( reader["ProductID"]);
                    od.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    od.Quantity = Convert.ToInt32(reader["Quantity"]);
                   od.Discount = Convert.ToDouble(reader["Discount"]);
                    od.OrderID = Convert.ToInt32(reader["OrderID"]);

                   
                }
            }
            catch (Exception e)  // exception if error occures
            {
            }

            return od;


        }
    }


}

