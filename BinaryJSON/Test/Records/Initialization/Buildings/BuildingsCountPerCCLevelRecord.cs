using Common.Data;

namespace Records.Initialization
{
    public class BuildingsCountPerCCLevelRecord
    {
        //уровень командного центра;
        public int ccLevel;
        //доступные здания
        public ItemCount[] buildings;
    }
}
