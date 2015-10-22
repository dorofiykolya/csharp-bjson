using System;
using System.IO;
using System.Text;

namespace BinaryJSON
{
    public class StringSerialization : TypeSerialization
    {
        public StringSerialization()
        {
        }

        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            if (value == null)
            {
                buffer.Write(BinaryValue.NULL);
            }
            else
            {
                buffer.Write(BinaryValue.STRING);
                var bytes = Encoding.UTF8.GetBytes((string)value);
                buffer.Write((int)bytes.Length);
                buffer.Write(bytes);
            }
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            var count = buffer.ReadInt32();
            var bytes = buffer.ReadBytes(count);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
