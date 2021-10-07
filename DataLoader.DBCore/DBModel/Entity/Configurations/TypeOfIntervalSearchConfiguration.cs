using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта TypeOfIntervalSearchEntity
    /// </summary>
    internal class TypeOfIntervalSearchConfiguration : IEntityTypeConfiguration<TypeOfIntervalSearchEntity>
    {
        public void Configure(EntityTypeBuilder<TypeOfIntervalSearchEntity> builder)
        {
            builder.ToTable("TypeOfIntervalSearch").HasKey(d => d.Id);
        }
    }
}
