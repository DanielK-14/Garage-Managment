using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleDetails> m_VehicleDetailsList;

        public Garage()
        {
            m_VehicleDetailsList = new Dictionary<string, VehicleDetails>();
        }

        internal static string GetEnumOptions(Type i_EnumType)
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

        public List<string> GetAllInformationRequiredForThisTypeOfVehicle(string i_LicenseNumber)
        {
            List<string> requiredInfo;
            Vehicle vehicle = m_VehicleDetailsList[i_LicenseNumber].Vehicle;
            requiredInfo = vehicle.RequiredInfoForCreation();
            return requiredInfo;
        }

        private void addVehicleToGarage(string i_LicenseNumber, object i_Vehicle, string i_OwnerName, string i_PhoneNumber)
        {
            Vehicle vehicle = i_Vehicle as Vehicle;
            VehicleDetails vehicleDetails = new VehicleDetails(vehicle, i_OwnerName, i_PhoneNumber);
            m_VehicleDetailsList.Add(i_LicenseNumber, vehicleDetails);
        }

        public string GetVehiclesPossibleStatusesInGarage()
        {
            string statuses = GetEnumOptions(typeof(VehicleDetails.eVehicleStatus));
            return statuses;
        }

        public void CheckInputForCreation(string i_UserInput, int i_RequestNumber, string i_LicenseNumber)
        {
            Vehicle vehicle = m_VehicleDetailsList[i_LicenseNumber].Vehicle;
            vehicle.CheckInputedValues(i_UserInput, i_RequestNumber);
        }

        public void CreateNewVehicle(string i_VehicleTypeNumber, string i_LicenseNumber, string i_OwnerName, string i_PhoneNumber)
        {
            Vehicle vehicle = VehicleCreator.CreateVehicle(i_VehicleTypeNumber, i_LicenseNumber);
            addVehicleToGarage(i_LicenseNumber, vehicle, i_OwnerName, i_PhoneNumber);
        }

        public void CheckOwnerName(string i_OwnerName)
        {
            if (i_OwnerName == string.Empty || i_OwnerName.StartsWith(" ") == true)
            {
                throw new ArgumentException("Name entered is not valid");
            }
        }

        public void CheckPhone(string i_PhoneNumber)
        {
            if (i_PhoneNumber == string.Empty || i_PhoneNumber.StartsWith(" ") == true)
            {
                throw new ArgumentException("Phone number entered is not valid");
            }

            foreach (var digit in i_PhoneNumber)
            {
                if (char.IsDigit(digit) == false)
                {
                    throw new ArgumentException("Phone number entered is not valid");
                }
            }
        }

        public List<string> GetLicenseNumbersInStatus(string i_UserInput)
        {
            VehicleDetails.eVehicleStatus status = (VehicleDetails.eVehicleStatus)int.Parse(i_UserInput);
            List<string> matchingLicenseNumbers = new List<string>();
            foreach (var item in m_VehicleDetailsList)
            {
                if (item.Value.Status == status)
                {
                    matchingLicenseNumbers.Add(item.Key);
                }
            }

            return matchingLicenseNumbers;
        }

        public void CheckLicenseNumberInGarage(string i_LicenseNumber)
        {
            CheckIfLicenseIsValid(i_LicenseNumber);
            if (m_VehicleDetailsList.ContainsKey(i_LicenseNumber) == false)
            {
                throw new ArgumentException("License number not found in the garage");
            }
        }

        public void CheckInputedStatus(string i_UserInput)
        {
            if (Enum.IsDefined(typeof(VehicleDetails.eVehicleStatus), int.Parse(i_UserInput)) == false)
            {
                throw new ArgumentException("Status picked not valid");
            }
        }

        public string GetFuelTypes()
        {
            string fuelTypes = GetEnumOptions(typeof(FuelEngine.eFuelType));
            return fuelTypes;
        }

        public void CheckIfFuelTypeIsValid(string i_FuelType)
        {
            if (Enum.IsDefined(typeof(FuelEngine.eFuelType), int.Parse(i_FuelType)) == false)
            {
                throw new ArgumentException("Fuel type picked is not valid");
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, string i_AmountToCharge)
        {
            Vehicle vehicle;
            vehicle = m_VehicleDetailsList[i_LicenseNumber].Vehicle;
            checkVehicleIsElectricType(vehicle);
            ElectricEngine engine = vehicle.VehicleEngine as ElectricEngine;
            engine.ReCharge(float.Parse(i_AmountToCharge));
        }

        public bool IfLicenseNumberExsitsChangeStatusInRepair(string i_LicenseNumber)
        {
            bool result = m_VehicleDetailsList.ContainsKey(i_LicenseNumber);
            if(result == true)
            {
                m_VehicleDetailsList[i_LicenseNumber].Status = VehicleDetails.eVehicleStatus.InRepair;
            }

            return result;
        }

        public void CheckIfLicenseIsValid(string i_LicenseNumber)
        {
            if(i_LicenseNumber == string.Empty || i_LicenseNumber.StartsWith(" ") == true)
            {
                throw new FormatException("Entered license number is invalid");
            }
        }

        public void ValidVehicleType(string i_UserInput)
        {
            if (Enum.IsDefined(typeof(VehicleCreator.eVehicleType), (VehicleCreator.eVehicleType)int.Parse(i_UserInput)) == false)
            {
                throw new ArgumentException("Picked vehicle type is invalid");
            }
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_Status)
        {
            VehicleDetails.eVehicleStatus status = (VehicleDetails.eVehicleStatus)int.Parse(i_Status);
            m_VehicleDetailsList[i_LicenseNumber].Status = status;
        }

        public void FillAirInVehicleWheelsToMax(string i_LicenseNumber)
        {
            m_VehicleDetailsList[i_LicenseNumber].Vehicle.SetAllWheelsAirPressureToMax();
        }

        public void RefuelVehicle(string i_LicenseNumber, string i_FuelType, string i_Amount)
        {
            Vehicle vehicle;
            vehicle = m_VehicleDetailsList[i_LicenseNumber].Vehicle;
            FuelEngine engine = vehicle.VehicleEngine as FuelEngine;
            engine.Refuel(float.Parse(i_Amount), (FuelEngine.eFuelType)int.Parse(i_FuelType));
        }

        public string VehiclesMaxAndCurrentSourceCapacity(string i_LicenseNumber)
        {
            float currentEnergyAmount, maxEnergyAmount;
            currentEnergyAmount = m_VehicleDetailsList[i_LicenseNumber].Vehicle.VehicleEngine.Remaining;
            maxEnergyAmount = m_VehicleDetailsList[i_LicenseNumber].Vehicle.VehicleEngine.MaximumCapacity;

            string info = string.Format("| Current amount: {0} | Maximum capacity: {1} |", currentEnergyAmount, maxEnergyAmount);
            return info;
        }

        public void CheckLicenseNumberForRefuel(string i_LicenseNumber)
        {
            CheckLicenseNumberInGarage(i_LicenseNumber);
            checkVehicleIsFuelType(m_VehicleDetailsList[i_LicenseNumber].Vehicle);
        }

        public void CheckLicenseNumberForRecharge(string i_LicenseNumber)
        {
            CheckLicenseNumberInGarage(i_LicenseNumber);
            checkVehicleIsElectricType(m_VehicleDetailsList[i_LicenseNumber].Vehicle);
        }

        private void checkVehicleIsFuelType(Vehicle i_Vehicle)
        {
            if(i_Vehicle.VehicleEngine.EngineType != Engine.eEngineType.Fuel)
            {
                throw new ArgumentException("Picked vehicle is not fuel powered");
            }
        }

        private void checkVehicleIsElectricType(Vehicle i_Vehicle)
        {
            if (i_Vehicle.VehicleEngine.EngineType != Engine.eEngineType.Electric)
            {
                throw new ArgumentException("Picked vehicle is not electric powered");
            }
        }

        public StringBuilder GetVehicleInfo(string i_LicenseNumber)
        {
            Vehicle vehicle = m_VehicleDetailsList[i_LicenseNumber].Vehicle;
            string owner = m_VehicleDetailsList[i_LicenseNumber].OwnerName;
            string phone = m_VehicleDetailsList[i_LicenseNumber].PhoneNumber;
            StringBuilder info;

            if(vehicle is Car)
            {
                info = (vehicle as Car).ShowInfo();
            }
            else if(vehicle is Motorcycle)
            {
                info = (vehicle as Motorcycle).ShowInfo();
            }
            else
            {
                info = (vehicle as Truck).ShowInfo();
            }

            info.AppendLine("Owner's name: " + owner);
            info.AppendLine("Phone number: " + phone);

            return info;
        }

        public string GetGarageVehiclesTypes()
        {
            string garageVehiclesTypesInfo;
            garageVehiclesTypesInfo = "Please choose one of the vehicles we work with in our garage:" + 
                Environment.NewLine + GetEnumOptions(typeof(VehicleCreator.eVehicleType));
            return garageVehiclesTypesInfo;
        }
    }
}