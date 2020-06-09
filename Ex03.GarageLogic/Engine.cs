using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        public enum eEngineType
        {
            Electric = 1,
            Fuel,
        }

        protected readonly eEngineType m_EngineType;
        protected float? m_RemainingEnergy;
        protected readonly float m_MaximumCapacity;

        public Engine(eEngineType i_EngineType, float i_MaximumEnergySourceCapacity)
        {
            m_EngineType = i_EngineType;
            m_MaximumCapacity = i_MaximumEnergySourceCapacity;
        }

        public float Remaining
        {
            get
            {
                if (m_RemainingEnergy.HasValue == true)
                {
                    return m_RemainingEnergy.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }
            set
            {
                if(value > m_MaximumCapacity || value < 0)
                {
                    throw new ValueOutOfRangeException(m_MaximumCapacity, 0); 
                }
                else
                {
                    m_RemainingEnergy = value;
                }
            }
        }

        public float MaximumCapacity
        {
            get
            {
                return m_MaximumCapacity;
            }
        }

        public eEngineType EngineType
        {
            get
            {
                return m_EngineType;
            }
        }

        public abstract List<string> RequiredInfoForCreation();
    }
}
