using Microsoft.AspNetCore.Mvc;
using WeatherArchivesDisplay.DataAccess;
using WeatherArchivesDisplay.Infrastructure;

namespace WeatherArchivesDisplay.Controllers
{
    public class ArchivesImportPageController : Controller
    {
        private readonly Db _db;
        private AutoResetEvent _wait = new(true);

        public ArchivesImportPageController(Db db)
        {
            _db = db;
        }

        /// <summary>
        /// Загрузка коллекции файлов excel и последуюющий парсинг в бд
        /// </summary>
        /// <param name="data">Загружаемая коллекция файлов</param>
        [HttpPost]
        public async Task<ActionResult> UploadFiles([FromQuery(Name = "id")] int dataSourceId, [FromForm(Name = "data")] IFormFileCollection data)
        {
            if (data is null) return BadRequest("Отправленный файл не был получен");

            try
            {
                // парсинг данных
                Parallel.ForEach(data, (file) => ParseAndSetDataToDb(dataSourceId, file.OpenReadStream()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        private void ParseAndSetDataToDb(long dataSourceId, Stream stream)
        {
            var parser = ParserFactory.GetParser(dataSourceId, stream);

            var entries = parser.Parse();

            _wait.WaitOne();

            // запись в бд
            _db.LogEntries.AddRange(entries);
            _db.SaveChanges();

            _wait.Set();
        }
    }
}
