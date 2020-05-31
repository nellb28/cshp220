using VehicleDB;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRepository
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
    }

    public class VehicleRepository
    {
        public VehicleModel Add(VehicleModel vehicleModel)
        {
            var vehicleDb = ToDbModel(vehicleModel);

            DatabaseManager.Instance.Vehicle.Add(vehicleDb);
            DatabaseManager.Instance.SaveChanges();

            vehicleModel = new VehicleModel
            {
                VehicleID = vehicleDb.VehicleID,
                VIN = vehicleDb.VehicleVIN,
                StockNumber = vehicleDb.VehicleStockNumber,
                MSRP = vehicleDb.VehicleMSRP,
                SellingPrice = vehicleDb.VehicleSellingPrice,
                VehicleType = vehicleDb.VehicleVehicleType,
                Type = vehicleDb.VehicleType,
                Mileage = vehicleDb.VehicleMileage,
                DealerCertified = vehicleDb.VehicleDealerCertified,
                Year = vehicleDb.VehicleYear,
                Make = vehicleDb.VehicleMake,
                Model = vehicleDb.VehicleModel,
                Trim = vehicleDb.VehicleTrim
            };
            return vehicleModel;
        }

        public List<VehicleModel> GetAll()
        {
            // Use .Select() to map the database vehicle to VehicleModel
            var items = DatabaseManager.Instance.Vehicle
              .Select(t => new VehicleModel
              {
                  VehicleID = t.VehicleID,
                  VIN = t.VehicleVIN,
                  StockNumber = t.VehicleStockNumber,
                  MSRP = t.VehicleMSRP,
                  SellingPrice = t.VehicleSellingPrice,
                  VehicleType = t.VehicleType,
                  Type = t.VehicleType,
                  Mileage = t.VehicleMileage,
                  DealerCertified = t.VehicleDealerCertified,
                  Year = t.VehicleYear,
                  Make = t.VehicleMake,
                  Model = t.VehicleModel,
                  Trim = t.VehicleTrim
              }).ToList();

            return items;
        }

        public bool Update(VehicleModel vehicleModel)
        {
            var original = DatabaseManager.Instance.Vehicle.Find(vehicleModel.VehicleID);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(vehicleModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int vehicleId)
        {
            var items = DatabaseManager.Instance.Vehicle
                                .Where(t => t.VehicleID == vehicleId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Vehicle.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Vehicle ToDbModel(VehicleModel vehicleModel)
        {
            var vehicleDb = new Vehicle
            {
                VehicleID = vehicleModel.VehicleID,
                VehicleVIN = vehicleModel.VIN,
                VehicleStockNumber = vehicleModel.StockNumber,
                VehicleMSRP = vehicleModel.MSRP,
                VehicleSellingPrice = vehicleModel.SellingPrice,
                VehicleVehicleType = vehicleModel.VehicleType,
                VehicleType = vehicleModel.Type,
                VehicleMileage = vehicleModel.Mileage,
                VehicleDealerCertified = vehicleModel.DealerCertified,
                VehicleYear = vehicleModel.Year,
                VehicleMake = vehicleModel.Make,
                VehicleModel = vehicleModel.Model,
                VehicleTrim = vehicleModel.Trim
            };

            return vehicleDb;
        }
    }
}