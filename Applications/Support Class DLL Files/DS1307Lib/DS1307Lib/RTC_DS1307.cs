using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS1307Lib
{
    public class RTC_DS1307
    {
        TimeSpan Now = DateTime.Now.TimeOfDay;

        public string getHours()
        { 
            string rtcHours = Now.Hours.ToString();
            return rtcHours;
        }

        public string getMinutes()
        {
            string rtcMinutes = Now.Minutes.ToString();
            return rtcMinutes;
        }

        public string getSeconds()
        {
            string rtcSeconds = Now.Seconds.ToString();
            return rtcSeconds;
        }

        public string getDayOfWeek()
        {
            string rtcDayOfWeek = DateTime.Now.DayOfWeek.ToString();

            switch (rtcDayOfWeek)
            {
                case "Sunday": rtcDayOfWeek = "1"; break;
                case "Monday": rtcDayOfWeek = "2"; break;
                case "Tuesday": rtcDayOfWeek = "3"; break;
                case "Wednesday": rtcDayOfWeek = "4"; break;
                case "Thursday": rtcDayOfWeek = "5"; break;
                case "Friday": rtcDayOfWeek = "6"; break;
                case "Saturday": rtcDayOfWeek = "7"; break;
            }

            return rtcDayOfWeek;
        }

        public string getMonth()
        {
            string rtcMonth = DateTime.Now.Month.ToString();
            return rtcMonth;
        }

        public string getDayOfMonth()
        {
            string rtcDayOfMonth = DateTime.Now.Day.ToString();
            return rtcDayOfMonth;
        }

        public string getYear()
        {
            string rtcYear = DateTime.Now.Year.ToString().Substring(2, 2);
            return rtcYear;
        }
    }
}
