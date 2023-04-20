using BusinessObjects;
using DataAccessObjects;
using System.Collections.Generic;

namespace Repositories;

public class ProjectRepository : IProjectRepository
{
    public IEnumerable<ProjectObject> GetAllProjects() => ProjectDAO.Instance.GetAllProjects;
    public void Add(ProjectObject project) => ProjectDAO.Instance.Add(project);
    public void Update(ProjectObject project) => ProjectDAO.Instance.Update(project);
    public void Delete(int projectID) => ProjectDAO.Instance.Delete(projectID);
    public IEnumerable<ProjectObject> SearchProjectByID(int id)
    {
        return ProjectDAO.Instance.SearchProjectByID(id);
    }
    public IEnumerable<ProjectObject> SearcProjectByName(string name)
    {
        return ProjectDAO.Instance.SearcProjectByName(name);
    }
    public IEnumerable<ProjectObject> FilterProjectCity(string city)
    {
        return ProjectDAO.Instance.FilterProjectCity(city);
    }



    
}