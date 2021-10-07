using Microsoft.EntityFrameworkCore;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Энтити контекст для работы с БД
    /// </summary>
    internal class EfContext : DbContext
    {
        public EfContext(DbContextOptions options) : base(options)
        {
                Database.Migrate(); // проверять и создавать недостающие миграции
        }

        /// <summary>
        /// Конфигурация БД
        /// </summary>
        /// <param name="modelBuilder">Строитель модели</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DPConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorConfiguration());
            modelBuilder.ApplyConfiguration(new IntervalDirectionConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleStoreConfiguration());
            modelBuilder.ApplyConfiguration(new Tag2ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new Tag2TagGroupConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new TagGroupConfiguration());
            modelBuilder.ApplyConfiguration(new TagValueConfiguration());
            modelBuilder.ApplyConfiguration(new TimeIntervalTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TypeOfIntervalSearchConfiguration());
        }
    }
}
