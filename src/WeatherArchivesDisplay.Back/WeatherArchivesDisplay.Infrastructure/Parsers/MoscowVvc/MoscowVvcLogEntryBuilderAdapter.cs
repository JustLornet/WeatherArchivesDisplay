using WeatherArchivesDisplay.Domain.Aggreagtes;
using WeatherArchivesDisplay.Domain.Aggreagtes.Utils;
using WeatherArchivesDisplay.Domain.Services;

namespace WeatherArchivesDisplay.Infrastructure.Parsers.MoscowVvc
{
    internal sealed class MoscowVvcLogEntryBuilderAdapter
    {
        private readonly LogEntryBuilder _logEntryBuilder;

        /// <summary>
        /// Адаптер для присвоения свойств из отчетов метеостанции `Москва ВВЦ` в цикле по номеру столбца в таблице эксель
        /// </summary>
        /// <param name="dateTime">Дата и время замера</param>
        public MoscowVvcLogEntryBuilderAdapter(DateTime dateTime)
        {
            _logEntryBuilder = new(dateTime);
        }

        public LogEntry GetLogEntry()
        {
            return _logEntryBuilder.SetDataSource(DataSourceIds.MoscowVvc).Build();
        }

        /// <summary>
        /// Установка значения в запись
        /// </summary>
        /// <param name="valueNumber">Номер столбца в таблице Эксель, чье значение записывается (без учета столбцов с датой)</param>
        /// <param name="value">Значение, которое будет приведено к нужному типу и записано</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetValue(int valueNumber, string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;

            bool isParsed = true;

            switch (valueNumber)
            {
                case 1:
                    isParsed = float.TryParse(value, out float temperature);

                    if (!isParsed) break;

                    _logEntryBuilder.SetAirTemperature(temperature);
                    break;

                case 2:
                    isParsed = float.TryParse(value, out float humidity);

                    if (!isParsed) break;

                    _logEntryBuilder.SetAirHumidity(humidity);
                    break;

                case 3:
                    isParsed = float.TryParse(value, out float dewPoint);

                    if (!isParsed) break;

                    _logEntryBuilder.SetDewPoint(dewPoint);
                    break;

                case 4:
                    isParsed = Int16.TryParse(value, out short pressure);

                    if (!isParsed) break;

                    _logEntryBuilder.SetAtmospherePressure(pressure);
                    break;

                case 5:
                    _logEntryBuilder.SetWindDirection(value);
                    break;

                case 6:
                    isParsed = Int16.TryParse(value, out short windSpeed);

                    if (!isParsed) break;

                    _logEntryBuilder.SetWindSpeed(windSpeed);
                    break;

                case 7:
                    isParsed = byte.TryParse(value, out byte cloudiness);

                    if (!isParsed) break;

                    _logEntryBuilder.SetCloadiness(cloudiness);
                    break;

                case 8:
                    isParsed = Int16.TryParse(value, out short cloudBase);

                    if (!isParsed) break;

                    _logEntryBuilder.SetCloudBase(cloudBase);
                    break;

                case 9:
                    _logEntryBuilder.SetHorizontalVisibility(value);
                    break;

                case 10:
                    _logEntryBuilder.SetWeatherConditions(value);
                    break;

                default:
                    throw new NotImplementedException($"Действия для столбца с номером отсноительно начала парсинга {valueNumber} отсутствуют");
            }

            if (!isParsed) throw new InvalidCastException($"Не удалось привести данные из столбца {valueNumber} относительно начала парсинга к требуемому типу. Исодное значение: {value}");
        }
    }
}
