using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text.Json;

namespace ProjectManagementWinApp_NguyenPhanPhuocThinh
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLogin());
        }
    }
}