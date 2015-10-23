using Common.Data;

namespace Records.Initialization
{
    public class FightPaidItemRecord
    {
        /// <summary> 
        /// уникальный идентификатор 
        /// </summary>
        public int objectId;
        
        /// <summary>
        /// информация о юнитах или спеллах
        /// </summary>
        public ItemLevelCount item;
    }
}
