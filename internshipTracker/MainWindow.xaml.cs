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

namespace InternshipApplicationTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            //  AddApplicationForm add = new AddApplicationForm();
            //  add.Show();
        }

        private void btnAddApplication_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Added");
            AddApplicationForm add = new AddApplicationForm();
            add.Show();
        }
    }
}

