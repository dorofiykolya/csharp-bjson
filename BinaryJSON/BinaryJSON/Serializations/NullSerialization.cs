using System;
using System.IO;

namespace BinaryJSON
{
    public class NullSerialization : TypeSerialization
    {
        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            buffer.Write(BinaryValue.NULL);
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            return null;
        }
    }
}
