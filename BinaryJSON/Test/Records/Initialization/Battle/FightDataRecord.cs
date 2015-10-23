namespace Records.Initialization
{
    public class FightDataRecord
    {
        //массив с информацией о ресурсах, необходимых для атаки
        public ScoutRequirementRecord[] scoutRequirements;

        //информация о видах атак в игре
        public DamageRecord[] damages;

        //информация о триггерах
        public TriggerRecord[] triggers;

        //действия-спеллы, которые проиходят при использовании заклинаний, артефактов, срабатывании некоторых ловушек
        public SpellActionRecord[] spellsActions;

        // коэффициенты опыта для героев
        public HeroExpRecord[] heroesExpCoef;
    }
}
