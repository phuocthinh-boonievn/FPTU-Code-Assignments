namespace SaleManagementWinApp
{
    partial class frmMemberManagement
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
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            label1 = new Label();
            dgvMembers = new DataGridView();
            groupBox1 = new GroupBox();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            txtMemberEmail = new TextBox();
            txtMemberId = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtMemberPassword = new TextBox();
            label4 = new Label();
            txtCompanyName = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(591, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 35);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(424, 26);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 35);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(255, 26);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(126, 35);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 6;
            label1.Text = "View Members";
            // 
            // dgvMembers
            // 
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(11, 195);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.RowTemplate.Height = 29;
            dgvMembers.Size = new Size(921, 311);
            dgvMembers.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Location = new Point(11, 512);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(955, 89);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(656, 140);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(230, 27);
            txtCity.TabIndex = 71;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(656, 87);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(230, 27);
            txtCountry.TabIndex = 70;
            // 
            // txtMemberEmail
            // 
            txtMemberEmail.Location = new Point(205, 90);
            txtMemberEmail.Name = "txtMemberEmail";
            txtMemberEmail.Size = new Size(226, 27);
            txtMemberEmail.TabIndex = 69;
            // 
            // txtMemberId
            // 
            txtMemberId.Location = new Point(205, 40);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(226, 27);
            txtMemberId.TabIndex = 68;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 90);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 67;
            label7.Text = "Country";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(516, 143);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 66;
            label6.Text = "City";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 90);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 65;
            label3.Text = "Member Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 43);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 64;
            label2.Text = "Member ID";
            // 
            // txtMemberPassword
            // 
            txtMemberPassword.Location = new Point(205, 140);
            txtMemberPassword.Name = "txtMemberPassword";
            txtMemberPassword.Size = new Size(226, 27);
            txtMemberPassword.TabIndex = 73;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 143);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 72;
            label4.Text = "Member Password";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(656, 40);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(230, 27);
            txtCompanyName.TabIndex = 74;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(516, 43);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 75;
            label5.Text = "Company Name";
            // 
            // frmMemberManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 831);
            Controls.Add(label5);
            Controls.Add(txtCompanyName);
            Controls.Add(txtMemberPassword);
            Controls.Add(label4);
            Controls.Add(txtCity);
            Controls.Add(txtCountry);
            Controls.Add(txtMemberEmail);
            Controls.Add(txtMemberId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(dgvMembers);
            Controls.Add(label1);
            Name = "frmMemberManagement";
            Text = "Member Management";
            FormClosing += frmMemberManagement_FormClosing;
            Load += frmMemberManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        internal Button btnUpdate;
        internal Button btnCreate;
        private Label label1;
        private DataGridView dgvMembers;
        private GroupBox groupBox1;
        private TextBox txtCity;
        private TextBox txtCountry;
        private TextBox txtMemberEmail;
        private TextBox txtMemberId;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label2;
        private TextBox txtMemberPassword;
        private Label label4;
        private TextBox txtCompanyName;
        private Label label5;
    }
}