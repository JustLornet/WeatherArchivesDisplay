using OfficeOpenXml;
using WeatherArchivesDisplay.Domain.Aggreagtes;

namespace WeatherArchivesDisplay.Infrastructure.Parsers.MoscowVvc
{
    public sealed class MoscowVvcParser : ParserBase
    {
        private readonly List<LogEntry> _parsedEntries;

        internal MoscowVvcParser(Stream stream) : base(stream)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            _parsedEntries = new List<LogEntry>();
        }

        /// <summary>
        /// Парсинн потока данных заданного шаблона в сущности для БД
        /// </summary>
        /// <param name="data">Данные для парсинга</param>
        public override IEnumerable<LogEntry> Parse()
        {
            using ExcelPackage excelFile = new(_stream);

            foreach (var sheet in excelFile.Workbook.Worksheets)
            {
                // проходим по каждой строке
                for (int i = sheet.Dimension.Start.Row; i <= sheet.Dimension.End.Row; i++)
                {
                    var isRowValid = RowTryParseDateTime(sheet, i, out DateTime? parsedDateTime);

                    if (!isRowValid) continue;

                    var entryBuilder = new MoscowVvcLogEntryBuilderAdapter((DateTime)parsedDateTime!);

                    // проходим по каждому столбцу в строке, кроме первых двух, которые отвечают за дату, которую уже записали
                    for (int j = sheet.Dimension.Start.Column + 2; j <= sheet.Dimension.End.Column; j++)
                    {
                        var currentCellValue = sheet.Cells[i, j].Value?.ToString();

                        // здесь передаем значение столбца относительно начала парсинга, то есть с 1
                        entryBuilder.SetValue(j - 2, currentCellValue);                        
                    }

                    var entry = entryBuilder.GetLogEntry();
                    _parsedEntries.Add(entry);
                }
             }

            return _parsedEntries;
        }

        private bool RowTryParseDateTime(ExcelWorksheet sheet, int rowNumber, out DateTime? parsedDateTime)
        {
            var startColumn = sheet.Dimension.Start.Column;

            // дата
            var startRowStartColumnValue = sheet.Cells[rowNumber, startColumn].Value?.ToString();
            var isDateParsed = DateTime.TryParseExact(startRowStartColumnValue, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate);

            if (!isDateParsed)
            {
                parsedDateTime = null;

                return false;
            }

            // время
            var startRowAfterStartColumnValue = sheet.Cells[rowNumber, startColumn + 1].Value?.ToString();
            var isTimeParsed = TimeSpan.TryParseExact(startRowAfterStartColumnValue, "hh\\:mm", null, out TimeSpan parsedTime);

            if (!isTimeParsed)
            {
                parsedDateTime = null;

                return false;
            }

            parsedDateTime = parsedDate.Date + parsedTime;

            return true;
        }
    }
}
