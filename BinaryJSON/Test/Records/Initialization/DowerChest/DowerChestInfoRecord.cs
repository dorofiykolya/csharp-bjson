namespace Records.Initialization
{
    public class DowerChestInfoRecord
    {
        //идентификатор ресурса (для открытия первой карты)
        public int itemIdFirstCard;

        //процент от общей вместимости складов ресурса (для открытия первой карты)
        public int percentFirstCard;

        //стоимость открытия карт в зависимоти от уровня ратуши
        public CardPriceRecord[] cardsPricesByCCLevel;

        //массив возможных карточек
        public CardRewardInfoRecord[] cards;
    }
}
