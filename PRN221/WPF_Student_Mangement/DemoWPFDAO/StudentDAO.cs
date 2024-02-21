using DemoWPFBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPFDAO
{
    public class StudentDAO
    {
        private IStudentData studentData;
        public StudentDAO()
        {

        }
        public List<StudentDTO> getStudents(string fileName, int type)
        {
            try
            {
                switch (type)
                {
                    case 1:
                        studentData = new StudentDataJSON();
                        break;
                    case 2:
                        studentData = new StudentDataXML();
                        break;
                }
                return studentData.getStudents(fileName);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
