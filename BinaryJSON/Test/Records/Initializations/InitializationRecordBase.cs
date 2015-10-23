using System;
using System.Collections.Generic;
using Records.Initialization;

namespace Common.Records.Initializations
{
    public class InitializationRecordBase
    {
        public virtual BuildingRecordBase[] GetBuildings()
        {
            //need to override
            return new BuildingRecordBase[0];
        }

        public virtual ItemShopRecord[] GetShopItems()
        {
            return new ItemShopRecord[0];
        }

        public virtual ItemPaidRecord[] GetPaidItems()
        {
            return new ItemPaidRecord[0];
        }
    }
}