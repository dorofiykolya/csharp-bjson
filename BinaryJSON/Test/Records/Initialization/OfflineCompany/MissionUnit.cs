using Common.Data;
namespace Records.Initialization
{
    public class MissionUnit
    {
        /// <summary>
        /// идентификатор здания
        /// </summary>
        public int buildingId;

        /// <summary>
        /// массив юнитов и спелов доступных для миссии
        /// </summary>
        public IdLevelQuantity[] units;
    }
}
