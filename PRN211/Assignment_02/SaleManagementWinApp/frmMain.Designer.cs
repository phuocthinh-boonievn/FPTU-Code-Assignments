namespace SaleManagementWinApp
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            file = new ToolStripMenuItem();
            manageMemberToolStripMenuItem = new ToolStripMenuItem();
            manageProductToolStripMenuItem = new ToolStripMenuItem();
            manageOrderToolStripMenuItem = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            lblWelcome = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { file, menuExit });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = file;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1135, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "File";
            // 
            // file
            // 
            file.DropDownItems.AddRange(new ToolStripItem[] { manageMemberToolStripMenuItem, manageProductToolStripMenuItem, manageOrderToolStripMenuItem });
            file.Name = "file";
            file.Size = new Size(46, 24);
            file.Text = "File";
            // 
            // manageMemberToolStripMenuItem
            // 
            manageMemberToolStripMenuItem.Name = "manageMemberToolStripMenuItem";
            manageMemberToolStripMenuItem.Size = new Size(206, 26);
            manageMemberToolStripMenuItem.Text = "Manage Member";
            manageMemberToolStripMenuItem.Click += manageMemberToolStripMenuItem_Click;
            // 
            // manageProductToolStripMenuItem
            // 
            manageProductToolStripMenuItem.Name = "manageProductToolStripMenuItem";
            manageProductToolStripMenuItem.Size = new Size(206, 26);
            manageProductToolStripMenuItem.Text = "Manage Product";
            manageProductToolStripMenuItem.Click += manageProductToolStripMenuItem_Click;
            // 
            // manageOrderToolStripMenuItem
            // 
            manageOrderToolStripMenuItem.Name = "manageOrderToolStripMenuItem";
            manageOrderToolStripMenuItem.Size = new Size(206, 26);
            manageOrderToolStripMenuItem.Text = "Manage Order";
            manageOrderToolStripMenuItem.Click += manageOrderToolStripMenuItem_Click;
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(47, 24);
            menuExit.Text = "Exit";
            menuExit.Click += menuExit_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = SystemColors.AppWorkspace;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblWelcome.Location = new Point(27, 57);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(160, 46);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Welcome";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 862);
            Controls.Add(lblWelcome);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Management";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuExit;
        protected ToolStripMenuItem file;
        public ToolStripMenuItem manageMemberToolStripMenuItem;
        public ToolStripMenuItem manageProductToolStripMenuItem;
        public ToolStripMenuItem manageOrderToolStripMenuItem;
        private Label lblWelcome;
    }
}