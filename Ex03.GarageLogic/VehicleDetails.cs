using System;

namespace Ex03.GarageLogic
{
    internal class VehicleDetails
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_PhoneNumber;
        private eVehicleStatus? m_Status;

        public VehicleDetails(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_PhoneNumber = i_PhoneNumber;
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
                return r_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
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
