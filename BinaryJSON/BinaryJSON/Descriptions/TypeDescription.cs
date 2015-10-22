using System;
using System.Collections.Generic;

namespace BinaryJSON
{
    public class TypeDescription
    {
        private readonly Dictionary<Type, TypeInfo> _descriptions = new Dictionary<Type, TypeInfo>();
        private readonly TypeSerialization[] _serializations = new TypeSerialization[8];
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
        }

        public TypeSerialization Get(TypeInfo info)
        {
            return _serializations[(int)info.TypeValue];
        }

        public TypeSerialization Get(TypeValue type)
        {
            return _serializations[(int)type];
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
    }
}
