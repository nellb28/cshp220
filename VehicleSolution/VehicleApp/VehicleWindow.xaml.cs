using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Vehicle.Id = Int32.Parse(uxId.Text);
            Vehicle.Vin = uxVIN.Text;
            Vehicle.StockNumber = uxStockNumber.Text;
            Vehicle.Msrp = Int32.Parse(uxMSRPPrice.Text, NumberStyles.Currency);
            Vehicle.SellingPrice = Int32.Parse(uxSellingPrice.Text, NumberStyles.Currency);
            Vehicle.Type = uxVehicleType.Text;
            Vehicle.Mileage = Int32.Parse(uxMileage.Text);
            Vehicle.DealerCertified = uxDealerCertified.IsChecked;
            Vehicle.Year = Int32.Parse(uxYear.Text);
            Vehicle.Make = uxMake.Text;
            Vehicle.Model = uxModel.Text;
            Vehicle.Trim = uxTrim.Text;
            
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Vehicle != null)
            {
                //if (Vehicle.Phone == "Home")
                //{
                //    uxHome.IsChecked = true;
                //}
                //else
                //{
                //    uxMobile.IsChecked = true;
                //}
                uxSubmit.Content = "Update";
            }
            else
            {
                Vehicle = new VehicleModel();
                //TODO - add default values here
                //Vehicle.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Vehicle;
        }
    }
}
