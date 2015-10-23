using Records;

namespace Locations.Records
{
    public class SpellLevelRecordBase
    {
        //уровень лаборатории, необходимый для исследования
        //public int requiredTLLevel;        

        //предметы, необходимые для исследования и создания:
        public RequirementItem[] researchRequirements;
        public RequirementItem[] createRequirements;

        //значения параметров умения (для спеллов, которые применяются на локации: params[0] — увеличение характеристики, params[1] — время действия)
        public int[] parameters;

        //идентификатор наносимого урона
        public int damageId;

        //идентификатор действия заклинания, которое происходит при использовании
        public int spellActionId;
        //маленькая картинка для магазина;
        public string prefabShop;
        
        //время исследования умения до текщего уровня
        public int researchTime;
    }
}
