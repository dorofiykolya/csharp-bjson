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
                WriteToBuffer(GetDescription(value), value, writer);
                return buffer.ToArray();
            }
        }

        private TypeInfo GetDescription(object value)
        {
            Type type = value != null ? value.GetType() : null;
            return _typeDescriptor.GetType(type);
        }

        private void WriteToBuffer(TypeInfo info, object value, BinaryWriter writer)
        {
            _typeDescriptor.Get(info).Write(info, writer, value, this);
        }
    }
}
