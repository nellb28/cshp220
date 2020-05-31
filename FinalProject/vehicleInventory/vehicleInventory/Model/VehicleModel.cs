using System;

namespace VehicleInventory.Model
{
    public class VehicleModel
    {
        public int VehicleID { get; set; }
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public int? MSRP { get; set; }
        public int? SellingPrice { get; set; }
        public string VehicleType { get; set; }
        public string Type { get; set; }
        public int? Mileage { get; set; }
        public bool? DealerCertified { get; set; }
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        //public DateTime CreatedDate { get; set; }

        public VehicleRepository.VehicleModel ToRepositoryModel()
        {
            var repositoryModel = new VehicleRepository.VehicleModel
            {
                VehicleID = VehicleID,
                VIN = VIN,
                StockNumber = StockNumber,
                MSRP = MSRP,
                SellingPrice = SellingPrice,
                VehicleType = VehicleType,
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

        public static VehicleModel ToModel(VehicleRepository.VehicleModel respositoryModel)
        {
            var vehicleModel = new VehicleModel
            {
                VehicleID = respositoryModel.VehicleID,
                VIN = respositoryModel.VIN,
                StockNumber = respositoryModel.StockNumber,
                MSRP = respositoryModel.MSRP,
                SellingPrice = respositoryModel.SellingPrice,
                VehicleType = respositoryModel.VehicleType,
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