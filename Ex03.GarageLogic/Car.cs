using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        public enum eCarColor
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        public enum eDoorsAmount
        {
            TwoDoors = 1,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }

        private eCarColor m_CarColor;
        private eDoorsAmount m_DoorsAmount;

        public Car(string i_ModelName, string i_LicenseNumber, Engine i_Engine, string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount, eCarColor i_CarColor, eDoorsAmount i_DoorsAmount) 
            : base(i_ModelName, i_LicenseNumber, i_Engine, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure, i_WheelsAmount)  
        {
            m_CarColor = i_CarColor;
            m_DoorsAmount = i_DoorsAmount;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eDoorsAmount DoorsAmount
        {
            get
            {
                return m_DoorsAmount;
            }
        }

        public static List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = Vehicle.RequiredInfoForCreation();
            requiredInfo.Add("Please choose COLOR:\n" + Garage.GetEnumOptions(typeof(eCarColor)));
            requiredInfo.Add("Please choose DOORS AMOUNT:\n" + Garage.GetEnumOptions(typeof(eDoorsAmount)));

            return requiredInfo;
        }
    }
}
