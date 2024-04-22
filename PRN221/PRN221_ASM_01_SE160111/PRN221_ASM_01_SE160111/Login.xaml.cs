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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAccountService accountService;
        public static long AuthenAccount { get; set; }
        public Login()
        {
            InitializeComponent();
            accountService = new AccountService();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account acc = accountService.GetAccount(txtUsername.Text);
                if (txtUsername.Text == null || txtPassword.Password == null)
                {
                    MessageBox.Show("Login error! Recheck your credentials!");
                }
                else if (acc == null)
                {
                    MessageBox.Show("Login error! Recheck your credentials!");
                }
                else if (acc != null && acc.Password != txtPassword.Password)
                {
                    MessageBox.Show("Login error! Wrong password!");
                }
                else
                {
                    MessageBox.Show("Login succesfull!");
                    AuthenAccount = acc.Role;
                    this.Hide();
                    PCManagement pcManagement = new PCManagement(AuthenAccount);
                    pcManagement.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
