using System;
using System.Collections.Generic;

namespace vehicleInventory
{
    public partial class Vehicles
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
}
