using DemoWPFBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPFService
{
    public interface IStudentService
    {
        public List<StudentDTO> getStudents(string fileName);
    }
}
