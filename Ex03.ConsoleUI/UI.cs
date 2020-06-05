using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class UI
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
                    showActionsMenu();
                    userInput = Console.ReadLine();
                    do
                    {
                        valid = Int32.TryParse(userInput, out userMenuSelection);
                    }
                    while (valid == false);
                    handleUserSelection(userMenuSelection);
                }
                catch ()
                {
                    Console.WriteLine("Error...");
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
            }
        }
        private static void handleUserSelection(int i_UserChoose, string i_LicenseNumber)
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
                    FilVehicleWheelsAirToMax(i_LicenseNumber);
                    break;
                case 5:
                    FuelUpTank(i_LicenseNumber, eFuelType i_FuelType, i_AmountOfFuel);
                    break;
                case 6:
                    ChargeElectricVehicle(i_LicenseNumber, i_amountOfMinutesToCharge);
                    break;
                case 7:
                    ShowFullInfo(i_LicenseNumber);
                case 8:
                    s_ExitProgram = true;
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

            GarageLogic.ChangeCarSituation(licenseNumber, situation);
        }

        public static void FilVehicleWheelsAirToMax(string i_LicenseNumber)
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
                valid = Garage.FillUpTank(userInput, fuel, amount);
            }
            while (valid == false );
        }

        public static void ChargeElectricVehicle(string i_LicenseNumber, int i_amountOfMinutesToCharge)
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

        public static void ShowFullInfo(string i_LicenseNumber)
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
