using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Конфигурация создания таблицы БД для объекта DPEntity
    /// </summary>
    internal class DPConfiguration : IEntityTypeConfiguration<DPEntity>
    {
        public void Configure(EntityTypeBuilder<DPEntity> builder)
        {
            builder.ToTable("DP").HasKey(d => d.Id);
            builder.HasIndex(x => x.IdTag);
        }
    }
}
