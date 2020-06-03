using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVehicleType
        {
            Motorcycle = 1,
            Car,
            Truck
        }

        List<Vehicle> m_VehicleList;

        public List<string> ChooseNewVehicle()
        {
            List<string> vehiclesTypes = new List<string>();
            vehiclesTypes.Add("Please choose vehicle type:\n" + GetEnumOptions(typeof(eVehicleType)));
            return vehiclesTypes;
        }

        public bool IsVehicleSelectionValid(string i_Selection)
        {
            int selectionNumber = int.Parse(i_Selection);
            return Enum.IsDefined(typeof(eVehicleType), selectionNumber);
        }

        public List<string> GetAllInformationRequiredForThisTypeOfVehicle(string i_VehicleChosen)
        {
            eVehicleType vehicleType = (eVehicleType) int.Parse(i_VehicleChosen);
            List<string> requiredInfo;

            switch(vehicleType)
            {
                case eVehicleType.Motorcycle:
                    requiredInfo = Motorcycle.RequiredInfoForCreation();
                    break;

                case eVehicleType.Car:
                    requiredInfo = Car.RequiredInfoForCreation();
                    break;

                case eVehicleType.Truck:
                    requiredInfo = Truck.RequiredInfoForCreation();
                    break;

                default:
                    throw new FormatException();
            }

            return requiredInfo;
        }

        public bool IsValueInputedValidForCreation

        public List<string> AddSelectedVehicle(string i_Selection)
        {
            eVehicleType type = (eVehicleType)int.Parse(i_Selection);
            
        }

        public void BuildNewMotorcycle(string i_LicenseNumber, List<string> i_BuildInstructions)
        {
            if(ValidMotorcycleInfo(i_BuildInstructions) == true)
            {
                Motorcycle motorcycle = new Motorcycle(i_BuildInstructions[4], i_BuildInstructions[5]);
            }
        }
        public void BuildNewCar(string i_LicenseNumber, List<string> i_BuildInstructions)
        {
            if(ValidCarInfo(i_BuildInstructions) == true)
            {
                string i_ModelName, string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels, eCarColor i_CarColor, eDoorsAmount i_DoorsAmount
                Car car = new Car(i_BuildInstructions[0], i_BuildInstructions[1]);
                
            }
        }
        public void BuildNewTruck(string i_LicenseNumber, List<string> i_BuildInstructions)
        {
            if(ValidTruckInfo(i_BuildInstructions) == true)
            {

            }
        }
        public bool CheckIfLicenseIsValid(string i_LicenseNumber)
        {
            bool result = false;
            foreach (Vehicle vehicle in m_VehicleList)
            {
                if (i_LicenseNumber == vehicle.LicenseNumber)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void PutNewCarInGarage(string i_VehicleChoose, string i_LicenseNumber, List<string> i_BuildInstructions)
        {

            try
            {
                switch (i_VehicleChoose)
                {
                    case "1":
                        BuildNewMotorcycle(i_LicenseNumber, i_BuildInstructions);
                    case "2":
                        BuildNewCar(i_LicenseNumber, i_BuildInstructions);
                    case "3":
                        BuildNewTruck(i_LicenseNumber, i_BuildInstructions);
                }  
            }
            catch()
            {

            }
        }

        public List<string> ChooseVehicleType(string i_UserInput)
        {
            List<string> result;

            switch (i_UserInput)
            {
                case "1":
                    result = Motorcycle.RequiredInfoForCreation();
                case "2":
                    result = Car.RequiredInfoForCreation();
                case "3":
                    result = Truck.RequiredInfoForCreation();
                default:
                    result = null;
            }

            return result;
        }

        public static string GetEnumOptions(Type i_EnumType)
        {
            if (!typeof(Enum).IsAssignableFrom(i_EnumType))
            {
                throw new ArgumentException("Value must be enum type");
            }

            string optionsForPick = string.Empty;
            int optionNumber = 1;
            foreach (var type in Enum.GetNames(i_EnumType))
            {
                optionsForPick += "(" + optionNumber.ToString() + ")" + type + " ";
                optionNumber++;
            }

            return optionsForPick;
        }

        public bool ValidMotorcycleInfo(List<string> i_BuildiInfo)
        {
            bool valid = false;
            if (i_BuildiInfo.Count == 6)
            {
                if (ValidVehicleInfo(i_BuildiInfo) == true)
                {
                    if (IsValidLicenseType(i_BuildiInfo[4]) == true)
                    {
                        if (IsValidEngineCapacity(i_BuildiInfo[5]) == true)
                        {
                            valid = true;
                        }
                    }
                }
            }

            return valid;
        }
        public bool ValidCarInfo(List<string> i_BuildiInfo)
        {
            bool valid = false;
            if(i_BuildiInfo.Count == 6)
            {
                if(ValidVehicleInfo(i_BuildiInfo) == true)
                {
                    if(IsValidCarColor(i_BuildiInfo[4]) == true)
                    {
                        if(IsValidCarDoorsAmount(i_BuildiInfo[5]) == true)
                        {
                            valid = true;
                        }
                    }
                }
            }

            return valid;
        }
        public bool ValidTruckInfo(List<string> i_BuildiInfo)
        {
            bool valid = false;
            if (i_BuildiInfo.Count == 6)
            {
                if (ValidVehicleInfo(i_BuildiInfo) == true)
                {
                    if (IsValidDangerousGoods(i_BuildiInfo[4]) == true)
                    {
                        if (IsValidCargoCapacity(i_BuildiInfo[5]) == true)
                        {
                            valid = true;
                        }
                    }
                }
            }

            return valid;
        }
        public bool ValidVehicleInfo(List<string> i_BuildiInfo)
        {

        }

        public bool IsValidCarColor(string i_CarColor)
        {
            return Enum.IsDefined(Car.eCarColor, i_CarColor);
        }
        public bool IsValidCarDoorsAmount(string i_CarDoorsAmount)
        {
            return Enum.IsDefined(Car.eDoorsAmount, i_CarDoorsAmount);

        }
        public bool IsValidDangerousGoods(string i_DangerousGoods)
        {
            return Enum.IsDefined(Car.eCarColor, i_DangerousGoods);

        }
        public bool IsValidCargoCapacity(string i_CargoCapacity)
        {
            bool valid = true;
            foreach (char ch in i_CargoCapacity)
            {
                if (ch > 57 && ch < 48)
                {
                    valid = false;
                }
            }

            return valid;

        }
        public bool IsValidLicenseType(string i_LicenseType)
        {
            return Enum.IsDefined(Motorcycle.eLicenseType, i_LicenseType);

        }
        public bool IsValidEngineCapacity(string i_EngineCapacity)
        {
            bool valid = true;
            foreach(char ch in i_EngineCapacity)
            {
                if(ch > 57 && ch < 48)
                {
                    valid = false;
                }
            }

            return valid;
        }
    }
}

