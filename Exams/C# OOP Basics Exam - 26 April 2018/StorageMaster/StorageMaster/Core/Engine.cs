using System;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        private const string TerminatingCommand = "END";

        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = args[0];
                var result = string.Empty;

                try
                {
                    switch (methodName)
                    {
                        case "AddProduct":
                            var type = args[1];
                            var price = double.Parse(args[2]);
                            result = this.storageMaster.AddProduct(type, price);
                            break;
                        case "RegisterStorage":
                            type = args[1];
                            var name = args[2];
                            result = this.storageMaster.RegisterStorage(type, name);
                            break;
                        case "SelectVehicle":
                            var storageName = args[1];
                            var garageSlot = int.Parse(args[2]);
                            result = this.storageMaster.SelectVehicle(storageName, garageSlot);
                            break;
                        case "LoadVehicle":
                            var productNames = args.Skip(1);
                            result = this.storageMaster.LoadVehicle(productNames);
                            break;
                        case "SendVehicleTo":
                            var sourceName = args[1];
                            var sourceGarageSlot = int.Parse(args[2]);
                            var destinationName = args[3];
                            result = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            break;
                        case "UnloadVehicle":
                            storageName = args[1];
                            garageSlot = int.Parse(args[2]);
                            result = this.storageMaster.UnloadVehicle(storageName, garageSlot);
                            break;
                        case "GetStorageStatus":
                            storageName = args[1];
                            result = this.storageMaster.GetStorageStatus(storageName);
                            break;
                        default:
                            break;
                    }
                }
                catch(InvalidOperationException ex)
                {
                    result = "Error: " + ex.Message;
                }

                Console.WriteLine(result);
                input = Console.ReadLine();
            }

            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
