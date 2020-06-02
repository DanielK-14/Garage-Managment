using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        public enum eEngineType
        {
            Electric,
            Fuel,
        }

        protected eEngineType m_EngineType;
        protected float m_RemainingEnergySource;
        protected float m_MaximumEnergySourceCapacity;

        public Engine(float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity)
        {
            m_MaximumEnergySourceCapacity = i_MaximumEnergySourceCapacity;
            m_RemainingEnergySource = i_RemainingEnergySource;
        }

        public float RemainingEnergySource
        {
            get
            {
                return m_RemainingEnergySource;
            }
            set
            {
                if(value > m_MaximumEnergySourceCapacity)
                {
                    throw new ValueOutOfRangeException("Quantity over maximum level");  ///EXCEPTION to continue///
                }
            }
        }

        public float MaximumEnergySourceCapacity
        {
            get
            {
                return m_MaximumEnergySourceCapacity;
            }
        }

        public eEngineType EngineType
        {
            get
            {
                return m_EngineType;
            }
        }

        public virtual List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = new List<string>();
            requiredInfo.Add("Please choose engine POWER SOURCE:\n" + Garage.GetEnumOptions(typeof(eEngineType)));
            requiredInfo.Add("Please enter REMAINING POWER AMOUNT:");
            requiredInfo.Add("Please enter MAXIMUM POWER AMOUNT:");

            return requiredInfo;
        }
    }
}
