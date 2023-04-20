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
    public partial class frmProductManagement : Form
    {
        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {

        }

        private void frmProductManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain frmMain = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (frmMain != null)
            {
                frmMain.manageProductToolStripMenuItem.Enabled = true;
            }
        }
    }
}
