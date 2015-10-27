using System;
using System.IO;
using System.Text;

namespace BinaryJSON
{
    class ObjectSerialization : TypeSerialization
    {
        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            if (value == null)
            {
                buffer.Write(BinaryValue.NULL);
            }
            else
            {
                buffer.Write(BinaryValue.OBJECT);
                buffer.Write((int)info.Fields.Length);
                foreach (var field in info.Fields)
                {
                    WriteField(buffer, field.Name);
                    var typeInfo = info.TypeDescriptions.GetType(field.FieldType);
                    binaryJsonWriter.Write(typeInfo, field.GetValue(value), buffer);
                }
            }
        }

        private void WriteField(BinaryWriter buffer, string value)
        {
            var bytes = Encoding.ASCII.GetBytes(value);
            buffer.Write((int)bytes.Length);
            buffer.Write(bytes);
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            var count = buffer.ReadInt32();
            object result = resultType != null? Activator.CreateInstance(resultType) : null;
            for (int i = 0; i < count; i++)
            {
                var fieldName = ReadField(buffer);
                var info = typeDescriptor.GetType(resultType);
                var field = info.GetField(fieldName);
                Type type = field != null ? field.FieldType : null;
                var value = binaryJsonReader.Read(type, buffer);
                if (field != null)
                {
                    info.SetValue(fieldName, result, value);
                }
            }
            return result;
        }

        private string ReadField(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            return Encoding.ASCII.GetString(reader.ReadBytes(count));
        }
    }
}
