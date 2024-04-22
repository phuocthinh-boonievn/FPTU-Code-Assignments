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
    /// Interaction logic for PCManagement.xaml
    /// </summary>
    public partial class PCManagement : Window
    {
        private long AuthenAccount;
        private readonly IPCService pcService;
        public PCManagement(long authen)
        {
            InitializeComponent();
            pcService = new PCService();

            AuthenAccount = authen;
            SetAuthenData();
        }
        private void SetAuthenData()
        {
            // Hide all buttons by default
            btnAdd.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;

            if (AuthenAccount == 3) 
            {
                txtWelcome.Text = "Welcome Admin";
            }
            else if (AuthenAccount == 2) 
            {
                btnDelete.Visibility = Visibility.Collapsed;
                txtWelcome.Text = "Welcome Manager";
            }
            else
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            PCDetail pcDetailWindow = new PCDetail();
            pcDetailWindow.InitializeForAdd();
            pcDetailWindow.ShowDialog();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgvPCs.SelectedItem != null && dgvPCs.SelectedItem is Pc selectedPC)
            {
                PCDetail pcDetailWindow = new PCDetail(selectedPC);
                pcDetailWindow.InitializeForEdit();
                pcDetailWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a PC to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPC = dgvPCs.SelectedItem as Pc; 

            if (selectedPC != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete this item: {selectedPC.Title} ?", "Delete Confirmation", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                // Check the user's choice
                if (result == MessageBoxResult.Yes)
                {
                    pcService.DeletePC(selectedPC.ProductId);

                    btnLoad_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please select a PC.", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if(searchText == null || searchText.Equals(""))
            {
                MessageBox.Show("Please enter an valid item title.", "Search Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            List<Pc> searchResults = pcService.SearchPC(searchText);

            dgvPCs.ItemsSource = searchResults;
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Pc> PCs = pcService.GetPCs();
            dgvPCs.ItemsSource = PCs;
        }
        private void dgvPCs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPC = dgvPCs.SelectedItem as Pc; 

            if (selectedPC != null)
            {
                txtTitle.Text = selectedPC.Title;
                txtPrice.Text = selectedPC.Price.ToString(); 
                txtDesc.Text = selectedPC.Description;
                txtReview.Text = txtReview.Text = selectedPC.Review.ToString();
                if (selectedPC.Status == true)
                {
                    txtStatus.Text = "Available";
                }
                else
                {
                    txtStatus.Text = "N/A";
                }
            }
            else
            {
                txtTitle.Text = "";
                txtPrice.Text = "";
                txtDesc.Text = "";
                txtReview.Text = "";
                txtStatus.Text = "";
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            AuthenAccount = 0;

            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
