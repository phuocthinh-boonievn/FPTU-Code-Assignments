using BusinessObjects;
using Microsoft.Extensions.Configuration;
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
    public partial class frmLogin : Form
    {
        public bool isAdmin = false;
        private readonly IMemberRepository memberRepository;
        public frmLogin()
        {
            InitializeComponent();
            memberRepository = new MemberRepository();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            string email = config["AdminAccount:Email"];
            string password = config["AdminAccount:Password"];

            Member Admin = new Member
            {
                MemberId = 0,
                Email = email,
                Password = password,
                City = "",
                Country = "",
                CompanyName = ""
            };
            try
            {
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("User name is empty !");
                    txtEmail.Focus();
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password is empty !");
                    txtPassword.Focus();
                    return;
                }

                var members = memberRepository.GetMembersList().Append(Admin)
                        .Where(u => txtEmail.Text.Equals(u.Email)
                        && txtPassword.Text.Equals(u.Password))
                        .FirstOrDefault();
                if (members != null)
                {
                    if (members.MemberId == 0) //admin
                    {
                        //load form management account
                        frmMain frmMain = new frmMain
                        {
                            isAdmin = true,
                        };
                        this.Hide();
                        frmMain.ShowDialog();
                    }
                    else if (members.MemberId > 0) { }
                    {
                        MessageBox.Show("This function isn't developed yet!");
                        frmMain frmMain = new frmMain
                        {
                            isAdmin = false
                        };
                        this.Hide();
                        frmMain.ShowDialog();
                    }
                    MessageBox.Show("You are not allowed to access this function!");

                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Notification");
                    txtEmail.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(0);
            }
        }
    }
}
