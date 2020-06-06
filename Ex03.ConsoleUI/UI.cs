using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {

        Garage garage = new Garage();

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
        //public void AddNewVehicleToGarage(string i_LicenseNumber)
        //{
        //    List<string> info;
        //    List<string> buildInstructions = new List<string>();
        //    string vehicleChoose = string.Empty;
        //    string vehicleInfo = string.Empty;

        //    if (Garage.CheckIfLicenseIsValid(i_LicenseNumber) == true)
        //    {
        //        try
        //        {
        //            Console.WriteLine("Please choose cehicle: (1)motorccycle (2)car (3)truck"); //To change
        //            vehicleChoose = Console.ReadLine();
        //            info = Garage.ChooseVehicleType(vehicleChoose);
        //            foreach(string sentense in info)
        //            {
        //                Console.WriteLine(sentense);
        //                vehicleInfo = Console.ReadLine();
        //                buildInstructions.Add(vehicleInfo);
        //            }
        //            Garage.PutNewCarInGarage(vehicleChoose, i_LicenseNumber, buildInstructions);
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}

        static bool s_ExitProgram = false;

        public static void start()
        {
            int userMenuSelection;
            string userInput;
            bool valid = false;
            
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
                    handleUserSelection(userMenuSelection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error...");
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
        private static void handleUserSelection(int i_UserChoose)
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
                    break;
            }

        }

        public static void AddNewVehicleToGarage()
        {
            int vehicle, amountOfGoodInstructions = 0, maxInstructionsForVehicle = 0;
            bool valid = false, succesRequest = false;
            string input;
            List<string> info;
            List<string> buildInstructions = new List<string>();
            string vehicleChoose = string.Empty;
            string vehicleInfo = string.Empty;
            string licenseNumber;
            string Request;


            do
            {
                Console.Clear();
                Console.WriteLine("Please choose vehicle: (1)motorccycle (2)car (3)truck");
                input = Console.ReadLine();
                //valid = Int32.TryParse(input, out vehicle);
                valid = Garage.ValidVehicleType(input, out vehicle);
            }
            while (valid == false);


            Console.WriteLine("Please enter license number: ");
            licenseNumber = Console.ReadLine();
            if(Garage.IsInGarage(licenseNumber) == true)
            {
                Garage.ChangeStatuesToFixing(licenseNumber); /// to do func ChangeStatuesToFixing
            }
            else
            {
                info = Garage.ChooseVehicleType(vehicle, out maxInstructionsForVehicle);
                foreach(string instrucion in info)
                {
                    do
                    {
                        Console.WriteLine(instrucion);
                        Request = Console.ReadLine();
                        succesRequest = Garage.BuildNewVehicle(vehicle, Request, licenseNumber, amountOfGoodInstructions);
                        if(succesRequest == true)
                        {
                            amountOfGoodInstructions++;
                            buildInstructions.Add(Request);
                        }
                    }
                    while (succesRequest == false);

                    succesRequest = false;
                }
                Garage.MakeVehicleAndPlaceInGarage(buildInstructions, vehicle);
            }
        }

        public static void ShowLicenseNumbers()
        {
            int carSituation;
            string userInput;
            bool valid = false;
            do
            {
                Console.WriteLine("Show vehicles in the situation (1)InReapair (2)Fixed (3)Paied (4)All: ");
                userInput = Console.ReadLine();
                valid = int.TryParse(userInput, out carSituation);
            }
            while (valid == true && carSituation > 0 && carSituation < 5);

            List<string> LicensesList= Garage.ShowVehiclesInSituation(carSituation);

            foreach(string LicenseNumber in LicensesList)
            {
                Console.WriteLine(LicenseNumber);
            }
        }

        public static void ChangeVehicleStatues()
        {
            string licenseNumber, userInput;
            int situation;
            bool valid = false;
            do
            {
                Console.WriteLine("Please enter license: ");
                licenseNumber = Console.ReadLine();
                Console.WriteLine("Enter situation (1)InRepair (2)Fixed (3)Paied: ");
                userInput = Console.ReadLine();
                valid = Int32.TryParse(userInput, out situation);
            }
            while (valid == false && (situation < 1 || situation > 3));

            Garage.ChangeCarSituation(licenseNumber, situation);
        }

        public static void FilVehicleWheelsAirToMax()
        {
            bool valid = false;
            string userInput;
            do
            {
                Console.WriteLine("Please enter license number to fill Air in the wheels: ");
                userInput = Console.ReadLine();
                valid = Garage.FillAirInVehicle(userInput);
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
                    valid = Garage.FillUpTank(userInput, fuel, amount);
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
                    valid = Garage.ChargeBattery(licenseNumber, amount);
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
                valid = Garage.ShowVehicleInfo(licenseNumber);
            }
            while (valid == false);
        }
    }
}
