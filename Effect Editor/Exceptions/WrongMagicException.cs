using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effect_Editor;

namespace System
{
    public class WrongMagicException : Exception
    {
        public WrongMagicException(string WrongMagic, string CorrectMagic, long offset)
            : base("The magic " + WrongMagic + "  at offset 0x" + HexUtil.Hex32((uint)offset) + "does not match the magic " + CorrectMagic + "!")
        {

        }
    }
}
