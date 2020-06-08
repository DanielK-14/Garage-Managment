using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public enum eVehicleType
        {
            ElectricMotorcycle = 1,
            FuelMotorcycle,
            ElectricCar,
            FuelCar,
            Truck
        }
        public static object CreateVehicle(string i_VehicleType, string i_LicenseNumber)
        {
            eVehicleType vehicleType = (eVehicleType)int.Parse(i_VehicleType);
            object vehicle = null;

            switch (vehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar(i_LicenseNumber);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleType.FuelCar:
                    vehicle = new FuelCar(i_LicenseNumber);
                    break;
                case eVehicleType.FuelMotorcycle:
                    vehicle = new FuelMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicenseNumber);
                    break;
            }

            return vehicle;
        }
    }
}
