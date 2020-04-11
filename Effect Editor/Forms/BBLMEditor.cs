using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.BBLM;

namespace Effect_Editor
{
    public partial class BBLMEditor : Form
    {
        BBLM BBLM;
        const string Version = "v0.1.0"; string FileName = "";
        public BBLMEditor()
        {
            InitializeComponent();
            this.Text = this.Text + " | " + Version + " | By Wexos";
            BBLM = new BBLM();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            if (f.OpenEffect.ShowDialog() == DialogResult.OK)
            {
                f.ReadFile(f.OpenEffect.FileName);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName == null || FileName == "")
            {
                if (saveBBLM.ShowDialog() == DialogResult.OK)
                {
                    WriteBBLM(saveBBLM.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                WriteBBLM(FileName);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveBBLM.ShowDialog() == DialogResult.OK)
            {
                WriteBBLM(saveBBLM.FileName);
            }
        }        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BBLMEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to exit? Unsaved data will be lost!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (d)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    e.Cancel = true;
                    return;
            }
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wiki.tockdom.com/wiki/Post-Effect_Editor");
        }

        public void ReadBBLM(string FilePath)
        {
            FileName = FilePath;
            BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(FilePath)));
            BBLM.Magic = Reader.ReadASCII(4); if (BBLM.Magic != "PBLM") { throw new WrongMagicException(BBLM.Magic, "PBLM", Reader.BaseStream.Position - 4); }
            BBLM.FileSize = Reader.ReadUInt32(); if (BBLM.FileSize != 0xA4) { MessageBox.Show("Please give this file to Wexos!"); }
            BBLM.Unknown1 = Reader.ReadUInt64();
            BBLM.ScaleFactor = Reader.ReadSingle();
            BBLM.RGB = Reader.ReadUInt32();
            BBLM.blurrRGB = Reader.ReadUInt32();
            BBLM.Unknown2 = Reader.ReadUInt16();
            BBLM.Unknown3 = Reader.ReadUInt16();
            BBLM.Entries = new List<Entry>();
            for (int i = 0; i < 3; i++)
            {
                BBLM.Entries.Add(new Entry()
                {
                    Unknown1 = Reader.ReadSingle(),
                    Unknown2 = Reader.ReadSingle(),
                    Unknown3 = Reader.ReadUInt32(),
                    Unknown4 = Reader.ReadUInt32(),
                    Unknown5 = Reader.ReadUInt32(),
                    Unknown6 = Reader.ReadUInt32(),
                    Unknown7 = Reader.ReadUInt32(),
                    Unknown8 = Reader.ReadUInt32()
                });
            }
            BBLM.Unknown4 = Reader.ReadUInt32();
            BBLM.Unknown5 = Reader.ReadUInt32();
            BBLM.Unknown6 = Reader.ReadUInt32();
            BBLM.Unknown7 = Reader.ReadUInt32();
            BBLM.Unknown8 = Reader.ReadUInt32();
            BBLM.Unknown9 = Reader.ReadUInt32();
            BBLM.float1 = Reader.ReadSingle();
            BBLM.float2 = Reader.ReadSingle();
            BBLM.float3 = Reader.ReadSingle();

            bblmComponent1.AddData(BBLM);
            Reader.Close();
            this.Show();
        }
        public void WriteBBLM(string FilePath)
        {
            FileName = FilePath;
            BigEndianWriter Writer = new BigEndianWriter(File.Open(FilePath, FileMode.Create));
            BBLM b = bblmComponent1.ReturnData();
            Writer.WriteChars("PBLM".ToCharArray(), 0, 4);
            Writer.WriteUInt32(0xA4);
            Writer.WriteUInt64(b.Unknown1);
            Writer.WriteSingle(b.ScaleFactor);
            Writer.WriteUInt32(b.RGB);
            Writer.WriteUInt32(b.blurrRGB);
            Writer.WriteUInt16(b.Unknown2);
            Writer.WriteUInt16(b.Unknown3);
            for (int i = 0; i < b.Entries.Count; i++)
            {
                Writer.WriteSingle(b.Entries[i].Unknown1);
                Writer.WriteSingle(b.Entries[i].Unknown2);
                Writer.WriteUInt32(b.Entries[i].Unknown3);
                Writer.WriteUInt32(b.Entries[i].Unknown4);
                Writer.WriteUInt32(b.Entries[i].Unknown5);
                Writer.WriteUInt32(b.Entries[i].Unknown6);
                Writer.WriteUInt32(b.Entries[i].Unknown7);
                Writer.WriteUInt32(b.Entries[i].Unknown8);
            }
            Writer.WriteUInt32(b.Unknown4);
            Writer.WriteUInt32(b.Unknown5);
            Writer.WriteUInt32(b.Unknown6);
            Writer.WriteUInt32(b.Unknown7);
            Writer.WriteUInt32(b.Unknown8);
            Writer.WriteSingle(b.Unknown9);
            Writer.WriteSingle(b.float1);
            Writer.WriteSingle(b.float2);
            Writer.WriteSingle(b.float3);
            Writer.Close();
        }             
        public void NewBBLM()
        {

        }
        #region NewFile
        private void bBLMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.NewBBLM();
        }
        private void bDOFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.NewBDOF();
        }
        private void bFGToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.NewBFG();
        }
        private void bLIGHTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.NewBLIGHT();
        }
        private void bLMAPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.NewBLMAP();
        }
        #endregion        

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (FileList != null)
            {
                FormMain f = new FormMain();
                f.ReadFile(FileList[0]);
            }
        }
        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
