using StorageMaster.Constants;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vechiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private readonly List<Product> products;
        private readonly List<Vehicle> garage;

        protected Storage(string name, int capacity, int garageSlots,
            IEnumerable<Vehicle> garage)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            this.garage = InitializeGarage(garage);
            this.products = new List<Product>();
        }

        private List<Vehicle> InitializeGarage(IEnumerable<Vehicle> garage)
        {
            var arr = new Vehicle[GarageSlots];
            var index = 0;
            foreach (var item in garage)
            {
                arr[index] = item;
                index++;
            }

            return arr.ToList();
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(OutputMessages.InvalidGarageSlot);
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException(OutputMessages.EmptyGarageSlot);
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            var freeSlots = 0;

            foreach (var garageVehicle in deliveryLocation.Garage)
            {
                if (garageVehicle == null)
                {
                    freeSlots++;
                }
            }

            if (freeSlots == 0)
            {
                throw new InvalidOperationException(OutputMessages.NoRoomInGarage);
            }

            //Possible bug remove or make null?
            this.garage[garageSlot] = null;

            for (int i = 0; i < deliveryLocation.garage.Count; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    deliveryLocation.garage[i] = vehicle;
                    return i;
                }
            }

            //Possible bug 
            return -1;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(OutputMessages.StorageFull);
            }

            var vehicle = GetVehicle(garageSlot);
            var vehicleProducts = vehicle.Trunk;
            var unloadedProducts = 0;
 
            while(!this.IsFull && vehicle.Trunk.Count != 0)
            {
                unloadedProducts++;
                this.products.Add(vehicle.Unload());
            }

            return unloadedProducts;
        }

        public override string ToString()
        {
            var totalMoney = this.products.Sum(x => x.Price);

            return string.Format(OutputMessages.StorageOutput,
                this.Name, totalMoney);
        }
    }
}
