using System;
using System.IO;

namespace BinaryJSON
{
    public class BinaryJSONReader
    {
        private readonly TypeDescription _typeDescriptor;

        public BinaryJSONReader(TypeDescription typeDescriptor = null)
        {
            _typeDescriptor = typeDescriptor ?? new TypeDescription();
        }

        public T Read<T>(byte[] value)
        {
            using (var buffer = new MemoryStream(value))
            {
                var reader = new BinaryReader(buffer);
                return (T)Read(typeof(T), reader);
            }
        }

        internal object Read(Type type, BinaryReader reader)
        {
            var code = reader.ReadByte();
            switch (code)
            {
                case BinaryValue.NULL:
                    return _typeDescriptor.Get(TypeValue.Null).Read(reader, type, _typeDescriptor, code, this);
                case BinaryValue.BYTE:
                case BinaryValue.SBYTE:
                case BinaryValue.INT16:
                case BinaryValue.UINT16:
                case BinaryValue.INT32:
                case BinaryValue.UINT32:
                case BinaryValue.INT64:
                case BinaryValue.UINT64:
                case BinaryValue.FLOAT:
                case BinaryValue.BOOLEAN:
                case BinaryValue.DOUBLE:
                case BinaryValue.DECIMAL:
                case BinaryValue.CHAR:
                    return _typeDescriptor.Get(TypeValue.Primitive).Read(reader, type, _typeDescriptor, code, this);
                case BinaryValue.STRING:
                    return _typeDescriptor.Get(TypeValue.String).Read(reader, type, _typeDescriptor, code, this);
                case BinaryValue.ARRAY:
                    return _typeDescriptor.Get(TypeValue.Array).Read(reader, type, _typeDescriptor, code, this);
                case BinaryValue.OBJECT:
                    return _typeDescriptor.Get(TypeValue.Object).Read(reader, type, _typeDescriptor, code, this);
                case BinaryValue.DICTIONARY:
                    return _typeDescriptor.Get(TypeValue.Dictionary).Read(reader, type, _typeDescriptor, code, this);
            }
            return null;
        }
    }
}
