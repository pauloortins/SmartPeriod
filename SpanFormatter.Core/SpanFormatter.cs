using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SpanFormatter.Core.DatePieces;

namespace SpanFormatter.Core
{
    public class SpanFormatter
    {
        private bool _showEmpty;
        private DateTime _startDate;       
        private DateTime _endDate;       
        private ISelectedCulture _selectedCulture;
        private List<DatePiece> _datePieces = new List<DatePiece>();
        
        public SpanFormatter(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            _selectedCulture = GetCulture();            
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
  
        public SpanFormatter Date()
        {
            return Years().Months().Days();
        }

        public SpanFormatter Time()
        {
            return Hours().Minutes().Seconds();
        }

        public SpanFormatter DateTime()
        {
            return Date().Time();
        }

        public SpanFormatter Years()
        {
            _datePieces.Add(_selectedCulture.Year);            
            return this;
        }

        public SpanFormatter Months()
        {
            _datePieces.Add(_selectedCulture.Month);
            return this;
        }

        public SpanFormatter Days()
        {
            _datePieces.Add(_selectedCulture.Day);
            return this;
        }

        public SpanFormatter Hours()
        {
            _datePieces.Add(_selectedCulture.Hour);
            return this;
        }

        public SpanFormatter Minutes()
        {
            _datePieces.Add(_selectedCulture.Minute);
            return this;
        }

        public SpanFormatter Seconds()
        {
            _datePieces.Add(_selectedCulture.Second);
            return this;
        }

        public SpanFormatter ShowEmpty()
        {
            _showEmpty = true;
            return this;
        }

        public SpanFormatter Culture(ISelectedCulture selectedCulture)
        {
            _selectedCulture = selectedCulture;

            _datePieces = _datePieces.Select(x => x.ChangeCulture(selectedCulture)).ToList();
            return this;
        }

        public override string ToString()
        {
            var str = string.Empty;

            _datePieces.ForEach(x =>
                {
                    str += x.ToStr(_startDate, _endDate, _showEmpty);
                    _startDate = x.Subtract(_startDate, _endDate);
                });

            if (str.EndsWith(", "))
                str = str.Substring(0, str.Length - 2);

            return str;
        }
    }
}