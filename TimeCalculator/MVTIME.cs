/* TEAM ONE: TIME CALCULATOR
 * Shane Frost - 5600861
 * Jeewan Kalia - 8032997
 * Mireille Tabod Epse Nubaga - 6542864
 * Abhishek Sharma - 7719818
 * Edward Barber - 7925969
 * Joseph Kasumba - 8147696 
 */

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator
{
    class MVTIME : INotifyPropertyChanged
    {
        public string dispTimeColor;
        public Int64 nbrSeconde;
        public string dispTime;
        public const int SEC_IN_MIN = 60;   
        public const int SEC_IN_HOUR = 3600;
        public const int SEC_IN_DAY = 86400;
        public bool errorNbrSec;

        public string DISP_TIME_COLOR
        {
            get 
            { 
                return dispTimeColor; 
            }
            set 
            { 
                dispTimeColor = value; 
                NotifyPropertyChanged(); 
            }
        }

        public string NBR_SEC
        {
            get 
            { 
                return nbrSeconde.ToString(); 
            }
            set 
            { 
                if (Int64.TryParse(value, out nbrSeconde))
                    errorNbrSec = false;    //no error
                else
                    errorNbrSec = true;    //error

                NotifyPropertyChanged(); 
            }
        }

        public string DISP_TIME
        {
            get 
            {
                return dispTime; 
            }
            set
            { 
                dispTime = value; 
                NotifyPropertyChanged();
            }
        }

        public void CalculateTime()  
        {
            Int64 nbrDays = 0;
            Int64 nbrHours = 0;
            Int64 nbrMins = 0;
            Int64 nbrRemSecs = 0;
            Int64 nbrSign;

            if (!errorNbrSec) // if no errors
            {
                nbrRemSecs = Math.Abs(nbrSeconde);
                //to handle negative values, return 1 if nbrseconde = 0; otherwise, get the sign
                nbrSign = (nbrSeconde == 0 ?  1:(nbrSeconde / nbrRemSecs)); 

                //Days 86400 
                nbrDays = (nbrRemSecs / SEC_IN_DAY) * nbrSign;
                nbrRemSecs %= SEC_IN_DAY;
                //Hours 3600
                nbrHours = (nbrRemSecs / SEC_IN_HOUR) * nbrSign;
                nbrRemSecs %= SEC_IN_HOUR;
                //Minutes 60
                nbrMins = (nbrRemSecs / SEC_IN_MIN) * nbrSign;
                nbrRemSecs %= SEC_IN_MIN;

                //nbrRemSecs contains the remaining number of secondes
                nbrRemSecs *= nbrSign;
                DISP_TIME_COLOR = "Black";
                DISP_TIME = string.Concat(nbrDays.ToString(), " Days \n", nbrHours.ToString(), " Hours \n", 
                         nbrMins.ToString(), " Min \n", nbrRemSecs.ToString(), " Sec \n");
            }
            else //if errors
            {
                DISP_TIME_COLOR = "Red";
                DISP_TIME = "Please enter a valid number of seconds.";
            }
        }

        //Event Handler
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}