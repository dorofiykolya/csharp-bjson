using Locations.Records;

namespace Records.Initialization
{
    public class UnitLevelRecord : UnitLevelRecordBase
    {
        //уровень исследовательского центра, необходимый для исследования данного уровня юнита;
        //public int requirementTLLevel;       

        //массив с информацией о предметах, необходимых для исследования/тренировки;
        public RequirementItem[] researchRequirements;
        public RequirementItem[] trainRequirements;

        //скорость восстановления юнита hp в минуту;
        public int recoverySpeedHpPerMin;

        //опыт юнита;
        public int experience;

        //время в мс от начала атаки до возможности произвести следующую;
        public int attackSpeed;

        //идентификатор урона, который наносит юнит при смерти;
        public int damageUponDeathId;

        //
        public int damage;

        public int this[string param]
        {
            get
            {
                switch (param)
                {
                    case "attackSpeed": return attackSpeed;
                    case "experience": return experience;
                    case "recoverySpeedHpPerMin": return recoverySpeedHpPerMin;
                    case "hitpoints": return hitpoints;
                    case "speed": return speed;
                    default:
                        return -1;
                }
            }
            
        }
    }
}
