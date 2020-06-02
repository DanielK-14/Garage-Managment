using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Permissions;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public enum eVegicleType
        {
            Motorcycle,
            Car,
            Truck,
        }

        List<Vehicle> m_VehicleList;

        public void BuildNewVehicle()
        {
            eVegicleType vehicleTYpe = ;
            switch (vehicleTYpe)
            {
                case Motorcycle:
                    BuildNewMotorcycle();
                case Car:
                    BuildNewCar();
                case Truck;
                    BuildNewTruck();
            }
        }
        public void BuildNewMotorcycle()
        {

        }
        public void BuildNewCar()
        {

        }
        public void BuildNewTruck()
        {

        }
        public bool CheckIfLicenseIsValid(string i_LicenseNumber)
        {
            bool result = false;
            foreach (Vehicle vehicle in m_VehicleList)
            {
                if (i_LicenseNumber == vehicle.LicenseNumber)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public void PutCarInGarage(string i_LicenseNumber)
        {
            
        }

        public eVegicleType ChooseVehicleType()
        {
            string userInput;
            do
            {
                
            }
            while ();
        }

        public static string GetEnumOptions(Type i_EnumType)
        {
            if (!typeof(Enum).IsAssignableFrom(i_EnumType))
            {
                throw new ArgumentException("Value must be enum type");
            }

            string optionsForPick = string.Empty;
            int optionNumber = 1;
            foreach (var type in Enum.GetNames(i_EnumType))
            {
                optionsForPick += "(" + optionNumber.ToString() + ")" + type + " ";
                optionNumber++;
            }

            return optionsForPick;
        }



    }
}
