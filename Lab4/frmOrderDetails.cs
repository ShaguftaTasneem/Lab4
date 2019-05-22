using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;

namespace Lab4
{
    public partial class frmOrderDetails : Form
    {
        public frmOrderDetails()
        {
            InitializeComponent();
        }

        private void frmOrderDetails_Load(object sender, EventArgs e)
        {
            
        }
            
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEnterID_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(txtEnterID.Text);
            OrderDetails who = new OrderDetails();
            who = DataLayer.OrderDetailsDB.GetOrderDetailsDB(Convert.ToString(ID));

            lblOrderID.Text = who.OrderID.ToString();
            lblProductID.Text = who.ProductID;
            lblUnitPrice.Text = who.UnitPrice.ToString(); ;
            lblQuantity.Text = who.Quantity.ToString();
            lblDiscount.Text = who.Discount.ToString();

        }
    }
}
