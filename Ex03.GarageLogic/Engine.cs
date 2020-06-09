using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Engine
    {
        public enum eEngineType
        {
            Electric = 1,
            Fuel,
        }

        protected readonly float r_MaximumCapacity;
        protected readonly eEngineType r_EngineType;
        protected float? m_RemainingEnergy;

        internal Engine(eEngineType i_EngineType, float i_MaximumEnergySourceCapacity)
        {
            r_EngineType = i_EngineType;
            r_MaximumCapacity = i_MaximumEnergySourceCapacity;
        }

        internal float Remaining
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
                if(value > r_MaximumCapacity || value < 0)
                {
                    throw new ValueOutOfRangeException(r_MaximumCapacity, 0); 
                }
                else
                {
                    m_RemainingEnergy = value;
                }
            }
        }

        internal float MaximumCapacity
        {
            get
            {
                return r_MaximumCapacity;
            }
        }

        internal eEngineType EngineType
        {
            get
            {
                return r_EngineType;
            }
        }

        internal abstract List<string> RequiredInfoForCreation();
    }
}
