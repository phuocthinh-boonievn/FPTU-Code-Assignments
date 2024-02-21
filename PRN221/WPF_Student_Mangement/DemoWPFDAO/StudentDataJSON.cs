using DemoWPFBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoWPFDAO
{
    public class StudentDataJSON : IStudentData
    {
        public List<StudentDTO> getStudents(string fileName)
        {
            var json = File.ReadAllText(fileName);
            List<StudentDTO> students = JsonSerializer.Deserialize<List<StudentDTO>>(json);
            return students;
        }
    }
}
