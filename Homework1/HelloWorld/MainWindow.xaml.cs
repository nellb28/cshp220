//Nell Brisard
//Assignment 1

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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private bool enableSubmitButton()
        {
            if ((uxName.GetLineLength(0) == 0) && (uxPassword.GetLineLength(0) == 0))
            {
                return false;
            }
            else if ((uxName.GetLineLength(0) > 0) && (uxPassword.GetLineLength(0) > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            uxSubmit.IsEnabled = enableSubmitButton();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            uxSubmit.IsEnabled = enableSubmitButton();
        }
    }
}
