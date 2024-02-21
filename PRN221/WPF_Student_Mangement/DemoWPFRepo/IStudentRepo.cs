using DemoWPFBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPFRepo
{
    public interface IStudentRepo
    {
        public List<StudentDTO> getStudents(string fileName);
    }
}
