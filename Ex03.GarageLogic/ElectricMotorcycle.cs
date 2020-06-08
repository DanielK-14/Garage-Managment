using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseNumber)
            : base(i_LicenseNumber, new ElectricEngine((float)1.2)) {}
    }
}
