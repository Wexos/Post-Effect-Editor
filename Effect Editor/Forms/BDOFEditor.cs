using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.BDOF;

namespace Effect_Editor
{
    public partial class BDOFEditor : Form
    {
        BDOF BDOF;
        const string Version = "v0.1.0"; string FileName = "";
        public BDOFEditor()
        {
            InitializeComponent();
            this.Text = this.Text + " | " + Version + " | By Wexos";
            BDOF = new BDOF();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            if (f.OpenEffect.ShowDialog() == DialogResult.OK)
            {
                f.ReadFile(f.OpenEffect.FileName);
            };
        }        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName == null || FileName == "")
            {
                if (saveBDOF.ShowDialog() == DialogResult.OK)
                {
                    WriteBDOF(saveBDOF.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                WriteBDOF(FileName);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveBDOF.ShowDialog() == DialogResult.OK)
            {
                WriteBDOF(saveBDOF.FileName);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BDOFEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        public void ReadBDOF(string FilePath)
        {
            FileName = FilePath;
            BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(FilePath)));

            BDOF.Magic = Reader.ReadASCII(4); if (BDOF.Magic != "PDOF") { throw new WrongMagicException(BDOF.Magic, "PDOF", Reader.BaseStream.Position - 4); }
            BDOF.FileSize = Reader.ReadUInt32(); if (BDOF.FileSize != 0x50) { MessageBox.Show("Please give this file to Wexos!"); }
            BDOF.Unknown1 = Reader.ReadUInt64();
            BDOF.Activator = Reader.ReadUInt16();
            BDOF.Unknown2 = Reader.ReadUInt16();
            BDOF.Unknown3 = Reader.ReadUInt32();
            BDOF.FloatValues = Reader.ReadSingles(10);
            BDOF.Padding = Reader.ReadUInt64s(0x02);

            bdofComponent1.AddData(BDOF);            
            this.Show();
            Reader.Close();
        }
        public void WriteBDOF(string FilePath)
        {
            FileName = FilePath;
            BigEndianWriter Writer = new BigEndianWriter(File.Open(FilePath, FileMode.Create));
            BDOF b = bdofComponent1.ReturnData();
            Writer.WriteChars("PDOF".ToCharArray(), 0, 4);
            Writer.WriteUInt32(0x50);
            Writer.WriteUInt64(b.Unknown1);
            Writer.WriteUInt16(b.Activator);
            Writer.WriteUInt16(b.Unknown2);
            Writer.WriteUInt32(b.Unknown3);
            Writer.WriteSingles(b.FloatValues);
            Writer.WriteUInt64s(b.Padding);
            Writer.Close();
        }
        public void NewBDOF()
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
