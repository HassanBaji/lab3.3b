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
    
    public partial class frmOrders : Form
    {
        NorthwindDBContext context;
     
        public frmOrders()
        {
            InitializeComponent(); 
            context= new NorthwindDBContext();  
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {

            ddlFilterCustomer.DataSource = context.Customers.ToList();
            ddlFilterCustomer.DisplayMember = "ContactName";
            ddlFilterCustomer.ValueMember= "CustomerID";
            ddlFilterCustomer.SelectedItem = null;
            refreshList();
        }

        private void refreshList()
        {
            dgvOrders.DataSource = null;

            var orderToShow = context.Orders.AsQueryable();

            if (txtFilterOrderNo.Text != "")
            {
                orderToShow = orderToShow.Where(x=> x.OrderId == Convert.ToInt32(txtFilterOrderNo.Text));
            }
            else if (ddlFilterCustomer.SelectedValue != null)
            {
                orderToShow = orderToShow.Where(x => x.CustomerId == ddlFilterCustomer.SelectedValue.ToString());
            }

            dgvOrders.DataSource = orderToShow.OrderByDescending(x => x.OrderDate).Select(x => new
            {
                OrderID = x.OrderId,
                CustomerName = x.Customer.ContactName,
                EmployeeName = x.Employee.FirstName + " " + x.Employee.LastName,
                OrderDate= x.OrderDate.Value.ToString("dd-MM-yyyy"),
                RequiredDate = x.RequiredDate.Value.ToString("dd-MM-yyyy")
            }).ToList();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtFilterOrderNo.Text = "";
            ddlFilterCustomer.SelectedItem = null;
            refreshList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //getting the cell calye of the orderid cell
            int firstCell = Convert.ToInt32(dgvOrders.SelectedCells[0].OwningRow.Cells[0].Value);
            //creating order from the value of that cell
            Order order = context.Orders.Single(x=> x.OrderId== firstCell);

            if (MessageBox.Show("Are you sure you want to delete order(" + firstCell + ") $ its details?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes){

                //to delet and order we first have to delete all forgien keys related to it

                //deleting all orderdetails related to order
                var alldet = context.OrderDetails.Where(x => x.OrderId== order.OrderId);
                context.OrderDetails.RemoveRange(alldet);
                

                //deleting order
                context.Orders.Remove(order);

                //saving
                context.SaveChanges();

                //refrshing the list 
                refreshList();

            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOrdersDialogueAdd frm = new frmOrdersDialogueAdd();
            frm.ShowDialog();
            refreshList();
        }
    }
}
