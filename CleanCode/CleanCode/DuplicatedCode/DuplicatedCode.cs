
using System;

namespace CleanCode.DuplicatedCode
{
    public class AdmisionInformation
    {
        public AdmisionInformation(string admissionDateTime)
        {
            AdmissionDateTime = admissionDateTime;
        }

        public string AdmissionDateTime { get; private set; }
    }

    public class Time
    {
        public int Hours { get; }
        public int Minutes { get; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public static Time ParseTime(AdmisionInformation str)
        {
            int time;
            int hours;
            int minutes;
            if ((!string.IsNullOrWhiteSpace(str.AdmissionDateTime)) && (int.TryParse(str.AdmissionDateTime.Replace(":", ""), out time)))
            {
                hours = time / 100;
                minutes = time % 100;
            }
            else
                throw new ArgumentNullException("str");
            return new Time(hours, minutes);
        }

        public static void SomeTimeLogic(Time time)
        {
            if (time.Hours < 10)
            {
            }
        }
    }

    class DuplicatedCode
    {
        public void AdmitGuest(string name, string str)
        {
            // Some logic 
            // ...

            var time = Time.ParseTime(new AdmisionInformation(str));

            // Some more logic 
            // ...
            Time.SomeTimeLogic(time);
        }

        public void UpdateAdmission(int admissionId, string name, string str)
        {
            // Some logic 
            // ...
            var time = Time.ParseTime(new AdmisionInformation(str));

            // Some more logic 
            // ...
            Time.SomeTimeLogic(time);
        }
    }
}
