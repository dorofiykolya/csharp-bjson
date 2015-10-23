using Locations.Records;

namespace Records.Initialization
{
    public class SpellRecord : SpellRecordBase
    {
        public SpellLevelRecord[] levels;

        public override SpellLevelRecordBase GetLevel(int level)
        {
            if (levels == null || levels.Length == 0)
            {
                return null;
            }
            return levels.Length > level ? levels[level] : levels[0];
        }

        public override int GetLevelCount
        {
            get { return (levels == null || levels.Length == 0) ? 0 : levels.Length - 1; }
        }
    }
}
