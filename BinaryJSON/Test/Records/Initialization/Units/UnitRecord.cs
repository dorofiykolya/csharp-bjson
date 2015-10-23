using Locations.Records;
using Locations.Battle;

namespace Records.Initialization
{
    public class UnitRecord : UnitRecordBase
    {
        /// <summary>
        /// идентификатор юнита, который появляется после уничтожения текущего;
        /// </summary>
        public int rebornUnitId;

        //уровень бараков, необходимый для создания данного юнита
        //public int requirementBarrackLevel;

        /// <summary>
        /// иконка для квестов
        /// </summary>
        public string prefabQuestIcon;

        /// <summary>
        /// ссылка на картинку (картинка цели, для юнитов которые управляются в бою)
        /// </summary>
        public string prefabAim;

        /// <summary>
        /// ссылка на картинку в окне улучшения героя, когда герой лечится
        /// </summary>
        public string prefabHeroTreatment;

        /// <summary>
        /// ссылка на картинку в окне улучшения героя, когда герой в норм состоянии
        /// </summary>
        public string prefabHeroNormal;

        /// <summary>
        /// иконка героя в нормальном состоянии
        /// </summary>
        public string prefabIconGuard;

        /// <summary>
        /// иконка героя в состоянии отдыха
        /// </summary>
        public string prefabIconSleep;

        /// <summary>
        /// идентификатор звука при уничтожении
        /// </summary>
        public string soundDestroy;

        /// <summary>
        /// идентификатор звука при атаке
        /// </summary>
        public string soundAttack;

        /// <summary>
        /// идентификатор звука при высадке
        /// </summary>
        public string soundLanding;

        /// <summary>
        /// тип целей (0 — нету, 1 — земля, 2 — воздух, 3 — земля/воздух)
        /// </summary>
        public TTargetsType targetsType;

        /// <summary>
        /// тип предпочитаемых целей (0 —нету, 1 — ресурсные, 2 — защитные постройки, 3 — стенки)
        /// </summary>
        public int preferredTargets;

        /// <summary>
        /// тип радиуса поражени (0 — ближник, 1 — 3 клетки, 2 — 3,5 клеток)
        /// </summary>
        public int rangeType;

        /// <summary>
        /// радиус, в котором юнит реагирует на юнитов противника
        /// </summary>
        public int triggerRange;

        /// <summary>
        /// параметр, который отчвечает за возможность применения пассивного скила “уменьшение урона”
        /// </summary>
        public bool lowLevelDefIncAvailable;

        /// <summary>
        /// радиус действия пассивгого скила юнита
        /// </summary>
        public int passiveSkillRange;

        /// <summary>
        /// параметр действия пассивка
        /// </summary>
        public int passiveSkillParam;

        /// <summary>
        /// вещи, которые доступны герою (только для героев)
        /// </summary>
        public int[] heroItems;

        /// <summary>
        /// массив уровней
        /// </summary>
        public UnitLevelRecord[] levels;

        /// <summary>
        /// радиус атаки;
        /// </summary>
        public int range;

        /// <summary>
        /// тип домиков, которые юнит будет выбирать в первую очередь (0 — без разницы, 1 — ресурсные постройки, 2 — защитные постройки);
        /// </summary>
        public int searchPreferredTargets;

        /// <summary>
        /// время, между двумя последовательными атаками;
        /// </summary>
        public int timeBetweenAttacks;

        /// <summary>
        /// время подготовки к нанесению урона (от старта атаки до нанесения урона или выстрела);
        /// </summary>
        public int prepareAttackTime;

        /// <summary>
        /// тип пассивки (0 — специальными свойствами не обладает, 1 — увеличение наносимого урона, 2 — уменьшение получаемого урона, 3 — увеличение скорости передвижения);
        /// </summary>
        public TStatsModifier passiveSkillType;

        /// <summary>
        /// базовое время, между двумя последовательными атаками (для нормального отображения анимации);
        /// </summary>
        public int defaultTimeBetweenAttacks;

        public override UnitLevelRecordBase GetLevel(int level)
        {
            if (levels == null || levels.Length == 0)
            {
                return null;
            }
            return levels.Length > level ? levels[level] : levels[0];
        }

        /// <summary>
        /// максимальный уровень
        /// </summary>
        public override int MaxLevel
        {
            get { return (levels == null) ? 0 : levels.Length - 1; }
        }
    }
}
