using System;

namespace SpanFormatter.Core
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
        public abstract string ToStr(TimeSpan span, bool showEmpty);
        public abstract TimeSpan Subtract(TimeSpan span);

        public string Singular { get; set; }
        public string Plural { get; set; }
    }
}