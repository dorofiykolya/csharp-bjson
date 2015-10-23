using Records;

namespace Locations.Records
{
    public class SpellRecordBase : IShowedInInfoWindow
    {
        //идентификатор
        public int id;

        //идентификатор названия
        public string name;

        //идентификатор описания
        public string description;

        //время создания заклинания
        public int creationTime;

        //идентификатор изображения
        public string prefab;

        public string[] infoProgress;
        public string[] infoText;

        //позиция для отображения умения в фабрике
        public int createPosition;

        //позиция спелла в исследованиях (верхний ряд - четные индексы, нижний - нечетные, нумерация с 0)
        public int researchPosition;

        //уровень фабрики умений, необходимый для открытия заклинания
        //public int requiredSFLevel;

        //тип целей
        public int targetsType;

        //ссылка на картинку, на локации (над ратушой)
        public string prefabActiveSpell;

        //массив с идентификаторами описаний параметров умения
        public int[] paramsDescriptions;

        //при положительном значении можно применять только на локации, при отрицатеьлном — только в бою
        public bool usableOnLocation;

        public virtual SpellLevelRecordBase GetLevel(int level)
        {
            return null;
        }

        public virtual int GetLevelCount
        {
            get { return 0; }
        }

        public string[] InfoProgress
        {
            get { return infoProgress; }
        }

        public string[] InfoText
        {
            get { return infoText; }
        }
    }
}
