namespace Ex03.GarageLogic
{
    class FuelMotorcycle : Motorcycle
    {
        public FuelMotorcycle(string i_LicenseNumber)
            : base(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Octan95, 7)) {}
    }
}