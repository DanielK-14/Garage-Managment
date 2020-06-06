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
        protected readonly ElectricEngine m_ElectricEngine;
        protected readonly FuelEngine m_FuelEngine;
        protected readonly List<Wheel> m_Wheels;
        protected eVehicleStatus m_Status;

        public Vehicle(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_EngineType, string i_FuelType, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity
            , string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            if(i_EngineType == (Engine.eEngineType)1)
            {
                m_ElectricEngine = new ElectricEngine(i_RemainingEnergySource, i_MaximumEnergySourceCapacity);
                m_FuelEngine = null;
            }
            else
            {
                m_FuelEngine = new FuelEngine(i_FuelType, i_RemainingEnergySource, i_MaximumEnergySourceCapacity);
                m_ElectricEngine = null;
            }
            m_Wheels = new List<Wheel>(i_WheelsAmount);
            for(int i = 0; i < i_WheelsAmount; i++)
            {
                m_Wheels[i] = new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure);
            }
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

        public FuelEngine FuelEnergy
        {
            get
            {
                return m_FuelEngine;
            }
        }
        public ElectricEngine ElectricEnergy
        {
            get
            {
                return m_ElectricEngine;
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

        public virtual void FillEngineSourceUnit(int i_VehicleType, int i_AmountToInsert, int i_FuelType)
        {
            switch ((Engine.eEngineType)i_VehicleType)
            {
                case Engine.eEngineType.Electric:
                    m_ElectricEngine.ReCharge(i_AmountToInsert);
                    break;

                case Engine.eEngineType.Fuel:
                    m_FuelEngine.Refuel(i_AmountToInsert, (FuelEngine.eFuelType)i_FuelType);
                    break;

                default:
                    throw new ArgumentException("Engine type is unknown");
            }
        }
        public virtual List<string> ShowInfo()
        {
            List<string> vehicleInfo = new List<string>();
            //vehicleInfo.Add("ModelName: " + m_ModelName);
            //vehicleInfo.Add("License Number: " + m_LicenseNumber);
            //vehicleInfo.Add("Wheels manufacturer: " + m_Wheels[1].ManufacturerName);
            //vehicleInfo.Add("Wheels current air: " + m_Wheels[1].CurrentAirPressure.ToString());
            //vehicleInfo.Add("Wheels max air pressure: " + m_Wheels[1].MaximumAirPressure.ToString());

            return vehicleInfo;
        }
        public static List<string> RequiredInfoForCreation()
        {
            List<string> engineInformation = FuelEngine.RequiredInfoForCreation();
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

        //public static bool IsInfoInputValid(string i_Input, int i_ValueNumber)
        //{
        //    bool result;
        //    switch(i_ValueNumber)
        //    {
        //        case 1:
        //            break;
        //        case 2:
        //            break;
        //        case 3:
        //            break;
        //        case 4:
        //            break;
        //    }

        //    return result;
        //}

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
