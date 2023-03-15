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
    public partial class frmOrdersDialogueAdd : Form
    {
        NorthwindDBContext context;
        Order order;

       
        public frmOrdersDialogueAdd()
        {
            InitializeComponent();
            context= new NorthwindDBContext();
            order= new Order();
         
        }

        public frmOrdersDialogueAdd(Order order)
        {
            InitializeComponent();
            context = new NorthwindDBContext();
            this.order = order;

        }



        private void frmOrdersDialogueAdd_Load(object sender, EventArgs e)
        {
            ddlCustomer.DataSource = context.Customers.ToList();
            ddlCustomer.DisplayMember = "ContactName";
            ddlCustomer.ValueMember = "CustomerID";
            ddlCustomer.SelectedItem = null;

            ddlEmployee.DataSource = context.Employees.ToList();
             ddlEmployee.DisplayMember = "EmployeeName";
             ddlEmployee.ValueMember = "EmployeeID";
            ddlEmployee.SelectedItem = Global.EmployeeID;


           ddlShipVia.DataSource = context.Shippers.ToList();
            ddlShipVia.DisplayMember = "CompanyName";
            ddlShipVia.ValueMember = "ShipperID";
            ddlShipVia.SelectedItem = null;

         
            if (order.OrderId > 0)
            {
                txtOrderID.Text = order.OrderId.ToString();
                ddlCustomer.SelectedValue = order.CustomerId;
                ddlEmployee.SelectedValue = order.EmployeeId;
                dtpOrderDate.Value = order.OrderDate.Value;
                dtpRequiredDate.Value = order.RequiredDate.Value;
                
                if (order.ShippedDate != null)
                {
                    dtpShippedDate.Checked= true;
                    dtpShippedDate.Value= order.ShippedDate.Value;

                }
                else
                {
                    dtpShippedDate.Checked = false;
                    dtpShippedDate.Value = DateTime.Today;
                }
                ddlShipVia.SelectedValue= order.ShipVia != null ? order.ShipVia : "";

                txtAddress.Text = order.ShipAddress;
                txtCity.Text = order.ShipCity;
                txtCountry.Text = order.ShipCountry;
                txtFreight.Text = order.Freight.ToString();

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                order.Customer = null; order.Employee = null; order.ShipViaNavigation= null;

                //populate the order objts
                order.CustomerId = ddlCustomer.SelectedValue.ToString();

                order.EmployeeId = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
                order.OrderDate = dtpOrderDate.Value;

                order.RequiredDate = dtpRequiredDate.Value;

                if (dtpShippedDate.Checked)

                {
                    order.ShippedDate = dtpShippedDate.Value;
                }
                else //if Shipped Date is not checked, we insert null
                {
                    order.ShippedDate = null;
                }

                order.ShipVia = ddlShipVia.SelectedValue != null ? Convert.ToInt32(ddlShipVia.SelectedValue) : null;
                order.ShipAddress = txtAddress.Text;

                order.ShipCity = txtCity.Text;

                order.ShipCountry = txtCountry.Text;

                order.Freight = txtFreight.Text != "" ? Convert.ToDecimal(txtFreight.Text) : null;
                if (order.OrderId > 0)
                {
                    context.Orders.Update(order);
                }
                else
                {
                    context.Orders.Add(order);
                }
                
                

                //Execute the insert SQL
                context.SaveChanges();

                //0nly if the insert was successful, we can
                this.DialogResult = DialogResult.OK;
                //close the form

                this.Close();

            }
            catch(Exception ex) 
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }
    }

}

