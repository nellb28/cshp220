using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VehicleApp.Models;

namespace VehicleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadVehicles();
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            EditContact();
        }

        private void EditContact()
        {
            var window = new VehicleWindow();
            window.Vehicle = selectedVehicle.Clone();

            if (window.ShowDialog() == true)
            {
                App.VehiclesRepository.Update(window.Vehicle.ToRepositoryModel());
                LoadVehicles();
            }
        }

        private VehicleModel selectedVehicle;

        private void uxVehicleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedVehicle = (VehicleModel)uxVehicleList.SelectedValue;
            uxFileChange.IsEnabled = (selectedVehicle != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void LoadVehicles()
        {
            var vehicles = App.VehiclesRepository.GetAll();

            uxVehicleList.ItemsSource = vehicles
                .Select(t => VehicleModel.ToModel(t))
                .ToList();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new VehicleWindow();

            if (window.ShowDialog() == true)
            {
                var uiVehicleModel = window.Vehicle;

                var repositoryVehicleModel = uiVehicleModel.ToRepositoryModel();

                App.VehiclesRepository.Add(repositoryVehicleModel);
                LoadVehicles();
            }
        }

        //Add error validation
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.VehiclesRepository.Remove(selectedVehicle.Id);
            selectedVehicle = null;
            LoadVehicles();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedVehicle != null);
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedVehicle != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxVehicleList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            uxFileChange_Click(sender, null);
        }
    }
}
