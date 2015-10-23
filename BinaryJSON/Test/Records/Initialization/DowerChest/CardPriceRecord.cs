using Common.Data;

namespace Records.Initialization
{
    public class CardPriceRecord
    {
        //уровень ратуши
        public int ccLevel;

        //i-ый елемент массива — стоимость открытия i-ой карты (первый элемент забит нулями, стоимость расчитывается отдельно)
        public ItemCount[] itemsCount;
    }
}
