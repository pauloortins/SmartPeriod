using System;
using SmartPeriod.Core;

namespace SmartPeriod.Core.DatePieces
{
    public abstract class DatePiece
    {
        public DatePiece(string singular, string plural)
        {
            Singular = singular;
            Plural = plural;
        }

        public string DatePieceToString(int value, bool showEmpty)
        {
            if (value > 1)
                return value + " " + this.Plural + ", ";

            if (value == 1)
                return value + " " + this.Singular + ", ";            

            if (showEmpty)
            {
                return value + " " + this.Plural + ", ";
            }

            return string.Empty;
        }

        public abstract DatePiece ChangeCulture(ISelectedCulture culture);
        public abstract string ToStr(DateTime startDate, DateTime endDate, bool showEmpty);
        public abstract DateTime Subtract(DateTime startDate, DateTime endDate);

        public string Singular { get; set; }
        public string Plural { get; set; }
    }
}