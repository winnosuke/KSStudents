using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediCareApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var doctor = Application.Current.Properties.Contains("CurrentDoctor") 
                ? Application.Current.Properties["CurrentDoctor"] as MedicareHospital.Models.Doctor 
                : null;
            if (doctor != null)
            {
                var name = string.IsNullOrWhiteSpace(doctor.FullName) ? doctor.DoctorCode : doctor.FullName;
                if (this.FindName("txtWelcome") is TextBlock welcome)
                {
                    welcome.Text = $"Welcome, Dr. {name}";
                }
            }
        }

        private void Menu_Grades_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientManagermnetWindow();
            window.ShowDialog();
        }

        private void Menu_Students_Click(object sender, RoutedEventArgs e)
        {
            var window = new MyAppoinmentWindow();
            window.ShowDialog();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties.Remove("CurrentDoctor");
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}