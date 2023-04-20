using BusinessObjects;
using System.Xml.Linq;

namespace DataAccessObjects;
public class ProjectDAO
{
    private static List<ProjectObject> _projects = new List<ProjectObject>()
    {
        new ProjectObject
        {
            ProjectID = 1,
            ProjectName = "Project 1",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Now,
            ProjectCity = "Ho Chi Minh",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "This is prototype project"
        },
        new ProjectObject
        {
            ProjectID = 2,
            ProjectName = "Application Full-Stack Project ",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Now,
            ProjectCity = "Ho Chi Minh",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "This is a Full-Stack project"
        },
        new ProjectObject
        {
            ProjectID = 3,
            ProjectName = "Web Front-end JavaScript",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Now,    
            ProjectCity = "Ha Noi",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "A project description"
        },
        new ProjectObject
        {
            ProjectID = 4,
            ProjectName = "Web Front-end JavaScript",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Now,    
            ProjectCity = "Ho Chi Minh",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "Build started: Project: ProjectManagementWinApp_NguyenPhanPhuocThinh, Configuration: Debug Any CPU"
        },
        new ProjectObject
        {
            ProjectID = 5       ,
            ProjectName = "Web Front-end HTML",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Now,    
            ProjectCity = "Ha Noi",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "This is a HTML project"
        },
        new ProjectObject
        {
            ProjectID = 10,
            ProjectName = "Back-end Data Access",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Parse("31/12/2022"),
            ProjectCity = "Hai Phong",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "This is SQL project"
        },
        new ProjectObject
        {
            ProjectID = 11,
            ProjectName = "Back-end Connections",
            EstimatedStartDate = DateTime.Parse("31/12/2022"),
            EstimatedEndDate = DateTime.Parse("31/12/2022"),
            ProjectCity = "Hai Phong",
            ProjectAddress = "123 Nguyen Van Linh, Quan 7",
            ProjectDescription = "Back-end Connections"
        }
    };

    //singleton pattern
    private static ProjectDAO _instance = null;
    private static readonly object _instanceLock = new object();
    private ProjectDAO() { }
    public static ProjectDAO Instance
{
    get
    {
        if (_instance == null)
        {
            lock(_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new ProjectDAO();
                }
            }
        }
        return _instance;
    }
}

    public List<ProjectObject> GetAllProjects => _projects;
    public ProjectObject GetProject(int projectID)
    {
        return _projects.SingleOrDefault(pr => pr.ProjectID == projectID);
    }
    public void Add(ProjectObject project)
    {
        if(project == null)
        {
            throw new ArgumentNullException("Project does not exist!");
        }

        if (GetProject(project.ProjectID) == null)
        {
            _projects.Add(project);
        }

    }
    public void Update(ProjectObject project)
    {
        ProjectObject projectObject = GetProject(project.ProjectID);
        if (projectObject != null)
        {
            var index = _projects.IndexOf(projectObject);
            _projects[index] = project;
        }
        else
        {
            throw new Exception("Project does not exist!!");
        }
    }
    public void Delete(int projectID)
    {
        ProjectObject projectObject = GetProject(projectID);
        if(projectObject != null)
        {
            _projects.Remove(projectObject);
        }
        else 
        {
            throw new Exception("Project does not exist!");
        }
    }
    public IEnumerable<ProjectObject> SearchProjectByID(int id) 
    {
        var projectSearch = from project in _projects
                           where project.ProjectID == id
                           select project;
        return projectSearch;
    }
    public IEnumerable<ProjectObject> SearcProjectByName(string name) 
    {
        var projectSearch = from project in _projects
                           where project.ProjectName.Contains(name)
                           select project;
        return projectSearch;
    }
    public IEnumerable<ProjectObject> FilterProjectCity(string city) 
    {
        var projectSearch = from project in _projects
                            where project.ProjectCity.Contains(city)
                            select project;
        projectSearch = projectSearch.Distinct();
        return projectSearch;
    }
}