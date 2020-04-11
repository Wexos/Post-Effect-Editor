using System;
using System.Text;

namespace System.IO
{
    public class BigEndianReader : BinaryReader //By Wexos
    {
        public BigEndianReader(Stream stream) : base(stream) { }

        public override byte ReadByte()
        {
            return base.ReadByte();
        }
        public override byte[] ReadBytes(int Count)
        {
            byte[] value = new byte[Count];
            for (int i = 0; i < Count; i++)
            {
                value[i] = base.ReadByte();
            }
            return value;
        }
        public byte[] ReadBytes(uint Count)
        {
            byte[] value = new byte[Count];
            for (int i = 0; i < Count; i++)
            {
                value[i] = base.ReadByte();
            }
            return value;
        }
        public override SByte ReadSByte()
        {
            return base.ReadSByte();
        }
        public SByte[] ReadSBytes(int Count)
        {
            SByte[] value = new SByte[Count];
            for (int i = 0; i < Count; i++)
            {
                value[i] = base.ReadSByte();
            }
            return value;
        }
        public SByte[] ReadSBytes(uint Count)
        {
            SByte[] value = new SByte[Count];
            for (int i = 0; i < Count; i++)
            {
                value[i] = base.ReadSByte();
            }
            return value;
        }        
        public override UInt16 ReadUInt16()
        {
            byte[] value = base.ReadBytes(0x02);
            Array.Reverse(value);
            return BitConverter.ToUInt16(value, 0);
        }
        public UInt16[] ReadUInt16s(int Count)
        {
            UInt16[] value = new UInt16[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x02);
                Array.Reverse(value2);
                value[i] = BitConverter.ToUInt16(value2, 0);
            }
            return value;
        }
        public UInt16[] ReadUInt16s(uint Count)
        {
            UInt16[] value = new UInt16[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x02);
                Array.Reverse(value2);
                value[i] = BitConverter.ToUInt16(value2, 0);
            }
            return value;
        }
        public override Int16 ReadInt16()
        {
            byte[] value = base.ReadBytes(0x02);
            Array.Reverse(value);
            return BitConverter.ToInt16(value, 0);
        }
        public Int16[] ReadInt16s(int Count)
        {
            Int16[] value = new Int16[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x02);
                Array.Reverse(value2);
                value[i] = BitConverter.ToInt16(value2, 0);
            }
            return value;
        }
        public Int16[] ReadInt16s(uint Count)
        {
            Int16[] value = new Int16[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x02);
                Array.Reverse(value2);
                value[i] = BitConverter.ToInt16(value2, 0);
            }
            return value;
        }
        public override UInt32 ReadUInt32()
        {
            byte[] value = base.ReadBytes(0x04);
            Array.Reverse(value);
            return BitConverter.ToUInt32(value, 0);
        }
        public UInt32[] ReadUInt32s(int Count)
        {
            UInt32[] value = new UInt32[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x04);
                Array.Reverse(value2);
                value[i] = BitConverter.ToUInt32(value2, 0);
            }
            return value;
        }
        public UInt32[] ReadUInt32s(uint Count)
        {
            UInt32[] value = new UInt32[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x04);
                Array.Reverse(value2);
                value[i] = BitConverter.ToUInt32(value2, 0);
            }
            return value;
        }
        public override Int32 ReadInt32()
        {
            byte[] value = base.ReadBytes(0x04);
            Array.Reverse(value);
            return BitConverter.ToInt32(value, 0);
        }
        public Int32[] ReadInt32s(int Count)
        {
            Int32[] value = new Int32[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x04);
                Array.Reverse(value2);
                value[i] = BitConverter.ToInt32(value2, 0);
            }
            return value;
        }
        public Int32[] ReadInt32s(uint Count)
        {
            Int32[] value = new Int32[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x04);
                Array.Reverse(value2);
                value[i] = BitConverter.ToInt32(value2, 0);
            }
            return value;
        }
        public override UInt64 ReadUInt64()
        {
            byte[] value = base.ReadBytes(0x08);
            Array.Reverse(value);
            return BitConverter.ToUInt64(value, 0);
        }
        public UInt64[] ReadUInt64s(int Count)
        {
            UInt64[] value = new UInt64[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x08);
                Array.Reverse(value2);
                value[i] = BitConverter.ToUInt64(value2, 0);
            }
            return value;
        }
        public UInt64[] ReadUInt64s(uint Count)
        {
            UInt64[] value = new UInt64[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x08);
                Array.Reverse(value2);
                value[i] = BitConverter.ToUInt64(value2, 0);
            }
            return value;
        }
        public override Int64 ReadInt64()
        {
            byte[] value = base.ReadBytes(0x08);
            Array.Reverse(value);
            return BitConverter.ToInt64(value, 0);
        }
        public Int64[] ReadInt64s(int Count)
        {
            Int64[] value = new Int64[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x08);
                Array.Reverse(value2);
                value[i] = BitConverter.ToInt64(value2, 0);
            }
            return value;
        }
        public Int64[] ReadInt64s(uint Count)
        {
            Int64[] value = new Int64[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x08);
                Array.Reverse(value2);
                value[i] = BitConverter.ToInt64(value2, 0);
            }
            return value;
        }
        public override Single ReadSingle()
        {
            byte[] value = base.ReadBytes(0x04);
            Array.Reverse(value);
            return BitConverter.ToSingle(value, 0);
        }
        public Single[] ReadSingles(int Count)
        {
            Single[] value = new Single[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x04);
                Array.Reverse(value2);
                value[i] = BitConverter.ToSingle(value2, 0);
            }
            return value;
        }
        public Single[] ReadSingles(uint Count)
        {
            Single[] value = new Single[Count];
            for (int i = 0; i < Count; i++)
            {
                byte[] value2 = base.ReadBytes(0x04);
                Array.Reverse(value2);
                value[i] = BitConverter.ToSingle(value2, 0);
            }
            return value;
        }
        public override String ReadString()
        {
            return base.ReadString();
        }
        public string ReadASCII(int count)
        {
            return Encoding.ASCII.GetString(base.ReadBytes(count));
        }
        public string ReadASCII(uint count)
        {
            return Encoding.ASCII.GetString(base.ReadBytes(Convert.ToInt32(count)));
        }
        public String[] ReadStrings(int Count)
        {
            String[] value = new String[Count];
            for (int i = 0; i < Count; i++)
            {
                value[i] = base.ReadString();
            }
            return value;
        }        
    }
}
