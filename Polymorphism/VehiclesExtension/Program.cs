using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();
            string[] truckInput = Console.ReadLine().Split();
            string[] busInput = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            double carTankCapacity = double.Parse(carInput[3]);


            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            double truckTankCapacity = double.Parse(truckInput[3]);

            double busFuelQuantity = double.Parse(busInput[1]);
            double busFuelConsumption = double.Parse(busInput[2]);
            double busTankCapacity = double.Parse(busInput[3]);


            IVehicles car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            IVehicles truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            IVehicles bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string action = inputInfo[0];
                string vehicle = inputInfo[1];
                double value = double.Parse(inputInfo[2]);

                try
                {
                    if (action == "Drive")
                    {
                        if (vehicle == "Car")
                        {
                            if (car.CanDrive(value))
                            {
                                car.Drive(value);
                                Console.WriteLine($"Car travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine($"Car needs refueling");
                            }
                        }
                        else if (vehicle == "Truck")
                        {
                            if (truck.CanDrive(value))
                            {
                                truck.Drive(value);
                                Console.WriteLine($"Truck travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine($"Truck needs refueling");
                            }
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.IsEmpty = false;
                            if (bus.CanDrive(value))
                            {
                                bus.Drive(value);
                                Console.WriteLine($"Bus travelled {value} km");
                            }
                            else
                            {
                                Console.WriteLine($"Bus needs refueling");
                            }

                        }
                    }
                    else if (action == "Refuel")
                    {

                        if (vehicle == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehicle == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(value);
                        }

                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        if (bus.CanDrive(value))
                        {
                            bus.Drive(value);
                            Console.WriteLine($"Bus travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"Bus needs refueling");
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
