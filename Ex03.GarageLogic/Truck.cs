﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_CarryingDangerousGoods;
        private float m_CargoCapacity;

        public Truck(bool i_CarryingDangerousGoods, float i_CargoCapacity)
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
    }
}