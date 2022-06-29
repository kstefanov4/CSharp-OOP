using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        
        public Vehicle(double fuel, int horsePower)
        {
            Fuel = fuel;
            HorsePower = horsePower;
           // FuelConsumption = DefaultFuelConsumption;
        }

        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }

    }
}
