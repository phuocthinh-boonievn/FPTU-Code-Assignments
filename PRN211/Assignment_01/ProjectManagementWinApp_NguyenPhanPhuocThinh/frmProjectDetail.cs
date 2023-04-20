using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementWinApp_NguyenPhanPhuocThinh
{
    public partial class frmProjectDetail : Form
    {
        public bool AddOrUpdate { get; set; }
        public event EventHandler PaperDetailClosed;
        public ProjectObject ProjectDetail { get; set; }
        public IProjectRepository projectRepository { get; set; }
        public frmProjectDetail()
        {
            InitializeComponent();
        }

        private void frmProjectDetail_Load(object sender, EventArgs e)
        {
            if (AddOrUpdate)
            {
                btnSave.Text = "Add";
                btnSave.Tag = "Add".ToLower();
                lblDetail.Text = "Add a new project";
                this.Text = "Add a project";
            }
            else
            {
                txtId.Enabled = false;
                btnSave.Text = "Update project";
                btnSave.Tag = "Update project".ToLower();
                lblDetail.Text = "Update existing project";
                this.Text = "Update project";

                txtId.Text = ProjectDetail.ProjectID.ToString();
                txtName.Text = ProjectDetail.ProjectName;
                dtpStartDate.Value = ProjectDetail.EstimatedStartDate;
                dtpEndDate.Value = ProjectDetail.EstimatedEndDate;
                txtCity.Text = ProjectDetail.ProjectCity;
                txtAddr.Text = ProjectDetail.ProjectAddress;
                txtDesc.Text = ProjectDetail.ProjectDescription;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddOrUpdate)
            {
                try
                {
                    ProjectObject project = new ProjectObject()
                    {
                        ProjectID = int.Parse(txtId.Text),
                        ProjectName = txtName.Text,
                        EstimatedStartDate = dtpStartDate.Value,
                        EstimatedEndDate = dtpEndDate.Value,
                        ProjectAddress = txtAddr.Text,
                        ProjectCity = txtCity.Text,
                        ProjectDescription = txtDesc.Text,
                    };

                    projectRepository.Add(project);
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
                    ProjectObject project = new ProjectObject()
                    {
                        ProjectID = int.Parse(txtId.Text),
                        ProjectName = txtName.Text,
                        EstimatedStartDate = dtpStartDate.Value,
                        EstimatedEndDate = dtpEndDate.Value,
                        ProjectAddress = txtAddr.Text,
                        ProjectCity = txtCity.Text,
                        ProjectDescription = txtDesc.Text,
                    };
                    projectRepository.Update(project);
                    MessageBox.Show("Updated successfully!!", "Update existing project", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtId.Text = project.ProjectID.ToString();
                    txtName.Text = project.ProjectName;
                    dtpStartDate.Value = project.EstimatedStartDate;
                    dtpEndDate.Value = project.EstimatedEndDate;
                    txtCity.Text = project.ProjectCity;
                    txtAddr.Text = project.ProjectAddress;
                    txtDesc.Text = project.ProjectDescription; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Add project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmProjectDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
                frmProjectManagement projectManagementForm = Application.OpenForms.OfType<frmProjectManagement>().FirstOrDefault();
                if (projectManagementForm != null)
                {
                    projectManagementForm.btnUpdate.Enabled = true;
                    projectManagementForm.btnCreate.Enabled = true;
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
