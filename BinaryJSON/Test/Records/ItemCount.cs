
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Data
{
    [Serializable]
    public class ItemCount
    {
        public int id;
        public int count;
        public ItemCount()
        {
        }

        public ItemCount(int id)
        {
            this.id = id;
        }

        public ItemCount(int id, int count)
        {
            this.id = id;
            this.count = count;
        }
    }

    [Serializable]
    public class ItemLevelCount : ItemCount
    {
        public int level;

        public ItemLevelCount()
        {
            
        }

        public ItemLevelCount(int id, int count)
        {
            this.id = id;
            level = 0;
            this.count = count;
        }

        public ItemLevelCount(int id, int level, int count)
        {
            this.id = id;
            this.level = level;
            this.count = count;
        }

        public ItemLevelCount Copy()
        {
            return new ItemLevelCount(id, level, count);
        }

        // Comparer

        public static ItemLevelCountComparer DefaultComparer = new ItemLevelCountComparer();

        public class ItemLevelCountComparer : Comparer<ItemLevelCount>
        {
            public override int Compare(ItemLevelCount x, ItemLevelCount y)
            {
                return x.id - y.id;
            }
        }
    }


    public static class ItemLevelCountHelper
    {
        public static bool IsEmpty(this IEnumerable<ItemLevelCount> collection)
        {
            return collection == null || collection.All(s => s.count <= 0);
        }

        public static int Count(this IEnumerable<ItemLevelCount> collection, int id, int level)
        {
            if (collection == null) return 0;
            var firstOrDefault = collection.FirstOrDefault(s => s.id == id && s.level == level);
            if (firstOrDefault != null)
                return firstOrDefault.count;
            return 0;
        }

        public static void DeleteCount(this IEnumerable<ItemLevelCount> collection, int id, int level, int count = 1)
        {
            var firstOrDefault = collection.FirstOrDefault(s => s.id == id && s.level == level);
            if (firstOrDefault != null)
            {
                firstOrDefault.count -= count;
            }
        }
        
        public static void DeleteAt(this ItemLevelCount[] collection, int id)
        {
            var lenght = collection.Length;
            if (id < 0 || id >= lenght)
                return;

            if (id < lenght - 1)
                Array.Copy(collection, id + 1, collection, id, lenght - id - 1);

            Array.Resize(ref collection, lenght - 1);
        }

        public static ItemLevelCount[] Copy(this ItemLevelCount[] collection)
        {
            var result = new ItemLevelCount[collection.Length];
            for (var i = 0; i < collection.Length; i++)
            {
                result[i] = collection[i].Copy();
            }
            return result;
        }
    }
}
