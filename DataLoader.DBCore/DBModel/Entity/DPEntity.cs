namespace DataLoader.DBCore.DBModel
{
	/// <summary>
	/// Таблица внешнего ключа ТЭГа
	/// Связь с ТЭГом 1 к 1му (т.е. для каждого ТЭГа должен быть свой уникальный IdDirectoryParameter в этой таблице)
	/// Исторический рудимент
	/// </summary>
	internal class DPEntity : BaseEntity
	{
		/// <summary>
		/// Ключ ТЭГа
		/// </summary>
		public int IdTag { get; set; }

		/// <summary>
		/// Коментарий
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Внешний ключ
		/// </summary>
		public int IdDirectoryParameter { get; set; }
	}
}
