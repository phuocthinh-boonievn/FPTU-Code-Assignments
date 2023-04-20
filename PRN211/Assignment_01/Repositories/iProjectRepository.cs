using BusinessObjects;
using DataAccessObjects;

namespace Repositories;

public interface IProjectRepository
{
    public IEnumerable<ProjectObject> GetAllProjects();
    public void Add(ProjectObject project);
    public void Update(ProjectObject project);
    public void Delete(int projectID);
    public IEnumerable<ProjectObject> SearchProjectByID(int id);
    public IEnumerable<ProjectObject> SearcProjectByName(string name);
    public IEnumerable<ProjectObject> FilterProjectCity(string city);
}