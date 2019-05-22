using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using DataLayer;


namespace Lab4
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();

        }

        private void frmSupplier1_Load(object sender, EventArgs e)
        {
            //var lst= DataLayer.OrdersDB.GetOrdersGridDB();
            //dataGridView1.DataSource = lst;

            // dataGridView1.DataSource = DataLayer.OrdersDB.GetOrdersDB();
        }

        private void button1_Click(object sender, EventArgs e)
            {
                int ID = Convert.ToInt32(txtEnterID.Text);
                Orders who = new Orders();
            //string s =OrderDetailsDB.GetOrderDetailsDB("");

                who = DataLayer.OrdersDB.GetOrdersDB(Convert.ToString(ID));

                lblOrderID.Text = who.OrderID.ToString();
                lblCustomerID.Text = who.CustomerID.ToString();
            lblOrderDate.Text = Convert.ToDateTime(who.OrderDate).ToString();
                lblRequiredDate.Text = Convert.ToDateTime(who.RequiredDate).ToString();
                lblShippedDate.Text = Convert.ToDateTime(who.ShippedDate).ToString();

            // Trial 1:  Calculating the Order Total from the data in the Order Details Table 
            OrderDetails Total = new OrderDetails();
             Total = DataLayer.OrderDetailsDB.GetOrderDetailsDB(Convert.ToString(ID));
            Double D = Convert.ToDouble(Total.Discount);
            Double Q = Convert.ToDouble(Total.Quantity);
            Double P = Convert.ToDouble(Total.UnitPrice);
            Double OrderTotal;
            OrderTotal = P * (1 - D) *Q;

            lblOrderTotal.Text =OrderTotal.ToString();

            
            // Trial 2:  Calculating the Order Total from the data in the Order Details Table 


            //lblOrderTotal.Text = Total.OrderTotal.ToString();

            }
        
        private void button2_Click(object sender, EventArgs e)
        {
            // DataLayer.OrdersDB.AddOrders(txtOrderID.Text, txtCustomerID.Text, txtOrderDate.Text, txtRequiredDate.Text, txtShippedDate.Text);

            //Trial : To update the ShippDate 


            //public static DateTime UpdateOrder(DateTime ShippedDate)
            //{

            //    string sql = " If (ShippedDate==NOT NULL){ UPDATE  Orders  SET ShippedDate=@ShippedDate where ShippedDate> ORderDate && ShippedDate<RequiredDate} Else {Error Message.Box='Date Field can not be Null'" + ShippedDate;

            //    SqlConnection connection = Northwind.GetConnection();
            //    SqlCommand command = new SqlCommand(sql, connection);

            //    command.Parameters.AddWithValue("@ShippedDate", ShippedDate);


            //    int qq = command.ExecuteNonQuery();
            //    return qq;



            ////public static void AddOrders(Date ShippedDate)
            ////{
            ////    string sql = "Insert Into Orders" + "(ShippedDate)" + "Values" + "(@ShippedDate)";
            ////    SqlConnection connection = DataLayer.Northwind.GetConnection();
            ////    SqlCommand command = new SqlCommand(sql, connection);

            ////    command.Parameters.AddWithValue("@ShippedDate", ShippedDate);

            ////    command.ExecuteNonQuery();
            ////}

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = DataLayer.OrdersDB.GetOrdersGridDB();
        }

        private void BindGridview() {
            dataGridView2.DataSource = DataLayer.OrdersDB.GetOrdersGridDB();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            var lst = DataLayer.OrdersDB.GetOrdersGridDB();
            dataGridView2.DataSource = lst;
        }
    }

}