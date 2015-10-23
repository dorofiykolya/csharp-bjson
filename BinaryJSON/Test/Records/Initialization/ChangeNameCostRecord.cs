using Common.Data;

namespace Records.Initialization
{
    //стоимость смены имени игрока
    public class ChangeNameCostRecord
    {
        //секунды, с которых меняется стоимость;
        public int time;

        //стоимость;
        public ItemCount[] price;

    }
}
