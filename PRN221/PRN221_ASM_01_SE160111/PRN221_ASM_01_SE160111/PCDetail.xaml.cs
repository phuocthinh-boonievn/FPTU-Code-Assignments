using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_BO;
using WPF_Service;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for PCDetail.xaml
    /// </summary>
    public partial class PCDetail : Window
    {
        public Pc selectedPC;
        private short id;
        private bool isEditMode = false;
        private readonly IPCService pcService;

        public PCDetail(Pc pc)
        {
            InitializeComponent();
            pcService = new PCService();
            this.selectedPC = pc;
        }
        public PCDetail()
        {
            InitializeComponent();
            pcService = new PCService();
        }
        public void InitializeForAdd()
        {
            txtMode.Text = "Add a new item";
            btnAction.Content = "Add";
            isEditMode = false;
        }
        public void InitializeForEdit()
        {
            txtMode.Text = "Updating an item";
            btnAction.Content = "Save";
            isEditMode = true;
            txtTitle.Text = selectedPC.Title;
            txtDesc.Text = selectedPC.Description;
            txtPrice.Text = selectedPC.Price.ToString();
            txtReview.Text = selectedPC.Review.ToString();
            txtStatus.Text = selectedPC.Status.ToString();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            Pc updatedPc = selectedPC;
            if (isEditMode)
            {
                updatedPc.Title = txtTitle.Text;
                updatedPc.Description = txtDesc.Text;
                updatedPc.Price = Convert.ToInt64(txtPrice.Text);
                updatedPc.Review = Convert.ToInt64(txtReview.Text);
                updatedPc.Status = Convert.ToBoolean(txtStatus.Text);

                pcService.UpdatePC(updatedPc);

                MessageBox.Show("PC updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                Pc newPC = new Pc
                {
                    Title = txtTitle.Text,
                    Description = txtDesc.Text,
                    Price = Convert.ToInt64(txtPrice.Text),
                    Review = Convert.ToInt64(txtReview.Text),
                    Status = true,
                    CategoryId = 1,
                    StoreId= 1
                };

                pcService.AddPC(newPC);

                MessageBox.Show("New PC added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
