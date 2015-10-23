using System;
using Common.DesignData;
using Locations.Battle;
using Modules.Requirement;
using Records;

namespace Common.Records
{
    /// <summary>
    /// record of building in DataBase
    /// </summary>
    public class BuildingRecordBase : IShowedInInfoWindow
    {
        /// <summary>
        /// id of building
        /// </summary>
        public int id;

        /// <summary>
        /// building type (command_center, barracks ...)
        /// </summary>
        public int type;

        /// <summary>
        /// size of building in geodata dimensions
        /// </summary>
        public Size size;

        /// <summary>
        /// busy size of building on location, didn't go by UnitsLevel
        /// </summary>
        public Size busySize;

        /// <summary>
        ///  id of name
        /// </summary>
        public string name;

        /// <summary>
        /// id of description
        /// </summary>
        public string description;

        public string prefabShop;

        /// <summary>
        /// идентификатор ресурса (добывающие/склады постройки)
        /// </summary>
        public int resourceId = -1;

        /// <summary>
        /// время действия буста
        /// </summary>
        public int boostTime = -1;

        /// <summary>
        /// множитель буста
        /// </summary>
        public int boostMultiplier = -1;

        /// <summary>
        /// требуется ли строитель для улучшения
        /// </summary>
        public bool needBuilder;

        /// <summary>
        /// массив с текстовыми идентификаторами (соответствует плейсхолдеру с прогрессом в окне ИНФО, ключи: building_hp — к-во жизней, building_perfomance — производительность, 
        /// building_capacity — вместимость, building_damage_per_second — урон в секунду, buildgin_damage_per_shot — урон за выстрел, building_recharge_price — стоимость заряки, building_damage — урон, building_hero_level — уровень героя, building_hero_attack_speed — скорость атаки героя, building_hero_speed — скорость героя, building_hero_hp_regen — лечение в минуту, building_hero_hp - жизни героя,  building_hero_attack - атака героя)
        /// </summary>
        public string[] infoProgress;

        /// <summary>
        /// массив с текстовыми идентификаторами (соответствует плейсхолдеру с текстом в окне ИНФО, ключи: building_targets — building targets, building_damage_type — building damage type, 
        /// building_radius — building radius)
        /// </summary>
        public string[] infoText;

        /// <summary>
        /// можно ли удалять с локации;
        /// </summary>
        public bool removable;

        /// <summary>
        /// нуждается ли здание в перезарядке;
        /// </summary>
        public bool rechargeable;

        /// <summary>
        /// level records
        /// </summary>
        private BuildingLevelRecordBase[] levels;

        public int GetRemoveTime(int level)
        {
            var levelRecord = GetLevel(level);
            if (levelRecord != null)
            {
                return levelRecord.removeTime;
            }
            return 0;
        }

        public int GetBuildingTime(int level)
        {
            BuildingLevelRecordBase levelRecordBase = GetLevel(level);

            if (levelRecordBase != null)
            {
                return levelRecordBase.buildTime;
            }

            return 0;
        }

        public int GetPrice(int level)
        {
            BuildingLevelRecordBase levelRecordBase = GetLevel(level);

            if (levelRecordBase == null || levelRecordBase.requirements == null)
                return -1;

            RequirementItem requirementItem = levelRecordBase.requirements.GetItemByType(RequirementType.RESOURCE_COUNT);
            if (requirementItem != null)
            {
                return requirementItem.value;
            }

            return -1;
        }

        public RequirementItem[] GetRequirementsByLevel(int level)
        {
            return GetLevel(level).requirements;
        }

        public int GetRequirementResource(int level = 1)
        {
            BuildingLevelRecordBase levelRecordBase = GetLevel(level);

            if (levelRecordBase == null || levelRecordBase.requirements == null)
                return -1;

            RequirementItem requirementItem = levelRecordBase.requirements.GetItemByType(RequirementType.RESOURCE_COUNT);
            if (requirementItem != null)
            {
                return requirementItem.id;
            }

            return -1;
        }

        public string GetShopImage(int level)
        {
            BuildingLevelRecordBase levelRecordBase = GetLevel(level);

            if (levelRecordBase != null)
            {
                return levelRecordBase.prefab;
            }

            return null;
        }

        public virtual BuildingLevelRecordBase GetLevel(int level)
        {
            if (levels == null || levels.Length == 0)
            {
                return null;
            }
            return levels.Length > level ? levels[level] : levels[0];
        }

        /// <summary>
        /// чтобы получить максимальный уровень, возможный у здания, нужно из полученного вычесть 1
        /// </summary>
        public virtual int MaxLevel
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

        public string[] InfoProgress
        {
            get { return infoProgress; }
        }

        public string[] InfoText
        {
            get { return infoText; }
        }

        public TBuildingType BuildingType
        {
            get { return (TBuildingType)type; }
        }

        public override string ToString()
        {
            return "[BuildingRecordBase id:" + id + ", type:" + type + ", name:" + name + "]";
        }
    }
}