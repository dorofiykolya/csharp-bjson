using Common.Data;

namespace Records.Initialization
{
    public class PaidItemRecord
    {
        /// <summary>
        /// уникальный иденфтикатор плюшки;
        /// </summary>
		public int objectId;

        /// <summary>
        /// тип плюшки PaidItemType (0 — без юнитов и спеллов, 1 — юнит, 2 — спелл);
        /// </summary>
		public int type;
		
		/// <summary>
        /// вариант применения PaidItemUseType (0 — во время боя, 1 — после боя, если закончилось время, 2 — после боя, если не осталось юнитов);
        /// </summary>
		public int useType;

        /// <summary>
        /// идентификатор плюшки с paidItemsData;
        /// </summary>
        public int fightItemId;

        /// <summary>
        /// время в секундах, на которое увеличивается время боя
        /// </summary>
        public int timeIncrease;
        
        /// <summary>
        /// стоимость применения;
        /// </summary>
		public ItemCount[] requirements;
    }
}
