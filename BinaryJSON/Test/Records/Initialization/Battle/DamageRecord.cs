using Locations.Battle;

namespace Records.Initialization
{
    public class DamageRecord
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int id;

        /// <summary>
        /// тип 
        /// 0 — не определено, 
        /// 1 — одиночные цели, не выстрел, 
        /// 2 — одиночные цели, выстрел, 
        /// 3 — сплэш по фиксированным координатам, 
        /// 4 — сплэш по координатам цели, 
        /// 5 — хилка
        /// </summary>
        public TDamageType type;

        /// <summary>
        /// задержка до нанесения урона
        /// </summary>
        public int delaySteps;

        /// <summary>
        /// радиус нанесения урона
        /// </summary>
        public int splashRadius;

        /// <summary>
        /// тип целей, по которым наносится увеличенный урон
        /// </summary>
        public TPreferredTarget preferredTargets;

        /// <summary>
        /// идентификатор целей, по которым наносится увеличенный урон
        /// </summary>
        public int preferredTargetsId;

        /// <summary>
        /// коэффициент, на который умножается базовый урон, если цель приоритетная
        /// </summary>
        public int preferredTargetsCoef;

        /// <summary>
        /// название картинки
        /// </summary>
        public string prefab;

        /// <summary>
        /// граывитация пульки
        /// </summary>
        public int gravity;

        /// <summary>
        /// название эффекта, проигрывается когда наносится урон
        /// </summary>
        public string explosionPrefab;
    }
}
