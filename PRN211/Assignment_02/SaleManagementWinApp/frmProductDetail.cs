using BusinessObjects;
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
    public partial class frmProductDetail : Form
    {
        public bool AddOrUpdate { get; set; }
        public Product ?ProductDetail { get; set; }
        public IProductRepository ?productRepository { get; set; }
        public frmProductDetail()
        {
            InitializeComponent();
        }
    }
}
