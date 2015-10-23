namespace Records.Initialization
{
    public class MapLocationTrapLimitRecord
    {
        //идентификатор домика
        public int buildingId;

        //максимальное количечество ловушек, которые можно разместить на обычную локацию
        public int maxQuantityOnCasualCell;

        //максимальное количечество ловушек, которые можно разместить на излучатель
        public int maxQuantityOnRadiantCell;

        //максимальное количечество ловушек, которые может разместить на обычную локацию один игрок
        public int maxQuantityOnCasualCellForUser;

        //максимальное количечество ловушек, которые может разместить на излучатель один игрок
        public int maxQuantityOnRadiantCellForUser;

    }
}
