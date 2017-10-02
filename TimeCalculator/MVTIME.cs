using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator
{
    class MVTIME : INotifyPropertyChanged
    {
        public string dispTimeColor;
        public int nbrSeconde;
        public string dispTime;
        public const int SEC_IN_MIN = 60;   
        public const int SEC_IN_DAY = 3600;
        public const int SEC_IN_YEAR = 86400;
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
                if (int.TryParse(value, out nbrSeconde))
                    errorNbrSec = false;    //no error
                else
                    errorNbrSec = true;    //error

                NotifyPropertyChanged(); 
            }
        }

        public string DISP_TIME
        {
            get { return dispTime; }
            set { dispTime = value; NotifyPropertyChanged(); }
        }

        public void CalculateTime()  
        {
            int nbrDays = 0;
            int nbrHours = 0;
            int nbrMins = 0;
            int nbrRemSecs = 0;
            int nbrSign;

            if (!errorNbrSec) // if no errors
            {
                nbrRemSecs = Math.Abs(nbrSeconde);
                //to handle negative values, return 1 if nbrseconde = 0; otherwise, get the sign
                nbrSign = (nbrSeconde == 0 ?  1:(nbrSeconde / nbrRemSecs)); 

                if (nbrRemSecs >= SEC_IN_YEAR)     //Days 86400
                { 
                    nbrDays = (nbrRemSecs / SEC_IN_YEAR) * nbrSign;
                    nbrRemSecs %= SEC_IN_YEAR;
                }
                if (nbrRemSecs >= SEC_IN_DAY)      //Hours 3600
                {
                    nbrHours = (nbrRemSecs / SEC_IN_DAY) * nbrSign;
                    nbrRemSecs %= SEC_IN_DAY;
                }
                if (nbrRemSecs >= SEC_IN_MIN)      //Minutes 60
                {
                    nbrMins = (nbrRemSecs / SEC_IN_MIN) * nbrSign;
                    nbrRemSecs %= SEC_IN_MIN;
                }
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