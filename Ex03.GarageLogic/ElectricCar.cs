using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car
    {
        public ElectricCar(string i_LicenseNumber)
           : base(i_LicenseNumber, new ElectricEngine((float)2.1)) {}
    }
}
