using Common.Data;

namespace Records.Initialization
{
    public class UnitItemLevelRecord
    {
        //ценность предмета
        public int itemFeck;

        //необходимый уровень юнита для открытия шмотки
        //public int requiredUnitLevel;

        //время в секундах, необходимое для исследования предмета  до данного уровня
        public int researchTime;

        //массив с информацией о предметах, необходимых для исследования
        public RequirementItem[] requirements;

        //опыт, который дается герою при улучшении вещи
        public int experience;

        //идентификатор изображения предмета
        public string prefab;
    }
}
