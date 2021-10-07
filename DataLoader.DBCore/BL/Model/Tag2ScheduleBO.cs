using DataLoader.Service.Contract;

namespace DataLoader.DBCore.BL
{
	/// <summary>
	/// Привязка ТЭГа к расписанию
	/// </summary>
	public class Tag2ScheduleBO : BaseBO
	{
		/// <summary>
		/// Ключ ТЭГа
		/// </summary>
		public int IdTag { get; set; }

		/// <summary>
		/// Ключ расписания
		/// </summary>
		public int IdSchedule { get; set; }

		/// <summary>
		/// Тип поиска значения (т.к. ищем в интервале)
		/// Искать последний по времени / первый по времени / минимальный по значению / максимальный по значению / все
		/// </summary>
		public TypeOfIntervalSearch TypeOfIntervalSearch { get; set; }
	}
}
