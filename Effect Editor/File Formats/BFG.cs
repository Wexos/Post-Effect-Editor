using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.BFG
{
    public class BFG
    {
        public UInt32 Unknown1 { get; set; }
        public float Unknown2 { get; set; }

        public List<Entry> Entries { get; set; }

        public float Float4A { get; set; }
        public UInt32 Bytes4A { get; set; }
        public UInt16 Unknown4A { get; set; }
        public UInt16 Unknown4B { get; set; }
        public float Float4B { get; set; }
        public UInt32 Unknown4C { get; set; }
    }
    public struct Entry
    {
        public float Distance { get; set; }
        public UInt32 RGBA { get; set; }
        public UInt16 Unknown1 { get; set; }
        public UInt16 Unknown2 { get; set; }
        public float Float1B { get; set; }
        public UInt32 Unknown3 { get; set; }
        public UInt32 Unknown4 { get; set; }
        public UInt32 Padding { get; set; }
    }
}
