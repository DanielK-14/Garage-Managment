namespace Ex03.GarageLogic
{
    internal class VehicleCreator
    {
        internal enum eVehicleType
        {
            ElectricMotorcycle = 1,
            FuelMotorcycle,
            ElectricCar,
            FuelCar,
            Truck
        }

        internal static Vehicle CreateVehicle(string i_VehicleType, string i_LicenseNumber)
        {
            eVehicleType vehicleType = (eVehicleType)int.Parse(i_VehicleType);
            Vehicle vehicle = null;

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
