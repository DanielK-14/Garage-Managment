using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine(float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity)
            : base((Engine.eEngineType)1, i_RemainingEnergySource, i_MaximumEnergySourceCapacity)
        { }
        
        public bool ReCharge(float i_HoursToAdd)
        {
            bool valid = false;
            if(i_HoursToAdd + m_RemainingEnergySource > m_MaximumEnergySourceCapacity)
            {
                throw new ValueOutOfRangeException();   // Too much fuel //EXCEPTION to continue//
            }
            else
            {
                m_RemainingEnergySource = m_RemainingEnergySource + i_HoursToAdd;
                valid = true;
            }

            return valid;
        }
        public eEngineType EngineType
        {
            get
            {
                return m_EngineType;
            }
        }

        public void ChargeToMax()
        {
            if(m_RemainingEnergySource < m_MaximumEnergySourceCapacity)
            {
                ReCharge(m_MaximumEnergySourceCapacity - m_RemainingEnergySource);
            }
        }

        public void MakeBatteryEmpty()
        {
            m_RemainingEnergySource = 0;
        }

        public static List<string> RequiredInfoForCreation()
        {
            return Engine.RequiredInfoForCreation();
        }
    }
}
