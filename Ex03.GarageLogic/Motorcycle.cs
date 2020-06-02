using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity) : base()  ///Fix ctor with base class
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

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = base.RequiredInfoForCreation();
            requiredInfo.Add("Please choose LICENSE TYPE:\n" + Garage.GetEnumOptions(typeof(eLicenseType)));
            requiredInfo.Add("Please enter ENGINE CPACITY:");

            return requiredInfo;
        }
    }
}
