
namespace NorthwindApp
{
    partial class frmDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteOrderDetail = new System.Windows.Forms.Button();
            this.btnEditOrderDetail = new System.Windows.Forms.Button();
            this.btnAddOrderDetail = new System.Windows.Forms.Button();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(90)))), ((int)(((byte)(132)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(26, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteOrderDetail);
            this.groupBox3.Controls.Add(this.btnEditOrderDetail);
            this.groupBox3.Controls.Add(this.btnAddOrderDetail);
            this.groupBox3.Controls.Add(this.dgvOrderDetails);
            this.groupBox3.Location = new System.Drawing.Point(26, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 285);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order Details";
            // 
            // btnDeleteOrderDetail
            // 
            this.btnDeleteOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(152)))), ((int)(((byte)(198)))));
            this.btnDeleteOrderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteOrderDetail.ForeColor = System.Drawing.Color.White;
            this.btnDeleteOrderDetail.Location = new System.Drawing.Point(299, 34);
            this.btnDeleteOrderDetail.Name = "btnDeleteOrderDetail";
            this.btnDeleteOrderDetail.Size = new System.Drawing.Size(133, 30);
            this.btnDeleteOrderDetail.TabIndex = 24;
            this.btnDeleteOrderDetail.Text = "Delete Line";
            this.btnDeleteOrderDetail.UseVisualStyleBackColor = false;
            this.btnDeleteOrderDetail.Click += new System.EventHandler(this.btnDeleteOrderDetail_Click);
            // 
            // btnEditOrderDetail
            // 
            this.btnEditOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(152)))), ((int)(((byte)(198)))));
            this.btnEditOrderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrderDetail.ForeColor = System.Drawing.Color.White;
            this.btnEditOrderDetail.Location = new System.Drawing.Point(160, 34);
            this.btnEditOrderDetail.Name = "btnEditOrderDetail";
            this.btnEditOrderDetail.Size = new System.Drawing.Size(133, 30);
            this.btnEditOrderDetail.TabIndex = 23;
            this.btnEditOrderDetail.Text = "Edit Line";
            this.btnEditOrderDetail.UseVisualStyleBackColor = false;
            this.btnEditOrderDetail.Click += new System.EventHandler(this.btnEditOrderDetail_Click);
            // 
            // btnAddOrderDetail
            // 
            this.btnAddOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(152)))), ((int)(((byte)(198)))));
            this.btnAddOrderDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrderDetail.ForeColor = System.Drawing.Color.White;
            this.btnAddOrderDetail.Location = new System.Drawing.Point(21, 34);
            this.btnAddOrderDetail.Name = "btnAddOrderDetail";
            this.btnAddOrderDetail.Size = new System.Drawing.Size(133, 30);
            this.btnAddOrderDetail.TabIndex = 22;
            this.btnAddOrderDetail.Text = "Add Line";
            this.btnAddOrderDetail.UseVisualStyleBackColor = false;
            this.btnAddOrderDetail.Click += new System.EventHandler(this.btnAddOrderDetail_Click);
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(16, 80);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowTemplate.Height = 25;
            this.dgvOrderDetails.Size = new System.Drawing.Size(724, 188);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(683, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 40);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Order details for Order ID:";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrderID.Location = new System.Drawing.Point(277, 35);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(120, 25);
            this.lblOrderID.TabIndex = 24;
            this.lblOrderID.Text = "[lblOrderID]";
            // 
            // frmDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Name = "frmDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.frmDetails_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Button btnEditOrderDetail;
        private System.Windows.Forms.Button btnAddOrderDetail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteOrderDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrderID;
    }
}