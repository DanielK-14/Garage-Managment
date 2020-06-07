using System;
using System.Collections.Generic;

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

        public Garage()
        {
            m_VehicleList = new List<Vehicle>();
        }

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
            eVehicleType vehicleType = (eVehicleType)int.Parse(i_VehicleChosen);
            List<string> requiredInfo;

            switch (vehicleType)
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

        public bool BuildNewVehicle(int i_VehicleType, string i_UserInput, int io_CurrectInstructions,
            ref bool io_IsFuelEngine, ref float i_MaximumPowerCapacity, ref float io_MaximumAirPresure)
        {
            bool valid = false;
            if (io_CurrectInstructions < 10)
            {
                switch (io_CurrectInstructions)
                {
                    case 1:
                        valid = IsValidModelName(i_UserInput);
                        break;
                    case 2:
                        valid = IsValidEngine(i_UserInput, ref io_IsFuelEngine);
                        break;
                    case 3:
                        valid = IsValidMaximumPowerAmount(i_UserInput, i_VehicleType, ref i_MaximumPowerCapacity);
                        break;
                    case 4:
                        valid = IsValidRemainingPowerAmount(i_UserInput, i_VehicleType, i_MaximumPowerCapacity);
                        break;
                    case 5:
                        valid = IsValidFuelType(i_UserInput, i_VehicleType);
                        break;
                    case 6:
                        valid = IsValidWheelsManufacturerName(i_UserInput);
                        break;
                    case 7:
                        valid = IsValidMaximumAirPressure(i_UserInput);
                        break;
                    case 8:
                        valid = IsValidWheelsAirPressure(i_UserInput, ref io_MaximumAirPresure);
                        break;
                    case 9:
                        valid = IsValidWheelsAmount(i_UserInput, i_VehicleType);
                        break;
                }
            }
            else
            {
                switch ((eVehicleType)i_VehicleType)
                {
                    case eVehicleType.Motorcycle:
                        valid = BuildNewMotorcycle(i_UserInput, io_CurrectInstructions - 9);
                        break;
                    case eVehicleType.Car:
                        valid = BuildNewCar(i_UserInput, io_CurrectInstructions - 9);
                        break;
                    case eVehicleType.Truck:
                        valid = BuildNewTruck(i_UserInput, io_CurrectInstructions - 9);
                        break;
                }
            }

            return valid;
        }

        public bool BuildNewMotorcycle(string i_Request, int i_CurrectInstructions)
        {
            bool valid = false;
            switch (i_CurrectInstructions)
            {
                case 1:
                    valid = IsValidLicenseType(i_Request);
                    break;
                case 2:
                    valid = IsValidEngineCapacity(i_Request);
                    break;
                default:

                    break;
            }
            return valid;
        }

        public bool BuildNewCar(string i_Request, int i_CurrectInstructions)
        {
            bool valid = false;
            switch (i_CurrectInstructions)
            {
                case 1:
                    valid = IsValidCarColor(i_Request);
                    break;
                case 2:
                    valid = IsValidDoorsAmount(i_Request);
                    break;
                default:

                    break;
            }
            return valid;
        }

        public bool BuildNewTruck(string i_Request, int i_CurrectInstructions)
        {
            bool valid = false;
            switch (i_CurrectInstructions)
            {
                case 1:
                    valid = IsValidDangerousGoods(i_Request);
                    break;
                case 2:
                    valid = IsValidCargoCapacity(i_Request);
                    break;
                default:

                    break;
            }
            return valid;
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

        public List<string> ChooseVehicleType(int i_UserInput, out int io_MaxInstructions)
        {
            List<string> result;

            switch (i_UserInput)
            {
                case 1:
                    result = Motorcycle.RequiredInfoForCreation();
                    io_MaxInstructions = 12;
                    break;
                case 2:
                    result = Car.RequiredInfoForCreation();
                    io_MaxInstructions = 12;
                    break;
                case 3:
                    result = Truck.RequiredInfoForCreation();
                    io_MaxInstructions = 12;
                    break;
                default:
                    result = null;
                    io_MaxInstructions = 0;
                    break;
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

        public bool IsValidModelName(string i_ModelName)
        {
            return true;
        }

        public bool IsValidLicenseNumber(string i_LicenseNumber)
        {
            return true;
        }

        public bool IsValidEngine(string i_Engine, ref bool io_IsFuelEngine)
        {
            int engineTypeNumber;
            bool result = false;

            if(Int32.TryParse(i_Engine, out engineTypeNumber) == true)
            {
                Engine.eEngineType engineType = (Engine.eEngineType)engineTypeNumber;
                result = Enum.IsDefined(typeof(Engine.eEngineType), engineType);
                if(engineType == Engine.eEngineType.Fuel)
                {
                    io_IsFuelEngine = true;
                }
            }

            return result;
        }

        public bool IsValidRemainingPowerAmount(string i_RemainingPowerAmount, int i_VehicleType, float i_MaximumPowerCapacity)
        {
            bool valid;
            eVehicleType vehicleType = (eVehicleType)i_VehicleType;
            float remainingPowerAmount;
            valid = float.TryParse(i_RemainingPowerAmount, out remainingPowerAmount);
            if (valid == true && (remainingPowerAmount < 0 || remainingPowerAmount > i_MaximumPowerCapacity))
            {
                valid = false;
            }

            return valid;
        }

        public void ChangeStatuesToInRepair(string i_License)
        {
            foreach(Vehicle vehicle in m_VehicleList)
            {
                if(vehicle.LicenseNumber == i_License)
                {
                    vehicle.Status = (Vehicle.eVehicleStatus)1;
                }
            }
        }

        public bool IsValidMaximumPowerAmount(string i_MaximumPowerAmount, int i_VehicleTypre, ref float i_MaximumPowerCapacity)
        {
            bool valid;
            float maximumPowerAmount;
            valid = float.TryParse(i_MaximumPowerAmount, out maximumPowerAmount);
            if (valid == true && maximumPowerAmount <= 0)
            {
                valid = false;
            }
            else
            {
                i_MaximumPowerCapacity = maximumPowerAmount;
            }

            return valid;
        }

        public bool IsValidFuelType(string i_Request, int i_Vehicle)
        {
            bool valid = false;
            if (Enum.IsDefined(typeof(FuelEngine.eFuelType), i_Request) == true)
            {
                valid = true;
            }
            else
            {
                if(i_Request == "none")
                {
                    valid = true;
                }
            }

            return valid;
        }

        public bool IsValidWheelsManufacturerName(string i_WheelsManufaturerName)
        {
            return true;
        }

        public bool IsValidWheelsAirPressure(string i_WheelsAirPressure, ref float io_MaximumAirPressure)
        {
            bool valid;
            float currentAirPressure;
            valid = float.TryParse(i_WheelsAirPressure, out currentAirPressure);
            if (valid == true && (currentAirPressure < 0 || currentAirPressure > io_MaximumAirPressure))
            {
                valid = false;
            }

            return valid;
        }

        public bool IsValidMaximumAirPressure(string i_MaximumAirPressure)
        {
            bool valid;
            float maxAirPressure;
            valid = float.TryParse(i_MaximumAirPressure, out maxAirPressure);
            if(valid == true && maxAirPressure <= 0)
            {
                valid = false;
            }

            return valid;
        }

        public bool IsValidWheelsAmount(string i_WheelsAmount, int i_VehicleType)
        {
            bool valid = false;
            eVehicleType vehicleType = (eVehicleType)i_VehicleType;
            switch(vehicleType)
            {
                case eVehicleType.Motorcycle:
                    valid = IsValidMotorcycleWheelsAmount(i_WheelsAmount);
                    break;
                case eVehicleType.Car:
                    valid = IsValidCarWheelsAmount(i_WheelsAmount);
                    break;
                case eVehicleType.Truck:
                    valid = IsValidTruckWheelsAmount(i_WheelsAmount);
                    break;
            }

            return valid;
        }

        public bool IsValidCarColor(string i_CarColor)
        {
            return Enum.IsDefined(typeof(Car.eCarColor), i_CarColor);
        }

        public bool IsValidDoorsAmount(string i_CarDoorsAmount)
        {
            return Enum.IsDefined(typeof(Car.eDoorsAmount), i_CarDoorsAmount);

        }

        public bool IsValidDangerousGoods(string i_DangerousGoods)
        {
            bool valid = false;
            if(i_DangerousGoods == "true" ||i_DangerousGoods == "false")
            {
                valid = true;
            }

            return valid;
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
            return Enum.IsDefined(typeof(Motorcycle.eLicenseType), i_LicenseType);
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

        public bool ValidVehicleType(string i_UserInput, out int io_Vehicle)
        {
            bool valid = false;
            if(Int32.TryParse(i_UserInput, out io_Vehicle) == true)
            {
                if(io_Vehicle > 0 && io_Vehicle < 4)
                {
                    valid = true;
                }
            }

            return valid;
        }

        public bool IsInGarage(string i_License)
        {
            bool exist = false;
            foreach(Vehicle vehicle in m_VehicleList)
            {
                if(vehicle.LicenseNumber == i_License) /// to do equel func
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }

        public bool IsValidMotorcycleWheelsAmount(string i_WheelsAmount)
        {
            bool valid;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if(valid != true || (wheelsAmount != 2 && wheelsAmount != 3))
            {
                valid = false;
            }

            return valid;
        }

        public bool IsValidCarWheelsAmount(string i_WheelsAmount)
        {
            bool valid = false;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if (valid != true || wheelsAmount != 4)
            {
                valid = false;
            }

            return valid;
        }

        public bool IsValidTruckWheelsAmount(string i_WheelsAmount)
        {
            bool valid;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if (valid != true || wheelsAmount < 16)
            {
                valid = false;
            }

            return valid;
        }

        public void MakeVehicleAndPlaceInGarage(List<string> i_BuildInstructions, int i_Vehicle)
        {
            bool valid = false;
            int type, color, doors;
            eVehicleType vehicleType = (eVehicleType)i_Vehicle;
            
            switch(vehicleType)
            {
                case eVehicleType.Motorcycle:
                        Int32.TryParse(i_BuildInstructions[10], out type);
                        Motorcycle motorecycle = new Motorcycle(i_BuildInstructions[0], i_BuildInstructions[1], (Engine.eEngineType)Int32.Parse(i_BuildInstructions[2]), i_BuildInstructions[3], float.Parse(i_BuildInstructions[4]), float.Parse(i_BuildInstructions[5]), i_BuildInstructions[6], float.Parse(i_BuildInstructions[7]), float.Parse(i_BuildInstructions[8]), Int32.Parse(i_BuildInstructions[9]), (Motorcycle.eLicenseType)type, Int32.Parse(i_BuildInstructions[11]));
                        m_VehicleList.Add(motorecycle);
                    break;
                case eVehicleType.Car:
                        Int32.TryParse(i_BuildInstructions[10], out color);
                        Int32.TryParse(i_BuildInstructions[11], out doors);
                        Car car = new Car(i_BuildInstructions[0], i_BuildInstructions[1], (Engine.eEngineType)Int32.Parse(i_BuildInstructions[2]), i_BuildInstructions[3], float.Parse(i_BuildInstructions[4]), float.Parse(i_BuildInstructions[5]), i_BuildInstructions[6], float.Parse(i_BuildInstructions[7]), float.Parse(i_BuildInstructions[8]), Int32.Parse(i_BuildInstructions[9]), (Car.eCarColor)color, (Car.eDoorsAmount)doors);
                        m_VehicleList.Add(car);
                    break;
                case eVehicleType.Truck:
                    if(i_BuildInstructions[10] == "true")
                    {
                        valid = true;
                    }
                    Truck truck = new Truck(i_BuildInstructions[0], i_BuildInstructions[1], (Engine.eEngineType)Int32.Parse(i_BuildInstructions[2]), i_BuildInstructions[3], float.Parse(i_BuildInstructions[5]), float.Parse(i_BuildInstructions[5]), i_BuildInstructions[6], float.Parse(i_BuildInstructions[7]), float.Parse(i_BuildInstructions[8]), Int32.Parse(i_BuildInstructions[9]), valid, float.Parse(i_BuildInstructions[11]));
                    m_VehicleList.Add(truck);
                    break;
            }
        }
        public List<string> ShowVehiclesInSituation(int i_CarSituation)
        {
            List<string> licensesList= new List<string>();

            if(i_CarSituation == 4)
            {
                foreach (Vehicle vehicle in m_VehicleList)
                {
                    licensesList.Add(vehicle.LicenseNumber);
                }
            }
            else
            {
                Vehicle.eVehicleStatus status = (Vehicle.eVehicleStatus)i_CarSituation;
                foreach (Vehicle vehicle in m_VehicleList)
                {
                    if (vehicle.Status == status)
                    {
                        licensesList.Add(vehicle.LicenseNumber);
                    }
                }
            }

            return licensesList;
        }
        public void ChangeCarSituation(string i_LicenseNumber, int i_Situation)
        {
            if(IsInGarage(i_LicenseNumber) == true)
            {
                foreach(Vehicle vehicle in m_VehicleList)
                {
                    if(vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        vehicle.Status = (Vehicle.eVehicleStatus)i_Situation;
                        break;
                    }
                }
            }
            else
            {
                ///exception
            }
        }
        public bool FillAirInVehicle(string i_LicenseNumber)
        {
            bool valid = false;
            if(IsInGarage(i_LicenseNumber) == true)
            {
                foreach (Vehicle vehicle in m_VehicleList)
                {
                    if (vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        foreach(Vehicle.Wheel wheel in vehicle.Wheels)
                        {
                            wheel.AddAirTillMaxPressure();
                        }
                        valid = true;
                        break;
                    }
                }
            }
            else
            {
                ///exception
            }

            return valid;
        }
        public bool FillUpTank(string i_LicenseNumber, int i_FuelType, string i_Amount)
        {
            int fuel;
            bool valid = false;
            if (IsInGarage(i_LicenseNumber) == true)
            {
                foreach (Vehicle vehicle in m_VehicleList)
                {
                    if (vehicle.LicenseNumber == i_LicenseNumber && vehicle.FuelEnergy != null)
                    {
                        if(Int32.TryParse(i_Amount, out fuel) == true)
                        {
                            vehicle.FillEngineSourceUnit(2, fuel, i_FuelType);
                            valid = true;
                            break;
                        }
                        
                    }
                }
            }
            else
            {
                ///exception
            }

            return valid;
        }
        public bool ChargeBattery(string i_LicenseNumber, int i_MinutesToAdd)
        {
            bool valid = false;
            if (IsInGarage(i_LicenseNumber) == true)
            {
                foreach(Vehicle vehicle in m_VehicleList)
                {
                    if(vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        if(vehicle.FuelEnergy.EngineType == (Engine.eEngineType)1)
                        {
                            valid = vehicle.ElectricEnergy.ReCharge(i_MinutesToAdd); 
                        }
                    }
                }
            }

            return valid;
        }
        public bool ShowVehicleInfo(string i_LicenseNumber)
        {
            bool valid = false;
            if(IsInGarage(i_LicenseNumber))
            {
                foreach(Vehicle vehicle in m_VehicleList)
                {
                    if(vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        vehicle.ShowInfo();
                        valid = true;
                        break;
                    }
                }
            }

            return valid;
        }

        public string GetGarageVehiclesTypes()
        {
            string garageVehiclesTypesInfo = string.Empty;
            garageVehiclesTypesInfo = "Please choose one of the vehicles we work with in our garage:\n" + GetEnumOptions(typeof(eVehicleType));
            return garageVehiclesTypesInfo;
        }
    }
}

