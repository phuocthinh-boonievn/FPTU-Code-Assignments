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
    public partial class frmOrderManagement : Form
    {
        public frmOrderManagement()
        {
            InitializeComponent();
        }

        private void frmOrderManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain frmMain = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (frmMain != null)
            {
                frmMain.manageOrderToolStripMenuItem.Enabled = true;
            }
        }
    }
}
