using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string m_LicenseNumber;
        protected readonly Engine m_Engine;
        protected List<Wheel> m_Wheels;

        public Vehicle(string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_ModelName = string.Empty;
            m_Engine = i_Engine;
            m_Wheels = i_Wheels;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_Engine;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public virtual StringBuilder ShowInfo()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine("ModelName: " + m_ModelName);
            vehicleInfo.AppendLine("License Number: " + m_LicenseNumber);
            vehicleInfo.AppendLine("Wheels manufacturer: " + m_Wheels[1].ManufacturerName);
            vehicleInfo.AppendLine("Wheels current air: " + m_Wheels[1].CurrentAirPressure.ToString());
            vehicleInfo.AppendLine("Wheels max air pressure: " + m_Wheels[1].MaximumAirPressure.ToString());
            if (m_Engine is FuelEngine)
            {
                FuelEngine fuelEngine = m_Engine as FuelEngine;
                vehicleInfo.AppendLine("Engine type: " + fuelEngine.EngineTypestring);
                vehicleInfo.AppendLine("Fuel type: " + Enum.GetName(typeof(FuelEngine.eFuelType), fuelEngine.FuelType));
                vehicleInfo.AppendLine("Remaining fuel amount: " + fuelEngine.Remaining.ToString());
                vehicleInfo.AppendLine("Maximum fuel amount: " + fuelEngine.MaximumCapacity.ToString());
            }
            else
            {
                vehicleInfo.AppendLine("Engine type: " + m_Engine.EngineTypestring);
                vehicleInfo.AppendLine("Remaining battery energy hours : " + m_Engine.Remaining.ToString());
                vehicleInfo.AppendLine("Maximum battery energy in hours : " + m_Engine.MaximumCapacity.ToString());
            }

            return vehicleInfo;
        }
        public virtual List<string> RequiredInfoForCreation()
        {
            List<string> engineInformation;
            if (m_Engine is ElectricEngine)
            {
                ElectricEngine electricEngine = m_Engine as ElectricEngine;
                engineInformation = electricEngine.RequiredInfoForCreation();
            }
            else
            {
                FuelEngine fuelEngine = m_Engine as FuelEngine;
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

        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool equals = false;

            if(obj != null)
            {
                if(obj is Vehicle)
                {
                    equals = this.GetHashCode() == ((Vehicle)obj).GetHashCode();
                }
            }

            return equals;
        }

        public void SetAllWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach(var wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public void SetAllWheelsAirPressure(float i_AirPressure)
        {
            foreach (var wheel in m_Wheels)
            {
                wheel.CurrentAirPressure = i_AirPressure;
            }
        }

        public void SetAllWheelsAirPressureToMax()
        {
            foreach(var wheel in m_Wheels)
            {
                wheel.AddAirTillMaxPressure();
            }
        }

        public static List<Wheel> CreateWheelsForVehicle(int i_Amount, float i_MaxPressure)
        {
            List<Wheel> wheels = new List<Wheel>(i_Amount);
            for (int i = 0; i < i_Amount; i++)
            {
                wheels.Add(new Wheel(i_MaxPressure));
            }

            return wheels;
        }

        public class Wheel
        {
            private string m_ManufacturerName;
            private float? m_CurrentAirPressure;
            private readonly float m_MaximumAirPressure;

            public Wheel(float i_MaximumAirPressure)
            {
                m_MaximumAirPressure = i_MaximumAirPressure;
            }

            public string ManufacturerName
            {
                get
                {
                    return m_ManufacturerName;
                }
                set
                {
                    m_ManufacturerName = value;
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
                    if(value > m_MaximumAirPressure || value < 0)
                    {
                        throw new ValueOutOfRangeException(m_MaximumAirPressure, 0);
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
                    return m_MaximumAirPressure;
                }
            }

            public void AddAirToWheel(float i_AmountOfAirToAdd)
            {
                if (m_CurrentAirPressure < m_MaximumAirPressure)
                {
                    m_CurrentAirPressure = m_CurrentAirPressure + i_AmountOfAirToAdd;
                }
            }

            public void AddAirTillMaxPressure()
            {
                if (m_CurrentAirPressure.HasValue == true)
                {
                    float difference = m_MaximumAirPressure - m_CurrentAirPressure.Value;
                    if (difference > 0)
                    {
                        AddAirToWheel(difference);
                    }
                }
            }

            public virtual List<string> RequiredInfoForCreation()
            {
                List<string> requiredInfo = new List<string>();

                requiredInfo.Add("Please enter WHEEL'S MANUFACTURER NAME:");
                requiredInfo.Add(string.Format("Please enter current WHEEL'S AIR PRESSURE (MAXIMUM: {0}):", m_MaximumAirPressure));

                return requiredInfo;
            }
        }
    }
}
