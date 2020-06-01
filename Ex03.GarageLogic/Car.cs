﻿using System;
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

        protected eCarColor m_CarColor;
        protected eDoorsAmount m_DoorsAmount;

        public Car(eCarColor i_CarColor, eDoorsAmount i_DoorsAmount)
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

    }
}
