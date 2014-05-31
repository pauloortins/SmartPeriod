using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanFormatter.Core.DatePieces
{
    public class SecondPiece : DatePiece
    {
        public SecondPiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Second;
        }

        public override string ToStr(TimeSpan span, bool showEmpty)
        {
            return DatePieceToString(span.Seconds, showEmpty);
        }

        public override TimeSpan Subtract(TimeSpan span)
        {
            return new TimeSpan(0, 0, 0, span.Seconds);
        }
    }
}
