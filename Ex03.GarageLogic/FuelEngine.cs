using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity) 
            : base(i_RemainingEnergySource, i_MaximumEnergySourceCapacity)
        {
            m_FuelType = i_FuelType;
            m_MaximumEnergySourceCapacity = i_MaximumEnergySourceCapacity;
            m_RemainingEnergySource = i_RemainingEnergySource;
        }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if(i_LitersToAdd + m_RemainingEnergySource > m_MaximumEnergySourceCapacity)
            {
                throw new ValueOutOfRangeException();       // Too much fuel //EXCEPTION to continue///
            }
            else if(this.isSameTypeOfFuel(i_FuelType) == false)
            {
                throw new ArgumentException();              // Wrong type of fuel //EXCEPTION to continue///
            }
            else
            {
                m_RemainingEnergySource = m_RemainingEnergySource + i_LitersToAdd;
            }
        }

        private bool isSameTypeOfFuel(eFuelType i_FuelToAdd)
        {
            bool result = false;
            if(i_FuelToAdd == m_FuelType)
            {
                result = true;
            }

            return result;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

    }
}
