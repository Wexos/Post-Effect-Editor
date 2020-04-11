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
using System.BFG;

namespace Effect_Editor
{
    public partial class BFGEditor : Form
    {
        BFG BFG; const string Version = "v0.1.0"; string FileName = "";
        public BFGEditor()
        {
            InitializeComponent();
            this.Text = this.Text + " | " + Version + " | By Wexos";
            BFG = new BFG();
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
                if (saveBFG.ShowDialog() == DialogResult.OK)
                {
                    WriteBFG(saveBFG.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                WriteBFG(FileName);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveBFG.ShowDialog() == DialogResult.OK)
            {
                WriteBFG(saveBFG.FileName);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BFGEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        public void ReadBFG(string FilePath)
        {
            FileName = FilePath;
            BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(FilePath)));
            BFG.Entries = new List<Entry>();
            BFG.Unknown1 = Reader.ReadUInt32();
            BFG.Unknown2 = Reader.ReadSingle();
            for (int i = 0; i < 3; i++)
            {
                BFG.Entries.Add(new Entry()
                {
                    Distance = Reader.ReadSingle(),
                    RGBA = Reader.ReadUInt32(),
                    Unknown1 = Reader.ReadUInt16(),
                    Unknown2 = Reader.ReadUInt16(),
                    Float1B = Reader.ReadSingle(),
                    Unknown3 = Reader.ReadUInt32(),
                    Unknown4 = Reader.ReadUInt32(),
                    Padding = Reader.ReadUInt32(),
                });
            }
            BFG.Float4A = Reader.ReadSingle();
            BFG.Bytes4A = Reader.ReadUInt32();
            BFG.Unknown4A = Reader.ReadUInt16();
            BFG.Unknown4B = Reader.ReadUInt16();
            BFG.Float4B = Reader.ReadSingle();
            BFG.Unknown4C = Reader.ReadUInt32();
            bfgComponent1.AddData(BFG);

            this.Show();
            Reader.Close();
        }
        public void WriteBFG(string FilePath)
        {
            FileName = FilePath;
            BigEndianWriter Writer = new BigEndianWriter(File.Open(FilePath, FileMode.Create));
            BFG b = bfgComponent1.ReturnData();

            Writer.WriteUInt32(b.Unknown1);
            Writer.WriteSingle(b.Unknown2);
            foreach (Entry e in b.Entries)
            {
                Writer.WriteSingle(e.Distance);
                Writer.WriteUInt32(e.RGBA);
                Writer.WriteUInt16(e.Unknown1);
                Writer.WriteUInt16(e.Unknown2);
                Writer.WriteSingle(e.Float1B);
                Writer.WriteUInt32(e.Unknown3);
                Writer.WriteUInt32(e.Unknown4);
                Writer.WriteUInt32(e.Padding);
            }
            Writer.WriteSingle(b.Float4A);
            Writer.WriteUInt32(b.Bytes4A);
            Writer.WriteUInt16(b.Unknown4A);
            Writer.WriteUInt16(b.Unknown4B);
            Writer.WriteSingle(b.Float4B);
            Writer.WriteUInt32(b.Unknown4C);
            Writer.Close();
        }
        public void NewBFG()
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
