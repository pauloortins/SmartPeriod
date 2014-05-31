using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartPeriod.Core;

namespace SmartPeriod.Tests
{
    [TestClass]
    public class PeriodFormatterTests
    {
        private Core.Period CreatePeriod(DateTime endDate, DateTime startDate)
        {            
            return new Core.Period(startDate, endDate);
        }

        [TestMethod]
        public void Should_Format_Date_With_A_Exact_Year_Correctly()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Years().Months().Days()).Should().Be("1 year");                        
        }

        [TestMethod]
        public void Should_Format_Date_With_More_Than_A_Year_But_In_Months_Correctly()
        {
            var aDate = new DateTime(2014, 1, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Months()).Should().Be("13 months");
        }
        
        [TestMethod]
        public void Should_Format_Date_With_Two_Years_Correctly()
        {
            var aDate = new DateTime(2014, 2, 2);
            var aDateTwoYearsAgo = new DateTime(2012, 2, 2);

            CreatePeriod(aDate, aDateTwoYearsAgo).ToString(PeriodFormatter.Years().Months().Days()).Should().Be("2 years");            
        }

        [TestMethod]
        public void Should_Format_Date_With_Multiple_Months()
        {
            var aDate = new DateTime(2013, 2, 1);
            var anotherDate = new DateTime(2012, 3, 1);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Date()).Should().Be("11 months");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_A_Month_Properly()
        {
            var aDate = new DateTime(2014, 2, 2);
            var anotherDate = new DateTime(2014, 1, 2);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Date()).Should().Be("1 month");            
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_A_Day_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = new DateTime(2014, 10, 3);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Date()).Should().Be("1 day");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_Days_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = new DateTime(2014, 10, 2);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Date()).Should().Be("2 days");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_A_Hour_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = aDate.AddHours(-1);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Time()).Should().Be("1 hour");            
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_Hours_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = aDate.AddHours(-2);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Time()).Should().Be("2 hours");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_A_Minute_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = aDate.AddMinutes(-1);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Time()).Should().Be("1 minute");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_Minutes_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = aDate.AddMinutes(-2);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Time()).Should().Be("2 minutes");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_A_Second_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = aDate.AddSeconds(-1);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Time()).Should().Be("1 second");
        }

        
        [TestMethod]
        public void When_Converting_ToMoreSignificantTimeString_Should_Convert_Seconds_Properly()
        {
            var aDate = new DateTime(2014, 10, 4);
            var anotherDate = aDate.AddSeconds(-2);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Time()).Should().Be("2 seconds");
        }
        
        [TestMethod]
        public void Should_Format_Full_Date_Correctly()
        {
            var aDate = new DateTime(2014, 7, 9);
            var anotherDate = new DateTime(2012, 3, 3);

            CreatePeriod(aDate, anotherDate).ToString(PeriodFormatter.Years().Months().Days()).Should().Be("2 years, 4 months, 6 days");
        }

        [TestMethod]
        public void Should_Format_Full_Date_Showing_Empty_Values_Correctly()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Years().Months().Days().ShowEmpty()).Should().Be("1 year, 0 months, 0 days");
        }

        [TestMethod]
        public void Should_Be_Able_To_Select_Culture()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Years().Months().Days().ShowEmpty().Culture(new SelectedCulturePtBr())).Should().Be("1 ano, 0 meses, 0 dias");
        }

        [TestMethod]
        public void Date_Should_Be_A_ShortCut_For_Year_Month_Day()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            var full = CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Years().Months().Days());
            var shortCut = CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Date());

            full.Should().Be(shortCut);
        }

        [TestMethod]
        public void Time_Should_Be_A_ShortCut_For_Hour_Minute_Second()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            var full = CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Hours().Minutes().Seconds());
            var shortCut = CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Time());

            full.Should().Be(shortCut);
        }

        [TestMethod]
        public void Time_Should_Be_A_ShortCut_For_Year_Month_Second_Hour_Minute_Second()
        {
            var aDate = new DateTime(2013, 12, 12,3,2,1);
            var aDateYearAgo = new DateTime(2012, 12, 12,6,5,4);

            var full = CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.DateTime());
            var shortCut = CreatePeriod(aDate, aDateYearAgo).ToString(PeriodFormatter.Date().Time());

            full.Should().Be(shortCut);
        }
    }
}
