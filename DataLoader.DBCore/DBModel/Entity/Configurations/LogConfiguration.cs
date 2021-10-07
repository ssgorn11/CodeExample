using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта LogEntity
    /// </summary>
    internal class LogConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Log").HasKey(d => d.Id);
        }
    }
}
