namespace ProjectManagementWinApp_NguyenPhanPhuocThinh
{
    partial class frmProjectDetail
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
            groupBox2 = new GroupBox();
            txtCity = new TextBox();
            txtAddr = new TextBox();
            label8 = new Label();
            dtpEndDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label6 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            txtId = new TextBox();
            txtName = new TextBox();
            dtpStartDate = new DateTimePicker();
            txtDesc = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            groupBox1 = new GroupBox();
            lblDetail = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCity);
            groupBox2.Controls.Add(txtAddr);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(dtpEndDate);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnClose);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(txtId);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(dtpStartDate);
            groupBox2.Controls.Add(txtDesc);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(12, 91);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(511, 447);
            groupBox2.TabIndex = 64;
            groupBox2.TabStop = false;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(180, 273);
            txtCity.Margin = new Padding(2);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(309, 27);
            txtCity.TabIndex = 67;
            // 
            // txtAddr
            // 
            txtAddr.Location = new Point(180, 226);
            txtAddr.Margin = new Padding(2);
            txtAddr.Name = "txtAddr";
            txtAddr.Size = new Size(309, 27);
            txtAddr.TabIndex = 66;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 331);
            label8.Name = "label8";
            label8.Size = new Size(135, 20);
            label8.TabIndex = 65;
            label8.Text = "Project Description";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(180, 175);
            dtpEndDate.Margin = new Padding(2);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(309, 27);
            dtpEndDate.TabIndex = 61;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 229);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 64;
            label1.Text = "Project Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(15, 180);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 60;
            label2.Text = "Estimated End Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 276);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 63;
            label6.Text = "Project City";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(355, 393);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 29);
            btnClose.TabIndex = 57;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(181, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 29);
            btnSave.TabIndex = 56;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(181, 32);
            txtId.Margin = new Padding(2);
            txtId.Name = "txtId";
            txtId.Size = new Size(309, 27);
            txtId.TabIndex = 53;
            // 
            // txtName
            // 
            txtName.Location = new Point(181, 76);
            txtName.Margin = new Padding(2);
            txtName.Name = "txtName";
            txtName.Size = new Size(309, 27);
            txtName.TabIndex = 47;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(181, 125);
            dtpStartDate.Margin = new Padding(2);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(309, 27);
            dtpStartDate.TabIndex = 45;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(180, 324);
            txtDesc.Margin = new Padding(2);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Vertical;
            txtDesc.Size = new Size(309, 27);
            txtDesc.TabIndex = 44;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(15, 130);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(146, 20);
            label9.TabIndex = 42;
            label9.Text = "Estimated Start Date";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ImeMode = ImeMode.NoControl;
            label10.Location = new Point(15, 79);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(99, 20);
            label10.TabIndex = 41;
            label10.Text = "Project Name";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ImeMode = ImeMode.NoControl;
            label11.Location = new Point(15, 35);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(74, 20);
            label11.TabIndex = 40;
            label11.Text = "Project ID";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDetail);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(511, 73);
            groupBox1.TabIndex = 63;
            groupBox1.TabStop = false;
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblDetail.Location = new Point(31, 14);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(107, 46);
            lblDetail.TabIndex = 58;
            lblDetail.Text = "Detail";
            // 
            // frmProjectDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 550);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmProjectDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProjectDetail";
            FormClosed += frmProjectDetail_FormClosed;
            Load += frmProjectDetail_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TextBox txtCity;
        private TextBox txtAddr;
        private Label label8;
        private DateTimePicker dtpEndDate;
        private Label label1;
        private Label label2;
        private Label label6;
        private Button btnClose;
        private Button btnSave;
        private TextBox txtId;
        private TextBox txtName;
        private DateTimePicker dtpStartDate;
        private TextBox txtDesc;
        private Label label9;
        private Label label10;
        private Label label11;
        private GroupBox groupBox1;
        private Label lblDetail;
    }
}