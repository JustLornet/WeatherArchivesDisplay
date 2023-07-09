using System.Text.Json;
using WeatherArchivesDisplay.Controllers.Utils;
using WeatherArchivesDisplay.Infrastructure.Parsers.MoscowVvc;
using WeatherArchivesDisplay.Tests.ExcelSample;

namespace WeatherArchivesDisplay.Tests.Unit
{
    [TestFixture]
    public class ParsersTests
    {
        private Stream _stream;

        [SetUp]
        public void CreateFileStream()
        {
            var sampleName = "MoscowVvcSampleReport.xlsx";
            var sampleFullPath = Path.Combine(ReadAppSettings.GetAssembleDirectory(), "ExcelSample", sampleName);

            _stream = new FileStream(sampleFullPath, FileMode.Open);
        }

        [TearDown]
        public void DisposeStreamAfterTest()
        {   
            _stream.Dispose();
        }

        [Test]
        public void MoscowVvcParser()
        {
            // arrange
            var parser = new MoscowVvcParser(_stream);

            // act
             var parsedData = parser.Parse();

            Assert.That(JsonSerializer.Serialize(parsedData), Is.EqualTo(JsonSerializer.Serialize(MoscowVvcSample.LogEntries)));
        }
    }
}