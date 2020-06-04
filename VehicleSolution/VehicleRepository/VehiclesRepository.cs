using VehicleDB;
using System.Collections.Generic;
using System.Linq;

//This project/namespace maps to the Database Vehicles
namespace VehiclesRepository
{
    public class VehicleModel 
    {
        //TODO - determin if these should be private
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
    }

    public class VehiclesRepository // Maps to the database table Vehicles
    {
        public VehicleModel Add(VehicleModel vehicleModel)
        {
            var vehicleDb = ToDbModel(vehicleModel);

            DatabaseManager.Instance.Vehicles.Add(vehicleDb);
            DatabaseManager.Instance.SaveChanges();

            vehicleModel = new VehicleModel
            {
                 Id = vehicleDb.VehicleId, 
                 Vin = vehicleDb.VehicleVin, 
                 StockNumber = vehicleDb.VehicleStockNumber,
                 Msrp = vehicleDb.VehicleMsrp,
                 SellingPrice = vehicleDb.VehicleSellingPrice,
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
            // Use .Select() to map the database vehicles to VehicleModel
            var items = DatabaseManager.Instance.Vehicles
              .Select(t => new VehicleModel
              {
                  Id = t.VehicleId,
                  Vin = t.VehicleVin,
                  StockNumber = t.VehicleStockNumber,
                  Msrp = t.VehicleMsrp,
                  SellingPrice = t.VehicleSellingPrice,
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
            var original = DatabaseManager.Instance.Vehicles.Find(vehicleModel.Id);

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
            var items = DatabaseManager.Instance.Vehicles
                                .Where(t => t.VehicleId == vehicleId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Vehicles.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Vehicles ToDbModel(VehicleModel vehicleModel)
        {
            var vehicleDb = new Vehicles
            {
                VehicleId = vehicleModel.Id,
                VehicleVin = vehicleModel.Vin,
                VehicleStockNumber = vehicleModel.StockNumber,
                VehicleMsrp = vehicleModel.Msrp,
                VehicleSellingPrice = vehicleModel.SellingPrice,
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