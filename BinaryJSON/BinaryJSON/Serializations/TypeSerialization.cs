using System;
using System.IO;

namespace BinaryJSON
{
    public class TypeSerialization
    {
        public virtual void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            
        }

        public virtual object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            return null;
        }

        public virtual bool AvailableTypeCode(byte code)
        {
            return false;
        }
    }
}
