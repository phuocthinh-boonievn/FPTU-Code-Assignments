namespace SaleManagementWinApp
{
    partial class frmProductManagement
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
            grSearch = new GroupBox();
            radioAvailableSearch = new RadioButton();
            radioPriceSearch = new RadioButton();
            radioNameSearch = new RadioButton();
            radioIDSearch = new RadioButton();
            btnSearch = new Button();
            txtSearchValue = new TextBox();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            dgvProducts = new DataGridView();
            label5 = new Label();
            txtCompanyName = new TextBox();
            txtMemberPassword = new TextBox();
            label4 = new Label();
            txtCity = new TextBox();
            txtCountry = new TextBox();
            txtMemberEmail = new TextBox();
            txtMemberId = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grSearch.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // grSearch
            // 
            grSearch.BackColor = SystemColors.Control;
            grSearch.Controls.Add(radioAvailableSearch);
            grSearch.Controls.Add(radioPriceSearch);
            grSearch.Controls.Add(radioNameSearch);
            grSearch.Controls.Add(radioIDSearch);
            grSearch.Controls.Add(btnSearch);
            grSearch.Controls.Add(txtSearchValue);
            grSearch.Location = new Point(12, 593);
            grSearch.Margin = new Padding(3, 4, 3, 4);
            grSearch.Name = "grSearch";
            grSearch.Padding = new Padding(3, 4, 3, 4);
            grSearch.Size = new Size(816, 141);
            grSearch.TabIndex = 56;
            grSearch.TabStop = false;
            grSearch.Text = "Search by ID, name, price and in stock";
            // 
            // radioAvailableSearch
            // 
            radioAvailableSearch.AutoSize = true;
            radioAvailableSearch.Location = new Point(361, 88);
            radioAvailableSearch.Name = "radioAvailableSearch";
            radioAvailableSearch.Size = new Size(80, 24);
            radioAvailableSearch.TabIndex = 26;
            radioAvailableSearch.TabStop = true;
            radioAvailableSearch.Text = "In stock";
            radioAvailableSearch.UseVisualStyleBackColor = true;
            // 
            // radioPriceSearch
            // 
            radioPriceSearch.AutoSize = true;
            radioPriceSearch.Location = new Point(660, 39);
            radioPriceSearch.Name = "radioPriceSearch";
            radioPriceSearch.Size = new Size(131, 24);
            radioPriceSearch.TabIndex = 25;
            radioPriceSearch.TabStop = true;
            radioPriceSearch.Text = "Search by price";
            radioPriceSearch.UseVisualStyleBackColor = true;
            // 
            // radioNameSearch
            // 
            radioNameSearch.AutoSize = true;
            radioNameSearch.Location = new Point(499, 39);
            radioNameSearch.Name = "radioNameSearch";
            radioNameSearch.Size = new Size(138, 24);
            radioNameSearch.TabIndex = 24;
            radioNameSearch.TabStop = true;
            radioNameSearch.Text = "Search by Name";
            radioNameSearch.UseVisualStyleBackColor = true;
            // 
            // radioIDSearch
            // 
            radioIDSearch.AutoSize = true;
            radioIDSearch.Location = new Point(361, 39);
            radioIDSearch.Name = "radioIDSearch";
            radioIDSearch.Size = new Size(113, 24);
            radioIDSearch.TabIndex = 23;
            radioIDSearch.TabStop = true;
            radioIDSearch.Text = "Search by ID";
            radioIDSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(15, 35);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(81, 27);
            btnSearch.TabIndex = 22;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchValue
            // 
            txtSearchValue.Location = new Point(108, 37);
            txtSearchValue.Margin = new Padding(3, 4, 3, 4);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.Size = new Size(238, 27);
            txtSearchValue.TabIndex = 17;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Location = new Point(12, 741);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(815, 79);
            groupBox1.TabIndex = 57;
            groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(515, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 35);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(348, 26);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 35);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(179, 26);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(126, 35);
            btnCreate.TabIndex = 3;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 205);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.RowTemplate.Height = 29;
            dgvProducts.Size = new Size(815, 381);
            dgvProducts.TabIndex = 59;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(430, 41);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 88;
            label5.Text = "Weight";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(570, 38);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(230, 27);
            txtCompanyName.TabIndex = 87;
            // 
            // txtMemberPassword
            // 
            txtMemberPassword.Location = new Point(168, 138);
            txtMemberPassword.Name = "txtMemberPassword";
            txtMemberPassword.Size = new Size(226, 27);
            txtMemberPassword.TabIndex = 86;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 141);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 85;
            label4.Text = "Product Name";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(570, 138);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(230, 27);
            txtCity.TabIndex = 84;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(570, 85);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(230, 27);
            txtCountry.TabIndex = 83;
            // 
            // txtMemberEmail
            // 
            txtMemberEmail.Location = new Point(168, 88);
            txtMemberEmail.Name = "txtMemberEmail";
            txtMemberEmail.Size = new Size(226, 27);
            txtMemberEmail.TabIndex = 82;
            // 
            // txtMemberId
            // 
            txtMemberId.Location = new Point(168, 38);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(226, 27);
            txtMemberId.TabIndex = 81;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(430, 88);
            label7.Name = "label7";
            label7.Size = new Size(41, 20);
            label7.TabIndex = 80;
            label7.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(430, 141);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 79;
            label6.Text = "In Stock";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 88);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 78;
            label3.Text = "Category ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 41);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 77;
            label2.Text = "Product ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 76;
            label1.Text = "View Products";
            // 
            // frmProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 829);
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
            Controls.Add(label1);
            Controls.Add(dgvProducts);
            Controls.Add(groupBox1);
            Controls.Add(grSearch);
            Name = "frmProductManagement";
            Text = "Product Management";
            FormClosing += frmProductManagement_FormClosing;
            Load += frmProductManagement_Load;
            grSearch.ResumeLayout(false);
            grSearch.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grSearch;
        private RadioButton radioAvailableSearch;
        private RadioButton radioPriceSearch;
        private RadioButton radioNameSearch;
        private RadioButton radioIDSearch;
        private Button btnSearch;
        private TextBox txtSearchValue;
        private GroupBox groupBox1;
        private Button btnDelete;
        private DataGridView dgvProducts;
        private Label label5;
        private TextBox txtCompanyName;
        private TextBox txtMemberPassword;
        private Label label4;
        private TextBox txtCity;
        private TextBox txtCountry;
        private TextBox txtMemberEmail;
        private TextBox txtMemberId;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label2;
        private Label label1;
        public Button btnUpdate;
        public Button btnCreate;
    }
}