﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicensePlateNumber;
        protected float m_LeftPercentageOfEnergy;
        protected List<Wheel> m_ListOfWheels;

        public Vehicle(string i_ModelName, string i_LicensePlateNumber,int i_NumOfWheels, float i_MaxPressureForWheel)
        {
            r_ModelName = i_ModelName;
            r_LicensePlateNumber = i_LicensePlateNumber;
            makeWheelListForCar(i_NumOfWheels, i_MaxPressureForWheel);
        }

       
        public virtual void SetAttribute(string i_WhichAttributeToSet, string i_InputFromUser)
        {
            if (i_WhichAttributeToSet == "ManufactureName")
            {
                string[] ManufactureNames = new string[ListOfWheels.Count];
                for (int i = 0; i < ListOfWheels.Count; i++)
                {
                    ManufactureNames[i] = i_InputFromUser;
                }
                UpdateListOfWheels(ManufactureNames);
            }

            if(i_WhichAttributeToSet == "CurrPressureLevel")
            {
                float currPressureLevel = float.Parse(i_InputFromUser); //can throw an exeption
                float[] currPressureLevelArr = new float[ListOfWheels.Count];
                if (currPressureLevel > m_ListOfWheels[0].MaxPressureLevel || currPressureLevel < 0)
                {
                    throw new ValueOutOfRangeException(0, m_ListOfWheels[0].MaxPressureLevel);
                }
                for (int i = 0; i < ListOfWheels.Count; i++)
                {
                    currPressureLevelArr[i] = currPressureLevel;
                }
                UpdateListOfWheels(currPressureLevelArr);
            }
        }
  
        public string ModelName
        {
            get
            {
                return r_ModelName;            
            }       
        }

        protected void UpdateListOfWheels(float [] i_CurrPressureLevelArr)
        {
            int i = 0;
            foreach (Wheel currWheel in ListOfWheels)
            {
                currWheel.CurrPressureLevel = i_CurrPressureLevelArr[i];
            }
        }
        protected void UpdateListOfWheels(string[] i_ManufactureNameArr)
        {
            int i = 0;
            foreach (Wheel currWheel in ListOfWheels)
            {
                currWheel.ManufactureName = i_ManufactureNameArr[i];
            }
        }
        protected static List<string> getAtributes()
        {
            List<string> atributes = new List<string>();
            atributes.Add("ManufactureName");
            atributes.Add("CurrPressureLevel");
            return atributes;
        }

        protected static List<string> getQuestions()
        {
            List<string> questionsToUser = new List<string>();
            questionsToUser.Add("Please enter manufacture name for the wheels");
            questionsToUser.Add("Please enter current pressure level for the wheels");
            return questionsToUser;

        }
        public float LeftPercentageOfEnergy
        {
            get
            {
                return m_LeftPercentageOfEnergy;
            }
            set
            {
                m_LeftPercentageOfEnergy = value;
            }
        }

        public List<Wheel> ListOfWheels
        {
            get
            {
                return m_ListOfWheels;
            }
            set
            {
                m_ListOfWheels = value;
            }

        }
        public string LicencsePlateNumber
        {
            get
            {
                return r_LicensePlateNumber;
            }           
        }

        
        private void makeWheelListForCar(int i_NumOfWheels, float i_MaxPressureLevelForWheel)
        {
            m_ListOfWheels = new List<Wheel>();
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_ListOfWheels.Add(new Wheel(i_MaxPressureLevelForWheel));
            }
        }

        public void PumpAllWheels()
        {
            foreach (Wheel currWheelToPump in m_ListOfWheels)
            {
                currWheelToPump.PumpWheelToMax();
            }
        }
  
        public virtual StringBuilder GetAllDetalies()
        {
            StringBuilder detalies = new StringBuilder();
            detalies.AppendLine("License plate number:" + r_LicensePlateNumber.ToString()+ " ");
            detalies.AppendLine("Model name:" + r_ModelName.ToString());
            detalies.AppendLine("Manufcture name of wheels:" + m_ListOfWheels[0].ManufactureName);
            detalies.AppendLine("Current pressure level of wheels:" + m_ListOfWheels[0].CurrPressureLevel);
            return detalies;
        }
        public class Wheel
        {
            private string m_ManufactureName;
            private float m_CurrPressureLevel;
            private readonly float r_MaxPressureLevel;
            public Wheel(float i_MaxPressureLevel)
            {
                this.r_MaxPressureLevel = i_MaxPressureLevel;
            }

            public string ManufactureName
            {
                get
                {
                    return m_ManufactureName;
                }
                set
                {
                    m_ManufactureName = value;
                }
            }

            public float CurrPressureLevel
            {
                get
                {
                    return m_CurrPressureLevel;
                }
                set
                {
                    m_CurrPressureLevel = value;
                }
            }

            public float MaxPressureLevel
            {
                get
                {
                    return r_MaxPressureLevel;
                }
            }
            public void PumpWheelToMax()
            {
                m_CurrPressureLevel = r_MaxPressureLevel;
            }
            public void PumpWheel(float i_PressuureToAdd)    
            {        
                if(this.m_CurrPressureLevel + i_PressuureToAdd <= r_MaxPressureLevel)
                {
                    this.m_CurrPressureLevel += i_PressuureToAdd;
                }               
            }
        }
    }
}