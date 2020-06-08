using System;

namespace Ex03.GarageLogic
{
    class VehicleDetails
    {
        private readonly Vehicle m_Vehicle;
        private readonly string m_OwnerName;
        private readonly string m_PhoneNumber;
        private eVehicleStatus? m_Status;

        public VehicleDetails(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Status = eVehicleStatus.InRepair;
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Fixed,
            Paid
        }

        public Vehicle Vehicle
        {
            get 
            {
                return m_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }
        }

        public eVehicleStatus Status
        {
            get
            {
                if (m_Status.HasValue == true)
                {
                    return m_Status.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }
            set
            {
                if (Enum.IsDefined(typeof(eVehicleStatus), value) == true)
                {
                    m_Status = value;
                }
                else
                {
                    throw new FormatException("Status is not valid");
                }
            }
        }
    }
}
