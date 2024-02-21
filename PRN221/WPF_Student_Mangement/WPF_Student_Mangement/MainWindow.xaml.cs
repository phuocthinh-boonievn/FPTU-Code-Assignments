using DemoWPFGUI;
using DemoWPFService;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Student_Mangement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string loginName = "thinh";
        const string loginPass = "12345";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            string userName = txt_Username.Text;
            MessageBox.Show("Greetings" + userName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Username.Text != loginName || txt_Password.Text != loginPass)
            {
                MessageBox.Show("Login error! Recheck your credentials!");
            }
            else new DemoWPFGUI.Student().Show(); 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
