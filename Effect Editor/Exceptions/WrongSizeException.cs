using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effect_Editor;

namespace System
{
    public class WrongSizeException : Exception
    {
        public WrongSizeException(UInt32 CorrectSize, UInt32 WrongSize, long offset)
            : base("The file size is incorrect so the file is invalid! The correct size is " + HexUtil.Hex32(CorrectSize) + " but the size is 0x" + HexUtil.Hex32(WrongSize) + " at offset " + HexUtil.Hex32((uint)offset - 4))
        {

        }
    }
}
