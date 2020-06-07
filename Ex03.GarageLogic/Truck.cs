﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Truck : FuelVehicle
    {
        private const float k_MaxPressureOfWheel = 28;
        private Car m_Car;
        private bool m_isCarryDangerousMaterial;
        private float m_CarryVolume;

        public Truck(string i_ModelName, string i_LicensePlateNumber, int i_NumOfWheels, float i_MaxPressureLevelForWheel, FuelVehicle.eFuel i_FuelType, float i_MaxAmountOfFuel) : base(i_ModelName, i_LicensePlateNumber, i_NumOfWheels, i_MaxPressureLevelForWheel, i_MaxAmountOfFuel, i_FuelType)
        {
            m_Car = new Car();
        }

        public static new List<string> GetQuestions()
        {
            List<string> questionsToUserFuelVehicle = FuelVehicle.GetQuestions();
            List<string> questionsToUserCar = Car.GetQuestions();
            foreach (string str in questionsToUserCar)
            {
                questionsToUserFuelVehicle.Add(str);
            }

            questionsToUserFuelVehicle.Add("Please enter true if the truck carry dangerous material, or false if doesn't");
            questionsToUserFuelVehicle.Add("Please enter the carry volume of the truck");
            return questionsToUserFuelVehicle;
        }

       public static new List<string> GetAtributes()
        {
            List<string> atributesFuelVehicle = FuelVehicle.GetAtributes();
            List<string> atributesToUserCar = Car.GetAtributes();
            foreach (string str in atributesToUserCar)
            {
                atributesFuelVehicle.Add(str);
            }

            atributesFuelVehicle.Add("IsCarryDangerousMaterial");
            atributesFuelVehicle.Add("CarryVolume");
            return atributesFuelVehicle;
        }

        public override string GetAllDetalies()
        {
            return "Vehicle type: Truck \n" + base.GetAllDetalies() + m_Car.GetAllDetalies() + string.Format(@"
Truck carry volume is:{0}
Is carry dangerous material:{1}", m_CarryVolume.ToString(), m_isCarryDangerousMaterial.ToString());
        }
        public override void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            if(i_WhichAttributeToSet == "CarryVolume")
            {
                CarryVolume = float.Parse(i_InputFromUser);
            }

            if (i_WhichAttributeToSet == "IsCarryDangerousMaterial")
            {
                m_isCarryDangerousMaterial = bool.Parse(i_InputFromUser);
            }

            m_Car.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
            base.SetAttribute(i_WhichAttributeToSet, i_InputFromUser);
        }        

        public float CarryVolume
        {
            get
            {
                return m_CarryVolume;            
            }

            set
            {
                m_CarryVolume = value;
            }
        }
    }
}