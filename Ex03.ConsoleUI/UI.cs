using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private static Garage m_Garage = new Garage();

        private const string k_MainMenuText =
     @"Please choose from the following options (1-8):
1. Add a new vehicle to garage.
2. Display license plate numbers for all vehicles in the garage.
3. Modify a vehicle's status.
4. Inflate a vehicle's wheels to maximum.
5. Refuel a gasoline-powered vehicle.
6. Charge an electric vehicle.
7. Display full details of a vehicle.
8. Quit.
";

        static bool s_ExitProgram = false;

        public static void start()
        {
            int userMenuSelection;
            string userInput;
            bool valid;
            
            while (!s_ExitProgram)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(k_MainMenuText);
                    userInput = Console.ReadLine();
                    do
                    {
                        valid = Int32.TryParse(userInput, out userMenuSelection);
                    }
                    while (valid == false);
                    IsUserSelectionOnManuValid(userMenuSelection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static void IsUserSelectionOnManuValid(int i_UserChoose)
        {
            switch (i_UserChoose)
            {
                case 1:
                    AddNewVehicleToGarage();
                    break;
                case 2:
                    ShowLicenseNumbers();
                    break;
                case 3:
                    ChangeVehicleStatues();
                    break;
                case 4:
                    FilVehicleWheelsAirToMax();
                    break;
                case 5:
                    FuelUpTank();
                    break;
                case 6:
                    ChargeElectricVehicle();
                    break;
                case 7:
                    ShowFullInfo();
                    break;
                case 8:
                    s_ExitProgram = true;
                    break;
                default:
                    throw new ValueOutOfRangeException();
            }

        }

        public static void AddNewVehicleToGarage()
        {
            int vehicleTypeNumber, amountOfValidInstructions = 0, maxInstructionsForVehicle;
            bool valid, succesRequest, isFuelEngine = false;
            List<string> requiredInfo;
            List<string> buildInstructions = new List<string>();
            string licenseNumber, userVehicleTypeInput, userInputInfoForVehicle;
            float maximumPowerCapacity = 0, maximumAirPresure = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(m_Garage.GetGarageVehiclesTypes());
                userVehicleTypeInput = Console.ReadLine();
                valid = m_Garage.ValidVehicleType(userVehicleTypeInput, out vehicleTypeNumber);
            }
            while (valid == false);


            Console.WriteLine("Please enter LICENSE NUMBER: ");
            licenseNumber = Console.ReadLine();
            if(m_Garage.IsInGarage(licenseNumber) == true)
            {
                m_Garage.ChangeStatuesToInRepair(licenseNumber);
            }
            else
            {
                buildInstructions.Add(licenseNumber);
                amountOfValidInstructions++;
                requiredInfo = m_Garage.ChooseVehicleType(vehicleTypeNumber, out maxInstructionsForVehicle);
                foreach(string instrucion in requiredInfo)
                {
                    do
                    {
                        Console.WriteLine(instrucion);

                        userInputInfoForVehicle = Console.ReadLine();
                        succesRequest = m_Garage.BuildNewVehicle(vehicleTypeNumber, userInputInfoForVehicle,
                            amountOfValidInstructions, ref isFuelEngine, ref maximumPowerCapacity, ref maximumAirPresure);

                        if (succesRequest == true)
                        {
                            amountOfValidInstructions++;
                            buildInstructions.Add(userInputInfoForVehicle);
                        }
                    }
                    while (succesRequest == false);

                    succesRequest = false;
                }
                m_Garage.MakeVehicleAndPlaceInGarage(buildInstructions, vehicleTypeNumber);
            }
        }

        public static void ShowLicenseNumbers()
        {
            int carSituation;
            string userInput;
            bool valid;
            do
            {
                Console.WriteLine("Show vehicles in the situation (1)InReapair (2)Fixed (3)Paied (4)All: ");
                userInput = Console.ReadLine();
                valid = int.TryParse(userInput, out carSituation);
            }
            while (valid == true && carSituation > 0 && carSituation < 5);

            List<string> LicensesList= m_Garage.ShowVehiclesInSituation(carSituation);

            foreach(string LicenseNumber in LicensesList)
            {
                Console.WriteLine(LicenseNumber);
            }
        }

        public static void ChangeVehicleStatues()
        {
            string licenseNumber, userInput;
            int situation;
            bool valid;
            do
            {
                Console.WriteLine("Please enter license: ");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Enter situation (1)InRepair (2)Fixed (3)Paied: ");
                userInput = Console.ReadLine();
                valid = Int32.TryParse(userInput, out situation);
            }
            while (valid == false && (situation < 1 || situation > 3));

            m_Garage.ChangeCarSituation(licenseNumber, situation);
        }

        public static void FilVehicleWheelsAirToMax()
        {
            bool valid;
            string userInput;
            do
            {
                Console.WriteLine("Please enter license number to fill Air in the wheels: ");
                userInput = Console.ReadLine();
                valid = m_Garage.FillAirInVehicle(userInput);
            }
            while (valid == false);
        }

        public static void FuelUpTank()
        {
            bool valid = false;
            int fuel;
            string userInput, fuelType, amount;

            do
            {
                Console.WriteLine("Please enter license number to fuel up tank: ");
                userInput = Console.ReadLine();
                Console.WriteLine("Chose fuel type (1)Soler (2)Octan95 (3)Octan96 (4)Octan98: ");
                fuelType = Console.ReadLine();
                Console.WriteLine("How much fuel do you want? ");
                amount = Console.ReadLine();
                valid = Int32.TryParse(fuelType, out fuel);
                if(valid == true)
                {
                    valid = m_Garage.FillUpTank(userInput, fuel, amount);
                }
            }
            while (valid == false );
        }

        public static void ChargeElectricVehicle()
        {
            bool valid = false;
            int amount;
            string userInput, licenseNumber;

            do
            {
                Console.WriteLine("Please enter license number to charge up battery: ");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("How much to charge the battery?  ");
                userInput = Console.ReadLine();
                valid = Int32.TryParse(userInput, out amount);
                if (valid == true)
                {
                    valid = m_Garage.ChargeBattery(licenseNumber, amount);
                }
            }
            while (valid == false);
        }

        public static void ShowFullInfo()
        {
            bool valid = false;
            string licenseNumber;

            do
            {
                Console.WriteLine("Please enter The license number of which vehicle information you want to see: ");
                licenseNumber = Console.ReadLine();
                valid = m_Garage.ShowVehicleInfo(licenseNumber);
            }
            while (valid == false);
        }
    }
}
