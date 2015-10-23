using System;
using Records;

namespace Common.DesignData
{

    [Serializable]
    // Настройки здания согласно его Левелу
    public class BuildingLevelRecordBase		
    {
        // Имя префаба виджета
        public string prefab;

        //идентификатор изображения здания на текущем уровне
        public string prefabInfo;

        // к-во здоровья здания
        public int hitpoints;

        // (может быть неопределен) — количество ресурсов или юнитов, которое может вмещать строение, юниты для телепорта;
        public int capacity;

        // необходимый уровень командного центра для постройки данного уровня здания;
        //public int requiredCCLevel = -1;

        // время постройки (апгрейда, если строение не первого уровня) строения;
        public int buildTime = -1;

        // время удаления (только для мусора);
        public int removeTime;

        public RequirementItem[] requirements;

        public RequirementItem[] removeRequirements;

        public RequirementItem[] boostRequirements;

        //производимость в час (определена только для типа ‘resource_mine’)
        public int hourlyRate;

        //тип наносимого урона;
        public int damageTypeId;
    }
}
