using DemoWPFBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DemoWPFDAO 
{
    public class StudentDataXML : IStudentData
    {
        public List<StudentDTO> getStudents(string fileName)
        {
            List<StudentDTO> students = new List<StudentDTO>();
            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.SelectSingleNode("students");
            XmlNodeList prop = node.SelectNodes("students");
            foreach (XmlNode item in prop) 
            {
                StudentDTO student = new StudentDTO();
                student.Code = item.SelectSingleNode("code").InnerText;
                student.Name = item.SelectSingleNode("name").InnerText;
                student.Email = item.SelectSingleNode("email").InnerText;
                student.City = item.SelectSingleNode("city").InnerText;
                student.Phone = item.SelectSingleNode("phone").InnerText;
                student.Classcode = item.SelectSingleNode("classcode").InnerText;

                students.Add(student);
            }
            return students;
        }

    }
}
