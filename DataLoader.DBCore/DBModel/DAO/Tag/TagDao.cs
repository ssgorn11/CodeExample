using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным ТЭГов
    /// </summary>
    internal class TagDao : EntityDao<TagEntity>, ITagDao
    {
        public TagDao(IDataSource dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Получить весь список ТЭГов
        /// </summary>
        /// <returns>Список ТЭГов</returns>
        public IQueryable<TagEntity> GetTags(Expression<Func<TagEntity, bool>> condition = null)
        {
            return Get(condition);
        }

        public async Task DeleteAsync(int idTag)
        {
            await base.DeleteAsync(idTag);
        }

        public async Task AddAsync(TagEntity tag)
        {
            await base.CreateAsync(tag);
        }
        public async Task UpdateAsync(TagEntity tag)
        {
            await base.UpdateAsync(tag);
        }
    }
}
