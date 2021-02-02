using System;
using System.Collections.Generic;
using System.Text;

namespace library
{
    public class CovidRecord
    {
        private string _city;
        private int _household;
        private int _tested;
        private int _sick;

        public int Id { get; set; }

        public string City
        {
            get { return _city; }
            set { CheckCity(value); _city = value; }
        }

        public int Household
        {
            get { return _household; }
            set { CheckHousehold(value); _household = value; }
        }
        public int Tested
        {
            get { return _tested; }
            set { CheckTested(value); _tested = value; }
        }

        public int Sick
        {
            get { return _sick; }
            set { CheckSick(value); _sick = value; }
        }

        public CovidRecord(int id, string city, int household, int tested, int sick)
        {
            CheckCity(city);
            CheckHousehold(household);
            CheckSick(sick);
            CheckTested(tested);
            Id = id;
            City = city;
            Household = household;
            Tested = tested;
            Sick = sick;
        }

        public CovidRecord()
        {
            
        }

        private static void CheckCity(string city)
        {
            if (city.Length < 2)
            {
                throw new ArgumentException("mindst 2 tegn");
            }
        }

        private static void CheckHousehold(int household)
        {
            if (household >= 1)
            {
                
            }
            else
            {
                throw new ArgumentException("mindst 1 medlem");
            }
        }

        private static void CheckTested(int tested)
        {
            if (tested < 0)
            {
                throw new ArgumentException("mindst 0 tested");
            }
        }

        private static void CheckSick(int sick)
        {
            if (sick < 0)
            {
                throw new ArgumentException("mindst 0 syge");
            }
        }
    }
}
