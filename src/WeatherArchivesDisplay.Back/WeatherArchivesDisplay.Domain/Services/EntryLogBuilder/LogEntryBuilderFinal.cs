using WeatherArchivesDisplay.Domain.Aggreagtes;

namespace WeatherArchivesDisplay.Domain.Services
{
    public sealed class LogEntryBuilderFinal
    {
        private readonly LogEntry _logEntry;

        internal LogEntryBuilderFinal(LogEntry logEntry)
        {
            _logEntry = logEntry;
        }

        public LogEntry Build()
        {
            return _logEntry;
        }
    }
}