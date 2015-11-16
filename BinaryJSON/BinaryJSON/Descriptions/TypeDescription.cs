using System;
using System.Collections.Generic;

namespace BinaryJSON
{
    public class TypeDescription
    {
        private readonly Dictionary<Type, TypeInfo> _descriptions = new Dictionary<Type, TypeInfo>();
        private readonly TypeSerialization[] _serializations = new TypeSerialization[8];
        private readonly Dictionary<Type, byte> _binaryValue = new Dictionary<Type, byte>();
        private readonly TypeInfo _nullTypeInfo;

        public TypeDescription()
        {
            _nullTypeInfo = new TypeInfo(this, null);

            _serializations[(int)TypeValue.Primitive] = new PrimitiveSerialization();
            _serializations[(int)TypeValue.Null] = new NullSerialization();
            _serializations[(int)TypeValue.String] = new StringSerialization();
            _serializations[(int)TypeValue.Object] = new ObjectSerialization();
            _serializations[(int)TypeValue.Array] = new ArraySerialization();
            _serializations[(int)TypeValue.List] = new ArraySerialization();
            _serializations[(int)TypeValue.Dictionary] = new DictionarySerialization();
            _serializations[(int)TypeValue.Enum] = new EnumSerialization();

            _binaryValue.Add(typeof(bool), BinaryValue.BOOLEAN);
            _binaryValue.Add(typeof(byte), BinaryValue.BYTE);
            _binaryValue.Add(typeof(sbyte), BinaryValue.SBYTE);
            _binaryValue.Add(typeof(Int16), BinaryValue.INT16);
            _binaryValue.Add(typeof(UInt16), BinaryValue.UINT16);
            _binaryValue.Add(typeof(Int32), BinaryValue.INT32);
            _binaryValue.Add(typeof(UInt32), BinaryValue.UINT32);
            _binaryValue.Add(typeof(Int64), BinaryValue.INT64);
            _binaryValue.Add(typeof(UInt64), BinaryValue.UINT64);
            _binaryValue.Add(typeof(float), BinaryValue.FLOAT);
            _binaryValue.Add(typeof(Decimal), BinaryValue.DECIMAL);
            _binaryValue.Add(typeof(Char), BinaryValue.CHAR);
            _binaryValue.Add(typeof(Double), BinaryValue.DOUBLE);
            _binaryValue.Add(typeof(String), BinaryValue.STRING);
        }

        public byte GetCodeByPrimitiveType(Type type)
        {
            return _binaryValue[type];
        }

        public TypeSerialization Get(TypeInfo info)
        {
            return _serializations[(int)info.TypeValue];
        }

        public TypeSerialization Get(TypeValue type)
        {
            return _serializations[(int)type];
        }

        public TypeSerialization Get(byte typeCode)
        {
            for (int i = 0; i < _serializations.Length; i++)
            {
                if (_serializations[i].AvailableTypeCode(typeCode))
                {
                    return _serializations[i];
                }
            }
            return null;
        }

        public TypeSerialization Get(Type type)
        {
            return Get(GetType(type).TypeValue);
        }

        public TypeInfo GetType(Type type)
        {
            if (type == null) return _nullTypeInfo;
            TypeInfo result;
            if (!_descriptions.TryGetValue(type, out result))
            {
                result = new TypeInfo(this, type);
                _descriptions.Add(type, result);
            }
            return result;
        }

        public TypeInfo GetType(object value)
        {
            if (value == null) return _nullTypeInfo;
            Type type = value.GetType();
            return GetType(type);
        }
    }
}
