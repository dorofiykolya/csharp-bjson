namespace Records.Initialization
{
    public class MissionMap
    {
        /// <summary>
        /// точки соединений баз на карте одиночных миссий;
        /// </summary>
        public Point[] route;

        /// <summary>
        /// массив островов на карте
        /// </summary>
        public MissionIslandData[] islands;
    }

    public class MissionIslandData
    {
        /// <summary>
        /// идентификатор острова
        /// </summary>
        public string id;
        /// <summary>
        /// координаты
        /// </summary>
        public Point coords;
    }
}
