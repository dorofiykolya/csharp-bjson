using System;
using System.IO;

namespace BinaryJSON
{
    class EnumSerialization : TypeSerialization
    {
        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            buffer.Write(BinaryValue.ENUM);
            var result = Convert.ChangeType(value, info.EnumUnderlyingType);
            var infoType = info.TypeDescriptions.GetType(info.EnumUnderlyingType);
            binaryJsonWriter.Write(infoType, result, buffer);
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code,
            BinaryJSONReader binaryJsonReader)
        {
            var value = binaryJsonReader.Read(Enum.GetUnderlyingType(resultType), buffer);
            var result = Enum.ToObject(resultType, value);
            return result;
        }

        public override bool AvailableTypeCode(byte code)
        {
            return code == BinaryValue.ENUM;
        }
    }
}
