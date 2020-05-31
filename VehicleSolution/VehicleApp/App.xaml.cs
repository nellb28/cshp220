using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace VehicleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static VehiclesRepository.VehiclesRepository vehiclesRepository;

        static App()
        {
            vehiclesRepository = new VehiclesRepository.VehiclesRepository();
        }

        public static VehiclesRepository.VehiclesRepository VehiclesRepository
        {
            get
            {
                return vehiclesRepository;
            }
        }

    }
}
