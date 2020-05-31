using VehicleDB;

namespace VehiclesRepository
{
    public static class DatabaseManager
    {
        private static readonly VehiclesContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new VehiclesContext();
        }

        // Provide an accessor to the database
        public static VehiclesContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}