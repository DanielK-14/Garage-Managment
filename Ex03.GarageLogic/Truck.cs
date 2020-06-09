using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool? m_CarryingDangerousGoods;
        private float? m_CargoCapacity;

        internal Truck(string i_LicenseNumber) : base(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Soler, 120), Vehicle.CreateWheelsForVehicle(16, 28))
        {
        }

        internal bool CarryingDangerousGoods
        {
            get
            {
                if (m_CarryingDangerousGoods.HasValue == true)
                {
                    return m_CarryingDangerousGoods.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }

            set
            {
                m_CarryingDangerousGoods = value;
            }
        }

        internal float CargoCapacity
        {
            get
            {
                if (m_CargoCapacity.HasValue == true)
                {
                    return m_CargoCapacity.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        internal override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = RequiredInfoForCreationOfVehicle();
            requiredInfo.Add("Is the truck CARRYING DANGEROUS GOODS?" + Environment.NewLine + "YES or NO :");
            requiredInfo.Add("Please enter truck's CARGO CPACITY:");

            return requiredInfo;
        }

        internal override void CheckInputedValues(string i_UserInput, int i_RequestNumber)
        {
            if (i_RequestNumber < 5)
            {
                CheckVehicleValuesInputted(i_UserInput, i_RequestNumber);
            }
            switch (i_RequestNumber)
            {
                case 5:
                    if (i_UserInput.ToLower() == "yes")
                    {
                        CarryingDangerousGoods = true;
                    }
                    else if (i_UserInput.ToLower() == "no")
                    {
                        CarryingDangerousGoods = false;
                    }
                    else
                    {
                        throw new ArgumentException("Wrong answer entered");
                    }
                    break;
                case 6:
                    CargoCapacity = float.Parse(i_UserInput);
                    break;
            }
        }

        internal override StringBuilder ShowInfo()
        {
            StringBuilder vehicleInfo = ShowInfoVehicle();
            vehicleInfo.AppendLine("Is carrying dangerous goods: " + m_CarryingDangerousGoods.ToString());
            vehicleInfo.AppendLine("Cargo capacity: " + m_CargoCapacity.ToString());

            return vehicleInfo;
        }
    }
}
