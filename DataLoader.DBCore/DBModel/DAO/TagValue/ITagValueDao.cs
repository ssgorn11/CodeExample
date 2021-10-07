using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.DBModel
{
    /// <summary>
    /// Доступ к данным значений ТЭГов
    /// </summary>
    internal interface ITagValueDao
    {
        /// <summary>
        /// Добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        void AddTags(IEnumerable<TagValueEntity> tags);

        /// <summary>
        /// Асинхронно добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        Task AddTagsAsync(IEnumerable<TagValueEntity> tags);
    }
}
