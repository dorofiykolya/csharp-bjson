namespace Records.Initialization
{
    public class MissionsPaidItems
    {
        /// <summary>
        /// инфа о доступных юнитах и спеллах:
        /// </summary>
        public FightPaidItemRecord[] fightItems;

        /// <summary>
        /// инфа о платных плюшках
        /// </summary>
        public PaidItemRecord[] paidItems;

        /// <summary>
        /// привязка платных плюшек к миссиям
        /// </summary>
        public PaidItemsByMissions[] paidItemsByMissions;
    }
}
