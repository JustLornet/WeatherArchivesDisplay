namespace WeatherArchivesDisplay.Controllers.Utils
{
    [Serializable]
    public sealed class DateTimeFilters
    {
        private DateTime _startDateTime;
        private DateTime _endDateTime;

        public string Start { get; set; }

        public string End { get; set; }

        internal DateTime StartDateTime
        {
            get
            {
                if (_startDateTime == default)
                {
                    _startDateTime = DateTimeOffset.Parse(Start).UtcDateTime;
                    //var isParsed = DateTime.TryParse(Start, out _startDateTime);

                    //if (!isParsed) throw new InvalidCastException("Не удалось распарсить данные с фронта");
                }

                return _startDateTime;
            }
        }

        internal DateTime EndDateTime
        {
            get
            {
                if (_endDateTime == default)
                {
                    _endDateTime = DateTimeOffset.Parse(End).UtcDateTime;
                    //var isParsed = DateTime.TryParse(Start, out _endDateTime);

                    //if (!isParsed) throw new InvalidCastException("Не удалось распарсить данные с фронта");
                }

                return _endDateTime;
            }
        }
    }
}
