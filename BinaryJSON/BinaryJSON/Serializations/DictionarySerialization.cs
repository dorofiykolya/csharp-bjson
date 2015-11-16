using System;
using System.Collections;
using System.IO;
using System.Text;

namespace BinaryJSON
{
    class DictionarySerialization : TypeSerialization
    {
        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            if (value == null)
            {
                buffer.Write(BinaryValue.NULL);
            }
            else
            {
                buffer.Write(BinaryValue.DICTIONARY);
                var dictionary = (IDictionary)value;
                var count = dictionary.Count;
                buffer.Write((int)count);

                var keyType = dictionary.GetType().GetGenericArguments()[0];
                if (keyType.IsEnum) keyType = Enum.GetUnderlyingType(keyType);
                var code = info.TypeDescriptions.GetCodeByPrimitiveType(keyType);
                buffer.Write(code);

                foreach (var key in dictionary.Keys)
                {
                    WriteField(key, buffer, code);
                    var keyValue = dictionary[key];
                    binaryJsonWriter.Write(keyValue, buffer);
                }
            }
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            var count = buffer.ReadInt32();
            var keyCode = buffer.ReadByte();
            IDictionary result = null;
            Type valueType = null;
            if (IsValidDictionary(resultType))
            {
                result = (IDictionary)Activator.CreateInstance(resultType);
                valueType = resultType.GetGenericArguments()[1];
            }
            for (int i = 0; i < count; i++)
            {
                var key = ReadField(buffer, keyCode);
                var value = binaryJsonReader.Read(valueType, buffer);
                if (result != null)
                {
                    result.Add(key, GetValue(value, valueType));
                }
            }
            return result;
        }

        private object GetValue(object value, Type resultType)
        {
            if (value == null) return null;
            var valueType = value.GetType();
            if (valueType.IsPrimitive || valueType == typeof(string))
            {
                value = Convert.ChangeType(value, resultType);
            }
            return value;
        }

        private bool IsValidDictionary(Type type)
        {
            var genericKey = type.GetGenericArguments()[0];
            return genericKey.IsPrimitive || genericKey == typeof(string) || genericKey.IsEnum;
        }

        private void WriteField(object key, BinaryWriter writer, byte code)
        {
            switch (code)
            {
                case BinaryValue.BYTE:
                    writer.Write((byte)key);
                    break;
                case BinaryValue.SBYTE:
                    writer.Write((sbyte)key);
                    break;
                case BinaryValue.INT16:
                    writer.Write((Int16)key);
                    break;
                case BinaryValue.UINT16:
                    writer.Write((UInt16)key);
                    break;
                case BinaryValue.INT32:
                    writer.Write((Int32)key);
                    break;
                case BinaryValue.UINT32:
                    writer.Write((UInt32)key);
                    break;
                case BinaryValue.INT64:
                    writer.Write((Int64)key);
                    break;
                case BinaryValue.UINT64:
                    writer.Write((UInt64)key);
                    break;
                case BinaryValue.FLOAT:
                    writer.Write((float)key);
                    break;
                case BinaryValue.BOOLEAN:
                    writer.Write((bool)key);
                    break;
                case BinaryValue.DOUBLE:
                    writer.Write((double)key);
                    break;
                case BinaryValue.DECIMAL:
                    writer.Write((decimal)key);
                    break;
                case BinaryValue.CHAR:
                    writer.Write((char)key);
                    break;
                case BinaryValue.STRING:
                    var bytes = Encoding.ASCII.GetBytes((string)key);
                    writer.Write(bytes.Length);
                    writer.Write(bytes);
                    break;
            }
        }

        private object ReadField(BinaryReader reader, byte code)
        {
            switch (code)
            {
                case BinaryValue.BYTE:
                    return reader.ReadByte();
                case BinaryValue.SBYTE:
                    return reader.ReadSByte();
                case BinaryValue.INT16:
                    return reader.ReadInt16();
                case BinaryValue.UINT16:
                    return reader.ReadUInt16();
                case BinaryValue.INT32:
                    return reader.ReadInt32();
                case BinaryValue.UINT32:
                    return reader.ReadUInt32();
                case BinaryValue.INT64:
                    return reader.ReadInt64();
                case BinaryValue.UINT64:
                    return reader.ReadUInt64();
                case BinaryValue.FLOAT:
                    return reader.ReadSingle();
                case BinaryValue.BOOLEAN:
                    return reader.ReadBoolean();
                case BinaryValue.DOUBLE:
                    return reader.ReadDouble();
                case BinaryValue.DECIMAL:
                    return reader.ReadDecimal();
                case BinaryValue.CHAR:
                    return reader.ReadChar();
                case BinaryValue.STRING:
                    var count = reader.ReadInt32();
                    var bytes = reader.ReadBytes(count);
                    return Encoding.ASCII.GetString(bytes);
            }
            throw new Exception("do not support type");
        }

        public override bool AvailableTypeCode(byte code)
        {
            return code == BinaryValue.DICTIONARY;
        }
    }
}
