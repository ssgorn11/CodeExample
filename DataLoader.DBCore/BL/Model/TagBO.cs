namespace DataLoader.DBCore.BL
{
	/// <summary>
	/// ТЭГ - некий текстовый ключ данных
	/// </summary>
	public class TagBO : BaseBO
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
