using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanFormatter.Core.DatePieces
{
    public class MinutePiece : DatePiece
    {
        public MinutePiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Minute;
        }

        public override string ToStr(TimeSpan span, bool showEmpty)
        {
            return DatePieceToString(span.Minutes,showEmpty);
        }

        public override TimeSpan Subtract(TimeSpan span)
        {
            return new TimeSpan(0, 0, span.Minutes, 0);
        }
    }
}
