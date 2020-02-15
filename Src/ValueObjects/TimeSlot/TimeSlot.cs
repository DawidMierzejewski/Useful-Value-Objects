using System;

namespace ValueObjects
{
    public readonly struct TimeSlot
    {
        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }

        public TimeSlot(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime > endTime)
            {
                throw new StartDateCannotBeGreaterThanEndDateException();
            }

            StartTime = startTime;
            EndTime = endTime;
        }

        public bool IsInTimeRange(TimeSlot timeSlot)
        {
            return timeSlot.StartTime >= StartTime && timeSlot.StartTime <= EndTime ||
                   timeSlot.EndTime >= StartTime && timeSlot.EndTime <= EndTime;
        }
    }
}
