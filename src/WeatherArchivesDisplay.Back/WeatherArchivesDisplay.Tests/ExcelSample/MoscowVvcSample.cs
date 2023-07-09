using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherArchivesDisplay.Domain.Aggreagtes;
using WeatherArchivesDisplay.Domain.Services;

namespace WeatherArchivesDisplay.Tests.ExcelSample
{
    internal static class MoscowVvcSample
    {
        internal static IEnumerable<LogEntry> LogEntries
        {
            get
            {
                List<LogEntry> entries = new List<LogEntry>();

                var firstEntry = new LogEntryBuilder(new DateTime(2010, 01, 01, 0, 0, 0)).SetAirTemperature(-5.5f).SetAirHumidity(89).SetDewPoint(-6.9f)
                    .SetAtmospherePressure(737).SetWindDirection("З,ЮЗ").SetWindSpeed(1).SetCloadiness(100).SetCloudBase(800).SetWeatherConditions("Дымка").SetDataSource(1).Build();
                entries.Add(firstEntry);

                var secEntry = new LogEntryBuilder(new DateTime(2010, 01, 01, 3, 0, 0)).SetAirTemperature(-6f).SetAirHumidity(91).SetDewPoint(-7.1f)
                    .SetAtmospherePressure(738).SetWindDirection("штиль").SetWindSpeed(0).SetCloadiness(100).SetCloudBase(800).SetWeatherConditions("Дымка").SetDataSource(1).Build();
                entries.Add(secEntry);

                var thirdEntry = new LogEntryBuilder(new DateTime(2010, 02, 01, 0, 0, 0)).SetAirTemperature(-7.8f).SetAirHumidity(85).SetDewPoint(-9.6f)
                    .SetAtmospherePressure(748).SetWindDirection("В,ЮВ").SetWindSpeed(2).SetCloadiness(100).SetCloudBase(800).SetWeatherConditions("Дымка").SetDataSource(1).Build();
                entries.Add(thirdEntry);

                var fourthEntry = new LogEntryBuilder(new DateTime(2010, 02, 01, 3, 0, 0)).SetAirTemperature(-7.2f).SetAirHumidity(89).SetDewPoint(-8.5f)
                    .SetAtmospherePressure(746).SetWindDirection("В,ЮВ").SetWindSpeed(2).SetCloadiness(100).SetCloudBase(450).SetWeatherConditions("Непрерывный слабый снег")
                    .SetDataSource(1).Build();
                entries.Add(fourthEntry);

                return entries;
            }
        }
    }
}
