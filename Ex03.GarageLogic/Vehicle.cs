using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyLeft;
        protected List<Wheel> m_Wheels;

        public class Wheel
        {
            private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_MaximumAirPressure;

            public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressure)
            {
                m_ManufacturerName = i_ManufacturerName;
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaximumAirPressure = i_MaximumAirPressure;
            }

            public string ManufacturerName
            {
                get
                {
                    return m_ManufacturerName;
                }
            }

            public float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
                }
            }

            public float MaximumAirPressure
            {
                get
                {
                    return m_MaximumAirPressure;
                }
            }

            public void AddAirToWheel(float i_AmountOfAirToAdd)
            {
                if(m_CurrentAirPressure < m_MaximumAirPressure)
                {
                    m_CurrentAirPressure = m_CurrentAirPressure + i_AmountOfAirToAdd;
                }
            }

        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
    }
}
