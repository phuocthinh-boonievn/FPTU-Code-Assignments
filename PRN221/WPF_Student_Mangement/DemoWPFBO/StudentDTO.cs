using System.Xml.Serialization;

namespace DemoWPFBO
{
    [XmlRoot("students")]
    public class StudentDTO
    {
        [XmlElement("code")]
        private string code;

        [XmlElement("name")]
        private string name;

        [XmlElement("email")]
        private string email;

        [XmlElement("city")]
        private string city;

        [XmlElement("phone")]
        private string phone;
        [XmlElement("classcode")]
        private string classcode;

        public StudentDTO()
        {
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.City = string.Empty;
            this.Phone = string.Empty;
            this.Classcode = string.Empty;
        }
        public StudentDTO(string code, string name, string email, string city, string phone, string classcode)
        {
            this.Code = code;
            this.Name = name;
            this.Email = email;
            this.City = city;
            this.Phone = phone;
            this.Classcode = classcode;
        }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string City { get => city; set => city = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Classcode { get => classcode; set => classcode = value; }
        public StudentDTO(StudentDTO student)
        {
            this.Code = student.Code;
            this.Name = student.Name;
            this.Email = student.Email;
            this.City = student.City;
            this.Phone = student.Phone;
            this.Classcode = student.Classcode;
        }
        public override bool Equals(object? obj)
        {
            return obj is StudentDTO dTO &&
                   Code == dTO.Code &&
                   Name == dTO.Name &&
                   Email == dTO.Email &&
                   City == dTO.City &&
                   Phone == dTO.Phone &&
                   Classcode == dTO.Classcode;
        }
    }
}