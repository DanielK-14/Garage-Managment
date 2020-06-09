using System;
using System.Collections.Generic;
using System.Threading;
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
3. Modify vehicle's status.
4. Inflate vehicle's wheels to maximum.
5. Refuel a gasoline-powered vehicle.
6. Charge an electric vehicle.
7. Display full details of a vehicle.
8. Quit.
";

        static bool s_ExitProgram = false;

        public static void Start()
        {
            int userMenuSelection;
            string userInput;
            bool valid;
            
            while (s_ExitProgram == false)
            {
                Console.Clear();
                try
                {
                    Console.WriteLine(k_MainMenuText);
                    Console.Write("Please choose a number: ");
                    userInput = Console.ReadLine();
                    do
                    {
                        valid = Int32.TryParse(userInput, out userMenuSelection);
                    }
                    while (valid == false);
                    userSelectionOnManu(userMenuSelection);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void userSelectionOnManu(int i_UserChoose)
        {
            Console.Clear();
            switch (i_UserChoose)
            {
                case 1:
                    addNewVehicleToGarage();
                    break;
                case 2:
                    showLicenseNumbersInStatus();
                    Thread.Sleep(3000);
                    break;
                case 3:
                    changeVehicleStatuses();
                    break;
                case 4:
                    filVehicleWheelsAirToMax();
                    break;
                case 5:
                    refuelVehicle();
                    break;
                case 6:
                    chargeElectricVehicle();
                    break;
                case 7:
                    showFullInfo();
                    Thread.Sleep(5000);
                    break;
                case 8:
                    s_ExitProgram = true;
                    break;
                default:
                    throw new ValueOutOfRangeException(8, 1);
            }

        }

        private static void addNewVehicleToGarage()
        {
            List<string> infoRequiredForCreation;
            string licenseNumber, vehicleTypeNumber, ownerName, phoneNumber;
            object vehicle;

            licenseNumber = getLicenseNumber();
            if(m_Garage.IfLicenseNumberExsitsChangeStatusInRepair(licenseNumber) != true)
            {
                vehicleTypeNumber = getVehicleInfo();
                vehicle = VehicleCreator.CreateVehicle(vehicleTypeNumber, licenseNumber);
                infoRequiredForCreation = m_Garage.GetAllInformationRequiredForThisTypeOfVehicle(vehicleTypeNumber, vehicle);
                getUserInputForCreationAndFillVehicleData(infoRequiredForCreation, vehicleTypeNumber, vehicle);
                ownerName = getOwnerName();
                phoneNumber = getPhoneNumber();
                m_Garage.AddVehicleToGarage(licenseNumber, vehicle, ownerName, phoneNumber);
            }
            else
            {
                Thread.Sleep(3000);
                Console.WriteLine("Vehicle already exists");
            }
        }

        private static string getOwnerName()
        {
            Console.Clear();
            bool valid;
            string ownerName = string.Empty;

            do
            {
                try
                {
                    Console.Write("Please enter vehicle's OWNER NAME: ");
                    ownerName = Console.ReadLine();
                    m_Garage.CheckOwnerName(ownerName);
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);

            return ownerName;
        }

        private static string getPhoneNumber()
        {
            Console.Clear();
            bool valid;
            string phoneNumber = string.Empty;

            do
            {
                try
                { 
                    Console.Write("Please enter owner's PHONE NUMBER: ");
                    phoneNumber = Console.ReadLine();
                    m_Garage.CheckPhone(phoneNumber);
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);

            return phoneNumber;
        }

        private static string getLicenseNumber()
        {
            Console.Clear();
            bool valid;
            string licenseNumber = string.Empty;
            do
            {
                try
                {
                    Console.Write("Please enter LICENSE NUMBER: ");
                    licenseNumber = Console.ReadLine();
                    m_Garage.CheckIfLicenseIsValid(licenseNumber);
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);

            return licenseNumber;
        }

        private static string getVehicleInfo()
        {
            Console.Clear();
            bool valid;
            string userVehicleTypeInput = string.Empty;
            do
            {
                try
                {
                    Console.WriteLine(m_Garage.GetGarageVehiclesTypes());
                    userVehicleTypeInput = Console.ReadLine();
                    m_Garage.ValidVehicleType(userVehicleTypeInput);
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);

            return userVehicleTypeInput;
        }

        private static void getUserInputForCreationAndFillVehicleData(List<string> i_InfoRequired, string i_VehicleType, object vehicle)
        {
            Console.Clear();
            int requestNumber = 1;
            string userInput;
            bool validInput;

            foreach(var request in i_InfoRequired)
            {
                Console.Clear();
                do
                {
                    try
                    {
                        Console.WriteLine(request);
                        userInput = Console.ReadLine();
                        m_Garage.CheckInputForCreation(userInput, requestNumber, i_VehicleType, vehicle);
                        requestNumber++;
                        validInput = true;

                    }
                    catch(Exception ex)
                    {
                        Console.Clear();
                        validInput = false;
                        Console.WriteLine(ex.Message);
                    }

                } while (validInput == false);
            }
        }

        private static void showLicenseNumbersInStatus()
        {
            Console.Clear();
            string userInput;
            bool valid;

            do
            {
                try
                {
                    Console.WriteLine("Choose status for search : " + m_Garage.GetVehiclesPossibleStatusesInGarage());
                    userInput = Console.ReadLine();
                    m_Garage.CheckInputedStatus(userInput);
                    valid = true;
                    List<string> matchedLicenseNumbers = m_Garage.GetLicenseNumbersInStatus(userInput);
                    foreach (string LicenseNumber in matchedLicenseNumbers)
                    {
                        Console.WriteLine(LicenseNumber);
                    }
                }
                catch(Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);
        }

        private static void changeVehicleStatuses()
        {
            Console.Clear();
            string licenseNumber, statusInput;
            bool valid;
            do
            {
                try
                {
                    Console.Write("Please enter license number: ");
                    licenseNumber = Console.ReadLine();
                    m_Garage.CheckLicenseNumberInGarage(licenseNumber);

                    Console.WriteLine("Choose status to change to :" + m_Garage.GetVehiclesPossibleStatusesInGarage());
                    statusInput = Console.ReadLine();
                    m_Garage.CheckInputedStatus(statusInput);

                    m_Garage.ChangeVehicleStatus(licenseNumber, statusInput);
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);
        }

        private static void filVehicleWheelsAirToMax()
        {
            Console.Clear();
            bool valid;
            string licenseNumber;
            do
            {
                try
                {
                    Console.Write("Please enter license number to fill air-pressure wheels to maximum: ");
                    licenseNumber = Console.ReadLine();
                    m_Garage.CheckLicenseNumberInGarage(licenseNumber);
                    m_Garage.FillAirInVehicleWheelsToMax(licenseNumber);
                    valid = true;
                }
                catch(Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);
        }

        private static void refuelVehicle()
        {
            Console.Clear();
            bool valid;
            string licenseNumber, fuelType, fuelAmount;

            do
            {
                try
                {
                    Console.WriteLine("Please enter license number to refuel: ");
                    licenseNumber = Console.ReadLine();
                    m_Garage.CheckLicenseNumberForRefuel(licenseNumber);
                    Console.Clear();

                    Console.WriteLine("Choose fuel type to fill :" + m_Garage.GetFuelTypes());
                    fuelType = Console.ReadLine();
                    m_Garage.CheckIfFuelTypeIsValid(fuelType);
                    Console.Clear();

                    Console.WriteLine("How much fuel do you want to fill? " + m_Garage.VehiclesMaxAndCurrentSourceCapacity(licenseNumber));
                    fuelAmount = Console.ReadLine();
                    m_Garage.RefuelVehicle(licenseNumber, fuelType, fuelAmount);

                    valid = true;
                }
                catch(Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false );
        }

        private static void chargeElectricVehicle()
        {
            Console.Clear();
            bool valid;
            string amountToCharge, licenseNumber;

            do
            {
                try
                {
                    Console.WriteLine("Please enter license number to charge up battery: ");
                    licenseNumber = Console.ReadLine();
                    m_Garage.CheckLicenseNumberForRecharge(licenseNumber);
                    Console.Clear();

                    Console.WriteLine("How much energy do you want to fill? " + m_Garage.VehiclesMaxAndCurrentSourceCapacity(licenseNumber));
                    amountToCharge = Console.ReadLine();
                    m_Garage.ChargeVehicle(licenseNumber, amountToCharge);
                    Console.Clear();

                    valid = true;
                }
                catch(Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);
        }

        private static void showFullInfo()
        {
            Console.Clear();
            bool valid;
            string licenseNumber;

            do
            {
                try
                {
                    Console.WriteLine("Please enter The license number of which vehicle's information you want to see: ");
                    licenseNumber = Console.ReadLine();
                    m_Garage.CheckLicenseNumberInGarage(licenseNumber);
                    Console.WriteLine(m_Garage.GetVehicleInfo(licenseNumber));
                    valid = true;
                }
                catch (Exception ex)
                {
                    valid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);
        }
    }
}
