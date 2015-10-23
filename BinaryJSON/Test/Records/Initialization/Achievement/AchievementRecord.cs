namespace Records.Initialization
{
    public class AchievementRecord
    {
        public int id;

        //идентификатор названия квеста
        public string name;

        //уровни квестов
        public RewardLevelRecord[] levels;

        public RewardLevelRecord GetLevelInfo(int level)
        {
            if (level < 1)
                level = 1;
            if (level > levels.Length)
                level = levels.Length;

            RewardLevelRecord levelRecord = null;
            foreach (var levelInfo in levels)
                if (level == levelInfo.level)
                {
                    levelRecord = levelInfo;
                    break;
                }
            return levelRecord;
        }
    }
}
