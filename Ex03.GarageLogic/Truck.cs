using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool? m_CarryingDangerousGoods;
        private float? m_CargoCapacity;

        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Soler, 120), Vehicle.CreateWheelsForVehicle(16, 28))
        {
        }

        public bool CarryingDangerousGoods
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

        public float CargoCapacity
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

        public override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = base.RequiredInfoForCreation();
            requiredInfo.Add("Is the truck CARRYING DANGEROUS GOODS?" + Environment.NewLine + "YES or NO :");
            requiredInfo.Add("Please enter truck's CARGO CPACITY:");

            return requiredInfo;
        }

        public override StringBuilder ShowInfo()
        {
            StringBuilder vehicleInfo = base.ShowInfo();
            vehicleInfo.AppendLine("Is carrying dangerous goods: " + m_CarryingDangerousGoods.ToString());
            vehicleInfo.AppendLine("Cargo capacity: " + m_CargoCapacity.ToString());

            return vehicleInfo;
        }
    }
}
