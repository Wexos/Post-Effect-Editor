using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.BLMAP
{
    public class BLMAP
    {
        public string Magic { get; set; }
        public UInt32 FileSize { get; set; }
        public UInt32 Unknown1 { get; set; }
        public UInt32 Unknown2 { get; set; }
        public UInt16 NrLTEX { get; set; }
        public UInt16 Unknown3 { get; set; }
        public UInt32 Unknown4 { get; set; }
        public UInt32 Unknown5 { get; set; }
        public UInt32 Unknown6 { get; set; }
    }        
    public class BLMAPLTEX
    {
        public string Magic { get; set; }
        public UInt32 SectionSize { get; set; }
        public UInt32 Padding { get; set; }
        public UInt32 Unknown { get; set; }
        public UInt16 NrEntries { get; set; }
        public UInt16 Unknown1 { get; set; }
        public string Texture { get; set; }
        public UInt32 Unknown2 { get; set; }
        public UInt32 Unknown3 { get; set; }
        public UInt32 Unknown4 { get; set; }
        public UInt32 Unknown5 { get; set; }
        public UInt32 Unknown6 { get; set; }
        public UInt32 Unknown7 { get; set; }
        public UInt32 Unknown8 { get; set; } //Float??
        public UInt32 Unknown9 { get; set; }
        public UInt32 EntriesSize { get; set; }
        public List<Entry> Entries { get; set; }
    }    
    public struct Entry
    {
        public float Unknown1 { get; set; }
        public UInt32 Unknown2 { get; set; }
    }
}
