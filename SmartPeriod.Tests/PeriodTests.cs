using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPeriod.Core;

namespace SmartPeriod.Tests
{
    [TestClass]
    public class PeriodTests
    {
        private Period _period;

        [TestInitialize]
        public void TestInit()
        {
            _period = new Period(new DateTime(2013, 5 , 10, 5 , 40, 30), new DateTime(2014, 10, 20, 10, 50 , 40));
        }

        [TestMethod]
        public void Should_Have_Years_Correctly()
        {
            _period.Years.Should().Be(1);
        }

        [TestMethod]
        public void Should_Have_Months_Correctly()
        {
            _period.Months.Should().Be(5);
        }

        [TestMethod]
        public void Should_Have_Days_Correctly()
        {
            _period.Days.Should().Be(10);
        }

        [TestMethod]
        public void Should_Have_Hours_Correctly()
        {
            _period.Hours.Should().Be(5);
        }

        [TestMethod]
        public void Should_Have_Minutes_Correctly()
        {
            _period.Minutes.Should().Be(10);
        }

        [TestMethod]
        public void Should_Have_Seconds_Correctly()
        {
            _period.Seconds.Should().Be(10);
        }
    }
}
