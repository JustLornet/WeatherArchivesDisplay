using Microsoft.EntityFrameworkCore;
using WeatherArchivesDisplay.Controllers.Utils;
using WeatherArchivesDisplay.DataAccess;

namespace WeatherArchivesDisplay.Tests.Integration
{
    [TestFixture]
    public class DbTests
    {
        private readonly DbContextOptions<Db> _contextOptions;
        private Db _database;

        public DbTests()
        {
            var connectionString = ReadAppSettings.GetConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<Db>();
            _contextOptions = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        [SetUp]
        // Обновление контекста бд перед каждым тестом
        public void InitDbContext()
        {
            if (_database is not null)
                _database.Dispose();

            _database = new Db(_contextOptions);
        }

        [Test]
        public void TestConnection()
        {
            // arrange
            var canConnect = _database.Database.CanConnect();

            //assert
            Assert.That(canConnect, Is.True);
        }
    }
}
