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
    public partial class frmProductManagement : Form
    {
        public IProductRepository productRepository { get; set; }
        public bool AddOrUpdate { get; set; }
        BindingSource source;

        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {

        }

        private void LoadProductsToGrid()
        {
            var products = productRepository.GetProductsList();
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                dgvProducts.DataSource = null;
                dgvProducts.DataSource = source;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list error");
            }
        }

        private void ClearBindings()
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.btnCreate.Enabled = false;
            frmProductDetail detailForm = new frmProductDetail()
            {
                productRepository = productRepository,
                AddOrUpdate = true
            };
            detailForm.ShowDialog();
            source.Position = source.Count - 1;
            LoadProductsToGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvProducts.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            Product selected = (Product)row.DataBoundItem;

            this.btnUpdate.Enabled = false;
            frmProductDetail detailForm = new frmProductDetail
            {
                productRepository = this.productRepository,
                AddOrUpdate = false,
                ProductDetail = selected
            };
            detailForm.Show();
            source.Position = source.IndexOf(selected);
            LoadProductsToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvProducts.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            Product selected = (Product)row.DataBoundItem;
            try
            {
                if (MessageBox.Show($"Are you sure? This product will be deleted:\n" + $"Product ID: {selected.ProductId}\n" + $"Product Name: {selected.ProductName}\n", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //var project = GetProjectObject();
                    productRepository.Delete(selected.ProductId);
                    LoadProductsToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete an paper");
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
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
