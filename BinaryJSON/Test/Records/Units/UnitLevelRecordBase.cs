namespace Locations.Records
{
    public class UnitLevelRecordBase
    {
        /// <summary>
        /// здоровье юнита;
        /// </summary>
        public int hitpoints;

        /// <summary>
        /// идентификатор анимации юнита;
        /// </summary>
        public string prefab;
        
        /// <summary>
        /// идентификатор изображения юнита;
        /// </summary>
        public string prefabInfo;

        /// <summary>
        /// время в секундах, необходимое для исследования юнита до данного уровня/тренировки на этом уровне;
        /// </summary>
        public int researchTime;

        /// <summary>
        /// скорость движения
        /// </summary>
        public int speed;

        /// <summary>
        /// идентификатор наносимого урона;
        /// </summary>
        public int damageTypeId;
    }
}
