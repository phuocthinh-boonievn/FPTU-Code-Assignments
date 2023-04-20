using BusinessObjects;
using Repositories;


namespace SaleManagementWinApp
{
    public partial class frmMemberManagement : Form
    {
        public IMemberRepository memberRepository { get; set; }
        public bool addOrUpdate { get; set; }

        BindingSource source;

        public frmMemberManagement()
        {
            InitializeComponent();
        }
        private void LoadMembersToGrid()
        {
            var projects = memberRepository.GetMembersList();
            try
            {
                ClearBindings();

                source = new BindingSource();
                source.DataSource = projects;


                txtMemberId.DataBindings.Add("Text", source, "MemberId");
                txtMemberEmail.DataBindings.Add("Text", source, "Email");
                txtMemberPassword.DataBindings.Add("Text", source, "Password");
                txtCompanyName.DataBindings.Add("Text", source, "CompanyName");
                txtCity.DataBindings.Add("Text", source, "City");
                txtCountry.DataBindings.Add("Text", source, "Country");

                dgvMembers.DataSource = null;
                dgvMembers.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load project list error");
            }
        }
        private void ClearBindings()
        {
            txtMemberId.DataBindings.Clear();
            txtMemberEmail.DataBindings.Clear();
            txtMemberPassword.DataBindings.Clear();
            txtCompanyName.DataBindings.Clear();
            txtCountry.DataBindings.Clear();
            txtCity.DataBindings.Clear();
        }
        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            LoadMembersToGrid();
        }
        private void frmMemberManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain frmMain = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (frmMain != null)
            {
                frmMain.manageMemberToolStripMenuItem.Enabled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.btnCreate.Enabled = false;
            frmMemberDetail detailForm = new frmMemberDetail()
            {
                memberRepository = memberRepository,
                addOrUpdate = true
            };
            detailForm.ShowDialog();
            source.Position = source.Count - 1;
            LoadMembersToGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvMembers.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            Member selected = (Member)row.DataBoundItem;

            this.btnUpdate.Enabled = false;
            frmMemberDetail detailForm = new frmMemberDetail
            {
                memberRepository = this.memberRepository,
                addOrUpdate = false,
                MemberDetail = selected
            };
            detailForm.Show();
            source.Position = source.IndexOf(selected);
            LoadMembersToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvMembers.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            Member selected = (Member)row.DataBoundItem;
            try
            {
                if (MessageBox.Show($"Are you sure? This member will be deleted:\n" + $"Member ID: {selected.MemberId}\n" + $"Email: {selected.Email}\n", "Delete project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //var project = GetProjectObject();
                    memberRepository.Delete(selected.MemberId);
                    LoadMembersToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete an paper");
            }
        }
    }
}
