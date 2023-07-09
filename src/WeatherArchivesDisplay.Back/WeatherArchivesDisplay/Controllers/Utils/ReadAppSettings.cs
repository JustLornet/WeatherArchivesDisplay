using System.Reflection;

namespace WeatherArchivesDisplay.Controllers.Utils
{
    internal static class ReadAppSettings
    {
        internal static string GetAssembleDirectory()
        {
            var dllPath = Assembly.GetExecutingAssembly().Location;
            var dllDirectory = Path.GetDirectoryName(dllPath)!;

            return dllDirectory;
        }

        internal static string GetConnectionString(string database = "SqlServer")
        {
            var settingsBuilder = new ConfigurationBuilder();
            var config = settingsBuilder.SetBasePath(ReadAppSettings.GetAssembleDirectory()).AddJsonFile("appsettings.json").Build();

            var cnString = config.GetConnectionString(database);

            if (string.IsNullOrEmpty(cnString))
                throw new KeyNotFoundException($"База данных с именем {database} не была найдена");

            return cnString;
        }
    }
}
