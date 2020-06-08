using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelCar : Vehicle
    {

        public enum eCarColor
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        public enum eDoorsAmount
        {
            TwoDoors = 1,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }

        private eCarColor m_CarColor;
        private eDoorsAmount m_DoorsAmount;

        public FuelCar(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_EngineType, string i_FuelType,
            float i_RemainingEnergySource, float i_MaximumEnergySourceCapacity, string i_ManufacturerName,
            float i_CurrentAirPressure, float i_MaximumAirPressure, int i_WheelsAmount, eCarColor i_CarColor, eDoorsAmount i_DoorsAmount)
            : base(i_LicenseNumber, i_ModelName, i_EngineType, i_FuelType, i_RemainingEnergySource,
                  i_MaximumEnergySourceCapacity, i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure, i_WheelsAmount)
        {
            m_CarColor = i_CarColor;
            m_DoorsAmount = i_DoorsAmount;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eDoorsAmount DoorsAmount
        {
            get
            {
                return m_DoorsAmount;
            }
        }

        public static List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = Vehicle.RequiredInfoForCreation();
            requiredInfo.Add("Please choose COLOR:\n" + Garage.GetEnumOptions(typeof(eCarColor)));
            requiredInfo.Add("Please choose DOORS AMOUNT:\n" + Garage.GetEnumOptions(typeof(eDoorsAmount)));

            return requiredInfo;
        }
        public override List<string> ShowInfo()
        {
            //List<string> vehicleInfo = Vehicle.ShowInfo();
            List<string> vehicleInfo = new List<string>();
            vehicleInfo.Add("ModelName: " + m_ModelName);
            vehicleInfo.Add("License Number: " + m_LicenseNumber);
            vehicleInfo.Add("Wheels manufacturer: " + m_Wheels[1].ManufacturerName);
            vehicleInfo.Add("Wheels current air: " + m_Wheels[1].CurrentAirPressure.ToString());
            vehicleInfo.Add("Wheels max air pressure: " + m_Wheels[1].MaximumAirPressure.ToString());
            if (m_ElectricEngine == null)
            {
                vehicleInfo.Add("Engine type: " + m_FuelEngine.EngineTypestring);
                vehicleInfo.Add("Remaining source energy: " + m_FuelEngine.RemainingEnergySource.ToString());
                vehicleInfo.Add("Remaining source energy: " + m_FuelEngine.MaximumEnergySourceCapacity.ToString());
            }
            else
            {
                vehicleInfo.Add("Engine type: " + m_ElectricEngine.EngineTypestring);
                vehicleInfo.Add("Remaining source energy: " + m_ElectricEngine.RemainingEnergySource.ToString());
                vehicleInfo.Add("Maximum source energy: " + m_ElectricEngine.MaximumEnergySourceCapacity.ToString());
            }
            vehicleInfo.Add("Car color: " + m_CarColor.ToString());
            vehicleInfo.Add("Doors amount: " + m_DoorsAmount.ToString());

            return vehicleInfo;
        }
    }
}
