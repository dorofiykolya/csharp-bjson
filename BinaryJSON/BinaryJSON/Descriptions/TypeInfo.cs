using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace BinaryJSON
{
    public enum TypeValue
    {
        Null,
        Primitive,
        Array,
        Object,
        String,
        List,
        Dictionary,
        Enum
    }

    public class TypeInfo
    {
        public static readonly Type Int32 = typeof(Int32);
        public static readonly Type Int16 = typeof(Int16);
        public static readonly Type UInt32 = typeof(UInt32);
        public static readonly Type UInt16 = typeof(UInt16);
        public static readonly Type Int64 = typeof(Int64);
        public static readonly Type UInt64 = typeof(UInt64);
        public static readonly Type Byte = typeof(Byte);
        public static readonly Type SByte = typeof(SByte);
        public static readonly Type Bool = typeof(Boolean);
        public static readonly Type Float = typeof(Single);
        public static readonly Type Double = typeof(Double);
        public static readonly Type Decimal = typeof(Decimal);
        public static readonly Type Char = typeof(Char);

        public static readonly byte SizeInt32 = sizeof(Int32);
        public static readonly byte SizeInt16 = sizeof(Int16);
        public static readonly byte SizeUInt32 = sizeof(UInt32);
        public static readonly byte SizeUInt16 = sizeof(UInt16);
        public static readonly byte SizeInt64 = sizeof(Int64);
        public static readonly byte SizeUInt64 = sizeof(UInt64);
        public static readonly byte SizeByte = sizeof(Byte);
        public static readonly byte SizeSByte = sizeof(SByte);
        public static readonly byte SizeBool = sizeof(Boolean);
        public static readonly byte SizeFloat = sizeof(Single);
        public static readonly byte SizeDouble = sizeof(Double);
        public static readonly byte SizeDecimal = sizeof(Decimal);
        public static readonly byte SizeChar = sizeof(Char);

        public readonly TypeDescription TypeDescriptions;
        public readonly Type Type;
        public readonly Type EnumUnderlyingType;
        public readonly TypeValue TypeValue;
        public readonly FieldInfo[] Fields;

        private readonly Dictionary<string, FieldInfo> _fields;

        public TypeInfo(TypeDescription typeDescription, Type type)
        {
            TypeDescriptions = typeDescription;
            Type = type;
            Type generic;
            if (type == null)
            {
                TypeValue = TypeValue.Null;
            }
            else if (type.IsPrimitive)
            {
                TypeValue = TypeValue.Primitive;
            }
            else if (type.IsArray)
            {
                TypeValue = TypeValue.Array;
            }
            else if (type.IsEnum)
            {
                TypeValue = TypeValue.Enum;
                EnumUnderlyingType = Enum.GetUnderlyingType(type);
            }
            else if (type == typeof(string))
            {
                TypeValue = TypeValue.String;
            }
            else if (typeof(IList).IsAssignableFrom(type))
            {
                TypeValue = TypeValue.List;
            }
            else if (typeof(IDictionary).IsAssignableFrom(type) && ((generic = type.GetGenericArguments()[0]).IsPrimitive || generic.IsEnum || generic == typeof(string)))
            {
                TypeValue = TypeValue.Dictionary;
            }
            else
            {
                TypeValue = TypeValue.Object;
                Fields = type.GetFields(BindingFlags.Instance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.Public);
                var count = Fields.Length;
                _fields = new Dictionary<string, FieldInfo>(count);
                FieldInfo field;
                for (int i = 0; i < count; i++)
                {
                    field = Fields[i];
                    _fields.Add(field.Name, field);
                }
            }
        }

        public FieldInfo GetField(string name)
        {
            FieldInfo result;
            _fields.TryGetValue(name, out result);
            return result;
        }

        public void SetValue(string name, object target, object value)
        {
            var field = GetField(name);
            if (field != null)
            {
                field.SetValue(target, value);
            }
        }
    }
}
