namespace SaleManagementWinApp
{
    partial class frmOrderManagement
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
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            dataGridView1 = new DataGridView();
            dgvOrders = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Location = new Point(12, 737);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(816, 79);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(533, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 35);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(366, 26);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 35);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(197, 26);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(126, 35);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 406);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(816, 311);
            dataGridView1.TabIndex = 11;
            // 
            // dgvOrders
            // 
            dgvOrders.AutoSize = true;
            dgvOrders.Location = new Point(12, 9);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.Size = new Size(89, 20);
            dgvOrders.TabIndex = 10;
            dgvOrders.Text = "View Orders";
            // 
            // frmOrderManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 829);
            Controls.Add(dataGridView1);
            Controls.Add(dgvOrders);
            Controls.Add(groupBox1);
            Name = "frmOrderManagement";
            Text = "Order Management";
            FormClosing += frmOrderManagement_FormClosing;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnDelete;
        internal Button btnUpdate;
        internal Button btnCreate;
        private DataGridView dataGridView1;
        private Label dgvOrders;
    }
}