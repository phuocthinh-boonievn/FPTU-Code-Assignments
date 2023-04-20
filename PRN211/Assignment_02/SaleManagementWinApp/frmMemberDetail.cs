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
using System.Xml.Linq;

namespace SaleManagementWinApp
{
    public partial class frmMemberDetail : Form
    {
        public bool AddOrUpdate { get; set; }
        public Member ?MemberDetail { get; set; }
        public IMemberRepository ?memberRepository { get; set; }
        public frmMemberDetail()
        {
            InitializeComponent();
        }

        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            if (AddOrUpdate)
            {
                btnSave.Text = "Add member";
                btnSave.Tag = "Add member".ToLower();
                lblDetail.Text = "Add a new member";
                this.Text = "Add a member";
            }
            else
            {
                txtId.Enabled = false;
                btnSave.Text = "Update member";
                btnSave.Tag = "Update member".ToLower();
                lblDetail.Text = "Update an existing member";
                this.Text = "Update member";

                txtId.Text = MemberDetail.MemberId.ToString();
                txtEmail.Text = MemberDetail.Email;
                txtPassword.Text = MemberDetail.Password;
                txtCountry.Text = MemberDetail.Country;
                txtCity.Text = MemberDetail.City;
                txtCompany.Text = MemberDetail.CompanyName;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (AddOrUpdate)
            {
                Member member = new Member()
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Country = txtCountry.Text,
                    City = txtCity.Text,
                    CompanyName = txtCompany.Text,
                };
                try
                {
                    if (txtEmail.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter valid email");
                        txtEmail.Focus();
                        return;
                    }
                    memberRepository.Add(member);
                    MessageBox.Show("Added successfully!!", "Add new project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Add project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    memberRepository.Update(MemberDetail);
                    MessageBox.Show("Updated successfully!!", "Update existing project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Add project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmMemberDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMemberManagement frmMemberManagement = Application.OpenForms.OfType<frmMemberManagement>().FirstOrDefault();
            if (frmMemberManagement != null)
            {
                frmMemberManagement.btnUpdate.Enabled = true;
                frmMemberManagement.btnCreate.Enabled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
