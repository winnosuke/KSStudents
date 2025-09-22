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
    /// Interaction logic for PatientManagermnetWindow.xaml
    /// </summary>
    public partial class PatientManagermnetWindow : Window
    {
        private readonly PateintRepo _patientRepo;
        public PatientManagermnetWindow()
        {
            InitializeComponent();
            var context = new DbMediCareContext();
            _patientRepo = new PateintRepo(context);
            LoadPatients();
        }

        private void LoadPatients()
        {
            dgPatients.ItemsSource = _patientRepo.GetAll();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patient = new Patient
                {
                    PatientCode = txtPatientCode.Text,
                    FullName = txtFullName.Text,
                    Phone = txtPhone.Text,
                    Age = int.TryParse(txtAge.Text, out var ageVal) ? ageVal : null
                };
                _patientRepo.Add(patient);
                LoadPatients();
                MessageBox.Show("Patient created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtPatientId.Text, out int patientId))
                {
                    var patient = _patientRepo.GetById(patientId);
                    if (patient != null)
                    {
                        patient.FullName = txtFullName.Text;
                        patient.PatientCode = txtPatientCode.Text;
                        patient.Phone = txtPhone.Text;
                        patient.Age = int.TryParse(txtAge.Text, out var ageVal) ? ageVal : null;
                        _patientRepo.Update(patient);
                        LoadPatients();
                        MessageBox.Show("Patient updated successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txtPatientId.Text, out int patientId))
                {
                    _patientRepo.Delete(patientId);
                    LoadPatients();
                    MessageBox.Show("Patient deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgPatients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selected = dgPatients.SelectedItem as Patient;
            if (selected != null)
            {
                txtPatientId.Text = selected.PatientId.ToString();
                txtPatientCode.Text = selected.PatientCode;
                txtFullName.Text = selected.FullName;
                txtPhone.Text = selected.Phone;
                txtAge.Text = selected.Age.HasValue ? selected.Age.Value.ToString() : string.Empty;
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadPatients();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}