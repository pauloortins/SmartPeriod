using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpanFormatter.Core;

namespace SpanFormatter.Tests
{
    [TestClass]
    public class SpanFormatterTests
    {
        [TestMethod]
        public void Should_Format_Date_With_A_Exact_Year_Correctly()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            new Core.SpanFormatter(aDate - aDateYearAgo).Years().Months().Days().ToString().Should().Be("1 year");            
        }
        
        [TestMethod]
        public void Should_Format_Date_With_Two_Years_Correctly()
        {
            var aDate = new DateTime(2014, 2, 2);
            var aDateTwoYearsAgo = new DateTime(2012, 2, 2);

            new Core.SpanFormatter(aDate - aDateTwoYearsAgo).Years().Months().Days().ToString().Should().Be("2 years, 1 day");            
        }
        
        [TestMethod]
        public void Should_Format_Full_Date_Correctly()
        {
            var aDate = new DateTime(2014, 7, 9);
            var anotherDate = new DateTime(2012, 3, 3);

            new Core.SpanFormatter(aDate - anotherDate).Years().Months().Days().ToString().Should().Be("2 years, 4 months, 6 days");
        }

        [TestMethod]
        public void Should_Format_Full_Date_Showing_Empty_Values_Correctly()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            new Core.SpanFormatter(aDate - aDateYearAgo).Years().Months().Days().ShowEmpty().ToString().Should().Be("1 year, 0 months, 0 days");
        }

        [TestMethod]
        public void Should_Be_Able_To_Select_Culture()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            new Core.SpanFormatter(aDate - aDateYearAgo).Years().Months().Days().ShowEmpty().Culture(new SelectedCulturePtBr()).ToString().Should().Be("1 ano, 0 meses, 0 dias");
        }

        [TestMethod]
        public void Date_Should_Be_A_ShortCut_For_Year_Month_Day()
        {
            var aDate = new DateTime(2013, 12, 12);
            var aDateYearAgo = new DateTime(2012, 12, 12);

            var full = new Core.SpanFormatter(aDate - aDateYearAgo).Years().Months().Days().ToString();
            var shortCut = new Core.SpanFormatter(aDate - aDateYearAgo).Date().ToString();

            full.Should().Be(shortCut);
        }
    }
}
