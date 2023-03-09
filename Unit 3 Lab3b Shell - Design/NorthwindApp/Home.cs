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
    public partial class frmHome : Form
    {
        Employee emp;
        NorthwindDBContext context;
      
        public frmHome()
        {
            InitializeComponent();
            context = new NorthwindDBContext();
            emp = (Employee) context.Employees.Find(Global.EmployeeID);
           
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblEmployeeName.Text = emp.ToString();
            LoadStatistics();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.Hide();
            Landing land = new Landing();
            this.Hide();
            land.Show();
        }

        private void LoadStatistics()
        {

            lblCustomers.Text = context.Customers.Count().ToString();
            lblTodayOrders.Text =  context.Orders.Where(x => x.OrderDate.Value.Date == DateTime.Today.Date).Count().ToString();
            //lblTodaySales.Text = context.OrderDetails.Where(x => x.Order.OrderDate == DateTime.Today.Date).Sum(x => x.Quantity * x.UnitPrice).ToString();
            //how to make the same thing but with foreach loop
            double sum;
            foreach (OrderDetail unit in context.OrderDetails)
            {
               
                Order order = (Order)context.Orders.Find(unit.OrderId);
                if (order.OrderDate == DateTime.Today.Date)
                {
                    sum = Convert.ToDouble(unit.UnitPrice) * Convert.ToDouble(unit.Quantity);
                    lblTodaySales.Text = Convert.ToString(sum);
                }
                else
                {
                    lblTodaySales.Text = "0";
                }
            }

            lblTotalSales.Text = context.OrderDetails.Sum(x=> x.Quantity * x.UnitPrice).ToString();

            lblTopSellingProduct.Text = context.OrderDetails.OrderByDescending(x => x.Product.UnitPrice * x.Quantity)
                                     .Select(x => x.Product.ProductName)
                                     .FirstOrDefault();


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}
