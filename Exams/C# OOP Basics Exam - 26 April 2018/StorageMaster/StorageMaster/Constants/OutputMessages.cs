namespace StorageMaster.Constants
{
    public class OutputMessages
    {
        public const string NegativePrice = "Price cannot be negative!";

        public const string VechileFull = "Vehicle is full!";

        public const string VechileEmpty = "No products left in vehicle!";

        public const string InvalidGarageSlot = "Invalid garage slot!";

        public const string EmptyGarageSlot = "No vehicle in this garage slot!";

        public const string StorageFull = "Storage is full!";

        public const string NoRoomInGarage = "No room in garage!";

        public const string InvalidType = "Invalid {0} type!";

        public const string AddedItem = "Added {0} to pool";

        public const string RegisterStorage = "Registered {0}";

        public const string InvalidSource = "Invalid source storage!";

        public const string InvalidDestination = "Invalid destination storage!";

        public const string SentVechileTo = "Sent {0} to {1} (slot {2})";

        public const string UnloadVehicle = "Unloaded {0}/{1} products at {2}";

        public const string SelectVehicle = "Selected {0}";

        public const string ProductOutOfStock = "{0} is out of stock!";

        public const string LoadedVehicle = "Loaded {0}/{1} products into {2}";

        public const string StorageOutput = "{0}:\nStorage worth: ${1:F2}";
    }
}
