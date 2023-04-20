namespace ProjectManagementWinApp_NguyenPhanPhuocThinh
{
    partial class frmProjectManagement
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
            btnClose = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            dgvProjectList = new DataGridView();
            label1 = new Label();
            grSearch = new GroupBox();
            btnFilter = new Button();
            cboCityFilter = new ComboBox();
            radioNameSearch = new RadioButton();
            radioIDSearch = new RadioButton();
            btnSearch = new Button();
            txtSearchValue = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtProjectID = new TextBox();
            txtProjectName = new TextBox();
            txtProjectAddress = new TextBox();
            txtProjectCity = new TextBox();
            txtProjectDescription = new TextBox();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjectList).BeginInit();
            grSearch.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClose);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Location = new Point(25, 678);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(804, 92);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(598, 35);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(126, 35);
            btnClose.TabIndex = 3;
            btnClose.Text = "Exit";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(432, 35);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(126, 35);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(265, 35);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(126, 35);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(96, 35);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(126, 35);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // dgvProjectList
            // 
            dgvProjectList.BackgroundColor = SystemColors.Control;
            dgvProjectList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjectList.GridColor = SystemColors.Control;
            dgvProjectList.Location = new Point(25, 418);
            dgvProjectList.Name = "dgvProjectList";
            dgvProjectList.RowHeadersWidth = 51;
            dgvProjectList.RowTemplate.Height = 29;
            dgvProjectList.Size = new Size(804, 254);
            dgvProjectList.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 2;
            label1.Text = "View Projects";
            // 
            // grSearch
            // 
            grSearch.BackColor = SystemColors.Control;
            grSearch.Controls.Add(btnFilter);
            grSearch.Controls.Add(cboCityFilter);
            grSearch.Controls.Add(radioNameSearch);
            grSearch.Controls.Add(radioIDSearch);
            grSearch.Controls.Add(btnSearch);
            grSearch.Controls.Add(txtSearchValue);
            grSearch.Location = new Point(25, 272);
            grSearch.Margin = new Padding(3, 4, 3, 4);
            grSearch.Name = "grSearch";
            grSearch.Padding = new Padding(3, 4, 3, 4);
            grSearch.Size = new Size(804, 132);
            grSearch.TabIndex = 51;
            grSearch.TabStop = false;
            grSearch.Text = "Search or filter ";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(59, 82);
            btnFilter.Margin = new Padding(3, 4, 3, 4);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(81, 27);
            btnFilter.TabIndex = 26;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cboCityFilter
            // 
            cboCityFilter.FormattingEnabled = true;
            cboCityFilter.Location = new Point(152, 82);
            cboCityFilter.Name = "cboCityFilter";
            cboCityFilter.Size = new Size(226, 28);
            cboCityFilter.TabIndex = 25;
            // 
            // radioNameSearch
            // 
            radioNameSearch.AutoSize = true;
            radioNameSearch.Location = new Point(531, 37);
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
            radioIDSearch.Location = new Point(400, 37);
            radioIDSearch.Name = "radioIDSearch";
            radioIDSearch.Size = new Size(113, 24);
            radioIDSearch.TabIndex = 23;
            radioIDSearch.TabStop = true;
            radioIDSearch.Text = "Search by ID";
            radioIDSearch.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(59, 34);
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
            txtSearchValue.Location = new Point(152, 36);
            txtSearchValue.Margin = new Padding(3, 4, 3, 4);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.Size = new Size(226, 27);
            txtSearchValue.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 53);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 52;
            label2.Text = "Project ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 100);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 53;
            label3.Text = "Project Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 155);
            label4.Name = "label4";
            label4.Size = new Size(146, 20);
            label4.TabIndex = 54;
            label4.Text = "Estimated Start Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 208);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 55;
            label5.Text = "Estimated End Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(425, 100);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 56;
            label6.Text = "Project City";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(425, 53);
            label7.Name = "label7";
            label7.Size = new Size(112, 20);
            label7.TabIndex = 57;
            label7.Text = "Project Address";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(425, 155);
            label8.Name = "label8";
            label8.Size = new Size(135, 20);
            label8.TabIndex = 58;
            label8.Text = "Project Description";
            // 
            // txtProjectID
            // 
            txtProjectID.Location = new Point(177, 50);
            txtProjectID.Name = "txtProjectID";
            txtProjectID.Size = new Size(226, 27);
            txtProjectID.TabIndex = 59;
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(177, 100);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(226, 27);
            txtProjectName.TabIndex = 60;
            // 
            // txtProjectAddress
            // 
            txtProjectAddress.Location = new Point(577, 50);
            txtProjectAddress.Name = "txtProjectAddress";
            txtProjectAddress.Size = new Size(230, 27);
            txtProjectAddress.TabIndex = 62;
            // 
            // txtProjectCity
            // 
            txtProjectCity.Location = new Point(577, 100);
            txtProjectCity.Name = "txtProjectCity";
            txtProjectCity.Size = new Size(230, 27);
            txtProjectCity.TabIndex = 63;
            // 
            // txtProjectDescription
            // 
            txtProjectDescription.Location = new Point(577, 152);
            txtProjectDescription.Multiline = true;
            txtProjectDescription.Name = "txtProjectDescription";
            txtProjectDescription.ScrollBars = ScrollBars.Vertical;
            txtProjectDescription.Size = new Size(230, 46);
            txtProjectDescription.TabIndex = 65;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Enabled = false;
            dtpEndDate.Location = new Point(177, 205);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(224, 27);
            dtpEndDate.TabIndex = 66;
            // 
            // dtpStartDate
            // 
            dtpStartDate.AllowDrop = true;
            dtpStartDate.Enabled = false;
            dtpStartDate.Location = new Point(177, 155);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(224, 27);
            dtpStartDate.TabIndex = 68;
            // 
            // frmProjectManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 782);
            Controls.Add(dtpStartDate);
            Controls.Add(dtpEndDate);
            Controls.Add(txtProjectDescription);
            Controls.Add(txtProjectCity);
            Controls.Add(txtProjectAddress);
            Controls.Add(txtProjectName);
            Controls.Add(txtProjectID);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(grSearch);
            Controls.Add(label1);
            Controls.Add(dgvProjectList);
            Controls.Add(groupBox1);
            Name = "frmProjectManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProjectManagement";
            FormClosing += frmProjectManagement_FormClosing;
            Load += frmProjectManagement_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProjectList).EndInit();
            grSearch.ResumeLayout(false);
            grSearch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnClose;
        private DataGridView dgvProjectList;
        private Label label1;
        private GroupBox grSearch;
        private RadioButton radioNameSearch;
        private RadioButton radioIDSearch;
        private Button btnSearch;
        private TextBox txtSearchValue;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cboCityFilter;
        private Label label7;
        private Label label8;
        private TextBox txtProjectID;
        private TextBox txtProjectName;
        private TextBox txtProjectAddress;
        private TextBox txtProjectCity;
        private TextBox txtProjectDescription;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        internal Button btnUpdate;
        internal Button btnCreate;
        private Button btnFilter;
    }
}