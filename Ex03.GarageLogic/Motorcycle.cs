using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, Engine i_Engine, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount, eLicenseType i_LicenseType, int i_EngineCapacity) 
            : base(i_ModelName, i_LicenseNumber, i_Engine, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure, i_WheelsAmount)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public static List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = Vehicle.RequiredInfoForCreation();
            requiredInfo.Add("Please choose LICENSE TYPE:\n" + Garage.GetEnumOptions(typeof(eLicenseType)));
            requiredInfo.Add("Please enter ENGINE CPACITY:");

            return requiredInfo;
        }
    }
}
