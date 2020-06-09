using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        internal enum eCarColor
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        internal enum eDoorsAmount
        {           
            TwoDoors = 1,
            ThreeDoors,
            FourDoors,
            FiveDoors
        }

        private eCarColor? m_CarColor;
        private eDoorsAmount? m_DoorsAmount;

        internal Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine, Vehicle.CreateWheelsForVehicle(4, 32))
        {
        }

        internal eCarColor CarColor
        {
            get
            {
                if (m_CarColor.HasValue == true)
                {
                    return m_CarColor.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }

            set
            {
                if (Enum.IsDefined(typeof(eCarColor), value) == false)
                {
                    throw new ArgumentException("Color picked not valid");
                }
                else
                {
                    m_CarColor = value;
                }
            }
        }

        internal eDoorsAmount DoorsAmount
        {
            get
            {
                if (m_DoorsAmount.HasValue == true)
                {
                    return m_DoorsAmount.Value;
                }
                else
                {
                    throw new FormatException("Value was not yet initialzed");
                }
            }

            set
            {
                if (Enum.IsDefined(typeof(eDoorsAmount), value) == false)
                {
                    throw new ArgumentException("Doors Amount picked not valid");
                }
                else
                {
                    m_DoorsAmount = value;
                }
            }
        }

        internal override List<string> RequiredInfoForCreation()
        {
            List<string> requiredInfo = RequiredInfoForCreationOfVehicle();
            requiredInfo.Add("Please choose COLOR:" + Environment.NewLine + Garage.GetEnumOptions(typeof(eCarColor)));
            requiredInfo.Add("Please choose DOORS AMOUNT:" + Environment.NewLine + Garage.GetEnumOptions(typeof(eDoorsAmount)));

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
                    CarColor = (Car.eCarColor)int.Parse(i_UserInput);
                    break;
                case 6:
                    DoorsAmount = (Car.eDoorsAmount)int.Parse(i_UserInput);
                    break;
            }
        }

        internal override StringBuilder ShowInfo()
        {
            StringBuilder vehicleInfo = base.ShowInfo();
            
            vehicleInfo.AppendLine("Car color: " + m_CarColor.ToString());
            vehicleInfo.AppendLine("Doors amount: " + m_DoorsAmount.ToString());

            return vehicleInfo;
        }
    }
}
