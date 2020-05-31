using VehicleDB;

namespace VehicleRepository
{
    public class DatabaseManager
    {
        private static readonly VehicleInventoryContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new VehicleInventoryContext();
        }

        // Provide an accessor to the database
        public static VehicleInventoryContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}