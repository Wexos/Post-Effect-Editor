using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.BBLM
{
    public class BBLM
    {
        public string Magic { get; set; }
        public UInt32 FileSize { get; set; }
        public UInt64 Unknown1 { get; set; }
        public float ScaleFactor { get; set; }
        public UInt32 RGB { get; set; }
        public UInt32 blurrRGB { get; set; }
        public UInt16 Unknown2 { get; set; }
        public UInt16 Unknown3 { get; set; }

        public List<Entry> Entries { get; set; }

        public UInt32 Unknown4 { get; set; }
        public UInt32 Unknown5 { get; set; }
        public UInt32 Unknown6 { get; set; }
        public UInt32 Unknown7 { get; set; }
        public UInt32 Unknown8 { get; set; }
        public UInt32 Unknown9 { get; set; }
        public float float1 { get; set; }
        public float float2 { get; set; }
        public float float3 { get; set; }
    }
    public struct Entry
    {
        public float Unknown1 { get; set; }
        public float Unknown2 { get; set; }
        public UInt32 Unknown3 { get; set; }
        public UInt32 Unknown4 { get; set; }
        public UInt32 Unknown5 { get; set; }
        public UInt32 Unknown6 { get; set; }
        public UInt32 Unknown7 { get; set; }
        public UInt32 Unknown8 { get; set; }
    }
}
