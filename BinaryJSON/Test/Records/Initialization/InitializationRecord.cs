using Common.Records;
using Common.Records.Initializations;

namespace Records.Initialization
{
    public class InitializationRecord : InitializationRecordBase
    {
        //идентификатор игры;
        public int supportGameId;

        //адрес службы поддержки (http://support.restr.net);
        public string supportServerUrl;

        //массив, каждый элемент которого содержит количество опыта, необходимого для достижения следующего уровня. Уровень — индекс ячейки массива.
        public int[] experiencePerLevel;

        //массив стоимости смены имени игрока
        private ChangeNameCostRecord[] changeNameCost;

        // массив с вопросами и ответами
        public FaqRecord[] faq;

        //массив с информацией о зданиях в игре
        public BuildingRecord[] buildings;

        //количество домиков в зависимости от уровня командного центра
        public BuildingsCountPerCCLevelRecord[] buildingCountPerCCLevel;

        //массив с инфоррмацией о юнитах
        public UnitRecord[] units;

        //информация о предметах юнита
        public UnitItemRecord[] unitItems;

        //массив с информацией о заклинаниях в игре
        public SpellRecord[] spells;

        //информация, связанная с боями
        public FightDataRecord fightsData;

        // массив с информацией о предметах в игре
        public ItemRecord[] items;

        //информация о предметах в магазине
        public ItemShopRecord[] itemsShop;

        //массив с информацией о покупках игровой валюты
        public ItemPaidRecord[] itemsPaid;

        //список призов, которые можно заработать в игре
        public RewardRecord[] rewards;

        //награды за приглашенных друзей
        public ReffererReward[] referrerRewards;

        //информация по квестах
        public AchievementRecord[] achievements;

        //информация о сундуках в игре
        public DowerChestInfoRecord dowerChestInfo;

        //награды, за занятые места в клановых дуэлях (индекс — уровень “сложности” турнира)
        public PlaceRewardsRecord[] clansDuelsRewards;

        //плюшки, которые пользователь получает за победы в клановых дуэлях (индекс — уровень сложности турнира)
        public ClansDuelsAttackBonusRecord[] clansDuelsAttackBonuses;

        //информация о нападении на свою базу
        public TestFightInfoRecord testFight;

        public ArtefactInfoRecord[] artefacts;

        //лимиты по расстановке ловушек на локации на карте 
        public MapLocationTrapLimitRecord[] mapLocationTrapsLimits;

        //картинки на состояния турнира
        public TournamentStateInfoRecord[] tournamentStateInfo;

        //
        public RequirementItem createClanRequirement;

        // инфа о фигне, которую не смогли никуда засунуть
        public DesignationsRecord[] designations;

        // Аудио
        public SoundsRecord[] sounds;

        /// <summary>
        /// одиночные миссии
        /// </summary>
        public MissionRecord[] missions;

        /// <summary>
        ///  карта для одиночных мисий, в которых атакуешь тем, что дают
        /// </summary>
        public MissionMap missionsMap;

        /// <summary>
        /// инфа о платных плюшках в миссиях
        /// </summary>
        public MissionsPaidItems missionsPaidItems;

        public override BuildingRecordBase[] GetBuildings()
        {
            return buildings;
        }

        public override ItemShopRecord[] GetShopItems()
        {
            return itemsShop;
        }

        public override ItemPaidRecord[] GetPaidItems()
        {
            return itemsPaid;
        }
    }
}