using System;
using System.Collections.Generic;
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
using MediCareRepository;
using MedicareHospital;
using MedicareHospital.Models;


namespace MediCareApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        
        private readonly DbMediCareContext _context;
        public LoginWindow()
        {
            InitializeComponent();

            _context = new DbMediCareContext();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string code = txtStudentCode.Text.Trim();
            string password = txtPassword.Password.Trim();

            var doctor = _context.Doctors
                .FirstOrDefault(s => s.DoctorCode == code && s.Password == password);

            if (doctor != null)
            {
                // Lưu thông tin bác sĩ đăng nhập để các màn hình khác sử dụng
                Application.Current.Properties["CurrentDoctor"] = doctor;

                var mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid DoctorCode or Password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
