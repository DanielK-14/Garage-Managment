namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : Motorcycle
    {
        internal FuelMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Octan95, 7))
        {
        }
    }
}