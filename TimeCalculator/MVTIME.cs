using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeCalculator
{
    class MVTIME: INotifyPropertyChanged
    {
        public decimal nbrSeconde;
        public string sTime;
        public const int BASE_SEC_1 = 60;
        public const int BASE_SEC_2 = 3600;
        public const int BASE_SEC_3 = 86400;

        public decimal NBR_SEC
        {
            get { return nbrSeconde; }
            set { nbrSeconde = value; NotifyPropertyChanged(); }
        }

        public string S_TIME
        {
            get { return sTime; }
            set { sTime = value; NotifyPropertyChanged(); }
        }

        public void ConvertTime()
        {
            int nbrDays = 0;
            int nbrHours = 0;
            int nbrMins = 0;

            try
            { 
                if (nbrSeconde >= BASE_SEC_3)  //Days 86400
                { 
                    nbrDays = (int) (nbrSeconde / BASE_SEC_3);
                    nbrSeconde %= BASE_SEC_3;
                }
                if (nbrSeconde >= BASE_SEC_2)  //Hours 3600
                {
                    nbrHours = (int)(nbrSeconde / BASE_SEC_2);
                    nbrSeconde %= BASE_SEC_2;
                }
                if (nbrSeconde >= BASE_SEC_1)  //Minutes 60
                {
                    nbrMins = (int)(nbrSeconde / BASE_SEC_1);
                    nbrSeconde %= BASE_SEC_1;
                }
                //nbrSeconde contains the remaining number of secondes

                S_TIME = string.Concat(nbrDays.ToString(), " Days \n", nbrHours.ToString(), " Hours \n", 
                         nbrMins.ToString(), " Min \n", nbrSeconde.ToString(), " Sec \n");
            }
            catch 
            {
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