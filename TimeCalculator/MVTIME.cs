using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeCalculator
{
    class MVTIME : INotifyPropertyChanged
    {
        public string nbrSecColor;
        public int nbrSeconde;
        public string sTime;
        public const int BASE_SEC_1 = 60;
        public const int BASE_SEC_2 = 3600;
        public const int BASE_SEC_3 = 86400;

        public string NBR_SEC_COLOR
        {
            get { return nbrSecColor; }
            set { nbrSecColor = value; NotifyPropertyChanged(); }
        }

        public int NBR_SEC
        {
            get { return nbrSeconde; }
            set { nbrSeconde = value; NotifyPropertyChanged(); }
        }

        public string S_TIME
        {
            get { return sTime; }
            set { sTime = value; NotifyPropertyChanged(); }
        }

        public void ConvertTime(bool nbrSecEmpty = false)
        {
            int nbrDays = 0;
            int nbrHours = 0;
            int nbrMins = 0;
            int nbrSecs = 0;
            int nbrSign;

            if (!nbrSecEmpty)
            {
                nbrSecs = Math.Abs(nbrSeconde);
                nbrSign = nbrSeconde / nbrSecs;

                if (nbrSecs >= BASE_SEC_3)  //Days 86400
                { 
                    nbrDays = (nbrSecs / BASE_SEC_3) * nbrSign;
                    nbrSecs %= BASE_SEC_3;
                }
                if (nbrSecs >= BASE_SEC_2)  //Hours 3600
                {
                    nbrHours = (nbrSecs / BASE_SEC_2) * nbrSign;
                    nbrSecs %= BASE_SEC_2;
                }
                if (nbrSecs >= BASE_SEC_1)  //Minutes 60
                {
                    nbrMins = (nbrSecs / BASE_SEC_1) * nbrSign;
                    nbrSecs %= BASE_SEC_1;
                }
                //nbrSecs contains the remaining number of secondes
                nbrSecs *= nbrSign;
                NBR_SEC_COLOR = "Black";
                S_TIME = string.Concat(nbrDays.ToString(), " Days \n", nbrHours.ToString(), " Hours \n", 
                         nbrMins.ToString(), " Min \n", nbrSecs.ToString(), " Sec \n");
            }
            else 
            {
                NBR_SEC_COLOR = "Red";
                S_TIME = "Please enter a valid number of seconds.";
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