using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VehicleApp.Models;

namespace VehicleApp
{
    /// <summary>
    /// Interaction logic for VehicleWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {
        public VehicleWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public VehicleModel Vehicle { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Vehicle = new VehicleModel();

            Vehicle.Vin = uxVIN.Text;
            Vehicle.StockNumber = uxStockNumber.Text;
            Vehicle.SellingPrice = Int32.Parse(uxSellingPrice.Text);
            //Vehicle.Email = uxEmail.Text;

            //if (uxHome.IsChecked.Value)
            //{
            //    Vehicle.PhoneType = "Home";
            //}
            //else
            //{
            //    Vehicle.PhoneType = "Mobile";
            //}
            //
            //Vehicle.PhoneNumber = uxPhoneNumber.Text;
            //Vehicle.Age = 0;
            //Vehicle.Notes = uxNotes.Text;
            //Vehicle.CreatedDate = DateTime.Now;

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }
    }
}
