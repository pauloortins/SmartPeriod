using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core
{
    public class Period
    {        
        private DateTime _startDate;       
        private DateTime _endDate;               
        
        public Period(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;

            var yearPiece = new YearPiece(string.Empty, string.Empty);
            _years = yearPiece.CalculateYears(startDate, endDate);
            startDate = yearPiece.Subtract(startDate, endDate);

            var monthPiece = new MonthPiece(string.Empty, string.Empty);
            _months = monthPiece.CalculateMonths(startDate, endDate);
            startDate = monthPiece.Subtract(startDate, endDate);

            var dayPiece = new DayPiece(string.Empty, string.Empty);
            _days = dayPiece.CalculateDays(startDate, endDate);
            startDate = dayPiece.Subtract(startDate, endDate);

            var hourPiece = new HourPiece(string.Empty, string.Empty);
            _hours = hourPiece.CalculateHours(startDate, endDate);
            startDate = hourPiece.Subtract(startDate, endDate);

            var minutePiece = new MinutePiece(string.Empty, string.Empty);
            _minutes = minutePiece.CalculateMinutes(startDate, endDate);
            startDate = minutePiece.Subtract(startDate, endDate);

            var secondPiece = new SecondPiece(string.Empty, string.Empty);
            _seconds = secondPiece.CalculateSeconds(startDate, endDate);
            startDate = secondPiece.Subtract(startDate, endDate);
        }

        private readonly int _years;
        public int Years
        {
            get
            {                
                return _years;
            }
        }

        private readonly int _months;
        public int Months
        {
            get
            {                
                return _months;
            }
        }

        private readonly int _days;
        public int Days
        {
            get
            {
                return _days;
            }
        }

        private readonly int _hours;
        public int Hours
        {
            get
            {
                return _hours;
            }
        }

        private readonly int _minutes;
        public int Minutes
        {
            get
            {
                return _minutes;
            }
        }

        private readonly int _seconds;
        public int Seconds
        {
            get
            {
                return _seconds;
            }
        }

        public string ToString(Formatter formatter)
        {
            return formatter.ToString(_startDate, _endDate);
        }
    }
}