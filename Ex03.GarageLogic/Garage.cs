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

        public List<string> GetAllInformationRequiredForThisTypeOfVehicle(string i_VehicleType, object i_Vehicle)
        {
            VehicleCreator.eVehicleType vehicleType = (VehicleCreator.eVehicleType)int.Parse(i_VehicleType);
            List<string> requiredInfo;

            switch (vehicleType)
            {
                case VehicleCreator.eVehicleType.ElectricMotorcycle:
                    ElectricMotorcycle electricMotor = i_Vehicle as ElectricMotorcycle;
                    requiredInfo = electricMotor.RequiredInfoForCreation();
                    break;

                case VehicleCreator.eVehicleType.ElectricCar:
                    ElectricCar electricCar = i_Vehicle as ElectricCar;
                    requiredInfo = electricCar.RequiredInfoForCreation();
                    break;

                case VehicleCreator.eVehicleType.FuelCar:
                    FuelCar fuelCar = i_Vehicle as FuelCar;
                    requiredInfo = fuelCar.RequiredInfoForCreation();
                    break;

                case VehicleCreator.eVehicleType.FuelMotorcycle:
                    FuelMotorcycle fuelMotor = i_Vehicle as FuelMotorcycle;
                    requiredInfo = fuelMotor.RequiredInfoForCreation();
                    break;

                case VehicleCreator.eVehicleType.Truck:
                    Truck truck = i_Vehicle as Truck;
                    requiredInfo = truck.RequiredInfoForCreation();
                    break;

                default:
                    throw new FormatException();
            }

            return requiredInfo;
        }

        public void AddVehicleToGarage(string i_LicenseNumber, object i_Vehicle, string i_OwnerName, string i_PhoneNumber)
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

        public void CheckInputForCreation(string i_UserInput, int i_RequestNumber, string i_VehicleType, object i_Vehicle)
        {
            if (i_RequestNumber < 5)
            {
                checkVehicleInputedValues(i_UserInput, i_RequestNumber, i_Vehicle as Vehicle);
            }
            else
            {
                VehicleCreator.eVehicleType vehicleType = (VehicleCreator.eVehicleType)int.Parse(i_VehicleType);
                switch (vehicleType)
                {
                    case VehicleCreator.eVehicleType.ElectricCar:
                        checkCarInputedValues(i_UserInput, i_RequestNumber, i_Vehicle as Car);
                        break;
                    case VehicleCreator.eVehicleType.ElectricMotorcycle:
                        checkMotorcycleInputedValues(i_UserInput, i_RequestNumber, i_Vehicle as Motorcycle);
                        break;
                    case VehicleCreator.eVehicleType.FuelCar:
                        checkCarInputedValues(i_UserInput, i_RequestNumber, i_Vehicle as Car);
                        break;
                    case VehicleCreator.eVehicleType.FuelMotorcycle:
                        checkMotorcycleInputedValues(i_UserInput, i_RequestNumber, i_Vehicle as Motorcycle);
                        break;
                    case VehicleCreator.eVehicleType.Truck:
                        checkTruckInputedValues(i_UserInput, i_RequestNumber, i_Vehicle as Truck);
                        break;
                    default:
                        throw new FormatException();
                }
            }
        }

        private void checkVehicleInputedValues(string i_UserInput, int i_RequestNumber, Vehicle i_Car)
        {
            switch (i_RequestNumber)
            {
                case 1:
                    i_Car.ModelName = i_UserInput;
                    break;
                case 2:
                    i_Car.VehicleEngine.Remaining = float.Parse(i_UserInput);
                    break;
                case 3:
                    i_Car.SetAllWheelsManufacturerName(i_UserInput);
                    break;
                case 4:
                    i_Car.SetAllWheelsAirPressure(float.Parse(i_UserInput));
                    break;
            }
        }

        private void checkCarInputedValues(string i_UserInput, int i_RequestNumber, Car i_Car)
        {
            switch (i_RequestNumber)
            {
                case 5:
                    i_Car.CarColor = (Car.eCarColor)int.Parse(i_UserInput);
                break;

                case 6:
                    i_Car.DoorsAmount = (Car.eDoorsAmount)int.Parse(i_UserInput);
                break;
            }
        }

        private void checkMotorcycleInputedValues(string i_UserInput, int i_RequestNumber, Motorcycle i_Motor)
        {
            switch (i_RequestNumber)
            {
                case 5:
                    i_Motor.LicenseType = (Motorcycle.eLicenseType)int.Parse(i_UserInput);
                    break;

                case 6:
                    i_Motor.EngineCapacity = int.Parse(i_UserInput);
                    break;
            }
        }

        private void checkTruckInputedValues(string i_UserInput, int i_RequestNumber, Truck i_Truck)
        {
            switch (i_RequestNumber)
            {
                case 5:
                    if(i_UserInput.ToLower() == "yes")
                    {
                        i_Truck.CarryingDangerousGoods = true;
                    }
                    else if(i_UserInput.ToLower() == "no")
                    {
                        i_Truck.CarryingDangerousGoods = false;
                    }
                    else
                    {
                        throw new ArgumentException("Wrong answer entered");
                    }

                    break;

                case 6:
                    i_Truck.CargoCapacity = float.Parse(i_UserInput);
                    break;
            }
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