using DemoWPFBO;

namespace DemoWPFDAO
{
    public interface IStudentData
    {
        public List<StudentDTO> getStudents(string fileName);
    }
}