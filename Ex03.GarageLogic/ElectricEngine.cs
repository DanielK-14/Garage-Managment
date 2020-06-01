using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : EnergySourceUnit
    {

        public ElectricEngine(float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity)
        {
            m_MaximumEnergySourceCapacity = i_MaximumEnergySourceCapacity;
            m_RemainingEnergySource = i_RemainingEnergySource;
        }
        public void Charge(float i_HoursToAdd)
        {
            if(i_HoursToAdd < m_MaximumEnergySourceCapacity)
            {
                m_RemainingEnergySource = m_RemainingEnergySource + i_HoursToAdd;
            }
        }
    }
}
