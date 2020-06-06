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

        private eFuelType m_FuelType;

        public FuelEngine(string i_FuelType, float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity) 
            : base((Engine.eEngineType)2, i_RemainingEnergySource, i_MaximumEnergySourceCapacity)
        {
            m_MaximumEnergySourceCapacity = i_MaximumEnergySourceCapacity;
            m_RemainingEnergySource = i_RemainingEnergySource;
            switch(i_FuelType)
            {
                case "Soler":
                    m_FuelType = (eFuelType)1;
                    break;
                case "Octan95":
                    m_FuelType = (eFuelType)2;
                    break;
                case "Octan96":
                    m_FuelType = (eFuelType)3;
                    break;
                case "Octan98":
                    m_FuelType = (eFuelType)4;
                    break;
            }
        }

        public void Refuel(int i_LitersToAdd, eFuelType i_FuelType)
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
        public eEngineType EngineType
        {
            get
            {
                return m_EngineType;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public static List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = Engine.RequiredInfoForCreation();
            requiredInfo.Add("Please enter FUEL TYPE:\n" + Garage.GetEnumOptions(typeof(eEngineType)) + "\nOr none if electric");

            return requiredInfo;
        }
    }
}
