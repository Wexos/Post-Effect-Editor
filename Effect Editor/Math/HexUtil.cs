using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Effect_Editor
{
    public static class HexUtil
    {
        public static string ConvertToHex(UInt64 Value)
        {
            return Value.ToString("X");
        }
        public static string ConvertToHex(Int64 Value)
        {
            return Value.ToString("X");
        }
        public static string Hex8(byte Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "0" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return Value2;
            }
            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex8(sbyte Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "0" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return Value2;
            }
            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex16(UInt16 Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "000" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return "00" + Value2;
            }

            else if (Value2.Length == 3)
            {
                return "0" + Value2;
            }

            else if (Value2.Length == 4)
            {
                return Value2;
            }

            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex16(Int16 Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "000" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return "00" + Value2;
            }

            else if (Value2.Length == 3)
            {
                return "0" + Value2;
            }

            else if (Value2.Length == 4)
            {
                return Value2;
            }

            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex32(UInt32 Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "0000000" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return "000000" + Value2;
            }

            else if (Value2.Length == 3)
            {
                return "00000" + Value2;
            }

            else if (Value2.Length == 4)
            {
                return "0000" + Value2;
            }

            else if (Value2.Length == 5)
            {
                return "000" + Value2;
            }

            else if (Value2.Length == 6)
            {
                return "00" + Value2;
            }

            else if (Value2.Length == 7)
            {
                return "0" + Value2;
            }

            else if (Value2.Length == 8)
            {
                return Value2;
            }

            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex32(Int32 Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "0000000" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return "000000" + Value2;
            }

            else if (Value2.Length == 3)
            {
                return "00000" + Value2;
            }

            else if (Value2.Length == 4)
            {
                return "0000" + Value2;
            }

            else if (Value2.Length == 5)
            {
                return "000" + Value2;
            }

            else if (Value2.Length == 6)
            {
                return "00" + Value2;
            }

            else if (Value2.Length == 7)
            {
                return "0" + Value2;
            }

            else if (Value2.Length == 8)
            {
                return Value2;
            }

            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex64(UInt64 Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "000000000000000" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return "00000000000000" + Value2;
            }

            else if (Value2.Length == 3)
            {
                return "0000000000000" + Value2;
            }

            else if (Value2.Length == 4)
            {
                return "000000000000" + Value2;
            }

            else if (Value2.Length == 5)
            {
                return "00000000000" + Value2;
            }

            else if (Value2.Length == 6)
            {
                return "0000000000" + Value2;
            }

            else if (Value2.Length == 7)
            {
                return "000000000" + Value2;
            }

            else if (Value2.Length == 8)
            {
                return "00000000" + Value2;
            }

            else if (Value2.Length == 9)
            {
                return "0000000" + Value2;
            }

            else if (Value2.Length == 10)
            {
                return "000000" + Value2;
            }

            else if (Value2.Length == 11)
            {
                return "00000" + Value2;
            }

            else if (Value2.Length == 12)
            {
                return "0000" + Value2;
            }

            else if (Value2.Length == 13)
            {
                return "000" + Value2;
            }

            else if (Value2.Length == 14)
            {
                return "00" + Value2;
            }

            else if (Value2.Length == 15)
            {
                return "0" + Value2;
            }

            else if (Value2.Length == 16)
            {
                return Value2;
            }

            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }
        public static string Hex64(Int64 Value)
        {
            string Value2 = Value.ToString("X");
            if (Value2.Length == 1)
            {
                return "000000000000000" + Value2;
            }
            else if (Value2.Length == 2)
            {
                return "00000000000000" + Value2;
            }

            else if (Value2.Length == 3)
            {
                return "0000000000000" + Value2;
            }

            else if (Value2.Length == 4)
            {
                return "000000000000" + Value2;
            }

            else if (Value2.Length == 5)
            {
                return "00000000000" + Value2;
            }

            else if (Value2.Length == 6)
            {
                return "0000000000" + Value2;
            }

            else if (Value2.Length == 7)
            {
                return "000000000" + Value2;
            }

            else if (Value2.Length == 8)
            {
                return "00000000" + Value2;
            }

            else if (Value2.Length == 9)
            {
                return "0000000" + Value2;
            }

            else if (Value2.Length == 10)
            {
                return "000000" + Value2;
            }

            else if (Value2.Length == 11)
            {
                return "00000" + Value2;
            }

            else if (Value2.Length == 12)
            {
                return "0000" + Value2;
            }

            else if (Value2.Length == 13)
            {
                return "000" + Value2;
            }

            else if (Value2.Length == 14)
            {
                return "00" + Value2;
            }

            else if (Value2.Length == 15)
            {
                return "0" + Value2;
            }

            else if (Value2.Length == 16)
            {
                return Value2;
            }

            else
            {
                throw new Exception("This shouldn't happen!");
            }
        }        
        public static bool IsHex(char c)
        {
            return (c >= '0' && c <= '9') ||
                     (c >= 'a' && c <= 'f') ||
                     (c >= 'A' && c <= 'F');
        }
    }
}
