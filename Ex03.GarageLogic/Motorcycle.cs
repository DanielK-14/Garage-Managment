using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public enum eBikeLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        private eBikeLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(eBikeLicenseType i_LicenseType, int i_EngineCapacity) : base()  ///Fix ctor with base class
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public eBikeLicenseType LicenseType
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
    }
}
