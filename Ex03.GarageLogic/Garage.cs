using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, VehicleDetails> m_VehicleDetailsList;

        public Garage()
        {
            m_VehicleDetailsList = new Dictionary<string, VehicleDetails>();
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

        public void CheckInputForCreation(string userInput, int requestNumber, string i_VehicleType, object vehicle)
        {
            if (requestNumber < 5)
            {
                checkVehicleInputedValues(userInput, requestNumber, vehicle as Vehicle);
            }
            else
            {
                VehicleCreator.eVehicleType vehicleType = (VehicleCreator.eVehicleType)int.Parse(i_VehicleType);
                switch (vehicleType)
                {
                    case VehicleCreator.eVehicleType.ElectricCar:
                        checkCarInputedValues(userInput, requestNumber, vehicle as Car);
                        break;
                    case VehicleCreator.eVehicleType.ElectricMotorcycle:
                        checkMotorcycleInputedValues(userInput, requestNumber, vehicle as Motorcycle);
                        break;
                    case VehicleCreator.eVehicleType.FuelCar:
                        checkCarInputedValues(userInput, requestNumber, vehicle as Car);
                        break;
                    case VehicleCreator.eVehicleType.FuelMotorcycle:
                        checkMotorcycleInputedValues(userInput, requestNumber, vehicle as Motorcycle);
                        break;
                    case VehicleCreator.eVehicleType.Truck:
                        checkTruckInputedValues(userInput, requestNumber, vehicle as Truck);
                        break;
                    default:
                        throw new FormatException();
                }
            }
        }

        private void checkVehicleInputedValues(string userInput, int requestNumber, Vehicle i_Car)
        {
            switch (requestNumber)
            {
                case 1:
                    i_Car.ModelName = userInput;
                    break;
                case 2:
                    i_Car.VehicleEngine.Remaining = float.Parse(userInput);
                    break;
                case 3:
                    i_Car.SetAllWheelsManufacturerName(userInput);
                    break;
                case 4:
                    i_Car.SetAllWheelsAirPressure(float.Parse(userInput));
                    break;
            }
        }

        private void checkCarInputedValues(string userInput, int requestNumber, Car i_Car)
        {
            switch (requestNumber)
            {
                case 5:
                    i_Car.CarColor = (Car.eCarColor)int.Parse(userInput);
                break;

                case 6:
                    i_Car.DoorsAmount = (Car.eDoorsAmount)int.Parse(userInput);
                break;
            }
        }

        private void checkMotorcycleInputedValues(string userInput, int requestNumber, Motorcycle i_Motor)
        {
            switch (requestNumber)
            {
                case 5:
                    i_Motor.LicenseType = (Motorcycle.eLicenseType)int.Parse(userInput);
                    break;

                case 6:
                    i_Motor.EngineCapacity = int.Parse(userInput);
                    break;
            }
        }

        private void checkTruckInputedValues(string userInput, int requestNumber, Truck i_Truck)
        {
            switch (requestNumber)
            {
                case 5:
                    if(userInput.ToLower() == "yes")
                    {
                        i_Truck.CarryingDangerousGoods = true;
                    }
                    else if(userInput.ToLower() == "no")
                    {
                        i_Truck.CarryingDangerousGoods = false;
                    }
                    else
                    {
                        throw new ArgumentException("Wrong answer entered");
                    }
                    break;

                case 6:
                    i_Truck.CargoCapacity = float.Parse(userInput);
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
                if (Char.IsDigit(digit) == false)
                {
                    throw new ArgumentException("Phone number entered is not valid");
                }
            }
        }

        public List<string> GetLicenseNumbersInStatus(string userInput)
        {
            VehicleDetails.eVehicleStatus status = (VehicleDetails.eVehicleStatus)int.Parse(userInput);
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

        public void CheckInputedStatus(string userInput)
        {
            if (Enum.IsDefined(typeof(VehicleDetails.eVehicleStatus), int.Parse(userInput)) == false)
            {
                throw new ArgumentException("Status picked not valid");
            }
        }

        public string GetFuelTypes()
        {
            string fuelTypes = GetEnumOptions(typeof(FuelEngine.eFuelType));
            return fuelTypes;
        }

        public void CheckIfFuelTypeIsValid(string fuelType)
        {
            if (Enum.IsDefined(typeof(FuelEngine.eFuelType), int.Parse(fuelType)) == false)
            {
                throw new ArgumentException("Fuel type picked is not valid");
            }
        }

        public void ChargeVehicle(string licenseNumber, string amountToCharge)
        {
            Vehicle vehicle;
            vehicle = m_VehicleDetailsList[licenseNumber].Vehicle;
            checkVehicleIsElectricType(vehicle);
            ElectricEngine engine = vehicle.VehicleEngine as ElectricEngine;
            engine.ReCharge(float.Parse(amountToCharge));
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

        public void CheckLicenseNumberForRefuel(string licenseNumber)
        {
            CheckLicenseNumberInGarage(licenseNumber);
            checkVehicleIsFuelType(m_VehicleDetailsList[licenseNumber].Vehicle);
        }

        public void CheckLicenseNumberForRecharge(string licenseNumber)
        {
            CheckLicenseNumberInGarage(licenseNumber);
            checkVehicleIsElectricType(m_VehicleDetailsList[licenseNumber].Vehicle);
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

