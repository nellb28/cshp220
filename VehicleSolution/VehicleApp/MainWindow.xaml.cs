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
            LoadContacts();
        }
        private VehicleModel selectedContact;

        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (VehicleModel)uxVehicleList.SelectedValue;
        }

        private void LoadContacts()
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
                var uiContactModel = window.Vehicle;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.VehiclesRepository.Add(repositoryContactModel);
                LoadContacts();
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}
