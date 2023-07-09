using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using WeatherArchivesDisplay.Domain.Aggreagtes.Utils;

namespace WeatherArchivesDisplay.Domain.Aggreagtes
{
    public sealed class DataSource : EntityBase, IEntityTypeConfiguration<DataSource>
    {
        /// <summary>
        /// Название метеостанции
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Атм. давление на высоте метеостанции над уровнем моря, м
        /// </summary>
        public int StationHeight { get; set; }

        /// <summary>
        /// Записи от данной метеостанции
        /// </summary>
        public IEnumerable<LogEntry> LogEntries { get; set; } = null!;

        public void Configure(EntityTypeBuilder<DataSource> builder)
        {
            builder.HasData(
                new DataSource()
                {
                    Id = DataSourceIds.MoscowVvc,
                    Name = "Метеостанция \"Москва, ВВЦ\"",
                    StationHeight = 156,
                });
        }
    }
}
