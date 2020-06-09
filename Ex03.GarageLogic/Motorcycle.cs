using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }

        private eLicenseType? m_LicenseType;
        private int? m_EngineCapacity;

        internal Motorcycle(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine, Vehicle.CreateWheelsForVehicle(2, 30)) { }

        internal eLicenseType LicenseType
        {
            get
            {
                if (m_LicenseType.HasValue == true)
                {
                    return m_LicenseType.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }

            set
            {
                if (Enum.IsDefined(typeof(eLicenseType), value) == false)
                {
                    throw new ArgumentException("License type picked not valid");
                }
                else
                {
                    m_LicenseType = value;
                }
            }
        }

        internal int EngineCapacity
        {
            get
            {
                if (m_EngineCapacity.HasValue == true)
                {
                    return m_EngineCapacity.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }

            set
            {
                m_EngineCapacity = value;
            }
        }

        internal override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = RequiredInfoForCreationOfVehicle();
            requiredInfo.Add("Please choose LICENSE TYPE: " + Environment.NewLine + Garage.GetEnumOptions(typeof(eLicenseType)));
            requiredInfo.Add("Please enter ENGINE CPACITY:");

            return requiredInfo;
        }

        internal override void CheckInputedValues(string i_UserInput, int i_RequestNumber)
        {
            if(i_RequestNumber < 5)
            {
                CheckVehicleValuesInputted(i_UserInput, i_RequestNumber);
            }
            switch (i_RequestNumber)
            {
                case 5:
                    LicenseType = (Motorcycle.eLicenseType)int.Parse(i_UserInput);
                    break;
                case 6:
                    EngineCapacity = int.Parse(i_UserInput);
                    break;
            }
        }

        internal override StringBuilder ShowInfo()
        {
            StringBuilder vehicleInfo = base.ShowInfo();
            vehicleInfo.AppendLine("License type: " + Enum.GetName(typeof(eLicenseType), m_LicenseType));
            vehicleInfo.AppendLine("Engine capacity: " + m_EngineCapacity.ToString());

            return vehicleInfo;
        }
    }
}
