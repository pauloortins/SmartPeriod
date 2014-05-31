using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core
{
    public class SelectedCulturePtBr : ISelectedCulture
    {
        public DatePiece Year { get { return new YearPiece("ano", "anos"); } set { } }
        public DatePiece Month { get { return new MonthPiece("mês", "meses"); } set { } }
        public DatePiece Day { get { return new SecondPiece("dia", "dias"); } set { } }
        public DatePiece Hour { get { return new HourPiece("hora", "horas"); } set { } }
        public DatePiece Minute { get { return new MinutePiece("minuto", "minutos"); } set { } }
        public DatePiece Second { get { return new SecondPiece("segundo", "segundos"); } set { } }
    }
}