using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core
{
    public static class PeriodFormatter
    {
        public static Formatter Date()
        {
            return new Formatter().Date();
        }

        public static Formatter Time()
        {
            return new Formatter().Time();
        }

        public static Formatter DateTime()
        {
            return new Formatter().Date().Time();
        }

        public static Formatter Years()
        {
            return new Formatter().Years();
        }

        public static Formatter Months()
        {
            return new Formatter().Months();
        }

        public static Formatter Days()
        {
            return new Formatter().Days();
        }

        public static Formatter Hours()
        {
            return new Formatter().Hours();
        }

        public static Formatter Minutes()
        {
            return new Formatter().Minutes();
        }

        public static Formatter Seconds()
        {
            return new Formatter().Seconds();
        }
    }

    public class Formatter
    {
        private bool _showEmpty;
        private ISelectedCulture _selectedCulture;
        private List<DatePiece> _datePieces = new List<DatePiece>();

        public Formatter()
        {
            _showEmpty = false;
            _selectedCulture = GetCulture();
        }

        public Formatter Date()
        {
            return Years().Months().Days();
        }

        public Formatter Time()
        {
            return Hours().Minutes().Seconds();
        }

        public Formatter DateTime()
        {
            return Date().Time();
        }

        public Formatter Years()
        {
            _datePieces.Add(_selectedCulture.Year);
            return this;
        }

        public Formatter Months()
        {
            _datePieces.Add(_selectedCulture.Month);
            return this;
        }

        public Formatter Days()
        {
            _datePieces.Add(_selectedCulture.Day);
            return this;
        }

        public Formatter Hours()
        {
            _datePieces.Add(_selectedCulture.Hour);
            return this;
        }

        public Formatter Minutes()
        {
            _datePieces.Add(_selectedCulture.Minute);
            return this;
        }

        public Formatter Seconds()
        {
            _datePieces.Add(_selectedCulture.Second);
            return this;
        }

        public Formatter ShowEmpty()
        {
            _showEmpty = true;
            return this;
        }

        public Formatter Culture(ISelectedCulture selectedCulture)
        {
            _selectedCulture = selectedCulture;

            _datePieces = _datePieces.Select(x => x.ChangeCulture(selectedCulture)).ToList();
            return this;
        }

        private ISelectedCulture GetCulture()
        {
            var cultureInfo = CultureInfo.CurrentCulture;

            switch (cultureInfo.Name)
            {
                case "en-US": return new SelectedCultureEnUs();
                case "pt-BR": return new SelectedCultureEnUs();
            }

            return new SelectedCultureEnUs();
        }

        public string ToString(DateTime startDate, DateTime endDate)
        {
            var str = string.Empty;

            _datePieces.ForEach(x =>
            {
                str += x.ToStr(startDate, endDate, _showEmpty);
                startDate = x.Subtract(startDate, endDate);
            });

            if (str.EndsWith(", "))
                str = str.Substring(0, str.Length - 2);

            return str;
        }
    }
}
