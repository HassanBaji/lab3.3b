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
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NorthwindApp
{
    public partial class frmDetails : Form
    {
        NorthwindDBContext context;
        Order order;
        public frmDetails(int orderID)
        {
            InitializeComponent();
            context= new NorthwindDBContext();
            this.order = context.Orders.Include(x=> x.OrderDetails).ThenInclude(a => a.Product).Where(c => c.OrderId== orderID).FirstOrDefault();

        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            lblOrderID.Text = order.OrderId.ToString();
            refreshList();
            
        }

        private void refreshList()
        {
            try
            {
                dgvOrderDetails.DataSource = context.OrderDetails.Local.Where(x=> x.OrderId== order.OrderId).ToList();
                dgvOrderDetails.Columns[5].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {
            
            try
            {


                frmDetailsDialogueEdit frm = new frmDetailsDialogueEdit(order.OrderId);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    context.OrderDetails.Add(frm.orderDetail);
                    refreshList();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedOrderDetail = (OrderDetail)dgvOrderDetails.SelectedCells[0].OwningRow.DataBoundItem;
                frmDetailsDialogueEdit frm = new frmDetailsDialogueEdit(selectedOrderDetail);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    context.OrderDetails.Update(frm.orderDetail);
                    refreshList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteOrderDetail_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCell = (OrderDetail)dgvOrderDetails.SelectedCells[0].OwningRow.DataBoundItem;
                if (MessageBox.Show("are you sure you want to delete?", "confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    context.OrderDetails.Remove(selectedCell);
                    refreshList();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                context.SaveChanges();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

