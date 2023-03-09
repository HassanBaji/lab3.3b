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
    public partial class Landing : Form
    {

        NorthwindDBContext context ;
    
        public Landing()
        {
            
            InitializeComponent();
            context = new NorthwindDBContext();
        }

        private void Landing_Load(object sender, EventArgs e)
        {

            ddlEmployees.DataSource = context.Employees.ToList();
           // ddlEmployees.DisplayMember =;
            // ddlEmployees.ValueMember = "EmployeeID";

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Employee emp = (Employee)ddlEmployees.SelectedItem; //context.Employees.Find(ddlEmployees.SelectedIndex);
            Global.EmployeeID = Convert.ToInt32(emp.EmployeeId);

            frmHome home = new frmHome();
            this.Hide();
            home.Show();
        }
    }
}
