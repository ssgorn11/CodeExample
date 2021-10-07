using System;

namespace DataLoader.DBCore.DBModel
{
	/// <summary>
	/// Простой лог ошибок
	/// </summary>
	internal class ErrorEntity : BaseEntity
	{
		/// <summary>
		/// Класс возникновения ошибки
		/// </summary>
		public string ClassName { get; set; }

		/// <summary>
		/// Метод возникновения ошибки
		/// </summary>
		public string Func { get; set; }

		/// <summary>
		/// Текст ошибки
		/// </summary>
		public string Error { get; set; }

		/// <summary>
		/// Время ошибки
		/// </summary>
		public DateTime EditMoment { get; set; }
	}
}
