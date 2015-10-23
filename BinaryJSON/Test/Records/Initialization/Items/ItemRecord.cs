using Common.Data;

namespace Records.Initialization
{
    public class ItemRecord
    {
        public int id;

        //тип предмета (0 = ‘money’(gems), 1 = ‘resource’(energy,toxine), 2 = ‘shield’, 3 = ‘fill_storage_by_percent’, 4 = ‘fill_storage_full’)
        public int type;

        //идентификатор имени предмета
        public string name;

        //идентификатор описания предмета
        public string description;

        //идентификатор изображения
        public string image;

        //идентификатор иконки
        public string icon;

        //эффект, который накладывается при использовании предмета (0 = ‘none’, 1 = ‘shield’, 2 = ‘fill_storage’)
        public int effect;

        //время длительности эффекта в секундах
        public int time;

        //время в секундах, которое нельзя будет повторно покупать данный предмет
        public int cooldown;

        public RequirementItem[] price;

        //client internal field to indicate 
        public bool isActive = false;
    }
}
