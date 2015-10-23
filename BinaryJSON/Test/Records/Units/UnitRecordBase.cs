using Locations.Battle;
using Records;

namespace Locations.Records
{
	public class UnitRecordBase : IShowedInInfoWindow
	{
		/// <summary>
		/// идентификатор юнита;
		/// </summary>
		public int id;

		/// <summary>
		/// тип юнита;
		/// </summary>
		public int type;

		/// <summary>
		/// идентификатор имени юнита;
		/// </summary>
		public string name;

		/// <summary>
		/// идентификатор описания юнита;
		/// </summary>
		public string description;

		/// <summary>
		/// идентификатор домика, в котором создаются юниты
		/// </summary>
		public int buildingId;

		/// <summary>
		/// время в секундах, необходимое для тренировки;
		/// </summary>
		public int trainTime;

		/// <summary>
		/// количество койкомест, занимаемых юнитом;
		/// </summary>
		public int housingSpace;

		/// <summary>
		/// имя префаба изображения юнита для магазина;
		/// </summary>
		public string prefabShopName;

		/// <summary>
        /// тип передвижения юнита (0 — не движется, 1 — наземные, 2 — по воздуху);
		/// </summary>
		public int moveType;

        /// <summary>
        /// ключи для отображения характеристик(прогрессы) в инфо
        /// </summary>
		public string[] infoProgress;

        /// <summary>
        /// ключи для отображения характеристик в инфо
        /// </summary>
		public string[] infoText;

		/// <summary>
        /// позиция юнита в окне тренировки (верхний ряд - четные индексы, нижний - нечетные, нумерация с 0);
		/// </summary>
		public int trainPosition;

		/// <summary>
        /// позиция юнита в окне исследований (верхний ряд - четные индексы, нижний - нечетные, нумерация с 0);
		/// </summary>
		public int researchPosition;

        /// <summary>
        /// базовая скорость передвижения юинта (для нормального отображения анимации);
        /// </summary>
	    public int defaultMoveSpeed;

		public virtual UnitLevelRecordBase GetLevel(int level)
		{
			return null;
		}

	    public T GetLevel<T>(int level) where T : UnitLevelRecordBase
	    {
	        return GetLevel(level) as T;
	    }

        /// <summary>
        /// максимальный уровень
        /// </summary>
		public virtual int MaxLevel
		{
			get { return 0; }
		}

		public string[] InfoProgress
		{
			get { return infoProgress; }
		}

		public string[] InfoText
		{
			get { return infoText; }
		}

	    public bool IsHero
	    {
	        get { return type == (int)TUnitType.utAirHero || type == (int)TUnitType.utGroundHero; }
	    }
	}
}
