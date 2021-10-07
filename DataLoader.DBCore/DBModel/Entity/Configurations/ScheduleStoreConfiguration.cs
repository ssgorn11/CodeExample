using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта ScheduleStoreEntity
    /// </summary>
    internal class ScheduleStoreConfiguration : IEntityTypeConfiguration<ScheduleStoreEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleStoreEntity> builder)
        {
            builder.ToTable("ScheduleStore").HasKey(d => d.Id);
        }
    }
}
