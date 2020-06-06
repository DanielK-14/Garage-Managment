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
        public bool BuildNewVehicle(int i_Vehicle, string i_Request, string i_LicenseNumber, int i_CurrectInstructions)
        {
            bool valid = false;
            if (i_CurrectInstructions < 11)
            {
                switch (i_CurrectInstructions)
                {
                    case 1:
                        valid = IsValidModelName(i_Request);
                        break;
                    case 2:
                        valid = IsValidLicenseNumber(i_Request);
                        break;
                    case 3:
                        valid = IsValidEngine(i_Request);
                        break;
                    case 4:
                        IsValidRemainingPowerAmount(i_Request, i_Vehicle);
                        break;
                    case 5:
                        valid = IsValidMaximumPowerAmount(i_Request, i_Vehicle);
                        break;
                    case 6:
                        valid = IsValidFuelType(i_Request, i_Vehicle);
                        break;
                    case 7:
                        valid = IsValidWheelsManufacturerName(i_Request);
                        break;
                    case 8:
                        valid = IsValidWheelsAirPressure(i_Request, i_Vehicle);
                        break;
                    case 9:
                        IsValidMaximumAirPressure(i_Request, i_Vehicle);
                        break;
                    case 10:
                        IsValidWheelsAmount(i_Request, i_Vehicle);
                        break;
                }
            }
            else
            {
                switch (i_Vehicle)
                {
                    case 1:
                        valid = BuildNewMotorcycle(i_Request, i_CurrectInstructions - 10);
                        break;
                    case 2:
                        valid = BuildNewCar(i_Request, i_CurrectInstructions - 10);
                        break;
                    case 3:
                        valid = BuildNewTruck(i_Request, i_CurrectInstructions - 10);
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
        public bool IsValidEngine(string i_Engine)
        {
            return Enum.IsDefined(typeof(Engine.eEngineType), i_Engine);
        }
        public bool IsValidRemainingPowerAmount(string i_RemainingPowerAmount, int i_VehicleTypre)
        {
            bool valid = false;
            int remainingPowerAmount;
            valid = int.TryParse(i_RemainingPowerAmount, out remainingPowerAmount);
            if (valid == true)
            {
                switch (i_VehicleTypre)
                {
                    case 1:
                        if (remainingPowerAmount < 8 && remainingPowerAmount > 0)
                        {
                            valid = true;
                        }
                        break;
                    case 2:
                        if (remainingPowerAmount < 61 && remainingPowerAmount > 0)
                        {
                            valid = true;
                        }
                        break;
                    case 3:
                        if (remainingPowerAmount < 121 && remainingPowerAmount > 0)
                        {
                            valid = true;
                        }
                        break;
                }
            }

            return valid;
        }
        
        public bool IsValidMaximumPowerAmount(string i_MaximumPowerAmount, int i_VehicleTypre)
        {
            bool valid = false;
            int maximumPowerAmount;
            valid = int.TryParse(i_MaximumPowerAmount, out maximumPowerAmount);
            if (valid == true)
            {
                switch(i_VehicleTypre)
                {
                    case 1:
                        if(maximumPowerAmount == 7)
                        {
                            valid = true;
                        }
                        break;
                    case 2:
                        if (maximumPowerAmount == 60)
                        {
                            valid = true;
                        }
                        break;
                    case 3:
                        if (maximumPowerAmount == 120)
                        {
                            valid = true;
                        }
                        break;
                }
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

        public bool IsValidWheelsAirPressure(string i_WheelsAirPressure, int i_VehicleType)
        {
            bool valid = false;
            switch (i_VehicleType)
            {
                case 1:
                    valid = IsValidMotorcycleWheelsAmount(i_WheelsAirPressure);
                    break;
                case 2:
                    valid = IsValidCarWheelsAmount(i_WheelsAirPressure);
                    break;
                case 3:
                    valid = IsValidTruckWheelsAmount(i_WheelsAirPressure);
                    break;
            }

            return valid;
        }
        public bool IsValidMaximumAirPressure(string i_MaximumAirPressure, int i_VehicleType)
        {
            bool valid = false;
            switch (i_VehicleType)
            {
                case 1:
                    valid = IsValidMotorcycleMaximumAirPressure(i_MaximumAirPressure);
                    break;
                case 2:
                    valid = IsValidCarMaximumAirPressure(i_MaximumAirPressure);
                    break;
                case 3:
                    valid = IsValidTruckMaximumAirPressure(i_MaximumAirPressure);
                    break;
            }

            return valid;
        }
        public bool IsValidWheelsAmount(string i_WheelsAmount, int i_VehicleType)
        {
            bool valid = false;
            switch(i_VehicleType)
            {
                case 1:
                    valid = IsValidMotorcycleWheelsAmount(i_WheelsAmount);
                    break;
                case 2:
                    valid = IsValidCarWheelsAmount(i_WheelsAmount);
                    break;
                case 3:
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
            bool valid = false;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if(valid != true || wheelsAmount != 2)
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
            bool valid = false;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if (valid != true || wheelsAmount != 16)
            {
                valid = false;
            }

            return valid;
        }
        public bool IsValidMotorcycleMaximumAirPressure(string i_WheelsAmount)
        {
            bool valid = false;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if (valid != true || wheelsAmount != 30)
            {
                valid = false;
            }

            return valid;
        }
        public bool IsValidCarMaximumAirPressure(string i_WheelsAmount)
        {
            bool valid = false;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if (valid != true || wheelsAmount != 32)
            {
                valid = false;
            }

            return valid;
        }
        public bool IsValidTruckMaximumAirPressure(string i_WheelsAmount)
        {
            bool valid = false;
            int wheelsAmount;
            valid = int.TryParse(i_WheelsAmount, out wheelsAmount);
            if (valid != true || wheelsAmount != 28)
            {
                valid = false;
            }

            return valid;
        }
        public void MakeVehicleAndPlaceInGarage(List<string> i_BuildInstructions, int i_Vehicle)
        {
            bool valid = false;
            int type, color, doors;
            
            switch(i_Vehicle)
            {
                case 1:
                        Int32.TryParse(i_BuildInstructions[10], out type);
                        Motorcycle motorecycle = new Motorcycle(i_BuildInstructions[0], i_BuildInstructions[1], (Engine.eEngineType)Int32.Parse(i_BuildInstructions[2]), i_BuildInstructions[3], float.Parse(i_BuildInstructions[4]), float.Parse(i_BuildInstructions[5]), i_BuildInstructions[6], float.Parse(i_BuildInstructions[7]), float.Parse(i_BuildInstructions[8]), Int32.Parse(i_BuildInstructions[9]), (Motorcycle.eLicenseType)type, Int32.Parse(i_BuildInstructions[11]));
                        m_VehicleList.Add(motorecycle);
                    break;
                case 2:
                        Int32.TryParse(i_BuildInstructions[10], out color);
                        Int32.TryParse(i_BuildInstructions[11], out doors);
                        Car car = new Car(i_BuildInstructions[0], i_BuildInstructions[1], (Engine.eEngineType)Int32.Parse(i_BuildInstructions[2]), i_BuildInstructions[3], float.Parse(i_BuildInstructions[4]), float.Parse(i_BuildInstructions[5]), i_BuildInstructions[6], float.Parse(i_BuildInstructions[7]), float.Parse(i_BuildInstructions[8]), Int32.Parse(i_BuildInstructions[9]), (Car.eCarColor)color, (Car.eDoorsAmount)doors);
                        m_VehicleList.Add(car);
                    break;
                case 3:
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
    }
}

