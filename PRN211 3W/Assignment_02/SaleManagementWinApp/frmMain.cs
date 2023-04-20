using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleManagementWinApp
{
    public partial class frmMain : Form
    {
        public bool isAdmin { get; set; }
        public bool addOrUpdate;
        IMemberRepository MemberRepository = new MemberRepository();

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                lblWelcome.Text = "Welcome Administrator";
            }
            else
            {
                lblWelcome.Text = "Welcome member, your actions are limited";
            }
        }

        protected void manageMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblWelcome.SendToBack();
            frmMemberManagement frmMember = new frmMemberManagement
            {
                memberRepository = this.MemberRepository
            };

            frmMember.MdiParent = this;
            frmMember.WindowState = FormWindowState.Maximized;
            this.manageMemberToolStripMenuItem.Enabled = false;
            frmMember.Show();

        }
        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductManagement frmProduct = new frmProductManagement();

            frmProduct.MdiParent = this;
            frmProduct.WindowState = FormWindowState.Maximized;
            this.manageProductToolStripMenuItem.Enabled = false;
            frmProduct.Show();
        }

        private void manageOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderManagement frmOrder = new frmOrderManagement();

            frmOrder.MdiParent = this;
            frmOrder.WindowState = FormWindowState.Maximized;
            this.manageOrderToolStripMenuItem.Enabled = false;
            frmOrder.Show();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult diaglog = MessageBox.Show("Do you really want to exit the application?"
                , "Exit", MessageBoxButtons.YesNo);
            if (diaglog == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else e.Cancel = true;
        }
        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }





}
