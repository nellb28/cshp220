using System;
using System.Collections.Generic;

namespace VehicleDB
{
    public partial class Vehicle
    {
        public int VehicleID { get; set; }
        public string VehicleVIN { get; set; }
        public string VehicleStockNumber { get; set; }
        public int? VehicleMSRP { get; set; }
        public int? VehicleSellingPrice { get; set; }
        public string VehicleVehicleType { get; set; }
        public string VehicleType { get; set; }
        public int? VehicleMileage { get; set; }
        public bool? VehicleDealerCertified { get; set; }
        public int? VehicleYear { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleTrim { get; set; }
    }
}
