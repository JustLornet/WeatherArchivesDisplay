using WeatherArchivesDisplay.Domain.Aggreagtes;

namespace WeatherArchivesDisplay.Infrastructure.Parsers
{
    public abstract class ParserBase
    {
        protected readonly Stream _stream;

        internal ParserBase(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Парсинг передаваемой инфорамции из объекта Stream
        /// </summary>
        /// <returns>Коллекция записей погоды</returns>
        public abstract IEnumerable<LogEntry> Parse();
    }
}
