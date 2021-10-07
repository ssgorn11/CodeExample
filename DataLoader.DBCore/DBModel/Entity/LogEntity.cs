using System;

namespace DataLoader.DBCore.DBModel
{
	/// <summary>
	/// Простой лог событий загрузки данных
	/// </summary>
	internal class LogEntity : BaseEntity
	{
		/// <summary>
		/// Ключ расписания
		/// </summary>
		public int IdSchedule { get; set; }

		/// <summary>
		/// Описание загрузки
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Количество загруженных данных
		/// </summary>
		public int CountValues { get; set; }

		/// <summary>
		/// Время загрузки
		/// </summary>
		public DateTime EditMoment { get; set; }
	}
}
