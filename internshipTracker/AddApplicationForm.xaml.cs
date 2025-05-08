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
using System.Globalization;
using Microsoft.EntityFrameworkCore; // Add this for EF Core
using System.ComponentModel.DataAnnotations;
using internshipTracker; // Add this for DataAnnotations

namespace InternshipApplicationTracker
{
    /// <summary>
    /// Interaction logic for AddApplicationForm.xaml
    /// </summary>
    public partial class AddApplicationForm : Window
    {
        // Add a field for your database context.  Replace YourDbContext with your actual context name
        private applicationContext _context;

        public string OrganizationName { get; set; }
        public string Status { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime? InternshipStartDate { get; set; }

        public AddApplicationForm()
        {
            InitializeComponent();
            // Initialize the combobox
            comboBoxStatus.Items.Add("Applied");
            comboBoxStatus.Items.Add("Interviewing");
            comboBoxStatus.Items.Add("Offered");
            comboBoxStatus.Items.Add("Rejected");
            comboBoxStatus.Items.Add("Accepted");
            comboBoxStatus.SelectedIndex = 0; // Default to "Applied"

            // Initialize the database context
            _context = new applicationContext(); //  Replace YourDbContext with your actual context name
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(txtOrganizationName.Text))
            {
                MessageBox.Show("Please enter the organization name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxStatus.Text))
            {
                MessageBox.Show("Please select the application status.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime dateAppliedValue;
            if (!DateTime.TryParseExact(txtDateApplied.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAppliedValue))
            {
                MessageBox.Show("Please enter a valid date applied in yyyy-MM-dd format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime? startDateValue = null; // Initialize startDateValue
            if (!string.IsNullOrWhiteSpace(txtInternshipStartDate.Text))
            {
                if (!DateTime.TryParseExact(txtInternshipStartDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tempStartDateValue))
                {
                    MessageBox.Show("Please enter a valid internship start date in yyyy-MM-dd format, or leave it empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                startDateValue = tempStartDateValue;
            }

            // Get the data from the text boxes
            OrganizationName = txtOrganizationName.Text;
            Status = comboBoxStatus.Text;
            DateApplied = dateAppliedValue;
            InternshipStartDate = startDateValue;

            // Create a new Application object (assuming you have an Application entity)
            application newApplication = new application // Replace Application with your actual entity name
            {
                OrganizationName = OrganizationName,
                Status = Status,
                DateApplied = DateApplied,
                InternshipStartDate = InternshipStartDate
            };

            // Add the new application to the database context
            _context.applications.Add(newApplication); //  Replace Applications with your actual DbSet name
            
            try
            {
                // Save the changes to the database
                _context.SaveChanges();
                MessageBox.Show("Application saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true; // Set dialog result before closing.  Use true/false for DialogResult
                Close(); // Close the form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving application: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false; // Set dialog result on error
            }
            finally
            {
                _context.Dispose();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Set the DialogResult to Cancel to indicate that the user cancelled the operation
            DialogResult = false; // Use true/false for DialogResult
            Close(); // Close the form
        }
    }
}
