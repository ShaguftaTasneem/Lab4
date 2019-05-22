using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer;

namespace DataLayer
{
    public static class OrdersDB
    {
        public static Orders GetOrdersDB(string s)

        {
            SqlConnection connection = Northwind.GetConnection();
            Orders O = new Orders();

            try

            {
                string sql = " Select OrderID,CustomerID, OrderDate,RequiredDate, ShippedDate from Orders WHERE OrderID=@OrderID";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@OrderID", s);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {

                    O.CustomerID = Convert.ToString(reader["CustomerID"]);
                    O.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    O.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
                    O.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
                    O.OrderID = Convert.ToInt32(reader["OrderID"]);
                   // reader.Add(O);
                    
                }

            }

                    catch(Exception e)
                    {  }
            finally
            {
                connection.Close();
            }

            return O;
    
        }


        public static List<Orders> GetOrdersGridDB()

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


        //                 public static void AddOrders(DateTime ShippedDate)
        //                  {
        //                string sql = "Insert Into Orders" + "(ShippedDate)" + "Values" + "(@ShippedDate)";
        //                SqlConnection connection = DataLayer.Northwind.GetConnection();
        //                SqlCommand command = new SqlCommand(sql, connection);

        //                command.Parameters.AddWithValue("@ShippedDate", ShippedDate);

        //                command.ExecuteNonQuery();
        //                  }

        //        public static int UpdaPackage(int PkgId, string PkgName, string PkgStartDate, string PkgEndDate, string PkgDesc, string PkgBasePrice, string PkgAgencyCommission)
        ////        {


        //           


    }
}

 // --------------------------------------------------------------------------------------------------------- 

    // 
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using BusinessLayer;

//namespace DataLayer
//{
//    public static class PackageDB
//    {
//        public static List<Packages> GetPackages()
//        {
//            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
//            List<Packages> results = new List<Packages>();

//            try
//            {

//                string sql = "SELECT * FROM Packages ";
//                SqlCommand command = new SqlCommand(sql, connection);
//                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//                while (reader.Read())
//                {
//                    Packages s = new Packages();
//                    s.PkgName = reader["PkgName"].ToString();
//                    s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
//                    s.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"].ToString());
//                    s.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"].ToString());
//                    s.PkgDesc = reader["PkgDesc"].ToString();
//                    s.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"].ToString());
//                    s.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"].ToString());

//                    results.Add(s);

//                }
//            }
//            catch { }
//            finally
//            {
//                connection.Close();
//            }

//            return results;

//        }


//        public static Packages GetPackage(int PkgId)
//        {
//            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
//            Packages s = new Packages();
//            try
//            {
//                string sql = "SELECT * " + "FROM Packages " +
//                    "WHERE PackageID =" + PkgId;
//                SqlCommand command = new SqlCommand(sql, connection);

//                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
//                while (reader.Read())
//                {
//                    s.PkgName = reader["PkgName"].ToString();
//                    s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
//                    s.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"].ToString());
//                    s.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"].ToString());
//                    s.PkgDesc = reader["PkgDesc"].ToString();
//                    s.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"].ToString());
//                    s.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"].ToString());

//                }
//            }
//            catch { }
//            finally
//            {
//                connection.Close();
//            }


//            return s;

//        }


//        public static int AddPackage(string PkgName, string PkgStartDate, string PkgEndDate, string PkgDesc, string PkgBasePrice, string PkgAgencyCommission)
//        {
//            string sql = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission)  VALUE (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission)";
//            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
//            SqlCommand command = new SqlCommand(sql, connection);

//            command.Parameters.AddWithValue("@PkgName", PkgName);
//            command.Parameters.AddWithValue("@PkgStartDate", PkgStartDate);
//            command.Parameters.AddWithValue("@PkgEndDate", PkgEndDate);
//            command.Parameters.AddWithValue("@PkgDesc", PkgDesc);
//            command.Parameters.AddWithValue("@PkgBasePrice", PkgBasePrice);
//            command.Parameters.AddWithValue("@PkgAgencyCommission", PkgAgencyCommission);

//            int qq = command.ExecuteNonQuery();

//            return qq;

//        }
//        public static int DelePackage(int PkgId)
//        {
//            string sql = "Delete Packages where PackageID=" + PkgId;

//            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
//            SqlCommand command = new SqlCommand(sql, connection);
//            int qq = command.ExecuteNonQuery();

//            return qq;

//        }

//        public static int UpdaPackage(int PkgId, string PkgName, string PkgStartDate, string PkgEndDate, string PkgDesc, string PkgBasePrice, string PkgAgencyCommission)
//        {


//            string sql = "UPDATE  Packages  SET PkgName=@PkgName, PkgStartDate=@PkgStartDate,PkgEndDate=@PkgEndDate,PkgDesc=@PkgDesc,PkgBasePrice=@PkgBasePrice,PkgAgencyCommission=@PkgAgencyCommission   where PackageId=" + PkgId;

//            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
//            SqlCommand command = new SqlCommand(sql, connection);

//            command.Parameters.AddWithValue("@PkgName", PkgName);
//            command.Parameters.AddWithValue("@PkgStartDate", PkgStartDate);
//            command.Parameters.AddWithValue("@PkgEndDate", PkgEndDate);
//            command.Parameters.AddWithValue("@PkgDesc", PkgDesc);
//            command.Parameters.AddWithValue("@PkgBasePrice", PkgBasePrice);
//            command.Parameters.AddWithValue("@PkgAgencyCommission", PkgAgencyCommission);

//            int qq = command.ExecuteNonQuery();
//            return qq;

//        }








//    }




//}

