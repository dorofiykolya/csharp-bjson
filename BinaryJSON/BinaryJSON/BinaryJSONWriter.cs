using System;
using System.IO;

namespace BinaryJSON
{
    public class BinaryJSONWriter
    {
        private readonly TypeDescription _typeDescriptor;

        public BinaryJSONWriter(TypeDescription typeDescriptor = null)
        {
            _typeDescriptor = typeDescriptor ?? new TypeDescription();
        }

        public byte[] Write(object value)
        {
            using (var buffer = new MemoryStream(64))
            {
                var writer = new BinaryWriter(buffer);
                Write(value, writer);
                return buffer.ToArray();
            }
        }

        internal void Write(object value, BinaryWriter buffer)
        {
            var info = _typeDescriptor.GetType(value);
            Write(info, value, buffer);
        }

        internal void Write(TypeInfo info, object value, BinaryWriter buffer)
        {
            _typeDescriptor.Get(info).Write(info, buffer, value, this);
        }
    }
}
