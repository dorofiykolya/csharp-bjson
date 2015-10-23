
namespace Modules.Requirement
{
    public class RequirementType
    {
        //-----------------------------
        // Resource requirements
        //-----------------------------

        public const int RESOURCE_COUNT = 0;


        //-----------------------------
        // Building requirements
        //-----------------------------

        /** 
         * Count of building on location 
         */
        public const int BUILDING_COUNT = 20;

        /** 
         * Requirement with this type check to reach maximum number of 
         * building with specific type.
         */
        public const int BUILDING_MAX_COUNT = 27;

        /** 
         * Building limit depending on command center level.
         */
        public const int BUILDING_LIMIT = 22;

        /** 
         * Existance of building. This requirement type check availability 
         * of building on location 
         */
        public const int BUILDING_EXISTS = 23;

        /** 
         * Level of building. Requrement with this type compare passed 
         * level with max level of buildings on location with specific
         * buildingType
         */
        public const int BUILDING_LEVEL = 1;

        /**
         * Level of building. Requirement with this type compare passed
         * level with max level of building on location.
         */
        public const int LOCATION_BUILDING_LEVEL = 24;

        /**
         * 
         */
        public const int BUILDING_LIMIT_DIFF = 25;

        /**
         * 
         */
        public const int LOCATION_SPACE = 26;


        //-----------------------------
        // Quest requirements
        //-----------------------------

        public const int QUEST_RUNING = 30;
        public const int QUEST_COMPLETED = 38;


        //-----------------------------
        // Item requirements
        //-----------------------------

        public const int ITEM_COUNT = 40;


        //-----------------------------
        // Special requiremetns
        //-----------------------------
        
        public const int HERO_LEVEL = 50;
        public const int TECH_LAB_LEVEL = 51;
        public const int COMAND_CENTER_LEVEL = 52;


        //-----------------------------
        // 
        //-----------------------------

        public const int BUILDER_COUNT = 60;
        

    }
}