using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта Tag2ScheduleEntity
    /// </summary>
    internal class Tag2ScheduleConfiguration : IEntityTypeConfiguration<Tag2ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<Tag2ScheduleEntity> builder)
        {
            builder.ToTable("Tag2Schedule").HasKey(d => d.Id);
            builder.HasIndex(x => x.IdTag);
            builder.HasIndex(x => x.IdSchedule);
        }
    }
}
