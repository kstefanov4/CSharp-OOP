﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicles
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km);
        void Drive(double km);
        void Refuel(double liters);
    }
}
