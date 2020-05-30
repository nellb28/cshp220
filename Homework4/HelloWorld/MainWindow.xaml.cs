using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;

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


        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsUSOrCanadianZipCode(uxTextBox.Text))
            {
                uxSubmit.IsEnabled = true;
            }
            else 
            {
                uxSubmit.IsEnabled = false;
            }
        }


        private bool IsUSOrCanadianZipCode(string zipCode)
        {
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9][ABCEGHJKLMNPRSTVWXYZ][0-9])$";
            var validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }
    }

}
