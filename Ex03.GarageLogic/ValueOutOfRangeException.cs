using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float? m_MaxValue;
        private float? m_MinValue;
        private string m_Message;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
            m_Message = "Value is not in range of MINIMUM: {0} and MAXIMUM: {1} .";
        }

        public override string Message
        {
            get
            {
                if (m_MaxValue.HasValue == true && m_MinValue.HasValue == true)
                {
                    return string.Format(m_Message, MinValue, MaxValue);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public float MaxValue
        {
            get
            {
                if(m_MaxValue.HasValue == true)
                {
                    return m_MaxValue.Value;
                }
                else
                {
                    throw new FormatException("MaxValue was not yet initialzed");
                }
            }

            set
            {
                m_MaxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                if (m_MinValue.HasValue == true)
                {
                    return m_MinValue.Value;
                }
                else
                {
                    throw new FormatException("MinValue was not yet initialzed");
                }
            }

            set
            {
                if (value > MaxValue)
                {
                    throw new ArgumentException("MinValue entered is above MaxValue");
                }
                else
                {
                    m_MinValue = value;
                }
            }
        }
    }
}