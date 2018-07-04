using System.Collections.Generic;
using StorageMaster.Models.Vechiles;

namespace StorageMaster.Models.Storages
{
    public class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots = 10;

        //Possible bug
        public Warehouse(string name)
            : base(name, WarehouseCapacity, WarehouseGarageSlots,
                  new List<Vehicle>() { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}
