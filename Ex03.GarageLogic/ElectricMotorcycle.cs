namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, new ElectricEngine((float)1.2)) 
        {
        }
    }
}
