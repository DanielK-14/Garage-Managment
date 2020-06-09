namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        internal ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber, new ElectricEngine((float)2.1))
        {
        }
    }
}
