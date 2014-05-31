using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanFormatter.Core.DatePieces
{
    public class MonthPiece : DatePiece
    {
        public MonthPiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Month;
        }

        public override string ToStr(TimeSpan span, bool showEmpty)
        {
            return DatePieceToString(span.GetMonths() % 12, showEmpty);
        }

        public override TimeSpan Subtract(TimeSpan span)
        {
            return new TimeSpan((int)Math.Round(30.436875 * span.GetMonths()), 0, 0, 0);
        }
    }
}
