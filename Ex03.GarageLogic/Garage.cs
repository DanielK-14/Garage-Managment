using System;
using System.Collections.Generic;
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
            foreach (var in m_VehicleList)
            {
                if (i_LicenseNumber == var.LicenseNumber)
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

        
    }
}
