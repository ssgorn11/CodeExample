using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DataLoader.DBCore.DBModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLoader.Service.Contract;

namespace DataLoader.DBCore.BL
{
    /// <summary>
    /// Бизнес объкта работы с ТЭГами
    /// </summary>
    internal class TagCollection : ITagCollection
    {
        private ITagDao _tagDao;
        private IScheduleDao _scheduleDao;
        private ITag2ScheduleDao _tag2ScheduleDao;
        private IMapper _mapper;

        /// <summary>
        /// Бизнес объкта работы с расписаниями
        /// </summary>
        /// <param name="scheduleDao">Объект доступа к расписаниям из БД</param>
        /// <param name="mapper">Мапер данных</param>
        public TagCollection(ITagDao tagDao, IMapper mapper, IScheduleDao scheduleDao, ITag2ScheduleDao tag2ScheduleDao)
        {
            _tagDao = tagDao;
            _scheduleDao = scheduleDao;
            _tag2ScheduleDao = tag2ScheduleDao;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDto>> GetTagsAsync()
        {
            var res = new List<TagDto>();

            var tagss = await _tagDao.GetTags().ToListAsync();
            var tags = tagss.Select(x => _mapper.Map<TagBO>(x)).ToList();

            //#region mock
            //tags = new List<TagBO>()
            //    {
            //        new TagBO() { Id = 1, Tag = "TIP_POM" },
            //        new TagBO() { Id = 2, Tag = "FGA_100" },
            //        new TagBO() { Id = 3, Tag = "POP40_LIT" },
            //        new TagBO() { Id = 4, Tag = "T20_POM" },
            //        new TagBO() { Id = 5, Tag = "TIP_H500P" },
            //        new TagBO() { Id = 6, Tag = "MUN_100" }
            //    };
            //#endregion mock

            res = tags.Select(x => _mapper.Map<TagDto>(x)).ToList();

            return res;
        }

        /// <summary>
        /// Получить список ТЭГов привязанных к расписанию
        /// </summary>
        /// <param name="idScedule">Ключ расписания</param>
        /// <returns>Список ТЭГов расписания</returns>
        public IEnumerable<TagBO> GetTagsBOBySchedule(int idScedule)
        {
            var tag2Schedules = _tag2ScheduleDao.GetTag2Schedules(x => x.IdSchedule == idScedule);
            var tadIdList = tag2Schedules.Select(x => x.IdTag).Distinct().ToList();
            var tags = _tagDao.GetTags(x => tadIdList.Any(z => z == x.Id));
            return tags.Select(x => _mapper.Map<TagBO>(x));
        }

        /// <summary>
        /// Асинхронно получить список ТЭГов привязанных к расписанию
        /// </summary>
        /// <param name="idScedule">Ключ расписания</param>
        /// <returns>Список ТЭГов расписания</returns>
        public async Task<IEnumerable<TagBO>> GetTagsBOByScheduleAsync(int idScedule)
        {
            var tag2Schedules = await _tag2ScheduleDao.GetTag2Schedules(x => x.IdSchedule == idScedule).ToListAsync();
            var tadIdList = tag2Schedules.Select(x => x.IdTag).Distinct().ToList();
            var tags = await _tagDao.GetTags(x => tadIdList.Any(z => z == x.Id)).ToListAsync();
            return tags.Select(x => _mapper.Map<TagBO>(x));
        }

        /// <summary>
        /// Асинхронно получить список ТЭГов привязанных к расписанию
        /// </summary>
        /// <param name="idScedule">Ключ расписания</param>
        /// <returns>Список ТЭГов расписания</returns>
        public async Task<IEnumerable<ScheduleTagDto>> GetTagsDtoByScheduleAsync(int idScedule)
        {
            var res = new List<ScheduleTagDto>();

            var t2s = await _tag2ScheduleDao.GetTag2Schedules(x => x.IdSchedule == idScedule).Select(x => _mapper.Map<Tag2ScheduleBO>(x)).ToListAsync();
            var tags = await GetTagsBOByScheduleAsync(idScedule);

            //#region mock
            //tags = new List<TagBO>()
            //    {
            //        new TagBO() { Id = idScedule == 1 ?  1 : 4, Tag = idScedule == 1 ?  "TIP_POM" : "T20_POM" },
            //        new TagBO() { Id = idScedule == 1 ?  2 : 5, Tag = idScedule == 1 ?  "FGA_100": "TIP_H500P" },
            //        new TagBO() { Id = idScedule == 1 ?  3 : 6, Tag = idScedule == 1 ?  "POP40_LIT": "MUN_100" }
            //    };
            //t2s = new List<Tag2ScheduleBO>()
            //    {
            //        new Tag2ScheduleBO() { IdTag = idScedule == 1 ?  1 : 4, TypeOfIntervalSearch = idScedule == 1 ? TypeOfIntervalSearch.all : TypeOfIntervalSearch.max },
            //        new Tag2ScheduleBO() { IdTag = idScedule == 1 ?  2 : 5, TypeOfIntervalSearch = idScedule == 1 ? TypeOfIntervalSearch.first : TypeOfIntervalSearch.min },
            //        new Tag2ScheduleBO() { IdTag = idScedule == 1 ?  3 : 6, TypeOfIntervalSearch = idScedule == 1 ? TypeOfIntervalSearch.all : TypeOfIntervalSearch.last }
            //    };
            //#endregion mock

            res = tags.Select(x => new ScheduleTagDto()
            {
                Id = x.Id,
                Tag = x.Tag,
                Comment = x.Comment,
                IdSchedule = idScedule,
                TypeOfIntervalSearch = t2s.FirstOrDefault(z => z.IdTag == x.Id)?.TypeOfIntervalSearch
            }).ToList();

            return res;
        }

        public async Task<IEnumerable<ScheduleTagDto>> GetTagsNotInScheduleAsync(int idScedule)
        {
            var res = new List<ScheduleTagDto>();
            var tagsInSchedule = _tag2ScheduleDao.GetTag2Schedules(x => x.IdSchedule == idScedule);
            var tadIdList = tagsInSchedule.Select(x => x.IdTag).Distinct().ToList();
            var tags = (await _tagDao.GetTags(x => !tadIdList.Any(z => z == x.Id)).ToListAsync())?.Select(x => _mapper.Map<TagBO>(x));

            //#region mock
            //tags = new List<TagBO>()
            //    {
            //        new TagBO() { Id = idScedule == 1 ?  7 : 10, Tag = idScedule == 1 ?  "44TIP_POM" : "55T20_POM" },
            //        new TagBO() { Id = idScedule == 1 ?  8 : 11, Tag = idScedule == 1 ?  "44FGA_100": "55TIP_H500P" },
            //        new TagBO() { Id = idScedule == 1 ?  9 : 12, Tag = idScedule == 1 ?  "44POP40_LIT": "55MUN_100" }
            //    };
            //#endregion mock

            res = tags.Select(x => new ScheduleTagDto()
            {
                Id = x.Id,
                Tag = x.Tag,
                Comment = x.Comment
            }).ToList();

            return res;
        }

        public async Task BoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags)
        {

            await _tag2ScheduleDao.AddRangeAsync(tags.Select(tag => _mapper.Map<Tag2ScheduleEntity>(
                new Tag2ScheduleBO()
                {
                    IdSchedule = idSchedule,
                    IdTag = tag.Id,
                    TypeOfIntervalSearch = tag.TypeOfIntervalSearch ?? TypeOfIntervalSearch.last
                })
                ));
        }

        public async Task UnBoundTagsAsync(int idSchedule, IEnumerable<ScheduleTagDto> tags)
        {
            await _tag2ScheduleDao.RemoveRangeAsync(idSchedule, tags.Select(x => x.Id));
        }

        public async Task DeleteAsync(int idTag)
        {
            await _tag2ScheduleDao.DeleteByTagAsync(idTag);
            await _tagDao.DeleteAsync(idTag);
        }

        public async Task AddAsync(TagDto tagDto)
        {
            await _tagDao.AddAsync(_mapper.Map<TagEntity>(_mapper.Map<TagBO>(tagDto)));
        }

        public async Task UpdateAsync(TagDto tagDto)
        {
            await _tagDao.UpdateAsync(_mapper.Map<TagEntity>(_mapper.Map<TagBO>(tagDto)));
        }
    }
}
