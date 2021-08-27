
using System;

namespace CleanCode.DuplicatedCode
{
    public class Time
    {
        public int Hours { get; }
        public int Minutes { get; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public Time ParseTime(AdmisionInformation str)
        {
            int time;
            int hours;
            int minutes;
            if ((!string.IsNullOrWhiteSpace(str.AdmissionDateTime)) && (int.TryParse(str.AdmissionDateTime.Replace(":", ""), out time)))
            {
                hours = time / 100;
                minutes = time % 100;
                Console.WriteLine(hours);
                Console.WriteLine(minutes);
            }
            else
                throw new ArgumentNullException();
            return new Time(hours, minutes);
        }

        public static void SomeTimeLogic(Time time)
        {
            if (time.Hours < 10)
            {
            }
        }
    }
}
