using DemoWPFBO;
using DemoWPFService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WPF_Student_Mangement;

namespace DemoWPFGUI
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        private readonly IStudentService studentService = null;

        public Student()
        {
            InitializeComponent();
            studentService = new StudentService();

        }

        private void btn_LoadFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(filePath);

                List<StudentDTO> students =  studentService.getStudents(filePath);
                dgv_Student.ItemsSource = students;
                Txt_FileName.Text = filePath;
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }
    }
}
