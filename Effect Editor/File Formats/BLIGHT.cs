using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.BLIGHT
{
    public class BLIGHT
    {
        public string Magic { get; set; }
        public UInt32 FileSize { get; set; }
        public UInt32 Unknown1 { get; set; }
        public UInt32 Unknown2 { get; set; }
        public UInt16 NrLOBJ { get; set; }
        public UInt16 NrAmbientLight { get; set; }
        public UInt32 Unknown3 { get; set; }
        public UInt64 Padding { get; set; }
        public UInt64 Padding2 { get; set; }
    }
    public struct BLIGHTLOBJ
    {
        public string Magic { get; set; }
        public UInt32 SectionSize { get; set; }
        public UInt64 Unknown1 { get; set; }
        public UInt16 Unknown2 { get; set; }
        public byte LightType { get; set; }
        public byte Unknown3 { get; set; }
        public UInt16 LightID { get; set; }
        public UInt16 Unknown4 { get; set; }
        public float[] OriginVector { get; set; }
        public float[] DestinationVector { get; set; }
        public float Scale { get; set; }
        public byte[] RGBA { get; set; } //byte[4]
        public UInt32 Unknown5 { get; set; } //Which Ambient Light to use?
        public float Unknown6 { get; set; }
        public float Unknown7 { get; set; }
        public float Unknown8 { get; set; }
        public UInt64 Padding { get; set; }                     
    }
    public struct BLIGHTAmbient
    {
        public byte[] RGBALight { get; set; } //byte[4]
        public UInt32 Padding { get; set; }                        
    }    
}
