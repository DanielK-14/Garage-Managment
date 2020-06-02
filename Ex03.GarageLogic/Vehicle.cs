using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected Engine m_Engine;
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
                if (m_CurrentAirPressure < m_MaximumAirPressure)
                {
                    m_CurrentAirPressure = m_CurrentAirPressure + i_AmountOfAirToAdd;
                }
            }

            public void AddAirTillMaxPressure()
            {
                float difference = m_MaximumAirPressure - m_CurrentAirPressure;
                if(difference > 0)
                {
                    AddAirToWheel(difference);
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

        public Engine EnergyUnit
        {
            get
            {
                return m_Engine;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public virtual void FillEngineSourceUnit(float i_AmountToInsert, object obj)
        {
            switch (m_Engine.EngineType)
            {
                case Engine.eEngineType.Electric:
                    
                    break;

                case Engine.eEngineType.Fuel:

                    break;

                default:
                    throw new ArgumentException("Engine type is unknown");      ///EXCEPTION to continue///
            }
        }

        public virtual List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = new List<string>();
            requiredInfo.Add("Please enter vehicle MODEL NAME:");
            requiredInfo.Add("Please enter LICENSE NUMBER:");
            requiredInfo.Add("Please enter WHEELS AMOUNT:");

            return requiredInfo;
        }
    }
}
