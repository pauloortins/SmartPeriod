using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanFormatter.Core.DatePieces
{
    public class DayPiece : DatePiece
    {
        public DayPiece(string singular, string plural) : base(singular, plural)
        {

        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Day;
        }

        public override string ToStr(TimeSpan span, bool showEmpty)
        {
            return DatePieceToString(span.Days, showEmpty);
        }

        public override TimeSpan Subtract(TimeSpan span)
        {
            return new TimeSpan(span.Days, 0, 0, 0);
        }
    }
}
