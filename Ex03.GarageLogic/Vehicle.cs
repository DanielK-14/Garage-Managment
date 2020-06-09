using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string r_LicenseNumber;
        protected readonly Engine r_Engine;
        protected string m_ModelName;
        protected List<Wheel> m_Wheels;

        internal Vehicle(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
        {
            r_LicenseNumber = i_LicenseNumber;
            m_ModelName = string.Empty;
            r_Engine = i_Engine;
            m_Wheels = i_Wheels;
        }

        internal static List<Wheel> CreateWheelsForVehicle(int i_Amount, float i_MaxPressure)
        {
            List<Wheel> wheels = new List<Wheel>(i_Amount);
            for (int i = 0; i < i_Amount; i++)
            {
                wheels.Add(new Wheel(i_MaxPressure));
            }

            return wheels;
        }

        internal string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                if (value != string.Empty && value.StartsWith(" ") == false)
                {
                    m_ModelName = value;
                }
                else
                {
                    throw new ArgumentException("Name entered is not valid");
                }
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        internal Engine VehicleEngine
        {
            get
            {
                return r_Engine;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        internal abstract StringBuilder ShowInfo();

        protected virtual StringBuilder ShowInfoVehicle()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine("ModelName: " + m_ModelName);
            vehicleInfo.AppendLine("License Number: " + r_LicenseNumber);
            vehicleInfo.AppendLine("Wheels manufacturer: " + m_Wheels[1].ManufacturerName);
            vehicleInfo.AppendLine("Wheels current air: " + m_Wheels[1].CurrentAirPressure.ToString());
            vehicleInfo.AppendLine("Wheels max air pressure: " + m_Wheels[1].MaximumAirPressure.ToString());
            if (r_Engine is FuelEngine)
            {
                FuelEngine fuelEngine = r_Engine as FuelEngine;
                vehicleInfo.AppendLine("Engine type: " + Enum.GetName(typeof(Engine.eEngineType), fuelEngine.EngineType));
                vehicleInfo.AppendLine("Fuel type: " + Enum.GetName(typeof(FuelEngine.eFuelType), fuelEngine.FuelType));
                vehicleInfo.AppendLine("Remaining fuel amount: " + fuelEngine.Remaining.ToString());
                vehicleInfo.AppendLine("Maximum fuel amount: " + fuelEngine.MaximumCapacity.ToString());
            }
            else
            {
                vehicleInfo.AppendLine("Engine type: " + Enum.GetName(typeof(Engine.eEngineType), r_Engine.EngineType));
                vehicleInfo.AppendLine("Remaining battery energy hours : " + r_Engine.Remaining.ToString());
                vehicleInfo.AppendLine("Maximum battery energy in hours : " + r_Engine.MaximumCapacity.ToString());
            }

            return vehicleInfo;
        }

        internal abstract List<string> RequiredInfoForCreation();

        protected virtual List<string> RequiredInfoForCreationOfVehicle()
        {
            List<string> engineInformation;
            if (r_Engine is ElectricEngine)
            {
                ElectricEngine electricEngine = r_Engine as ElectricEngine;
                engineInformation = electricEngine.RequiredInfoForCreation();
            }
            else
            {
                FuelEngine fuelEngine = r_Engine as FuelEngine;
                engineInformation = fuelEngine.RequiredInfoForCreation();
            }

            List<string> wheelsInformation = m_Wheels[0].RequiredInfoForCreation();
            List<string> requiredInfo = new List<string>();

            requiredInfo.Add("Please enter vehicle MODEL NAME:");
            foreach (string info in engineInformation)
            {
                requiredInfo.Add(info);
            }

            foreach (string info in wheelsInformation)
            {
                requiredInfo.Add(info);
            }

            return requiredInfo;
        }

        internal abstract void CheckInputedValues(string i_UserInput, int i_RequestNumber);

        internal void CheckVehicleValuesInputted(string i_UserInput, int i_RequestNumber)
        {
            switch (i_RequestNumber)
            {
                case 1:
                    ModelName = i_UserInput;
                    break;
                case 2:
                    VehicleEngine.Remaining = float.Parse(i_UserInput);
                    break;
                case 3:
                    SetAllWheelsManufacturerName(i_UserInput);
                    break;
                case 4:
                    SetAllWheelsAirPressure(float.Parse(i_UserInput));
                    break;
            }
        }

        internal void SetAllWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach(var wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        internal void SetAllWheelsAirPressure(float i_AirPressure)
        {
            foreach (var wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }
        }

        internal void SetAllWheelsAirPressureToMax()
        {
            foreach(var wheel in m_Wheels)
            {
                wheel.AddAirTillMaxPressure();
            }
        }

        internal class Wheel
        {
            private readonly float r_MaximumAirPressure;
            private string m_ManufacturerName;
            private float? m_CurrentAirPressure;

            public Wheel(float i_MaximumAirPressure)
            {
                r_MaximumAirPressure = i_MaximumAirPressure;
            }

            public string ManufacturerName
            {
                get
                {
                    return m_ManufacturerName;
                }

                set
                {
                    if (value != string.Empty && value.StartsWith(" ") == false)
                    {
                        m_ManufacturerName = value;
                    }
                    else
                    {
                        throw new ArgumentException("Name entered is not valid");
                    }
                }
            }

            public float CurrentAirPressure
            {
                get
                {
                    if (m_CurrentAirPressure.HasValue == true)
                    {
                        return (float)m_CurrentAirPressure;
                    }
                    else
                    {
                        throw new FormatException("Value was not yet initialzed");
                    }
                }

                set
                {
                    if(value > r_MaximumAirPressure || value < 0)
                    {
                        throw new ValueOutOfRangeException(r_MaximumAirPressure, 0);
                    }
                    else
                    {
                        m_CurrentAirPressure = value;
                    }
                }
            }

            public float MaximumAirPressure
            {
                get
                {
                    return r_MaximumAirPressure;
                }
            }

            public void AddAirToWheel(float i_AmountOfAirToAdd)
            {
                if (m_CurrentAirPressure < r_MaximumAirPressure)
                {
                    m_CurrentAirPressure = m_CurrentAirPressure + i_AmountOfAirToAdd;
                }
            }

            public void AddAirTillMaxPressure()
            {
                if (m_CurrentAirPressure.HasValue == true)
                {
                    float difference = r_MaximumAirPressure - m_CurrentAirPressure.Value;
                    if (difference > 0)
                    {
                        AddAirToWheel(difference);
                    }
                }
            }

            internal virtual List<string> RequiredInfoForCreation()
            {
                List<string> requiredInfo = new List<string>();

                requiredInfo.Add("Please enter WHEEL'S MANUFACTURER NAME:");
                requiredInfo.Add(string.Format("Please enter current WHEEL'S AIR PRESSURE (MAXIMUM: {0}):", r_MaximumAirPressure));

                return requiredInfo;
            }
        }
    }
}
