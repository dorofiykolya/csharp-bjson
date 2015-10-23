using System.Collections.Generic;
using Common.Records;

namespace Records.Initialization
{
    public class RewardRecord
    {
        public int id;

        /// <summary>
        /// RewardUseType тип применения приза (0 — как угодно, 1 — атакующий слот, 2 — защитный слот, 3 — тактический слот);
        /// </summary>
        public int useType;

        /// <summary>
        /// RewardType тип приза (0 – unit, 1 –  boostResource, 2 –  boostArmy, 3 – shield, 4 – spell, 5 – resource, 6 –  builder, 7 — premium, 8 - buildingCapacity, 9 - experience, 10 - trtMedal, 11 - trtBoostSpellFactory (BoostShaman))
        /// </summary>
        public int type;

        /// <summary>
        /// время действия (по необходимости);
        /// </summary>
        public int time;

        /// <summary>
        /// параметры награды (Параметры наград)
        /// для Unit 			param1, param2, param3 => id юнита, уровень, кол-во
        /// для BoostResource 	param1, param2, param3 => время действия буста(сек), домики (-1 - все здания, >0 - конкретный айди домика), кол-во зданий(-1 - все здания)
        /// для BoostArmy 		param1, param2, param3 => время действия буста(сек), домики (-1 - все здания, >0 - конкретный айди домика), кол-во зданий(-1 - все здания)
        /// для Shield 			param1 =>Ид щита
        /// для Spell 			param1, param2, param3 => id спела, уровень, кол-во
        /// для Resource 		param1, param2, param3 => id ресурса; кол-во, ограничение
        /// для Builder 		нет параметров
        /// для Premium          param1 => время в секундах
        /// для BuildingCapacity param1, param2, param3 => айди домика, количество мест, время действия в секундах
        /// для Medal            param1 => айди
        /// для Experience 		param1 => кол-во
        /// для BoostShaman 		param1, param2, param3 => время действия буста(сек), домики (-1 - все здания, >0 - конкретный айди домика), кол-во зданий(-1 - все здания)
        /// </summary>
        public int param1;
        public int param2;
        public int param3;

        /// <summary>
        /// описание награды
        /// </summary>
        public string description;

        /// <summary>
        /// картинка бонуса
        /// </summary>
        public string prefab;


    }
}
