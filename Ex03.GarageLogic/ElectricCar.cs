using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car
    {
        private ElectricEngine m_Engine;


        public ElectricCar(eCarColor i_CarColor, eDoorsAmount i_DoorsAmount, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity,
            string i_ModelName, string i_LicenseNumber, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            m_Engine = new ElectricEngine(i_RemainingEnergySource, i_MaximumEnergySourceCapacity);
            m_CarColor = i_CarColor;
            m_DoorsAmount = i_DoorsAmount;
            m_LicenseNumber = i_LicenseNumber;
            m_ModelName = i_ModelName;
            m_Wheels 
            for(int i = 0; i < 4; i++)
            {

            }
        }
    }
}
