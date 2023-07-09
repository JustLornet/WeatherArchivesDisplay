using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace WeatherArchivesDisplay.Domain.Aggreagtes
{
    public sealed class LogEntry : EntityBase, IEntityTypeConfiguration<LogEntry>
    {
        internal LogEntry(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public LogEntry() { }

        /// <summary>
        /// Дата и время замера
        /// </summary>
        public DateTime DateTime { get; internal set; }

        /// <summary>
        /// Температура воздуха, гр.Ц.
        /// </summary>
        public float? AirTemperature { get; internal set; }

        /// <summary>
        /// Влажность воздуха, %
        /// </summary>
        public float? AirHumidity {  get; internal set; }

        /// <summary>
        /// Точка росы, гр.Ц.
        /// </summary>
        public float? DewPoint { get; internal set; }

        /// <summary>
        /// Атмосферное давление, мм.рт.ст.
        /// </summary>
        public short? AtmospherePressure { get; internal set; }

        /// <summary>
        /// Направление ветра
        /// </summary>
        public string? WindDirection { get; internal set; } = null!;

        /// <summary>
        /// Скорость ветра, м/с
        /// </summary>
        public short? WindSpeed { get; internal set; }

        /// <summary>
        /// Облачность, %
        /// </summary>
        public byte? Cloudiness { get; internal set; }
        
        /// <summary>
        /// Нижняя граница облачности, м
        /// </summary>
        public short? CloudBase { get; internal set; }

        /// <summary>
        /// Горизонтальная видимость, км
        /// </summary>
        public string? HorizontalVisibility { get; internal set; }

        /// <summary>
        /// Погодные явления
        /// </summary>
        public string? WeatherConditions { get; internal set; }

        /// <summary>
        /// Информация по источнику данных - метеостанции
        /// </summary>
        public long DataSourceId { get; internal set; }
        public DataSource DataSource { get; internal set; } = null!;

        public void Configure(EntityTypeBuilder<LogEntry> builder)
        {
            builder.HasOne(p => p.DataSource).WithMany(p => p.LogEntries).HasForeignKey(p => p.DataSourceId).OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => p.DateTime).IsUnique();
        }
    }
}
