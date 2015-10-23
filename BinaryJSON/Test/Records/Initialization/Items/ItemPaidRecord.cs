namespace Records.Initialization
{
    public class ItemPaidRecord
    {
        public int id;

        //стоимость в валюте платформы
        public int price;

        //количество игровой валюты
        public int itemId;

        //количество игровой валюты
        public int itemCount;

        //количество бонуса
        public int bonus;

        //идентификатор названия товара
        public string name;

        //идентификатор описания товара
        public string description;

        //идентификатор изображения товара
        public string image;

        //тип платежной системы (VK = 1, OK = 2, FB = 3, MM = 4, Google = 5, QZone = 6, Apple = 7)
        public int paymentType;

    }
}
