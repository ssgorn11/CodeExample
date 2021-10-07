using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataLoader.DBCore.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Бизнес объкт работы с значениями ТЭГов
    /// </summary>
    internal class TagValueCollection : ITagValueCollection
    {
        private ITagValueDao _tagValueDao;
        private IMapper _mapper;

        /// <summary>
        /// Бизнес объкта работы с расписаниями
        /// </summary>
        /// <param name="scheduleDao">Объект доступа к расписаниям из БД</param>
        /// <param name="mapper">Мапер данных</param>
        public TagValueCollection(ITagValueDao tagValueDao, IMapper mapper)
        {
            _tagValueDao = tagValueDao;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        public void AddTags(IEnumerable<TagValueBO> tags)
        {
            _tagValueDao.AddTags(tags.Select(x => _mapper.Map<TagValueEntity>(x)));
        }

        /// <summary>
        /// Асинхронно добавить значеня ТЭГов
        /// </summary>
        /// <param name="tags">Список значений ТЭГов для сохранения</param>
        public async Task AddTagsAsync(IEnumerable<TagValueBO> tags)
        {
            await _tagValueDao.AddTagsAsync(tags.Select(x => _mapper.Map<TagValueEntity>(x)));
        }
    }
}
