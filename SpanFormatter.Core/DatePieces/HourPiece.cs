using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanFormatter.Core.DatePieces
{
    public class HourPiece : DatePiece
    {
        public HourPiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Hour;
        }

        public override string ToStr(TimeSpan span, bool showEmpty)
        {
            return DatePieceToString(span.Hours, showEmpty);
        }

        public override TimeSpan Subtract(TimeSpan span)
        {
            return new TimeSpan(0, span.Hours, 0, 0);
        }
    }
}
