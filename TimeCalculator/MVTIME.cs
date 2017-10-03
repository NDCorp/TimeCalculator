/* TEAM ONE: TIME CALCULATOR
 * Shane Frost - 5600861
 * Jeewan Kalia - 8032997
 * Mireille Tabod Epse Nubaga - 6542864
 * Abhishek Sharma - 7719818
 * Edward Barber - 7925969
 * Joseph Kasumba - 8147696 
 */

/* COMMENTS
 * constant: SEC_IN_MIN
 * public binded variables: NbrSec
 * Other private/public variables: nbrSecond
 * Use MVVM only for calculations and send the information to the UI to show a message or format the field in XAML
 * He asks "we should not be too specific", but if we are not, we may misinterpret the question
 * Design seems important to him. So try making thinks look fancier.
 * 
*/
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator
{
    class MVTIME : INotifyPropertyChanged
    {
        public string dispTimeColor;
        public Int64 nbrSecond;
        public string dispTime;
        public const int SEC_IN_MIN = 60;   
        public const int SEC_IN_HOUR = 3600;
        public const int SEC_IN_DAY = 86400;
        public bool errorNbrSec;

        public string DispTimeColor
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

        public string NbrSec
        {
            get 
            { 
                return nbrSecond.ToString(); 
            }
            set 
            { 
                if (Int64.TryParse(value, out nbrSecond))
                    errorNbrSec = false;    //no error
                else
                    errorNbrSec = true;    //error

                NotifyPropertyChanged(); 
            }
        }

        public string DispTime
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
            Int64 nbrDays;
            Int64 nbrHours;
            Int64 nbrMins;
            Int64 nbrRemSecs;

            if (!errorNbrSec) // if no errors
            {
                nbrRemSecs = nbrSecond;

                //Days 86400 
                nbrDays = (nbrRemSecs / SEC_IN_DAY);
                nbrRemSecs %= SEC_IN_DAY;
                //Hours 3600
                nbrHours = (nbrRemSecs / SEC_IN_HOUR);
                nbrRemSecs %= SEC_IN_HOUR;
                //Minutes 60
                nbrMins = (nbrRemSecs / SEC_IN_MIN);
                nbrRemSecs %= SEC_IN_MIN;

                //nbrRemSecs contains the remaining number of seconds               
                DispTimeColor = "Black";
                DispTime = string.Concat(nbrDays.ToString(), " Days \n", nbrHours.ToString(), " Hours \n", 
                                          nbrMins.ToString(), " Min \n", nbrRemSecs.ToString(), " Sec \n");
            }
            else //if errors
            {
                DispTimeColor = "Red";
                DispTime = "Please enter a valid number of seconds.";
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