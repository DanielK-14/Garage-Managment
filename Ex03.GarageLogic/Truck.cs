using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_CarryingDangerousGoods;
        private float m_CargoCapacity;

        public Truck(bool i_CarryingDangerousGoods, float i_CargoCapacity)  ///Fix ctor with base class
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

        public override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = base.RequiredInfoForCreation();
            requiredInfo.Add("Is the truck CARRYING DANGEROUS GOODS?");
            requiredInfo.Add("Please enter truck's CARGO CPACITY:");

            return requiredInfo;
        }
    }
}
