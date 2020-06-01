using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelEngine : EnergySourceUnit
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_EngineType;

        public void Charge(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if(this.isSameTypeOfFuel(i_FuelType) == true && i_LitersToAdd < m_MaximumEnergySourceCapacity)
            {
                m_RemainingEnergySource = m_RemainingEnergySource + i_LitersToAdd;
            }
        }

        private bool isSameTypeOfFuel(eFuelType i_FuelToAdd)
        {
            bool result = false;
            if(i_FuelToAdd == m_EngineType)
            {
                result = true;
            }

            return result;
        }

        public FuelEngine(eFuelType i_FuelType, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity)
        {
            m_EngineType = i_FuelType;
            m_MaximumEnergySourceCapacity = i_MaximumEnergySourceCapacity;
            m_RemainingEnergySource = i_RemainingEnergySource;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_EngineType
            }
            set
            {
                m_EngineType = value;
            }
        }

    }
}
