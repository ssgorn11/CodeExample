using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта TimeIntervalTypeEntity
    /// </summary>
    internal class TimeIntervalTypeConfiguration : IEntityTypeConfiguration<TimeIntervalTypeEntity>
    {
        public void Configure(EntityTypeBuilder<TimeIntervalTypeEntity> builder)
        {
            builder.ToTable("TimeIntervalType").HasKey(d => d.Id);
        }
    }
}
