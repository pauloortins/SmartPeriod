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

        public override string ToStr(TimeSpan span, bool showEmpty)
        {
            return DatePieceToString(span.GetYears(), showEmpty);
        }

        public override TimeSpan Subtract(TimeSpan span)
        {
            return new TimeSpan((int)Math.Round(365.2425 * span.GetYears()), 0, 0, 0);   
        }        
    }
}
