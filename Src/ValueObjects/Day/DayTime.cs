using System;
using System.Collections.Generic;

namespace ValueObjects
{
    public readonly struct DayTime : IEqualityComparer<DayTime>
    {
        public int Year { get; }

        public int Month { get; }

        public int Day { get; }

        public DayTime(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public DayTime(DateTime date)
        {
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
        }

        public static DayTime FromDateTime(DateTime date)
        {
            return new DayTime(date);
        }

        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day);
        }

        public bool Equals(DayTime date1, DayTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }

        public int GetHashCode(DayTime obj)
        {
            return (Year, Month, Day).GetHashCode();
        }
    }
}
