using System;

namespace ValueObjects
{
    public readonly struct TimeSlot : IEquatable<TimeSlot>
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

        public override bool Equals(object obj)
        {
            return obj is TimeSlot timeslot && Equals(timeslot);
        }

        public bool Equals(TimeSlot other)
        {
            return StartTime.Equals(other.StartTime) && EndTime.Equals(other.EndTime);
        }

        public override int GetHashCode()
        {
            return (StartTime, EndTime).GetHashCode();
        }
    }
}
