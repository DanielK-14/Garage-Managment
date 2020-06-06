using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_CarryingDangerousGoods;
        private float m_CargoCapacity;

        public Truck(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_EngineType, string i_FuelType, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount, bool i_CarryingDangerousGoods, float i_CargoCapacity)
            : base(i_ModelName, i_LicenseNumber, i_EngineType, i_FuelType, i_RemainingEnergySource, i_MaximumEnergySourceCapacity, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure, i_WheelsAmount)
        {
            m_CarryingDangerousGoods = i_CarryingDangerousGoods;
            m_CargoCapacity = i_CargoCapacity;
        }

        public bool CarryingDangerousGoods
        {
            get
            {
                return m_CarryingDangerousGoods;
            }
            set
            {
                m_CarryingDangerousGoods = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }
            set
            {
                m_CargoCapacity = value;
            }
        }

        public static List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = Vehicle.RequiredInfoForCreation();
            requiredInfo.Add("Is the truck CARRYING DANGEROUS GOODS?");
            requiredInfo.Add("Please enter truck's CARGO CPACITY:");

            return requiredInfo;
        }
        public override List<string> ShowInfo()
        {
            //List<string> vehicleInfo = Vehicle.ShowInfo();
            List<string> vehicleInfo = new List<string>();
            vehicleInfo.Add("ModelName: " + m_ModelName);
            vehicleInfo.Add("License Number: " + m_LicenseNumber);
            vehicleInfo.Add("Wheels manufacturer: " + m_Wheels[1].ManufacturerName);
            vehicleInfo.Add("Wheels current air: " + m_Wheels[1].CurrentAirPressure.ToString());
            vehicleInfo.Add("Wheels max air pressure: " + m_Wheels[1].MaximumAirPressure.ToString());
            vehicleInfo.Add("Engine type: " + m_FuelEngine.EngineTypestring);
            vehicleInfo.Add("Remaining source energy: " + m_FuelEngine.RemainingEnergySource.ToString());
            vehicleInfo.Add("Remaining source energy: " + m_FuelEngine.MaximumEnergySourceCapacity.ToString());
            vehicleInfo.Add("Is carrying dangerous goods: " + m_CarryingDangerousGoods.ToString());
            vehicleInfo.Add("Cargo capacity: " + m_CargoCapacity.ToString());

            return vehicleInfo;
        }
    }
}
