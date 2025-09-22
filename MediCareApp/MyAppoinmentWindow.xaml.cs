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
using MedicareHospital.Models;

namespace MediCareApp
{
    /// <summary>
    /// Interaction logic for MyAppoinmentWindow.xaml
    /// </summary>
    public partial class MyAppoinmentWindow : Window
    {
        private readonly AppointmentRepo _appointmentRepo;
        private readonly PateintRepo _patientRepo;
        private readonly Doctor? _currentDoctor;
        public MyAppoinmentWindow()
        {
            InitializeComponent();
            var context = new DbMediCareContext();
            _appointmentRepo = new AppointmentRepo(context);
            _patientRepo = new PateintRepo(context);

            _currentDoctor = Application.Current.Properties.Contains("CurrentDoctor")
                ? Application.Current.Properties["CurrentDoctor"] as Doctor
                : null;

            LoadAppointments();
        }

        private void LoadAppointments()
        {
            if (_currentDoctor == null)
            {
                dgAppointments.ItemsSource = _appointmentRepo.GetAll().OrderBy(a => a.AppointmentDate).ToList();
            }
            else
            {
                dgAppointments.ItemsSource = _appointmentRepo.GetByDoctor(_currentDoctor.DoctorId);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAppointments();
        }

        private Appointment? GetSelectedAppointment()
        {
            return dgAppointments.SelectedItem as Appointment;
        }

        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            var selected = GetSelectedAppointment();
            if (selected != null)
            {
                _appointmentRepo.UpdateStatus(selected.AppointmentId, "Completed");
                LoadAppointments();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var selected = GetSelectedAppointment();
            if (selected != null)
            {
                _appointmentRepo.UpdateStatus(selected.AppointmentId, "Cancelled");
                LoadAppointments();
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (_currentDoctor == null)
            {
                MessageBox.Show("Doctor is not logged in.");
                return;
            }

            var patient = _patientRepo.GetAll().FirstOrDefault(p => p.FullName == txtPatientCode.Text.Trim());
            if (patient == null)
            {
                MessageBox.Show("Patient not found by code.");
                return;
            }

            var date = dpDate.SelectedDate ?? DateTime.Now;
            var appt = new Appointment
            {
                Title = string.IsNullOrWhiteSpace(txtNewTitle.Text) ? "Checkup" : txtNewTitle.Text.Trim(),
                AppointmentDate = date,
                Status = "Scheduled",
                DoctorId = _currentDoctor.DoctorId,
                PatientId = patient.PatientId
            };
            _appointmentRepo.Add(appt);
            LoadAppointments();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
