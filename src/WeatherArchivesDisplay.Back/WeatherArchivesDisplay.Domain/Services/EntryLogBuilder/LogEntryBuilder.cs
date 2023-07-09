using WeatherArchivesDisplay.Domain.Aggreagtes;

namespace WeatherArchivesDisplay.Domain.Services
{
    public sealed class LogEntryBuilder
    {
        private readonly LogEntry _logEntry;

        public LogEntryBuilder(DateTime dateTime)
        {
            _logEntry = new(dateTime);
        }

        public LogEntryBuilder SetAirTemperature(float temperature)
        {
            _logEntry.AirTemperature = temperature;
         
            return this;
        }

        public LogEntryBuilder SetAirHumidity(float humidity)
        {
            _logEntry.AirHumidity = humidity;
         
            return this;
        }

        public LogEntryBuilder SetDewPoint(float dewPoint)
        {
            _logEntry.DewPoint = dewPoint;
         
            return this;
        }

        public LogEntryBuilder SetAtmospherePressure(short pressure)
        {
            _logEntry.AtmospherePressure = pressure;
         
            return this;
        }

        public LogEntryBuilder SetWindDirection(string direction)
        {
            _logEntry.WindDirection = direction;
         
            return this;
        }

        public LogEntryBuilder SetWindSpeed(short speed)
        {
            _logEntry.WindSpeed = speed;
         
            return this;
        }

        public LogEntryBuilder SetCloadiness(byte cloudiness)
        {
            _logEntry.Cloudiness = cloudiness;
         
            return this;
        }

        public LogEntryBuilder SetCloudBase(short height)
        {
            _logEntry.CloudBase = height;
        
            return this;
        }

        public LogEntryBuilder SetHorizontalVisibility(string visibility)
        {
            _logEntry.HorizontalVisibility = visibility;
        
            return this;
        }

        public LogEntryBuilder SetWeatherConditions(string description)
        {
            _logEntry.WeatherConditions = description;

            return this;
        }

        public LogEntryBuilderFinal SetDataSource(DataSource dataSource)
        {
            _logEntry.DataSource = dataSource;

            return new LogEntryBuilderFinal(_logEntry);
        }

        public LogEntryBuilderFinal SetDataSource(long dataSourceId)
        {
            _logEntry.DataSourceId = dataSourceId;

            return new LogEntryBuilderFinal(_logEntry);
        }
    }
}