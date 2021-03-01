using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAssignmentOOP
{
    //public is used for testing
    public class Person
    {
        string name;
        bool hat;
        string eyeColour;
        char gender;

        public string Name { get { return name; } }
        public bool Hat { get { return hat; } }
        public string EyeColour { get { return eyeColour; } }
        
        //ammendments to solve gender problem
        public char Gender { 
            get
            { return gender; }
            set
            {
                if (value == 'm' || value == 'f')
                    gender = value;
                else
                    gender = 'm';
            }
        }

        public Person(string pName, bool pHat, string pEyeColour, char pGender)
        {
            name = pName;
            hat = pHat;
            eyeColour = pEyeColour;
            Gender = pGender;
        }

        public String Description() 
        {
            string hasHat = string.Empty;
            string gndr = string.Empty;
            if (Hat == false)
            {
                hasHat = " does not have a hat, ";
            }
            else 
            {
                hasHat = " has a hat, ";
            }

            if(Gender == 'm')
            {
                gndr = "male";
            }
            else
            {
                gndr = "female";
            }

            string description = $"{Name}{hasHat}has {EyeColour} eyes, and is a {gndr}.";
            return description;
        }
    }
}
