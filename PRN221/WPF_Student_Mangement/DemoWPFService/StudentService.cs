using DemoWPFBO;
using DemoWPFRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPFService
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo studentRepo = null;
        public StudentService()
        {
            studentRepo = new StudentRepo();
        }
        public List<StudentDTO> getStudents(string fileName)
        {
            return studentRepo.getStudents(fileName);
        }
    }
}
