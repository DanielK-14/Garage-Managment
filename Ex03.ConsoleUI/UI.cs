using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class UI
    {


        public void AddNewVehicleToGarage(string i_LicenseNumber)
        {
            List<string> info;
            List<string> buildInstructions = new List<string>();
            string vehicleChoose = string.Empty;
            string vehicleInfo = string.Empty;

            if (Garage.CheckIfLicenseIsValid(i_LicenseNumber) == true)
            {
                try
                {
                    Console.WriteLine("Please choose cehicle: (1)motorccycle (2)car (3)truck");
                    vehicleChoose = Console.ReadLine();
                    info = Garage.ChooseVehicleType(vehicleChoose);
                    foreach(string sentense in info)
                    {
                        Console.WriteLine(sentense);
                        vehicleInfo = Console.ReadLine();
                        buildInstructions.Add(vehicleInfo);
                    }
                    Garage.PutNewCarInGarage(vehicleChoose, i_LicenseNumber, buildInstructions);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void ShowLicenseNumbers()
        {
            string carSituation;
            GarageLogic.ShowVehiclesLicenseInGarage();
            Console.WriteLine("Show vehicles in the situation: ");
            carSituation = Console.ReadLine();
            if(GarageLogic.IsValidSituation(carSituation))
            {
                switch(carSituation)
                {
                    case "fix":
                        return GarageLogic.ShowFixCars();
                    case "inrepair":
                        return GarageLogic.ShowInrepair();
                    case "paied":
                        return GarageLogic.ShowPaied();
                }
            } 
        }

        public void ChangeVehicleStatues()
        {
            string situation, licenseNumber;
            bool valid = false;
            do
            {
                Console.WriteLine("Please enter license number and then the vehicle situation: ");
                licenseNumber = Console.ReadLine();
                situation = Console.ReadLine();
            }
            while (valid == false);

            GarageLogic.ChangeCarSituation(licenseNumber, situation);
        }

        public void FilVehicleWheelsAirToMax(string i_LicenseNumber)
        {
            if(GarageLogic.IsValidLicenseNumber(i_LicenseNumber) == true)
            {
                GarageLogic.FillTiresAir(i_LicenseNumber);
            }
            else
            {
                Console.WriteLine("The license number is not valid!");
            }
        }

        public void FuelUpTank(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountOfFuel)
        {
            if(GarageLogic.IsFuelVehicleExists(i_LicenseNumber, i_FuelType) == true)
            {
                GarageLogic.FillUpTank(i_LicenseNumber, i_AmountOfFuel);
            }
            else
            {
                Console.WriteLine("License number with that fuel type does not exist");
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, int i_amountOfMinutesToCharge)
        {
            if (GarageLogic.IsElectricVehicleExists(i_LicenseNumber) == true)
            {
                GarageLogic.FillUpBattery(i_LicenseNumber, i_amountOfMinutesToCharge);
            }
            else
            {
                Console.WriteLine("License number with that fuel type does not exist");
            }
        }

        public void ShowFullInfo(string i_LicenseNumber)
        {
            if(GarageLogic.IsLicensenumberExist(i_LicenseNumber) == true)
            {
                GarageLogic.ShowAllInfo(i_LicenseNumber);
            }
            else
            {
                Console.WriteLine("The License number does not exist..");
            }
        }
    }
}
