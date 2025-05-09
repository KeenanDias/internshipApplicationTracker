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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using internshipTracker;

namespace InternshipApplicationTracker
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        private applicationContext _context;  // Declare your database context

        public MainForm()
        {
            InitializeComponent();
            _context = new applicationContext(); // Initialize the context
            LoadApplications(); // Load data on startup
        }

        private void LoadApplications()
        {
            try
            {
                // Ensure the database is created.
                _context.Database.EnsureCreated();
                // Load applications from the database
                List<application> applications = _context.applications.ToList();
                dataGridViewApplications.ItemsSource = applications; // Set the DataGrid's ItemsSource
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading applications: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddApplication_Click(object sender, RoutedEventArgs e)
        {
            AddApplicationForm add = new AddApplicationForm();
            //  Important:  Show the form as a dialog.
            if (add.ShowDialog() == true)
            {
                //  Data was saved, so refresh the grid.
                LoadApplications();
            }
            //  The form is closed, and the context is disposed in AddApplicationForm.
        }
    }
}
