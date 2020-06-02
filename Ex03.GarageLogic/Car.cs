using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        public enum eCarColor
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eDoorsAmount
        {
            TwoDoors,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }

        private eCarColor m_CarColor;
        private eDoorsAmount m_DoorsAmount;

        public Car(string i_ModelName, string i_LicenseNumber, Engine i_Engine, List<Wheel> i_Wheels, eCarColor i_CarColor, eDoorsAmount i_DoorsAmount) : base()   ///Fix ctor with base class
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

        public override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = base.RequiredInfoForCreation();
            requiredInfo.Add("Please choose COLOR:\n" + Garage.GetEnumOptions(typeof(eCarColor)));
            requiredInfo.Add("Please choose DOORS AMOUNT:\n" + Garage.GetEnumOptions(typeof(eDoorsAmount)));

            return requiredInfo;
        }
    }
}
