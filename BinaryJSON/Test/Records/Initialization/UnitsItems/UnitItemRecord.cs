namespace Records.Initialization
{
    public class UnitItemRecord
    {
        //идентификатор предмета
        public int id;

        //тип предмета(0 - увеличивает здоровье; 1 -увеличивает скорость; 2 - увеличивает  урон; 3 -  увеличивает скорость атаки; 4 - уменьшает время лечения)
        public int type;

        //идентификатор имени предмета
        public string name;

        //идентификатор описания предмета
        public string description;

        //положение картинки предмета, относительно картинки юнита
        public int x;

        //положение картинки предмета, относительно картинки юнита
        public int y;

        public UnitItemLevelRecord[] levels;

        public UnitItemLevelRecord GetLevel(int level)
        {
            if (levels == null || levels.Length == 0)
            {
                return null;
            }
            return levels.Length > level ? levels[level] : levels[0];
        }

        public int GetLevelCount
        {
            get { return (levels == null) ? 0 : levels.Length - 1; }
        }
    }
}
