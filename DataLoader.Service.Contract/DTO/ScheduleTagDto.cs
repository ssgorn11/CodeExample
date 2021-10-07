using System;
using System.Collections.Generic;
using System.Text;

namespace DataLoader.Service.Contract
{
    public class ScheduleTagDto : TagDto
	{
		public ScheduleTagDto() { }

		/// <summary>
		/// Ключ расписания
		/// </summary>
		public int IdSchedule { get; set; }

		/// <summary>
		/// Тип поиска значения (т.к. ищем в интервале)
		/// Искать последний по времени / первый по времени / минимальный по значению / максимальный по значению / все
		/// </summary>
		public TypeOfIntervalSearch? TypeOfIntervalSearch { get; set; } = Contract.TypeOfIntervalSearch.last;
	}
}
