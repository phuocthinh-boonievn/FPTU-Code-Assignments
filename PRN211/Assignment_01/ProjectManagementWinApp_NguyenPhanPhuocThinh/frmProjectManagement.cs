using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectManagementWinApp_NguyenPhanPhuocThinh
{
    public partial class frmProjectManagement : Form
    {
        IProjectRepository projectRepository = new ProjectRepository();
        IEnumerable<string> ciyList;

        BindingSource source;
        BindingSource citySource;

        private ProjectObject GetProjectObject()
        {
            ProjectObject? project = null;
            try
            {
                project = new ProjectObject
                {
                    ProjectID = int.Parse(txtProjectID.Text),
                    ProjectName = txtProjectName.Text,
                    EstimatedStartDate = dtpStartDate.Value,
                    EstimatedEndDate = dtpEndDate.Value,
                    ProjectCity = txtProjectCity.Text,
                    ProjectAddress = txtProjectAddress.Text,
                    ProjectDescription = txtProjectDescription.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return project;
        }
        private void ClearBindings()
        {
            txtProjectID.DataBindings.Clear();
            txtProjectName.DataBindings.Clear();
            dtpStartDate.DataBindings.Clear();
            dtpEndDate.DataBindings.Clear();
            txtProjectAddress.DataBindings.Clear();
            txtProjectCity.DataBindings.Clear();
            txtProjectDescription.DataBindings.Clear();
        }
        private void LoadProjectListToGrid()
        {
            try
            {
                var projects = projectRepository.GetAllProjects().OrderBy(p => p.ProjectName);

                source = new BindingSource();
                source.DataSource = projects;

                ClearBindings();

                txtProjectID.DataBindings.Add("Text", source, "ProjectID");
                txtProjectName.DataBindings.Add("Text", source, "ProjectName");
                dtpStartDate.DataBindings.Add("Text", source, "EstimatedStartDate");
                dtpEndDate.DataBindings.Add("Text", source, "EstimatedEndDate");
                txtProjectCity.DataBindings.Add("Text", source, "ProjectCity");
                txtProjectAddress.DataBindings.Add("Text", source, "ProjectAddress");
                txtProjectDescription.DataBindings.Add("Text", source, "ProjectDescription");

                dgvProjectList.DataSource = null;
                dgvProjectList.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load project list error");
            }
        }

        private void LoadSearchListToGrid(IEnumerable<ProjectObject> searchResult)
        {
            try
            {
                var projects = searchResult.OrderBy(p => p.ProjectName);

                source = new BindingSource();
                source.DataSource = projects;

                ClearBindings();

                txtProjectID.DataBindings.Add("Text", source, "ProjectID");
                txtProjectName.DataBindings.Add("Text", source, "ProjectName");
                dtpStartDate.DataBindings.Add("Text", source, "EstimatedStartDate");
                dtpEndDate.DataBindings.Add("Text", source, "EstimatedEndDate");
                txtProjectCity.DataBindings.Add("Text", source, "ProjectCity");
                txtProjectAddress.DataBindings.Add("Text", source, "ProjectAddress");
                txtProjectDescription.DataBindings.Add("Text", source, "ProjectDescription");

                dgvProjectList.DataSource = null;
                dgvProjectList.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load project list error");
            }
        }
        public frmProjectManagement()
        {
            InitializeComponent();
        }
        private void frmProjectManagement_Load(object sender, EventArgs e)
        {
            LoadProjectListToGrid();
            var projects = projectRepository.GetAllProjects();
            ciyList = from project in projects
                      where !string.IsNullOrEmpty(project.ProjectCity.Trim())
                      orderby project.ProjectCity ascending
                      select project.ProjectCity;
            ciyList = ciyList.Distinct();
            citySource = new BindingSource();
            citySource.DataSource = ciyList;
            cboCityFilter.DataSource = null;
            cboCityFilter.DataSource = citySource;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.btnCreate.Enabled = false;
            frmProjectDetail detailForm = new frmProjectDetail
            {
                projectRepository = this.projectRepository,
                AddOrUpdate = true,
            };
            detailForm.ShowDialog();
            source.Position = source.Count - 1;
            LoadProjectListToGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvProjectList.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            ProjectObject selected = (ProjectObject)row.DataBoundItem;

            this.btnUpdate.Enabled = false;
            frmProjectDetail detailForm = new frmProjectDetail
            {
                projectRepository = this.projectRepository,
                AddOrUpdate = false,
                ProjectDetail = selected
            };
            detailForm.ShowDialog();
            LoadProjectListToGrid();
            source.Position = source.Count - 1;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectObject project = GetProjectObject();
                if (MessageBox.Show($"Are you sure? This project will be deleted:\n" + $"Project ID: {project.ProjectID}\n" + $"Project Name: {project.ProjectName}\n", "Delete project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //var project = GetProjectObject();
                    projectRepository.Delete(project.ProjectID);
                    LoadProjectListToGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete an paper");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = txtSearchValue.Text;
                if (radioIDSearch.Checked)
                {
                    int searchID = int.Parse(searchValue);
                    IEnumerable<ProjectObject> searchResult = projectRepository.SearchProjectByID(searchID);
                    if (searchResult.Any())
                    {
                        LoadSearchListToGrid(searchResult);
                    }
                    else
                    {
                        MessageBox.Show("No result found!", "Search project ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else if (radioNameSearch.Checked)
                {
                    string searchName = searchValue;
                    IEnumerable<ProjectObject> searchResult = projectRepository.SearcProjectByName(searchName);
                    if (searchResult.Any())
                    {
                        LoadSearchListToGrid(searchResult);
                    }
                    else
                    {
                        MessageBox.Show("No result found!", "Search member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a search type!", "Search project ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search project ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filterCity = cboCityFilter.Text.ToString();
            IEnumerable<ProjectObject> searchResult = projectRepository.FilterProjectCity(filterCity);
            if (searchResult.Any())
            {
                LoadSearchListToGrid(searchResult);
            }
            else
            {
                MessageBox.Show("No result found!", "Filter City", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmProjectManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit the application", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else e.Cancel = true;
        }
    }
}
