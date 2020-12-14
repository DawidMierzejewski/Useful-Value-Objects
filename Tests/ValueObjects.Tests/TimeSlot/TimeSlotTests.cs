using FluentAssertions;
using System;
using Xunit;

namespace ValueObjects.Tests
{
    public class TimeSlotTests
    {
        [Fact]
        public void Should_Create()
        {
            var timeSlot = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 30, 0));

            timeSlot
                .StartTime
                .Should()
                .Be(new TimeSpan(10, 15, 0));

            timeSlot
                .EndTime
                .Should()
                .Be(new TimeSpan(10, 30, 0));
        }

        [Fact]
        public void Should_EndDateBeGreaterThanStartDate()
        {
            Action createTimeSlot = () => new TimeSlot(
                new TimeSpan(10, 31, 0),
                new TimeSpan(10, 30, 0));

            Assert.Throws<StartDateCannotBeGreaterThanEndDateException>(createTimeSlot);
        }

        [Theory]
        [ClassData(typeof(TimeSlotsOutOfRangeTestData))]
        public void Should_OutOfDateRange(TimeSlot timeSlotTestCase)
        {
            var timeSlot = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 30, 0));

            timeSlot
                .IsInTimeRange(timeSlotTestCase)
                .Should()
                .BeFalse();
        }

        [Theory]
        [ClassData(typeof(TimeSlotsInRangeTestData))]
        public void Should_BeInRange(TimeSlot timeSlotTestCase)
        {
            var timeSlot = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 30, 0));

            timeSlot
                .IsInTimeRange(timeSlotTestCase)
                .Should()
                .BeTrue();
        }

        [Fact]
        public void Should_BeEqual()
        {
            var timeSlot = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 30, 0));

            var timeSlot2 = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 30, 0));

            timeSlot.Equals(timeSlot2).Should().BeTrue();
        }

        [Fact]
        public void Should_NotBeEqual()
        {
            var timeSlot = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 30, 0));

            var timeSlot2 = new TimeSlot(
                new TimeSpan(10, 15, 0),
                new TimeSpan(10, 31, 0));

            timeSlot.Equals(timeSlot2).Should().BeFalse();
        }
    }
}
