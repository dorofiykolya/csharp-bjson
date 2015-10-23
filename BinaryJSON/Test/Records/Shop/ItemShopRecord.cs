namespace Common.Records
{
    public class ItemShopRecord
    {
        //тип раздела магазина, он же идентификатор названия
        public string label;

        /**
         * Order index
         */
        public int index;

        /**
         * Shop item type. This field used to separate items in shop
         * to categories.
         */
        public string type;

        //идентификатор херни данного типа
        public int id;

        public int price;

        public override string ToString()
        {
            return "{" + id.ToString() + ":" + type + "}";
        }
    }
}
