using System;

namespace SpanFormatter.Core.DatePieces
{
    public class YearPiece : DatePiece
    {
        public YearPiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Year;
        }

        public int CalculateYears(DateTime startDate, DateTime endDate)
        {
            var years = 0;

            while (startDate.AddYears(1) <= endDate)
            {
                startDate = startDate.AddYears(1);
                years += 1;
            }

            return years;
        }

        public override string ToStr(DateTime startDate, DateTime endDate, bool showEmpty)
        {
            return DatePieceToString(CalculateYears(startDate,endDate), showEmpty);
        }

        public override DateTime Subtract(DateTime startDate, DateTime endDate)
        {
            return startDate.AddYears(CalculateYears(startDate, endDate));
        }        
    }
}
