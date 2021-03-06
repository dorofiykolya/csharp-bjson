﻿using System;
using System.IO;

namespace BinaryJSON
{
    class PrimitiveSerialization : TypeSerialization
    {
        public override void Write(TypeInfo info, BinaryWriter buffer, object value, BinaryJSONWriter binaryJsonWriter)
        {
            var type = info.Type;
            if (type == TypeInfo.Int32)
            {
                int i = (int) value;
                if (i <= byte.MaxValue && i >= byte.MinValue)
                {
                    buffer.Write(BinaryValue.BYTE);
                    buffer.Write((byte)i);
                }
                else if (i <= sbyte.MaxValue && i >= sbyte.MinValue)
                {
                    buffer.Write(BinaryValue.SBYTE);
                    buffer.Write((sbyte)i);
                }
                else if (i <= Int16.MaxValue && i >= Int16.MinValue)
                {
                    buffer.Write(BinaryValue.INT16);
                    buffer.Write((Int16)i);
                }
                else if (i <= UInt16.MaxValue && i >= UInt16.MinValue)
                {
                    buffer.Write(BinaryValue.UINT16);
                    buffer.Write((UInt16)i);
                }
                else
                {
                    buffer.Write(BinaryValue.INT32);
                    buffer.Write(i);
                }
            }
            else if (type == TypeInfo.Float)
            {
                buffer.Write(BinaryValue.FLOAT);
                buffer.Write((float)value);
            }
            else if (type == TypeInfo.Bool)
            {
                buffer.Write(BinaryValue.BOOLEAN);
                buffer.Write((bool)value);
            }
            else if (type == TypeInfo.Double)
            {
                buffer.Write(BinaryValue.DOUBLE);
                buffer.Write((double)value);
            }
            else if (type == TypeInfo.Int16)
            {
                Int16 i = (Int16)value;
                if (i <= byte.MaxValue && i >= byte.MinValue)
                {
                    buffer.Write(BinaryValue.BYTE);
                    buffer.Write((byte)i);
                }
                else if (i <= sbyte.MaxValue && i >= sbyte.MinValue)
                {
                    buffer.Write(BinaryValue.SBYTE);
                    buffer.Write((sbyte)i);
                }
                else
                {
                    buffer.Write(BinaryValue.INT16);
                    buffer.Write(i);
                }
            }
            else if (type == TypeInfo.Byte)
            {
                buffer.Write(BinaryValue.BYTE);
                buffer.Write((byte)value);
            }
            else if (type == TypeInfo.SByte)
            {
                buffer.Write(BinaryValue.SBYTE);
                buffer.Write((sbyte)value);
            }
            else if (type == TypeInfo.UInt32)
            {
                UInt32 i = (UInt32)value;
                if (i <= byte.MaxValue)
                {
                    buffer.Write(BinaryValue.BYTE);
                    buffer.Write((byte)i);
                }
                else if (i <= UInt16.MaxValue)
                {
                    buffer.Write(BinaryValue.UINT16);
                    buffer.Write((UInt16)i);
                }
                else
                {
                    buffer.Write(BinaryValue.UINT32);
                    buffer.Write(i);
                }
            }
            else if (type == TypeInfo.UInt16)
            {
                UInt16 i = (UInt16)value;
                if (i <= byte.MaxValue)
                {
                    buffer.Write(BinaryValue.BYTE);
                    buffer.Write((byte)i);
                }
                else
                {
                    buffer.Write(BinaryValue.UINT16);
                    buffer.Write(i);
                }
            }
            else if (type == TypeInfo.Int64)
            {
                Int64 i = (Int64)value;
                if (i <= byte.MaxValue && i >= byte.MinValue)
                {
                    buffer.Write(BinaryValue.BYTE);
                    buffer.Write((byte)i);
                }
                else if (i <= sbyte.MaxValue && i >= sbyte.MinValue)
                {
                    buffer.Write(BinaryValue.SBYTE);
                    buffer.Write((sbyte)i);
                }
                else if (i <= Int16.MaxValue && i >= Int16.MinValue)
                {
                    buffer.Write(BinaryValue.INT16);
                    buffer.Write((Int16)i);
                }
                else if (i <= UInt16.MaxValue && i >= UInt16.MinValue)
                {
                    buffer.Write(BinaryValue.UINT16);
                    buffer.Write((UInt16)i);
                }
                else if (i <= Int32.MaxValue && i >= Int32.MinValue)
                {
                    buffer.Write(BinaryValue.INT32);
                    buffer.Write((int)i);
                }
                else if (i <= UInt32.MaxValue && i >= UInt32.MaxValue)
                {
                    buffer.Write(BinaryValue.UINT32);
                    buffer.Write((UInt32)i);
                }
                else
                {
                    buffer.Write(BinaryValue.INT64);
                    buffer.Write(i);
                }
            }
            else if (type == TypeInfo.UInt64)
            {
                UInt64 i = (UInt64)value;
                if (i <= byte.MaxValue)
                {
                    buffer.Write(BinaryValue.BYTE);
                    buffer.Write((byte)i);
                }
                else if (i <= UInt16.MaxValue)
                {
                    buffer.Write(BinaryValue.UINT16);
                    buffer.Write((UInt16)i);
                }
                else if (i <= Int32.MaxValue)
                {
                    buffer.Write(BinaryValue.INT32);
                    buffer.Write((int)i);
                }
                else if (i <= UInt32.MaxValue)
                {
                    buffer.Write(BinaryValue.UINT32);
                    buffer.Write((UInt32)i);
                }
                else
                {
                    buffer.Write(BinaryValue.UINT64);
                    buffer.Write(i);
                }
            }
            else if (type == TypeInfo.Decimal)
            {
                buffer.Write(BinaryValue.DECIMAL);
                buffer.Write((decimal)value);
            }
            else if (type == TypeInfo.Char)
            {
                buffer.Write(BinaryValue.CHAR);
                buffer.Write((char)value);
            }
        }

