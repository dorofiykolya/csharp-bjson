using Common.DesignData;
using Common.Records;
using Locations.Battle;

namespace Records.Initialization
{
    public class BuildingRecord : BuildingRecordBase
    {
        //идентификатор базового здания (если здание подразумевает несколько состояний);
        public int baseId;

        //идентификатор домика, которым можно подменять текущий;
        public int changeId;

        //идентификатор прав на строительство(0 - игрок не имеет возможности строить этот домик; 1 - игрок может строить этот домик только на своей локации; 2 - игрок может строить этот домик только на локации карты);
        public int buildScopeId;

        //идентификатор звука когда поставили
        public string soundLeave;

        //идентификатор звука (выстрел)
        public string soundAttack;

        //идентификатор звука при выделении...
        public string soundSelect;

        //идентификатор звука при разрушении...
        public string soundDestroy;

        //идентификатор триггера;
        public int triggerType;

        /// <summary>
        /// тип защитной постройки (
        /// 0 — без типа, 
        /// 1 — обычная пушка, 
        /// 2 — вышка стрелков, 
        /// 3 — мортира, 
        /// 4 — огнеметчик, 
        /// 5 — противовоздушная пушка, 
        /// 6 — бункер, 
        /// 7 — град (подобие токсиномета), 
        /// 8 — шквал (подобие теслы) с одной целью, 
        /// 9  — шквал (подобие теслы) с несколькими целями, 
        /// 10 — просто бомбочка, 
        /// 11 — бомбочка, которая выбрасывает юнитов).
        /// </summary>
        public int defBuildingType = -1;

        /// <summary>
        /// 0 - not available
        /// 1 - ground
        /// 2 - air
        /// 3 - ground and air
        /// </summary>
        public int targetsType = -1;

        /// <summary>
        ///  радиус срабатывания домика
        /// </summary>
        public int triggerRange;

        /// <summary>
        /// тип наносимого урона;
        /// </summary>
        //public int damageTypeId;

        /// <summary>
        /// минимальный радиус поражения
        /// </summary>
        public int minRange;

        /// <summary>
        /// максимальный радиус поражения
        /// </summary>
        public int maxRange;

        /// <summary>
        /// время между двумя последовательными атаками
        /// </summary>
        public int timeBetweenAttacks;

        /// <summary>
        /// время от начала атаки до произведения выстрела или срабатывания
        /// </summary>
        public int prepareAttackTime;

        /// <summary>
        /// идентификатор юнитов, на которых домик будет агриться в первую очередь
        /// </summary>
        public int searchPreferredTargetId;


        /// <summary>
        /// показывать скроллер в инфо или нет
        /// </summary>
        public bool needShowScroller;

        /// <summary>
        /// 
        /// </summary>
        public bool needCountShots;


        public BuildingLevelRecord[] levels;

        public override BuildingLevelRecordBase GetLevel(int level)
        {
            if (levels == null || levels.Length == 0)
            {
                return null;
            }
            return levels.Length > level ? levels[level] : levels[0];
        }

        public override int MaxLevel
        {
            get
            {
                if (levels == null || levels.Length == 0)
                {
                    return 0;
                }
                return levels.Length - 1;
            }
        }

        public int FightHalfSize
        {
            get
            {
                int halfSize;
                if (BuildingType == TBuildingType.btArmyCamp)
                {
                    halfSize = size.width - 3;
                }
                else if (BuildingType == TBuildingType.btWall)
                {
                    halfSize = size.width;
                }
                else
                {
                    halfSize = size.width - 1;
                }
                return halfSize * 4;
            }
        }

        public int MoveSize
        {
            get
            {
                if (BuildingType == TBuildingType.btArmyCamp) return size.width;
                return size.width - 2;
            }
        }
    }
}
