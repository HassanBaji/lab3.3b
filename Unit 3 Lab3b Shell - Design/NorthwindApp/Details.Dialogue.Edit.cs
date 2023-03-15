using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NWindBusinessObjects;


namespace NorthwindApp
{
    public partial class frmDetailsDialogueEdit : Form
    {
        NorthwindDBContext context;
        Order order;
        internal OrderDetail orderDetail;

        public frmDetailsDialogueEdit(int orderID) //if new line, we just need the order ID
        {
            InitializeComponent();
            context= new NorthwindDBContext();
            orderDetail= new OrderDetail();
            txtOrderID.Text=orderID.ToString();
        }

        public frmDetailsDialogueEdit(OrderDetail ord) 
        {
            InitializeComponent();
            context = new NorthwindDBContext();
            orderDetail = ord;
        }

        private void frmDetailsDialogueEdit_Load(object sender, EventArgs e)
        {
            ddlProduct.DataSource = context.Products.ToList();
            ddlProduct.DisplayMember= "ProductNme";
            ddlProduct.ValueMember= "ProductID";

           if (txtOrderID.Text == "")
            {
                ddlProduct.SelectedValue = orderDetail.Product;
                txtOrderID.Text = orderDetail.OrderId.ToString();
                txtQty.Text = orderDetail.Quantity.ToString();
                txtUnitPrice.Text = orderDetail.UnitPrice.ToString();
                txtDiscount.Text = orderDetail.Discount.ToString();

            }
           else
            {
                ddlProduct.SelectedValue = "";
            }


        }

        private void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Product product = context.Products.Where(x => x.ProductId == Convert.ToInt32(ddlProduct.SelectedValue.ToString())).FirstOrDefault();
                txtUnitPrice.Text = product.UnitPrice.ToString();
                txtQty.Text = "1";
                txtDiscount.Text = "0";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToDecimal(txtDiscount) > 1)
                {
                    MessageBox.Show("discount can only be between 0 and 1");
                }
                else
                {
                    orderDetail.ProductId = Convert.ToInt32(ddlProduct.SelectedValue.ToString());
                    orderDetail.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                    orderDetail.Quantity = Convert.ToInt16(txtQty.Text);
                    orderDetail.OrderId = Convert.ToInt32(txtOrderID.Text);
                    orderDetail.Discount = (float)Convert.ToDouble(txtDiscount.Text);

                    this.DialogResult = DialogResult.OK; this.Close();  
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
