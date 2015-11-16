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
            return _typeDescriptor.Get(code).Read(reader, type, _typeDescriptor, code, this);
        }
    }
}
