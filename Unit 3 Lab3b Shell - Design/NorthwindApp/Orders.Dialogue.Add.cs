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

            //if edit order, poplate the text boxes 
            if (order != null)
            {
                // Set the selected value of the customer dropdown list to the customer ID of the order
                ddlCustomer.SelectedValue = order.CustomerId;

                // Set the selected value of the employee dropdown list to the employee ID of the order
                ddlEmployee.SelectedValue = order.EmployeeId;

                // Set the value of the order date picker to the order date of the order
                dtpOrderDate.Value = order.OrderDate.Value;

                // Set the value of the required date picker to the required date of the order
                dtpRequiredDate.Value = order.RequiredDate.Value;

                // Set the value of the shipped date picker to the shipped date of the order if it's not null, or to the current date if it is null
                dtpShippedDate.Value = order.ShippedDate ?? DateTime.Now;

                // Set the checked state of the shipped date checkbox based on whether the shipped date of the order is null or not
                dtpShippedDate.Checked = order.ShippedDate != null;

                // Set the selected value of the ship via dropdown list to the shipper ID of the order if it's not null, or to 0 if it is null
                ddlShipVia.SelectedValue = order.ShipVia ?? 0;

                // Set the text of the ship address textbox to the ship address of the order
                txtAddress.Text = order.ShipAddress;

                // Set the text of the ship city textbox to the ship city of the order
                txtCity.Text = order.ShipCity;

                // Set the text of the ship country textbox to the ship country of the order
                txtCountry.Text = order.ShipCountry;

                // Set the text of the freight textbox to the freight of the order if it's not null, or to an empty string if it is null
                txtFreight.Text = order.Freight?.ToString() ?? "";
            }

             




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
           

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

                //3dd the order to the orders DBSet
                context.Orders.Add(order);

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

