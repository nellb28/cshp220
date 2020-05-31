using System;
using System.Collections.Generic;

namespace VehicleDB
{
    public partial class Vehicles
    {
        public int VehicleId { get; set; }
        public string VehicleVin { get; set; }
        public string VehicleStockNumber { get; set; }
        public int? VehicleMsrp { get; set; }
        public int? VehicleSellingPrice { get; set; }
        public string VehicleType { get; set; }
        public int? VehicleMileage { get; set; }
        public bool? VehicleDealerCertified { get; set; }
        public int? VehicleYear { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleTrim { get; set; }
    }
}
