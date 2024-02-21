using DemoWPFBO;
using DemoWPFDAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoWPFRepo
{
    public class StudentRepo : IStudentRepo
    {
        private StudentDAO studentDAO = null;
        public StudentRepo()
        {
            studentDAO = new StudentDAO();
        }
        public List<StudentDTO> getStudents(string fileName)
        {
            List <StudentDTO> students = new List<StudentDTO> ();
            string fileContent = File.ReadAllText(fileName);

            if (fileName.EndsWith(".json"))
            {
                students = JsonConvert.DeserializeObject<List<StudentDTO>>(fileContent);
                return students;
            }
            else if (fileName.EndsWith(".xml"))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<StudentDTO>), new XmlRootAttribute("students"));
                    using (StringReader reader = new StringReader(fileContent))
                    {
                        students = (List<StudentDTO>)serializer.Deserialize(reader);
                        return students;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during XML deserialization: {ex.Message}");
                    return null;
                }
            }
            return students;
        }
    }
}
