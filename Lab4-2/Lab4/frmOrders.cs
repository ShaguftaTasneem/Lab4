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
            InitializeComponent(); //Initialization of the Application
        }

        private void frmSupplier1_Load(object sender, EventArgs e)  //Form Loader
        {
            
        }

        private void button1_Click(object sender, EventArgs e)  //Button to enter the Order ID for Record Display
            {
                int ID = Convert.ToInt32(txtEnterID.Text);  //Converts the string in the text box into integer datatype
                Orders who = new Orders();                  //Object declaration
            

                who = DataLayer.OrdersDB.GetOrdersDB(Convert.ToString(ID));  //Object path 
                // Data elements to be displayed in labels
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
            // Displaying the Order Total
            lblOrderTotal.Text =OrderTotal.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            // To update the ShippDate 

            DateTime ShipDate = Convert.ToDateTime(txtShippedDate.Text);  //Reads and convert to datetime datatype
            int iret = DataLayer.OrdersDB.UpdateOrder(ShipDate);          // Function Call
            
                if (iret > 0)           // If function works
                {
                    
                    MessageBox.Show(" Shipped Date is Updated");
                }
            else    // If function does not work
            {
                    MessageBox.Show(" Please enter Valid Shipped Date where RequiredDate > ShippedDate AND ShippedDate < OrderDate in the form of mm/dd/yyyy");

                }
            
            
            }
        
           // Data Display in Grid View at the begginning of the application    

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void BindGridview()
        {
            
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            var lst = DataLayer.OrdersDB.GetOrdersGridDB();
            dataGridView2.DataSource = lst;
        }
    }

}