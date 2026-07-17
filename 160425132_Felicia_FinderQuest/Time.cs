using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _160425132_Felicia_FinderQuest // add existing file (klik kanan spt mau nambah form), pilih timer, lalu rename namespace spy sama dgn form" lain
{
    public class Time
    {
        
        private int hour;
        private int minute;
        private int second;

        #region constructors

        public Time() //def constructor
		{
			this.Hour = 1;
            this.Minute = 2;
            this.Second = 3;
        }

        public Time(int hh, int mm, int ss)
        {
            this.Hour = hh;
            this.Minute = mm;
            this.Second = ss;
        }
        #endregion

        #region properties
        public int Hour
        {
            get => hour;
            set
            {
                //nilai jam hrs bernilai 0-23
                if (value >= 0 && value <= 23)
                {
                    hour = value;
                }
                else
                {
                    throw new Exception("Hour must be 0-23");
                }
            }
        }
        public int Minute
        {
            get => minute;
            set
            {
                //nilai menit harus 0-59
                if (value >= 0 && value <= 59)
                {
                    minute = value;
                }
                else
                {
                    throw new Exception("Minute must be 0-59");
                }
            }
        }
        public int Second
        {
            get => second;
            set
            {
                //nilai detik harus 0-59
                if (value >= 0 && value <= 59)
                {
                    second = value;
                }
                else
                {
                    throw new Exception("Second must be 0-59");
                }
            }
        }
        #endregion

        #region methods
        public int ConvertToSecond()
        {
            int totalSecond = this.Hour * 3600 + this.Minute * 60 + this.Second;
            return totalSecond;
        }

        public void AddWithSecond(int detikInputan)
        {
            int totalDetikSaatIni = this.ConvertToSecond();
            int totalDetik = totalDetikSaatIni + detikInputan;
            
            //convert balik ke hh:mm:ss
            this.Hour = totalDetik / 3600;
            this.Minute = totalDetik % 3600 / 60;
            this.Second = totalDetik % 3600 % 60;
        }

        public string DisplayData()
        {
            string data = this.Hour.ToString().PadLeft(2, '0') + ":" +
                          this.Minute.ToString().PadLeft(2, '0') + ":" +
                          this.Second.ToString().PadLeft(2, '0');
            return data;
        }

        #endregion
    }
}