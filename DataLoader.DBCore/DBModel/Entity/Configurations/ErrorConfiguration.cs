using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта ErrorEntity
    /// </summary>
    internal class ErrorConfiguration : IEntityTypeConfiguration<ErrorEntity>
    {
        public void Configure(EntityTypeBuilder<ErrorEntity> builder)
        {
            builder.ToTable("Error").HasKey(d => d.Id);
        }
    }
}
