using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            Fixed,
            Paied,
        }

        protected readonly string m_ModelName;
        protected readonly string m_LicenseNumber;
        protected readonly Engine m_Engine;
        protected readonly List<Wheel> m_Wheels;
        protected eVehicleStatus m_Status;

        public Vehicle(string i_ModelName, string i_LicenseNumber, Engine i_Engine, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            m_Wheels = new List<Wheel>(i_WheelsAmount);
            m_Status = eVehicleStatus.InRepair;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public Engine EnergyUnit
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

        public eVehicleStatus Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        public virtual void FillEngineSourceUnit(float i_AmountToInsert, int i_FuelType)
        {
            switch (m_Engine.EngineType)
            {
                case Engine.eEngineType.Electric:
                    ((ElectricEngine)m_Engine).ReCharge(i_AmountToInsert);
                    break;

                case Engine.eEngineType.Fuel:
                    ((FuelEngine)m_Engine).Refuel(i_AmountToInsert, (FuelEngine.eFuelType)i_FuelType);
                    break;

                default:
                    throw new ArgumentException("Engine type is unknown");
            }
        }

        public static List<string> RequiredInfoForCreation()
        {
            List<string> engineInformation = Engine.RequiredInfoForCreation();
            List<string> wheelsInformation = Engine.RequiredInfoForCreation();
            List<string> requiredInfo = new List<string>();

            requiredInfo.Add("Please enter vehicle MODEL NAME:");
            requiredInfo.Add("Please enter LICENSE NUMBER:");
            foreach(string info in engineInformation)
            {
                requiredInfo.Add(info);
            }
            foreach (string info in wheelsInformation)
            {
                requiredInfo.Add(info);
            }
            requiredInfo.Add("Please enter WHEELS AMOUNT:");

            return requiredInfo;
        }

        public static bool IsInfoInputValid(string i_Input, int i_ValueNumber)
        {
            bool result;
            switch(i_ValueNumber)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return this.m_LicenseNumber.GetHashCode();
        }

        public class Wheel
        {
            private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_MaximumAirPressure;

            public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
            {
                m_ManufacturerName = i_ManufacturerName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaximumAirPressure = i_MaximumAirPressure;
            }

            public string ManufacturerName
            {
                get
                {
                    return m_ManufacturerName;
                }
            }

            public float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
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
                float difference = m_MaximumAirPressure - m_CurrentAirPressure;
                if (difference > 0)
                {
                    AddAirToWheel(difference);
                }
            }
            public void AddAirTillMaxPressure()
            {
                float difference = m_MaximumAirPressure - m_CurrentAirPressure;
                if (difference > 0)
                {
                    AddAirToWheel(difference);
                }
            }

            public static List<string> RequiredInfoForCreation()
            {
                List<string> requiredInfo = new List<string>();

                requiredInfo.Add("Please enter WHEEL'S MANUFACTURER NAME:");
                requiredInfo.Add("Please enter current WHEEL'S AIR PRESSURE:");
                requiredInfo.Add("Please enter WHEEL'S MAXIMUM AIR PRESSURE:");

                return requiredInfo;
            }
        }
    }
}
