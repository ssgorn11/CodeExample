using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта IntervalDirectionEntity
    /// </summary>
    internal class IntervalDirectionConfiguration : IEntityTypeConfiguration<IntervalDirectionEntity>
    {
        public void Configure(EntityTypeBuilder<IntervalDirectionEntity> builder)
        {
            builder.ToTable("IntervalDirection").HasKey(d => d.Id);
        }
    }
}
