using Common.Data;
using Common.DesignData;

namespace Records.Initialization
{
    public class BuildingLevelRecord : BuildingLevelRecordBase
    {

        public RequirementItem[] shotPrice;
        //public int shotPrice;

        // идентификатор дополнительного имени (для бункера, когда не видим его имя - название декора)
        public int hidenBuildingId;

        //время от окончания атаки до нанесения урона;
        public int attackSpeed;

        //идентификатор урона, который наносит здание;
        //public int damageId;

        //идентификатор действия заклинания, которое происходит при срабатывании в бою;
        public int spellActionId;

        //список дыбилоидов, которые стоят на здании и мочат всех
        public DefenceUnitRecord[] defenceUnits;

        //урон, который наносит домик
        public int damage;
    }
}
