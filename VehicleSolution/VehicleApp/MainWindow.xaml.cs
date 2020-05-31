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
        }

        private VehicleModel selectedVehicle;

        private void uxVehicleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedVehicle = (VehicleModel)uxVehicleList.SelectedValue;
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

        
    }
}
