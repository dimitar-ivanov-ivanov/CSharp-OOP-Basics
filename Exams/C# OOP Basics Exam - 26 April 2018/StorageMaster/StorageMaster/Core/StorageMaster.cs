using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Constants;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vechiles;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        //Possible bug change the products to Dict<string,int>
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private List<Product> products;
        private List<Storage> storages;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.products = new List<Product>();
            this.storages = new List<Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);
            this.products.Add(product);

            return string.Format(OutputMessages.AddedItem, type);
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);

            return string.Format(OutputMessages.RegisterStorage, name);
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storages.FirstOrDefault(x => x.Name == storageName);
            this.currentVehicle = storage.GetVehicle(garageSlot);

            return string.Format(OutputMessages.SelectVehicle, currentVehicle.GetType().Name);
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProducts = 0;

            foreach (var productName in productNames)
            {
                var product = this.products.LastOrDefault(x => x.GetType().Name == productName);

                if (product == null)
                {
                    throw new InvalidOperationException(string.Format(OutputMessages.ProductOutOfStock, productName));
                }

                this.products.Remove(product);
                this.currentVehicle.LoadProduct(product);
                loadedProducts++;
            }

            return string.Format(OutputMessages.LoadedVehicle,
                loadedProducts, productNames.Count(), this.currentVehicle.GetType().Name);
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var source = this.storages.FirstOrDefault(x => x.Name == sourceName);
            var destination = this.storages.FirstOrDefault(x => x.Name == destinationName);

            if (source == null)
            {
                throw new InvalidOperationException(OutputMessages.InvalidSource);
            }

            if (destination == null)
            {
                throw new InvalidOperationException(OutputMessages.InvalidDestination);
            }

            var vehicleType = source.GetVehicle(sourceGarageSlot).GetType().Name;
            var destinationGarageSlot = source.SendVehicleTo(sourceGarageSlot, destination);

            return string.Format(OutputMessages.SentVechileTo,
                vehicleType, destination.Name, destinationGarageSlot);
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var source = this.storages.FirstOrDefault(x => x.Name == storageName);
            var totalProducts = source.GetVehicle(garageSlot).Trunk.Count;
            var unloaded = source.UnloadVehicle(garageSlot);

            return string.Format(OutputMessages.UnloadVehicle,
                unloaded, totalProducts, source.Name);
        }

        public string GetStorageStatus(string storageName)
        {
            var builder = new StringBuilder();
            var storage = this.storages.FirstOrDefault(x => x.Name == storageName);
            var products = storage.Products;

            var grouping = GetGrouping(products);
            var totalWeight = grouping.Values.Sum(x => x.Sum(y => y.Weight));
            var totalCapacity = storage.Capacity;

            var groupingBuilder = new StringBuilder();

            foreach (var group in grouping)
            {
                groupingBuilder.Append($"{group.Key} ({group.Value.Count}), ");
            }

            if (groupingBuilder.Length > 0)
            {
                groupingBuilder = groupingBuilder.Remove(groupingBuilder.Length - 2, 2);
            }

            var first = $"Stock ({totalWeight}/{totalCapacity}): [{groupingBuilder}]\n";

            var garageBuilder = new StringBuilder();

            foreach (var item in storage.Garage)
            {
                if(item != null)
                {
                    garageBuilder.Append($"{item.GetType().Name}|");
                }
                else
                {
                    garageBuilder.Append($"empty|");
                }
            }

            if (garageBuilder.Length > 0)
            {
                garageBuilder = garageBuilder.Remove(garageBuilder.Length - 1, 1);
            }

            var second = $"Garage: [{garageBuilder}]";

            return first + second;
        }

        //Possible bug
        private Dictionary<string, List<Product>> GetGrouping(IReadOnlyCollection<Product> products)
        {
            var grouping = new Dictionary<string, List<Product>>();
            grouping.Add("Gpu", new List<Product>());
            grouping.Add("HardDrive", new List<Product>());
            grouping.Add("Ram", new List<Product>());
            grouping.Add("SolidStateDrive", new List<Product>());

            foreach (var product in products)
            {
                grouping[product.GetType().Name].Add(product);
            }

            grouping = grouping
                .Where(x => x.Value.Count != 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            return grouping;
        }

        public string GetSummary()
        {
            var builder = new StringBuilder();

            var ordered = this.storages
                .OrderByDescending(x => x.Products.Sum(y => y.Price));

            foreach (var storage in ordered)
            {
                builder.AppendLine(storage.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
