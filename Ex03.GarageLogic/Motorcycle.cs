using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        public Motorcycle(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_EngineType, string i_FuelType, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity
            , string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount, eLicenseType i_LicenseType, int i_EngineCapacity) 
            : base(i_ModelName, i_LicenseNumber, i_EngineType, i_FuelType, i_RemainingEnergySource, i_MaximumEnergySourceCapacity
                  , i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure, i_WheelsAmount)
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
        public string LicenseTypestring
        {
            get
            {
                if(LicenseType == (eLicenseType)1)
                {
                    return "A";
                }
                else if (LicenseType == (eLicenseType)2)
                {
                    return "A1";
                }
                else if (LicenseType == (eLicenseType)3)
                {
                    return "AA";
                }
                else
                {
                    return "B";
                }
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
        public List<string> ShowInfo()
        {
            List<string> vehicleInfo = Vehicle.ShowInfo();
            if(m_ElectricEngine == null)
            {
                vehicleInfo.Add("Engine type: " + m_FuelEngine.EngineTypestring);
                vehicleInfo.Add("Remaining source energy: " + m_FuelEngine.RemainingEnergySource.ToString());
                vehicleInfo.Add("Remaining source energy: " + m_FuelEngine.MaximumEnergySourceCapacity.ToString());
            }
            else
            {
                vehicleInfo.Add("Engine type: " + m_ElectricEngine.EngineTypestring);
                vehicleInfo.Add("Remaining source energy: " + m_ElectricEngine.RemainingEnergySource.ToString());
                vehicleInfo.Add("Maximum source energy: " + m_ElectricEngine.MaximumEnergySourceCapacity.ToString());
            }
            vehicleInfo.Add("License type: " + LicenseTypestring);
            vehicleInfo.Add("Energy capacity: " + m_EngineCapacity.ToString());

            return vehicleInfo;
        }
    }
}
