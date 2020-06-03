using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine(float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity)
            : base(i_RemainingEnergySource, i_MaximumEnergySourceCapacity)
        { }
        
        public void ReCharge(float i_HoursToAdd)
        {
            if(i_HoursToAdd + m_RemainingEnergySource > m_MaximumEnergySourceCapacity)
            {
                throw new ValueOutOfRangeException();   // Too much fuel //EXCEPTION to continue//
            }
            else
            {
                m_RemainingEnergySource = m_RemainingEnergySource + i_HoursToAdd;
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
