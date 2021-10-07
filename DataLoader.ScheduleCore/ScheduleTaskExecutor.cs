using DataLoader.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLoader.PHDReder;
using DataLoader.DBCore.BL;
using DataLoader.DBCore;

namespace DataLoader.ScheduleCore
{
    /// <summary>
    /// Класс запуска расписаний
    /// </summary>
    public class ScheduleTaskExecutor : IScheduleTaskExecutor
    {
        private readonly IDBCoreObjectFactory _dBCoreObjectFactory;
        private readonly IPHDDataReader _PHDDataReader;

        private readonly ITagCollection _tagCollection;
        private readonly ITag2ScheduleCollection _tag2ScheduleCollection;
        private readonly ITagValueCollection _tagValueCollection;

        public ScheduleTaskExecutor(IDBCoreObjectFactory dBCoreObjectFactory, IReaderObjectFactory readerObjectFactory)
        {
            _dBCoreObjectFactory = dBCoreObjectFactory;
            _tagCollection = dBCoreObjectFactory.Resolve<ITagCollection>();
            _tag2ScheduleCollection = dBCoreObjectFactory.Resolve<ITag2ScheduleCollection>();
            _tagValueCollection = dBCoreObjectFactory.Resolve<ITagValueCollection>();
            _PHDDataReader = readerObjectFactory.Resolve<IPHDDataReader>();
        }

        /// <summary>
        /// Асинхронный запуск выполнения расписания
        /// </summary>
        /// <param name="scedule"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public async Task Run(ScheduleBO scedule, DateTime now)
        {
            //Определить интервал поиска
            var interval = scedule.GetSearchInterval(now);

            //Получить список ТЭГов для загрузки
            var tags = await _tagCollection.GetTagsBOByScheduleAsync(scedule.Id);

            //Загрузить значения
            var data = await _PHDDataReader.GetPHDDataAsync(tags.Select(x => new Tuple<int, string>(x.Id, x.Tag)), interval.Item1, interval.Item2);

            //Подготовить данные к сохранению
            var dataToSave = PreparePHDValueToSave(scedule.Id, data, _tag2ScheduleCollection);

            //Сохранить значения
            await _tagValueCollection.AddTagsAsync(dataToSave);
        }

        /// <summary>
        /// Подготовить полученные данныые PHD к сохранению
        /// т.е. в выбранном диапазоне, могут находиться несколько записнй
        /// и в зависимости от настройки, надо выбрать последнее или с максимальным значением или все.
        /// </summary>
        /// <param name="idSchedule">Ключ расписания</param>
        /// <param name="items">Полученные данные</param>
        /// <param name="tag2ScheduleController">Контроллер работы с пересечением тэгов и расписаний</param>
        /// <returns>Список значений тэгов для сохранения</returns>
        private IEnumerable<TagValueBO> PreparePHDValueToSave(int idSchedule, IEnumerable<PHDDataDto> items, ITag2ScheduleCollection tag2ScheduleController)
        {
            var res = new List<TagValueBO>();

            foreach (var item in items)
            {
                if (!res.Any(x => x.IdTag == item.IdTag))
                {
                    var list = items.Where(x => x.IdTag == item.IdTag).ToList();

                    if (list.Count == 1)
                        res.Add(MapTagData(item));
                    else
                    {
                        var t2s = tag2ScheduleController.GetOne(item.IdTag, idSchedule);
                        if (t2s != null)
                        {
                            if (t2s.TypeOfIntervalSearch == TypeOfIntervalSearch.max)
                                res.Add(MapTagData(list.FirstOrDefault(x => x.Value == list.Max(v => v.Value))));
                            else if (t2s.TypeOfIntervalSearch == TypeOfIntervalSearch.min)
                                res.Add(MapTagData(list.FirstOrDefault(x => x.Value == list.Min(v => v.Value))));
                            else if (t2s.TypeOfIntervalSearch == TypeOfIntervalSearch.first)
                                res.Add(MapTagData(list.FirstOrDefault(x => x.DatePHD == list.Min(v => v.DatePHD))));
                            else if (t2s.TypeOfIntervalSearch == TypeOfIntervalSearch.last)
                                res.Add(MapTagData(list.FirstOrDefault(x => x.DatePHD == list.Max(v => v.DatePHD))));
                            else if (t2s.TypeOfIntervalSearch == TypeOfIntervalSearch.all)
                                res.AddRange(list.Select(x => MapTagData(x)));
                        }
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Конвертировать полученные данные в объект для сохранения
        /// </summary>
        /// <param name="item">Полученные данные</param>
        /// <returns>Объект для сохранения</returns>
        private TagValueBO MapTagData(PHDDataDto item)
        {
            var res = _dBCoreObjectFactory.Create<TagValueBO>();

            res.IdTag = item.IdTag;
            res.Value = item.Value;
            res.DatePHD = item.DatePHD;
            res.Confidence = item.Confidence;

            return res;
        }
    }
}
