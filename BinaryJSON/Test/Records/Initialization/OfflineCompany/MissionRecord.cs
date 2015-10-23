using Common.Data;
using Locations.Data;

namespace Records.Initialization
{
    public class MissionRecord
    {
        /// <summary>
        /// идентификатор миссии
        /// </summary>
        public int id;

        /// <summary>
        /// название миссии
        /// </summary>
        public string name;

        /// <summary>
        /// тип локации (0 - обычная база, 1 - босс)
        /// </summary>
        public int baseType;

        /// <summary>
        /// координаты миссии
        /// </summary>
        public Point coords;

        /// <summary>
        /// массив идентификаторов миссий для старта последующей миссии
        /// </summary>
        public int[] requirements;

        /// <summary>
        ///  картинка подложки локации
        /// </summary>
        public string prefab;

        /// <summary>
        ///  размеры локации  
        /// </summary>
        public LocationBounds bounds;

        /// <summary>
        /// массив зданий на локации
        /// </summary>
        public MissionBuilding[] buildings;

        /// <summary>
        /// награды за проходжение миссии на 3 звездочки
        /// </summary>
        public int[] rewards;

        /// <summary>
        /// массив юнитов в зданиях(юниты противника)     
        /// </summary>
        public MissionUnit[] buildingsUnits;

        /// <summary>
        /// массив юнитов доступных для атаки
        /// </summary>
        public IdLevelCount[] units;

        /// <summary>
        /// массив спелов доступных для атаки
        /// </summary>
        public IdLevelCount[] spells;
    }
}
