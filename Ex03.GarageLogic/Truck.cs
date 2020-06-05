using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_CarryingDangerousGoods;
        private float m_CargoCapacity;

        public Truck(string i_ModelName, string i_LicenseNumber, Engine i_Engine, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount, bool i_CarryingDangerousGoods, float i_CargoCapacity)
            : base(i_ModelName, i_LicenseNumber, i_Engine, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure, i_WheelsAmount)
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
    }
}
