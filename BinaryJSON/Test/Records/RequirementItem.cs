using System;
using System.Collections.Generic;
using System.Linq;

namespace Records
{
    public class RequirementItem
    {
        /// <summary>
        /// тип (0 - ресурсы, 1 - уровень домика)
        /// </summary>
        public int type;
        /// <summary>
        /// ИД (ид ресурса / ид домика)
        /// </summary>
        public int id;
        /// <summary>
        /// значение (к-во ресурса / уровень домика)
        /// </summary>
        public int value;
    }

    public static class RequirementExtension
    {
        public static RequirementItem GetItemByType(this RequirementItem[] array, int type)
        {
            return array.FirstOrDefault(item => item.type == type);
        }

        public static RequirementItem[] GetAllItemsByType(this RequirementItem[] array, int type)
        {
            return array.ToList().FindAll(item => item.type == type).ToArray();
        }

        public static RequirementItem[] Splice(this RequirementItem[] source, 
            int startIndex, int count = 0, params RequirementItem[] items)
        {
            int i = 0;
            int resultIndex = 0;
            int n = source.Length + items.Length - count;
            RequirementItem[] result = new RequirementItem[n];

            for (i = 0; i < startIndex; i++, resultIndex++)
                result[resultIndex] = source[i];

            for (i = 0; i < items.Length; i++, resultIndex++)
                result[resultIndex] = items[i];

            for (i = startIndex + count; i < source.Length; i++, resultIndex++)
                result[resultIndex] = items[i];

            return result;
        }

        public static RequirementItem[] RemoveItemById(this RequirementItem[] source, 
            params int[] types)
        {
            int resultIndex = 0;

            List<RequirementItem> result = new List<RequirementItem>();
            foreach (var requirement in source)
            {
                int index = Array.IndexOf(types, requirement.type);
                if (index == -1)
                    result.Add(requirement);
            }

            return result.ToArray();
        }

        public static Dictionary<int, RequirementItem> ToDictionary(this RequirementItem[] source)
        {
            Dictionary<int, RequirementItem> result = new Dictionary<int, RequirementItem>();

            for (int i = 0; i < source.Length; i++)
            {
                RequirementItem requirement = source[i];
                if (requirement != null)
                    result.Add(requirement.type, requirement);
            }

            return result;
        }
    }
}
