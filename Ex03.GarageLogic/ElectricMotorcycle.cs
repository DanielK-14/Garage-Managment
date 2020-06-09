namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        internal ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, new ElectricEngine((float)1.2)) 
        {
        }
    }
}
