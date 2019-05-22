using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer;

namespace DataLayer
{
    public static class OrdersDB    // Class OrderDB
    {
        public static Orders GetOrdersDB(string s)

        {
            SqlConnection connection = Northwind.GetConnection();  //Connction is estabilished
            Orders O = new Orders();  //Object Creation

            try

            {
                string sql = " Select OrderID,CustomerID, OrderDate,RequiredDate, ShippedDate from Orders WHERE OrderID=@OrderID";  // Selects the Data from the NorthWind

                SqlCommand command = new SqlCommand(sql, connection); 
                command.Parameters.AddWithValue("@OrderID", s); 
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection); // Declares the reader and Reads all the required data

                while (reader.Read())
                {

                    O.CustomerID = Convert.ToString(reader["CustomerID"]);
                    O.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    O.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                    O.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
                    O.OrderID = Convert.ToInt32(reader["OrderID"]);
                   

                }

            }

            catch (Exception e)  // exception if error occures
            { }
            finally
            {
                connection.Close();  //closes the connection 
            }

            return O;

        }


        public static List<Orders> GetOrdersGridDB()  // Prepares the dta for Grid View

        {
            SqlConnection connection = Northwind.GetConnection();
            Orders O;
            List<Orders> lstOrders = new List<Orders>();
            try

            {
                string sql = " Select OrderID,CustomerID, OrderDate,RequiredDate, ShippedDate from Orders";

                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    O = new Orders();

                    O.CustomerID = Convert.ToString(reader["CustomerID"]);
                    O.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    O.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                    O.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
                    O.OrderID = Convert.ToInt32(reader["OrderID"]);
                    // reader.Add(O);

                    lstOrders.Add(O);
                }

            }

            catch (Exception e)
            { }
            finally
            {
                connection.Close();
            }

            return lstOrders;

        }

        public static int UpdateOrder(DateTime ShippedDate)  // Update the data in ShippedDate field
        {
            SqlConnection connection = Northwind.GetConnection();
            int ireturn = 0;
            {
                try

                {
                    string sql = " UPDATE Orders SET ShippedDate =@ShippedDate";
                    //where OrderID='OrderID'";
                        //"WHERE RequiredDate > ShippedDate AND ShippedDate < OrderDate";
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@ShippedDate", ShippedDate);


                    ireturn = command.ExecuteNonQuery();
                }

                catch (Exception e)
                { }

                finally
                {
                    connection.Close();
                }

            }
            return ireturn;
        }
    }
}
       