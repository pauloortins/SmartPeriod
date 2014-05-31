using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core
{
    public class SmartPeriod
    {
        private bool _showEmpty;
        private DateTime _startDate;       
        private DateTime _endDate;       
        private ISelectedCulture _selectedCulture;
        private List<DatePiece> _datePieces = new List<DatePiece>();
        
        public SmartPeriod(DateTime startDate, DateTime endDate)
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
  
        public SmartPeriod Date()
        {
            return Years().Months().Days();
        }

        public SmartPeriod Time()
        {
            return Hours().Minutes().Seconds();
        }

        public SmartPeriod DateTime()
        {
            return Date().Time();
        }

        public SmartPeriod Years()
        {
            _datePieces.Add(_selectedCulture.Year);            
            return this;
        }

        public SmartPeriod Months()
        {
            _datePieces.Add(_selectedCulture.Month);
            return this;
        }

        public SmartPeriod Days()
        {
            _datePieces.Add(_selectedCulture.Day);
            return this;
        }

        public SmartPeriod Hours()
        {
            _datePieces.Add(_selectedCulture.Hour);
            return this;
        }

        public SmartPeriod Minutes()
        {
            _datePieces.Add(_selectedCulture.Minute);
            return this;
        }

        public SmartPeriod Seconds()
        {
            _datePieces.Add(_selectedCulture.Second);
            return this;
        }

        public SmartPeriod ShowEmpty()
        {
            _showEmpty = true;
            return this;
        }

        public SmartPeriod Culture(ISelectedCulture selectedCulture)
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