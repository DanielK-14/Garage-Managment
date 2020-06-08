using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_MaximumEnergySourceCapacity) 
            : base(Engine.eEngineType.Fuel, i_MaximumEnergySourceCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public void Refuel(float i_LitersToAdd, eFuelType i_FuelType)
        {
            if(i_LitersToAdd + m_RemainingEnergy > m_MaximumCapacity)
            {
                throw new ValueOutOfRangeException(m_MaximumCapacity, 0);
            }
            else if(this.isSameTypeOfFuel(i_FuelType) == false)
            {
                throw new ArgumentException("Wrong type of fuel picked");
            }
            else
            {
                m_RemainingEnergy = m_RemainingEnergy + i_LitersToAdd;
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

        public override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = new List<string>();
            requiredInfo.Add(string.Format("Please enter FUEL AMOUNT LEFT (MAXIMUM: {0}): ", m_MaximumCapacity));

            return requiredInfo;
        }

        public void RefuelToFullTank()
        {
            Remaining = MaximumCapacity;
        }
    }
}
