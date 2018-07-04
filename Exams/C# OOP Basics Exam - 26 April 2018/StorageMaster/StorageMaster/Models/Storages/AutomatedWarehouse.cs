﻿using System.Collections.Generic;
using StorageMaster.Models.Vechiles;

namespace StorageMaster.Models.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;

        public AutomatedWarehouse(string name) 
            : base(name, AutomatedWarehouseCapacity, AutomatedWarehouseGarageSlots, 
                  new List<Vehicle>() { new Truck() })
        {
        }
    }
}
