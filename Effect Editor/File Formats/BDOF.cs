using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.BDOF
{
    public class BDOF
    {
        public string Magic { get; set; }
        public UInt32 FileSize { get; set; }
        public UInt64 Unknown1 { get; set; }
        public UInt16 Activator { get; set; } //Unshure
        public UInt16 Unknown2 { get; set; }
        public UInt32 Unknown3 { get; set; }
        public float[] FloatValues { get; set; } //float[10]
        public UInt64[] Padding { get; set; } //Padding (0x10) UInt64[2]
    }
}