        public override object Read(BinaryReader buffer, Type resultType, TypeDescription typeDescriptor, byte code, BinaryJSONReader binaryJsonReader)
        {
            switch (code)
            {
                case BinaryValue.BYTE:
                    return Convert.ChangeType(buffer.ReadByte(), resultType);
                case BinaryValue.SBYTE:
                    return Convert.ChangeType(buffer.ReadSByte(), resultType);
                case BinaryValue.INT16:
                    return Convert.ChangeType(buffer.ReadInt16(), resultType);
                case BinaryValue.UINT16:
                    return Convert.ChangeType(buffer.ReadUInt16(), resultType);
                case BinaryValue.INT32:
                    return Convert.ChangeType(buffer.ReadInt32(), resultType);
                case BinaryValue.UINT32:
                    return Convert.ChangeType(buffer.ReadUInt32(), resultType);
                case BinaryValue.INT64:
                    return Convert.ChangeType(buffer.ReadInt64(), resultType);
                case BinaryValue.UINT64:
                    return Convert.ChangeType(buffer.ReadUInt64(), resultType);
                case BinaryValue.FLOAT:
                    return Convert.ChangeType(buffer.ReadSingle(), resultType);
                case BinaryValue.BOOLEAN:
                    return Convert.ChangeType(buffer.ReadBoolean(), resultType);
                case BinaryValue.DOUBLE:
                    return Convert.ChangeType(buffer.ReadDouble(), resultType);
                case BinaryValue.DECIMAL:
                    return Convert.ChangeType(buffer.ReadDecimal(), resultType);
                case BinaryValue.CHAR:
                    return Convert.ChangeType(buffer.ReadChar(), resultType);
            }
            return null;
        }

        public override bool AvailableTypeCode(byte code)
        {
            switch (code)
            {
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
                    return true;
            }
            return false;
        }
    }
}
