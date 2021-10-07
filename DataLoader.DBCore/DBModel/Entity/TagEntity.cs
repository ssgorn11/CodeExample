namespace DataLoader.DBCore.DBModel
{
	/// <summary>
	/// ТЭГ - некий текстовый ключ данных
	/// </summary>
	internal class TagEntity : BaseEntity
	{
		/// <summary>
		/// ТЭГ - некий текстовый ключ данных
		/// </summary>
		public string Tag { get; set; }

		/// <summary>
		/// Описание
		/// </summary>
		public string Comment { get; set; }
	}
}
