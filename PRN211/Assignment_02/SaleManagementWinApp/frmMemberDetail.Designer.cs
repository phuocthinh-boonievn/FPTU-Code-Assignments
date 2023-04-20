namespace SaleManagementWinApp
{
    partial class frmMemberDetail
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
            txtCompany = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            label8 = new Label();
            label1 = new Label();
            label6 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            txtId = new TextBox();
            txtEmail = new TextBox();
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
            groupBox2.Controls.Add(txtCompany);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(txtCity);
            groupBox2.Controls.Add(txtCountry);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnClose);
            groupBox2.Controls.Add(btnSave);
            groupBox2.Controls.Add(txtId);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label11);
            groupBox2.Location = new Point(22, 97);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(511, 421);
            groupBox2.TabIndex = 66;
            groupBox2.TabStop = false;
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(181, 272);
            txtCompany.Margin = new Padding(2);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(309, 27);
            txtCompany.TabIndex = 70;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(15, 131);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 69;
            label3.Text = "Member Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(181, 128);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(309, 27);
            txtPassword.TabIndex = 68;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(181, 221);
            txtCity.Margin = new Padding(2);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(309, 27);
            txtCity.TabIndex = 67;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(181, 174);
            txtCountry.Margin = new Padding(2);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(309, 27);
            txtCountry.TabIndex = 66;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 275);
            label8.Name = "label8";
            label8.Size = new Size(116, 20);
            label8.TabIndex = 65;
            label8.Text = "Company Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 177);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 64;
            label1.Text = "Country";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 224);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 63;
            label6.Text = "City";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(354, 350);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(136, 29);
            btnClose.TabIndex = 57;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(180, 350);
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
            // txtEmail
            // 
            txtEmail.Location = new Point(181, 76);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(309, 27);
            txtEmail.TabIndex = 47;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ImeMode = ImeMode.NoControl;
            label10.Location = new Point(15, 79);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(106, 20);
            label10.TabIndex = 41;
            label10.Text = "Member Email";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ImeMode = ImeMode.NoControl;
            label11.Location = new Point(15, 35);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(84, 20);
            label11.TabIndex = 40;
            label11.Text = "Member ID";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblDetail);
            groupBox1.Location = new Point(22, 18);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(511, 73);
            groupBox1.TabIndex = 65;
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
            // frmMemberDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 529);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmMemberDetail";
            Text = "Member Detail";
            FormClosed += frmMemberDetail_FormClosed;
            Load += frmMemberDetail_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private TextBox txtCity;
        private TextBox txtCountry;
        private Label label8;
        private Label label1;
        private Label label6;
        private Button btnClose;
        private Button btnSave;
        private TextBox txtId;
        private TextBox txtEmail;
        private Label label10;
        private Label label11;
        private GroupBox groupBox1;
        private Label lblDetail;
        private Label label3;
        private TextBox txtPassword;
        private TextBox txtCompany;
    }
}