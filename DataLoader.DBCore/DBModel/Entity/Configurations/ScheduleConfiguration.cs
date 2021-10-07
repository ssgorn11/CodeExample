using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта ScheduleEntity
    /// </summary>
    internal class ScheduleConfiguration : IEntityTypeConfiguration<ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
        {
            builder.ToTable("Schedule", "dbo").HasKey(d => d.Id);
        }
    }
}
