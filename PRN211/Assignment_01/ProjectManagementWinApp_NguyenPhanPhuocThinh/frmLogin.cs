using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementWinApp_NguyenPhanPhuocThinh
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string fileName = "appsettings.json";
            string json = File.ReadAllText(fileName);  // đọc text từ tập tin JSONs

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // deserialize từ chuỗi đọc ở tập tin JSOn --> đối tượng DefaultAccount
            var adminAccount = JsonSerializer.Deserialize<DefaultAccount>(json, options);

            string email = adminAccount.Email;
            string password = adminAccount.Password;
            string role = adminAccount.Role;

            if (txtEmail.Text.Equals(email) && txtPassword.Text.Equals(password))
            {
                frmProjectManagement projectManagement = new frmProjectManagement();
                projectManagement.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You are not allowed to access admin functions!");
            }
             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(0);
            }
        }
    }
    public class DefaultAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
