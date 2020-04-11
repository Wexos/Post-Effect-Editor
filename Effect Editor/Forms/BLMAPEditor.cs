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
using System.BLMAP;

namespace Effect_Editor
{
    public partial class BLMAPEditor : Form
    {
        BLMAP BLMAP; List<BLMAPLTEX> listLTEX;
        const string Version = "v1.0.0"; int SelectedNode = 0; string FileName = ""; bool Hex = true;
        public BLMAPEditor()
        {
            InitializeComponent();
            this.Text = this.Text + " | " + Version + " | By Wexos";
            BLMAP = new BLMAP();
            listLTEX = new List<BLMAPLTEX>();
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
                if (saveBLMAP.ShowDialog() == DialogResult.OK)
                {
                    WriteBLMAP(saveBLMAP.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                WriteBLMAP(FileName);
            }
        } 
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveBLMAP.ShowDialog() == DialogResult.OK)
            {
                WriteBLMAP(saveBLMAP.FileName);
            }
        } 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BLMAPEditor_FormClosing(object sender, FormClosingEventArgs e)
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes[1].Nodes[SelectedNode].Remove();
            for (int i = 0; i < treeView1.Nodes[0].Nodes[1].Nodes.Count; i++)
            {
                treeView1.Nodes[0].Nodes[1].Nodes[i].Text = "LTEX " + HexUtil.ConvertToHex(i);
            }
            listLTEX.RemoveAt(SelectedNode);
            if (treeView1.Nodes[0].Nodes[1].Nodes.Count != 0)
            {
                ltexComponent1.AddData(listLTEX[0]);
                AddLTEX(listLTEX[0].Entries);
                SelectedNode = 0;
            }
            else
            {
                ltexComponent1.AddData(null);
                dgwEntries.Rows.Clear();
                SelectedNode = -1;
            }
        }

        private void AddLTEX(List<Entry> l)
        {
            dgwEntries.Rows.Clear();
            for (int i = 0; i < l.Count; i++)
            {
                dgwEntries.Rows.Add(HexUtil.Hex8(Convert.ToByte(i)), l[i].Unknown1, HexUtil.Hex32(l[i].Unknown2));
            }
        }
        private List<Entry> ReturnLTEX()
        {
            List<Entry> l = new List<Entry>();
            for (int i = 0; i < dgwEntries.Rows.Count; i++)
            {
                l.Add(new Entry()
                {
                    Unknown1 = Convert.ToSingle(dgwEntries.Rows[i].Cells[1].Value.ToString()),
                    Unknown2 = UInt32.Parse(dgwEntries.Rows[i].Cells[2].Value.ToString(), NumberStyles.HexNumber)
                });
            }
            return l;
        }

        public void ReadBLMAP(string FilePath)
        {
            FileName = FilePath;
            BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(FilePath)));
            treeView1.Nodes[0].Nodes.Clear();
            treeView1.Nodes[0].Text = Path.GetFileName(FilePath);
            treeView1.Nodes[0].Nodes.Add("Header");
            treeView1.Nodes[0].Nodes.Add("LTEX");
            listLTEX.Clear();
            BLMAP.Magic = Reader.ReadASCII(4); if (BLMAP.Magic != "LMAP") { throw new WrongMagicException(BLMAP.Magic, "LMAP", Reader.BaseStream.Position - 4); }
            BLMAP.FileSize = Reader.ReadUInt32();
            BLMAP.Unknown1 = Reader.ReadUInt32();
            BLMAP.Unknown2 = Reader.ReadUInt32();
            BLMAP.NrLTEX = Reader.ReadUInt16();
            BLMAP.Unknown3 = Reader.ReadUInt16();
            BLMAP.Unknown4 = Reader.ReadUInt32();
            BLMAP.Unknown5 = Reader.ReadUInt32();
            BLMAP.Unknown6 = Reader.ReadUInt32();
            for (int i = 0; i < BLMAP.NrLTEX; i++)
            {
                BLMAPLTEX LTEX = new BLMAPLTEX();
                long Offset = Reader.BaseStream.Position;
                LTEX.Magic = Reader.ReadASCII(4); if (LTEX.Magic != "LTEX") { throw new WrongMagicException(LTEX.Magic, "LTEX", Reader.BaseStream.Position - 4); }
                LTEX.SectionSize = Reader.ReadUInt32();
                LTEX.Padding = Reader.ReadUInt32();
                LTEX.Unknown = Reader.ReadUInt32();
                LTEX.NrEntries = Reader.ReadUInt16();
                LTEX.Unknown1 = Reader.ReadUInt16();
                LTEX.Texture = Reader.ReadASCII(4);
                LTEX.Unknown2 = Reader.ReadUInt32();
                LTEX.Unknown3 = Reader.ReadUInt32();
                LTEX.Unknown4 = Reader.ReadUInt32();
                LTEX.Unknown5 = Reader.ReadUInt32();
                LTEX.Unknown6 = Reader.ReadUInt32();
                LTEX.Unknown7 = Reader.ReadUInt32();
                LTEX.Unknown8 = Reader.ReadUInt32();
                LTEX.Unknown9 = Reader.ReadUInt32();
                LTEX.EntriesSize = Reader.ReadUInt32();
                LTEX.Entries = new List<Entry>();
                for (int j = 0; j < LTEX.NrEntries; j++)
                {
                    LTEX.Entries.Add(new Entry() { Unknown1 = Reader.ReadSingle(), Unknown2 = Reader.ReadUInt32() });

                }
                listLTEX.Add(LTEX);
                treeView1.Nodes[0].Nodes[1].Nodes.Add("LTEX " + HexUtil.ConvertToHex(i));
                treeView1.Nodes[0].Nodes[1].Nodes[treeView1.Nodes[0].Nodes[1].Nodes.Count - 1].ContextMenuStrip = cmsDelete;
                Reader.BaseStream.Position = Offset + LTEX.SectionSize;
            }
            Reader.Close();
            lmapComponent1.AddData(BLMAP);
            if (BLMAP.NrLTEX >= 1)
            {
                ltexComponent1.AddData(listLTEX[0]);
                AddLTEX(listLTEX[0].Entries);
            }
            else
            {
                SelectedNode = -1;
            }
            this.Show();
        }
        public void WriteBLMAP(string FilePath)
        {
            FileName = FilePath;
            BigEndianWriter Writer = new BigEndianWriter(File.Open(FilePath, FileMode.Create));
            BLMAP BLMAP = lmapComponent1.ReturnData();            
            Writer.WriteChars("LMAP".ToCharArray(), 0, 4);
            Writer.WriteUInt32(0);
            Writer.WriteUInt32(BLMAP.Unknown1);
            Writer.WriteUInt32(BLMAP.Unknown2);
            Writer.WriteUInt16(Convert.ToUInt16(treeView1.Nodes[0].Nodes[1].Nodes.Count));
            Writer.WriteUInt16(BLMAP.Unknown3);
            Writer.WriteUInt32(BLMAP.Unknown4);
            Writer.WriteUInt32(BLMAP.Unknown5);
            Writer.WriteUInt32(BLMAP.Unknown6);
            int FileSize = 0x20;
            for (int i = 0; i < listLTEX.Count; i++)
            {
                BLMAPLTEX LTEX = ltexComponent1.ReturnData();
                LTEX.Entries = ReturnLTEX();
                listLTEX[SelectedNode] = LTEX;

                FileSize += 0x3C + listLTEX[i].Entries.Count * 8;
                Writer.WriteChars("LTEX".ToCharArray(), 0, 4);
                Writer.WriteInt32(0x3C + listLTEX[i].Entries.Count * 8);
                Writer.WriteUInt32(listLTEX[i].Padding);
                Writer.WriteUInt32(listLTEX[i].Unknown);
                Writer.WriteUInt16(Convert.ToUInt16(listLTEX[i].Entries.Count));
                Writer.WriteUInt16(listLTEX[i].Unknown1);
                Writer.WriteChars(listLTEX[i].Texture.ToCharArray(), 0, 4);
                Writer.WriteUInt32(listLTEX[i].Unknown2);
                Writer.WriteUInt32(listLTEX[i].Unknown3);
                Writer.WriteUInt32(listLTEX[i].Unknown4);
                Writer.WriteUInt32(listLTEX[i].Unknown5);
                Writer.WriteUInt32(listLTEX[i].Unknown6);
                Writer.WriteUInt32(listLTEX[i].Unknown7);
                Writer.WriteUInt32(listLTEX[i].Unknown8);
                Writer.WriteUInt32(listLTEX[i].Unknown9);
                Writer.WriteInt32(listLTEX[i].Entries.Count * 8);
                for (int j = 0; j < listLTEX[i].Entries.Count; j++)
                {
                    Writer.WriteSingle(listLTEX[i].Entries[j].Unknown1);
                    Writer.WriteUInt32(listLTEX[i].Entries[j].Unknown2);
                }
            }
            Writer.BaseStream.Position = 4;
            Writer.WriteInt32(FileSize);
            Writer.Close();
            treeView1.Nodes[0].Text = Path.GetFileName(FilePath);
        }
        public void NewBLMAP()
        {
            treeView1.Nodes[0].Nodes.Add("Header");
            treeView1.Nodes[0].Nodes.Add("LTEX");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("LTEX 0");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("LTEX 1");
            lmapComponent1.AddData(new BLMAP()
            {
                Unknown1 = 0, Unknown2 = 0,
                Unknown3 = 0, Unknown4 = 0,
                Unknown5 = 0, Unknown6 = 0
            });
            listLTEX.Add(new BLMAPLTEX()
            {
                Padding = 0, Unknown = 0,
                Unknown1 = 0, Texture = "lm_0",
                Unknown2 = 0, Unknown3 = 0,
                Unknown4 = 0, Unknown5 = 0,
                Unknown6 = 0, Unknown7 = 0,
                Unknown8 = 0, Unknown9 = 0,
                Entries = new List<Entry>()
            });
            listLTEX.Add(new BLMAPLTEX()
            {
                Padding = 0, Unknown = 0,
                Unknown1 = 0, Texture = "lm_1",
                Unknown2 = 0, Unknown3 = 0,
                Unknown4 = 0, Unknown5 = 0,
                Unknown6 = 0, Unknown7 = 0,
                Unknown8 = 0, Unknown9 = 0,
                Entries = new List<Entry>()
            });
            ltexComponent1.AddData(listLTEX[0]);
            this.Show();
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != treeView1.Nodes[0])
            {
                if (e.Node.Parent.Text == "LTEX")
                {
                    if (SelectedNode != -1)
                    {
                        BLMAPLTEX LTEX = ltexComponent1.ReturnData();
                        if (LTEX != null)
                        {
                            LTEX.Entries = new List<Entry>();
                            LTEX.Entries = ReturnLTEX();
                            listLTEX[SelectedNode] = LTEX;
                        }
                    }                    
                    ltexComponent1.AddData(listLTEX[e.Node.Index]);
                    AddLTEX(listLTEX[e.Node.Index].Entries);
                    SelectedNode = e.Node.Index;
                }
            }
        }
        private void AddLTEX(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes[1].Nodes.Add("LTEX " + HexUtil.ConvertToHex(treeView1.Nodes[0].Nodes[1].Nodes.Count));
            treeView1.Nodes[0].Nodes[1].Nodes[treeView1.Nodes[0].Nodes[1].Nodes.Count - 1].ContextMenuStrip = cmsDelete;
            listLTEX.Add(new BLMAPLTEX()
            {
                Padding = 0, Unknown = 0,
                Unknown1 = 0, Texture = "lm_0",
                Unknown2 = 0, Unknown3 = 0,
                Unknown4 = 0, Unknown5 = 0,
                Unknown6 = 0, Unknown7 = 0,
                Unknown8 = 0, Unknown9 = 0,
                Entries = new List<Entry>()
            });
            ltexComponent1.AddData(listLTEX[0]);
            AddLTEX(listLTEX[0].Entries);
            SelectedNode = 0;
        }
        private void AddLTEXEntry_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes[0].Nodes[1].Nodes.Count > 0)
            {
                dgwEntries.Rows.Add(HexUtil.Hex8(Convert.ToByte(dgwEntries.Rows.Count)), "1", "00000000");
            }
            else
            {
                MessageBox.Show("Unable to add LTEX entry!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgwEntries_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Hex = false;
            }
            else
            {
                Hex = true;
            }
        }
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dataGridView_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView_KeyPress);
        }
        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Hex == true)
            {
                if (HexUtil.IsHex(e.KeyChar) == true)
                {

                }
                else if (HexUtil.IsHex(e.KeyChar) == false)
                {
                    e.Handled = e.KeyChar != (char)Keys.Back;
                }
            }
            else
            {
                if (e.KeyChar.ToString() == "," || e.KeyChar.ToString() == "." || e.KeyChar.ToString() == "-")
                {

                }
                else if (char.IsDigit(e.KeyChar))
                {

                }
                else
                {
                    e.Handled = e.KeyChar != (char)Keys.Back;
                }
            }
        }
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.ColumnIndex == 1)
                {
                    if (dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                    else
                    {
                        try
                        {
                            float test = Convert.ToSingle(dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Invalid value!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        }
                    }
                }
            }
            else if (e.ColumnIndex == 2)
            {
                if (dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000000";
                }
                else
                {
                    dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex32(UInt32.Parse(dgwEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                }
            }            
        }
        private void dgwEntries_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (byte i = 0; i < dgwEntries.Rows.Count; i++)
            {
                dgwEntries.Rows[i].Cells[0].Value = HexUtil.Hex8(i);
            }
        }

        private void ImportLTEX_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Binary Light Texture (*bltex)|*.bltex";
            if (o.ShowDialog() == DialogResult.OK)
            {
                BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(o.FileName)));
                BLMAPLTEX LTEX = new BLMAPLTEX();
                LTEX.Magic = Reader.ReadASCII(4); if (LTEX.Magic != "LTEX") { throw new WrongMagicException(LTEX.Magic, "LTEX", Reader.BaseStream.Position - 4); }
                LTEX.SectionSize = Reader.ReadUInt32();
                LTEX.Padding = Reader.ReadUInt32();
                LTEX.Unknown = Reader.ReadUInt32();
                LTEX.NrEntries = Reader.ReadUInt16();
                LTEX.Unknown1 = Reader.ReadUInt16();
                LTEX.Texture = Reader.ReadASCII(4);
                LTEX.Unknown2 = Reader.ReadUInt32();
                LTEX.Unknown3 = Reader.ReadUInt32();
                LTEX.Unknown4 = Reader.ReadUInt32();
                LTEX.Unknown5 = Reader.ReadUInt32();
                LTEX.Unknown6 = Reader.ReadUInt32();
                LTEX.Unknown7 = Reader.ReadUInt32();
                LTEX.Unknown8 = Reader.ReadUInt32();
                LTEX.Unknown9 = Reader.ReadUInt32();
                LTEX.EntriesSize = Reader.ReadUInt32();
                LTEX.Entries = new List<Entry>();
                for (int j = 0; j < LTEX.NrEntries; j++)
                {
                    LTEX.Entries.Add(new Entry() { Unknown1 = Reader.ReadSingle(), Unknown2 = Reader.ReadUInt32() });

                }
                listLTEX.Add(LTEX);
                treeView1.Nodes[0].Nodes[1].Nodes.Add("LTEX " + HexUtil.ConvertToHex(treeView1.Nodes[0].Nodes[1].Nodes.Count));
                treeView1.Nodes[0].Nodes[1].Nodes[treeView1.Nodes[0].Nodes[1].Nodes.Count - 1].ContextMenuStrip = cmsDelete;
                Reader.Close();
            }
        }
        private void ExportLTEX_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Binary Light Texture (*bltex)|*.bltex";
            if (s.ShowDialog() == DialogResult.OK)
            {
                BLMAPLTEX LTEX = ltexComponent1.ReturnData();
                LTEX.Entries = ReturnLTEX();
                listLTEX[SelectedNode] = LTEX;

                BigEndianWriter Writer = new BigEndianWriter(File.Open(s.FileName, FileMode.Create));
                Writer.WriteChars("LTEX".ToCharArray(), 0, 4);
                Writer.WriteInt32(0x3C + LTEX.Entries.Count * 8);
                Writer.WriteUInt32(LTEX.Padding);
                Writer.WriteUInt32(LTEX.Unknown);
                Writer.WriteUInt16(Convert.ToUInt16(LTEX.Entries.Count));
                Writer.WriteUInt16(LTEX.Unknown1);
                Writer.WriteChars(LTEX.Texture.ToCharArray(), 0, 4);
                Writer.WriteUInt32(LTEX.Unknown2);
                Writer.WriteUInt32(LTEX.Unknown3);
                Writer.WriteUInt32(LTEX.Unknown4);
                Writer.WriteUInt32(LTEX.Unknown5);
                Writer.WriteUInt32(LTEX.Unknown6);
                Writer.WriteUInt32(LTEX.Unknown7);
                Writer.WriteUInt32(LTEX.Unknown8);
                Writer.WriteUInt32(LTEX.Unknown9);
                Writer.WriteInt32(LTEX.Entries.Count * 8);
                for (int j = 0; j < LTEX.Entries.Count; j++)
                {
                    Writer.WriteSingle(LTEX.Entries[j].Unknown1);
                    Writer.WriteUInt32(LTEX.Entries[j].Unknown2);
                }
                Writer.Close();
            }
        }

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
