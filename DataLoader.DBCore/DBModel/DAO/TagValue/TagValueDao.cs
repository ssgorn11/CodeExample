using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным значений ТЭГов
    /// </summary>
    internal class TagValueDao : EntityDao<TagValueEntity>, ITagValueDao
    {
        public TagValueDao(IDataSource dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        public void AddTags(IEnumerable<TagValueEntity> tags)
        {
            CreateRange(tags);
        }

        /// <summary>
        /// Асинхронно добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        public async Task AddTagsAsync(IEnumerable<TagValueEntity> tags)
        {
            await CreateRangeAsync(tags);
        }
    }
}
