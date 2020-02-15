using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ValueObjects.Tests
{
    public class DayTimeTests
    {
        [Fact]
        public void Should_ConvertFromDateTime()
        {
            var now = DateTime.Now;

            var date = DayTime.FromDateTime(now);

            date.Year.Should().Be(now.Year);
            date.Month.Should().Be(now.Month);
            date.Day.Should().Be(now.Day);
        }

        [Fact]
        public void Should_BeComparable()
        {
            var now = DateTime.Now;

            var date1 = new DayTime(now);
            var date2 = new DayTime(now);

            var isEqual = date1
                .Equals(date2);

            isEqual.Should().BeTrue();

            var date3 = new DayTime(now.AddDays(2));

            isEqual = date1
                .Equals(date3);

            isEqual.Should().BeFalse();
        }

        [Fact]
        public void Should_BeUseAsDictionaryKey()
        {
            var date = new DayTime(DateTime.Now);

            Assert.Throws<ArgumentException>(() => new Dictionary<DayTime, bool>
            {
                {date, true},
                {date, true }
            });

            var date2 = new DayTime(DateTime.Now.AddDays(2));

            var dictionary = new Dictionary<DayTime, bool>
            {
                {date, true},
                {date2, false}
            };

            dictionary[date].Should().BeTrue();
            dictionary[date2].Should().BeFalse();
        }
    }
}
