using System;
using System.Collections;
using System.IO;

namespace BinaryJSON
{
    public class ArraySerialization : TypeSerialization
    {
        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            if (value == null)
            {
                buffer.Write(BinaryValue.NULL);
            }
            else
            {
                var arr = value as Array;
                IEnumerable enumerable = null;
                int count = 0;
                if (arr != null)
                {
                    count = arr.Length;
                    enumerable = arr;
                }
                else
                {
                    var coll = value as IList;
                    if (coll != null)
                    {
                        enumerable = coll;
                        count = coll.Count;
                    }
                }
                if (enumerable != null)
                {
                    buffer.Write(BinaryValue.ARRAY);
                    buffer.Write((int)count);

                    foreach (var item in enumerable)
                    {
                        var itemDescription = info.TypeDescriptions.GetType(item != null ? item.GetType() : null);
                        info.TypeDescriptions.Get(itemDescription).Write(itemDescription, buffer, item, binaryJsonWriter);
                    }
                }
            }
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            var count = buffer.ReadInt32();
            object result = resultType != null ? Activator.CreateInstance(resultType, count) : null;
            var array = result as Array;
            var collection = result as IList;
            Type elemenType = resultType != null ? resultType.GetElementType() : null;
            if (elemenType == null && resultType != null)
            {
                elemenType = resultType.GetGenericArguments()[0];
            }
            for (int i = 0; i < count; i++)
            {
                var current = binaryJsonReader.Read(elemenType, buffer);
                if (array != null)
                {
                    array.SetValue(current, i);
                }
                else if (collection != null)
                {
                    collection.Add(current);
                }
            }
            return result;
        }
    }
}
