using Common.Data;

namespace Records.Initialization
{
    public class TestFightItemPriceRecord
    {
        public int id;

        //тип (0 — ’unit’, 1 — ‘spell’)
        public int type;

        public int level;

        //необходимые предметы
        public ItemCount[] requirements;
    }
}
