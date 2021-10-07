using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Интерйефс бизнес объкта работы с значениями ТЭГов
    /// </summary>
    public interface ITagValueCollection
    {
        /// <summary>
        /// Добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        void AddTags(IEnumerable<TagValueBO> tags);

        /// <summary>
        /// Асинхронно добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        Task AddTagsAsync(IEnumerable<TagValueBO> tags);
    }
}
