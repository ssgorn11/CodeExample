using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным ТЭГов
    /// </summary>
    internal interface ITagDao
    {
        /// <summary>
        /// Получить весь список ТЭГов
        /// </summary>
        /// <returns>Список ТЭГов</returns>
        IQueryable<TagEntity> GetTags(Expression<Func<TagEntity, bool>> condition = null);
        Task DeleteAsync(int idTag);
        Task AddAsync(TagEntity tagEntity);
        Task UpdateAsync(TagEntity tagEntity);
    }
}
