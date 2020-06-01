using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleDB;

namespace VehicleApp.Models
{
    public class VehicleModel
    {
        //failed attempt at automapper
        //private static MapperConfiguration mapperConfiguration = new MapperConfiguration(t => t.CreateMap<Vehicles, VehiclesRepository.VehicleModel>)().ReverseMap());
        public int Id { get; set; }
        public string Vin { get; set; }
        public string StockNumber { get; set; }
        public int? Msrp { get; set; }
        public int? SellingPrice { get; set; }
        public string Type { get; set; }
        public int? Mileage { get; set; }
        public bool? DealerCertified { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }

        public VehiclesRepository.VehicleModel ToRepositoryModel()
        {
            var repositoryModel = new VehiclesRepository.VehicleModel
            {
                Id = Id,
                Vin = Vin,
                StockNumber = StockNumber,
                Msrp = Msrp,
                SellingPrice = SellingPrice,
                Type = Type,
                Mileage = Mileage,
                DealerCertified = DealerCertified,
                Year = Year,
                Make = Make,
                Model = Model,
                Trim = Trim
            };

            return repositoryModel;
        }

        public static VehicleModel ToModel(VehiclesRepository.VehicleModel respositoryModel)
        {
            var vehicleModel = new VehicleModel
            {
                Id = respositoryModel.Id,
                Vin = respositoryModel.Vin,
                StockNumber = respositoryModel.StockNumber,
                Msrp = respositoryModel.Msrp,
                SellingPrice = respositoryModel.SellingPrice,
                Type = respositoryModel.Type,
                Mileage = respositoryModel.Mileage,
                DealerCertified = respositoryModel.DealerCertified,
                Year = respositoryModel.Year,
                Make = respositoryModel.Make,
                Model = respositoryModel.Model,
                Trim = respositoryModel.Trim
             };

            return vehicleModel;
        }
    }
}