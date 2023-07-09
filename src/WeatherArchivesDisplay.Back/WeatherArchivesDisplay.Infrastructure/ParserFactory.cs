using WeatherArchivesDisplay.Domain.Aggreagtes.Utils;
using WeatherArchivesDisplay.Infrastructure.Parsers;
using WeatherArchivesDisplay.Infrastructure.Parsers.MoscowVvc;

namespace WeatherArchivesDisplay.Infrastructure
{
    public static class ParserFactory
    {
        private static readonly Dictionary<long, Func<Stream, ParserBase>> _parsers = new()
        {
            { DataSourceIds.MoscowVvc, (stream) => new MoscowVvcParser(stream) }
        };

        public static ParserBase GetParser(long dataSourceId, Stream data)
        {
            if(!_parsers.ContainsKey(dataSourceId))
                throw new NotImplementedException("Парсерс для выбранной метеостанции отсутствует");

            return _parsers[dataSourceId](data);
        }
    }
}
