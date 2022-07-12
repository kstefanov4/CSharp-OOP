using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicles
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }

            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption 
        { 
            get => fuelConsumption; 
            set => fuelConsumption = value; 
        }
        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }

            set
            {

                tankCapacity = value;
            }
        }

        public bool IsEmpty { get; set; }
        

        public bool CanDrive(double km)
        {
            if (this.FuelQuantity - (km * this.FuelConsumption) >= 0)
            {
                return true;
            }

            return false;
        }
        public void Drive(double km)
        {
            if (!CanDrive(km))
            {

                return;
            }
            this.FuelQuantity -= km * this.FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0 )
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }
    }
}
