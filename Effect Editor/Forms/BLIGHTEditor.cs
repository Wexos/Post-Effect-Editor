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
using System.BLIGHT;

namespace Effect_Editor
{
    public partial class BLIGHTEditor : Form
    {
        BLIGHT BLIGHT; BLIGHTLOBJ LOBJ; BLIGHTAmbient Ambient;
        bool Hex; const string Version = "v1.0.0"; string FileName = "";
        public BLIGHTEditor()
        {
            InitializeComponent();
            this.Text = this.Text + " | " + Version + " | By Wexos";
            this.Size =  new Size(1085, 568);
            BLIGHT = new BLIGHT();
            LOBJ = new BLIGHTLOBJ();
            Ambient = new BLIGHTAmbient();
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
                if (saveBLIGHT.ShowDialog() == DialogResult.OK)
                {
                    WriteBLIGHT(saveBLIGHT.FileName);
                }
                else
                {
                    return;
                }
            }
            else
            {
                WriteBLIGHT(FileName);
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveBLIGHT.ShowDialog() == DialogResult.OK)
            {
                WriteBLIGHT(saveBLIGHT.FileName);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BLIGHTEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView d = sender as DataGridView;
            if (d == dgwLOBJ)
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 12)
                {
                    Hex = false;
                }
                else if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 13 || e.ColumnIndex == 14 || e.ColumnIndex == 15 || e.ColumnIndex == 16 || e.ColumnIndex == 17 || e.ColumnIndex == 18 || e.ColumnIndex == 19 || e.ColumnIndex == 20 || e.ColumnIndex == 21 || e.ColumnIndex == 22)
                {
                    Hex = true;
                }
            }
            else if (d == dgwAmbient)
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
            else if (Hex == false)
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
            DataGridView d = sender as DataGridView;
            if (d == dgwLOBJ)
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11 || e.ColumnIndex == 12)
                {
                    if (dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                    else
                    {
                        try
                        {
                            float test = Convert.ToSingle(dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        }
                        catch
                        {
                            //dgwLOBJ.CurrentCell = dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            MessageBox.Show("Invalid value!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //dgwLOBJ.BeginEdit(true);
                            dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        }
                    }
                }
                else if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 16 || e.ColumnIndex == 17 || e.ColumnIndex == 18 || e.ColumnIndex == 19)
                {
                    if (dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00";
                    }
                    else
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex8(byte.Parse(dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                    }
                }
                else if (e.ColumnIndex == 13 || e.ColumnIndex == 14 || e.ColumnIndex == 21)
                {
                    if (dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0000";
                    }
                    else
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex16(UInt16.Parse(dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                    }
                }
                else if (e.ColumnIndex == 15)
                {
                    if (dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000000";
                    }
                    else
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex32(UInt32.Parse(dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                    }
                }
                else if (e.ColumnIndex == 20 || e.ColumnIndex == 22)
                {
                    if (dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0000000000000000";
                    }
                    else
                    {
                        dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex64(UInt64.Parse(dgwLOBJ.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                    }
                }
            }
            else if (d == dgwAmbient)
            {
                if (e.ColumnIndex == 5)
                {
                    if (dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00000000";
                    }
                    else
                    {
                        dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex32(UInt32.Parse(dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                    }
                }
                else
                {
                    if (dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {
                        dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "00";
                    }
                    else
                    {
                        dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = HexUtil.Hex8(byte.Parse(dgwAmbient.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.HexNumber));
                    }
                }
            }
        }
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView d = sender as DataGridView;
            if (d == dgwLOBJ)
            {
                if (e.RowIndex == -1)
                {
                    LOBJColor.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF);
                }
                else
                {
                    DataGridViewRow DataRow = d.Rows[e.RowIndex];
                    LOBJColor.BackColor = Color.FromArgb(byte.Parse(DataRow.Cells[16].Value.ToString(), NumberStyles.HexNumber), byte.Parse(DataRow.Cells[17].Value.ToString(), NumberStyles.HexNumber), byte.Parse(DataRow.Cells[18].Value.ToString(), NumberStyles.HexNumber));
                }
            }
            else if (d == dgwAmbient)
            {
                if (e.RowIndex == -1)
                {
                    AmbientColor.BackColor = Color.FromArgb(0xFF, 0xFF, 0xFF);
                }
                else
                {
                    DataGridViewRow DataRow = d.Rows[e.RowIndex];
                    AmbientColor.BackColor = Color.FromArgb(byte.Parse(DataRow.Cells[1].Value.ToString(), NumberStyles.HexNumber), byte.Parse(DataRow.Cells[2].Value.ToString(), NumberStyles.HexNumber), byte.Parse(DataRow.Cells[3].Value.ToString(), NumberStyles.HexNumber));
                }
            }
        }
        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            DataGridView d = sender as DataGridView;
            for (int i = 0; i < d.Rows.Count; i++)
            {
                d.Rows[i].Cells[0].Value = HexUtil.Hex8(Convert.ToByte(i));
            }
        }

        public void NewBLIGHT()
        {
            for (int i = 0; i < 16; i++)
            {
                dgwLOBJ.Rows.Add(HexUtil.Hex8(Convert.ToByte(i)), "00", "01", 0, 0, 0, 0, 0, 0, 1, 90, 0.5, 0.5, HexUtil.Hex16(Convert.ToUInt16(i)), "0641", "000000FF", "00", "00", "00", "FF", "0200000000000000", "0000", "0000000000000000");
                dgwAmbient.Rows.Add(HexUtil.Hex8(Convert.ToByte(i)), "64", "64", "64", "FF", "00000000");
            }
            LOBJColor.BackColor = Color.FromArgb(0xFF, 0, 0, 0);
            AmbientColor.BackColor = Color.FromArgb(0xFF, 0x64, 0x64, 0x64);
            this.Show();
        }
        public void ReadBLIGHT(string FilePath)
        {
            FileName = FilePath;
            BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(FilePath)));
            BLIGHT.Magic = Encoding.ASCII.GetString(Reader.ReadBytes(0x04)); if (BLIGHT.Magic != "LGHT") { throw new WrongMagicException(BLIGHT.Magic, "LGHT", Reader.BaseStream.Position - 4); }
            BLIGHT.FileSize = Reader.ReadUInt32();
            BLIGHT.Unknown1 = Reader.ReadUInt32();
            BLIGHT.Unknown2 = Reader.ReadUInt32();
            BLIGHT.NrLOBJ = Reader.ReadUInt16();
            BLIGHT.NrAmbientLight = Reader.ReadUInt16();
            BLIGHT.Unknown3 = Reader.ReadUInt32();
            BLIGHT.Padding = Reader.ReadUInt64();
            BLIGHT.Padding2 = Reader.ReadUInt64();
            for (int i = 0; i < BLIGHT.NrLOBJ; i++)
            {
                LOBJ.Magic = Encoding.ASCII.GetString(Reader.ReadBytes(0x04)); if (LOBJ.Magic != "LOBJ") { throw new WrongMagicException(LOBJ.Magic, "LOBJ", Reader.BaseStream.Position - 4); }
                LOBJ.SectionSize = Reader.ReadUInt32(); if (LOBJ.SectionSize != 0x50) { MessageBox.Show("Please give this file to Wexos!"); }
                LOBJ.Unknown1 = Reader.ReadUInt64();
                LOBJ.Unknown2 = Reader.ReadUInt16();
                LOBJ.LightType = Reader.ReadByte();
                LOBJ.Unknown3 = Reader.ReadByte();
                LOBJ.LightID = Reader.ReadUInt16();
                LOBJ.Unknown4 = Reader.ReadUInt16();
                LOBJ.OriginVector = Reader.ReadSingles(3);
                LOBJ.DestinationVector = Reader.ReadSingles(3);
                LOBJ.Scale = Reader.ReadSingle();
                LOBJ.RGBA = Reader.ReadBytes(4);
                LOBJ.Unknown5 = Reader.ReadUInt32();
                LOBJ.Unknown6 = Reader.ReadSingle();
                LOBJ.Unknown7 = Reader.ReadSingle();
                LOBJ.Unknown8 = Reader.ReadSingle();
                LOBJ.Padding = Reader.ReadUInt64();
                dgwLOBJ.Rows.Add(HexUtil.Hex8(Convert.ToByte(i)), HexUtil.Hex8(LOBJ.LightType), HexUtil.Hex8(LOBJ.Unknown3), LOBJ.OriginVector[0], LOBJ.OriginVector[1], LOBJ.OriginVector[2], LOBJ.DestinationVector[0], LOBJ.DestinationVector[1], LOBJ.DestinationVector[2], LOBJ.Scale, LOBJ.Unknown6, LOBJ.Unknown7, LOBJ.Unknown8, HexUtil.Hex16(LOBJ.LightID), HexUtil.Hex16(LOBJ.Unknown4), HexUtil.Hex32(LOBJ.Unknown5), HexUtil.Hex8(LOBJ.RGBA[0]), HexUtil.Hex8(LOBJ.RGBA[1]), HexUtil.Hex8(LOBJ.RGBA[2]), HexUtil.Hex8(LOBJ.RGBA[3]), HexUtil.Hex64(LOBJ.Unknown1), HexUtil.Hex16(LOBJ.Unknown2), HexUtil.Hex64(LOBJ.Padding));
            }
            for (int i = 0; i < BLIGHT.NrAmbientLight; i++)
            {
                Ambient.RGBALight = Reader.ReadBytes(4);
                Ambient.Padding = Reader.ReadUInt32();
                dgwAmbient.Rows.Add(HexUtil.Hex8(Convert.ToByte(i)), HexUtil.Hex8(Ambient.RGBALight[0]), HexUtil.Hex8(Ambient.RGBALight[1]), HexUtil.Hex8(Ambient.RGBALight[2]), HexUtil.Hex8(Ambient.RGBALight[3]), HexUtil.Hex32(Ambient.Padding));
            }
            LOBJColor.BackColor = Color.FromArgb(byte.Parse(dgwLOBJ.Rows[0].Cells[16].Value.ToString(), NumberStyles.HexNumber), byte.Parse(dgwLOBJ.Rows[0].Cells[17].Value.ToString(), NumberStyles.HexNumber), byte.Parse(dgwLOBJ.Rows[0].Cells[18].Value.ToString(), NumberStyles.HexNumber));
            AmbientColor.BackColor = Color.FromArgb(byte.Parse(dgwAmbient.Rows[0].Cells[1].Value.ToString(), NumberStyles.HexNumber), byte.Parse(dgwAmbient.Rows[0].Cells[2].Value.ToString(), NumberStyles.HexNumber), byte.Parse(dgwAmbient.Rows[0].Cells[3].Value.ToString(), NumberStyles.HexNumber));
            this.Show();
            Reader.Close();
        }
        public void WriteBLIGHT(string FilePath)
        {
            FileName = FilePath;
            BigEndianWriter Writer = new BigEndianWriter(File.Open(FilePath, FileMode.Create));
            Writer.WriteChars("LGHT".ToCharArray(), 0, 4);
            Writer.WriteUInt32(Convert.ToUInt32(0x28 + dgwLOBJ.Rows.Count * 0x50 + dgwAmbient.Rows.Count * 8));
            Writer.WriteUInt32(BLIGHT.Unknown1);
            Writer.WriteUInt32(BLIGHT.Unknown2);
            Writer.WriteUInt16(Convert.ToUInt16(dgwLOBJ.Rows.Count));
            Writer.WriteUInt16(Convert.ToUInt16(dgwAmbient.Rows.Count));
            Writer.WriteUInt32(BLIGHT.Unknown3);
            Writer.WriteUInt64(BLIGHT.Padding);
            Writer.WriteUInt64(BLIGHT.Padding2);
            for (int i = 0; i < dgwLOBJ.Rows.Count; i++)
            {
                Writer.WriteChars("LOBJ".ToCharArray(), 0, 4);
                Writer.WriteUInt32(0x50);
                Writer.WriteUInt64(UInt64.Parse(dgwLOBJ.Rows[i].Cells[20].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt16(UInt16.Parse(dgwLOBJ.Rows[i].Cells[21].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[i].Cells[1].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[i].Cells[2].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt16(UInt16.Parse(dgwLOBJ.Rows[i].Cells[13].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt16(UInt16.Parse(dgwLOBJ.Rows[i].Cells[14].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[3].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[4].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[5].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[6].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[7].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[8].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[9].Value.ToString()));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[i].Cells[16].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[i].Cells[17].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[i].Cells[18].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[i].Cells[19].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt32(UInt32.Parse(dgwLOBJ.Rows[i].Cells[15].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[10].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[11].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[i].Cells[12].Value.ToString()));
                Writer.WriteUInt64(UInt64.Parse(dgwLOBJ.Rows[i].Cells[22].Value.ToString(), NumberStyles.HexNumber));
            }
            for (int i = 0; i < dgwAmbient.Rows.Count; i++)
            {
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[i].Cells[1].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[i].Cells[2].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[i].Cells[3].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[i].Cells[4].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt32(UInt32.Parse(dgwAmbient.Rows[i].Cells[5].Value.ToString(), NumberStyles.HexNumber));
            }
            Writer.Close();
        }

        private void lightObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgwLOBJ.Rows.Add(HexUtil.Hex8(Convert.ToByte(dgwLOBJ.Rows.Count)), "00", "01", 0, 0, 0, 0, 0, 0, 1, 90, 0.5, 0.5, HexUtil.Hex16(Convert.ToUInt16(dgwLOBJ.Rows.Count)), "0641", "000000FF", "FF", "FF", "FF", "FF", "0200000000000000", "0000", "0000000000000000");
        }
        private void ambientLightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgwAmbient.Rows.Add(HexUtil.Hex8(Convert.ToByte(dgwAmbient.Rows.Count)), "64", "64", "64", "FF", "00000000");
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p == LOBJColor)
            {
                ColorDialog c = new ColorDialog();
                if (c.ShowDialog() == DialogResult.OK)
                {
                    if (dgwLOBJ.SelectedRows.Count == 1)
                    {
                        dgwLOBJ.SelectedRows[0].Cells[16].Value = HexUtil.Hex8(c.Color.R);
                        dgwLOBJ.SelectedRows[0].Cells[17].Value = HexUtil.Hex8(c.Color.G);
                        dgwLOBJ.SelectedRows[0].Cells[18].Value = HexUtil.Hex8(c.Color.B);
                        LOBJColor.BackColor = c.Color;
                    }
                    else if (dgwLOBJ.SelectedRows.Count == 0 && dgwLOBJ.SelectedCells.Count == 1)
                    {                        
                        dgwLOBJ.Rows[dgwLOBJ.SelectedCells[0].RowIndex].Cells[16].Value = HexUtil.Hex8(c.Color.R);
                        dgwLOBJ.Rows[dgwLOBJ.SelectedCells[0].RowIndex].Cells[17].Value = HexUtil.Hex8(c.Color.G);
                        dgwLOBJ.Rows[dgwLOBJ.SelectedCells[0].RowIndex].Cells[18].Value = HexUtil.Hex8(c.Color.B);
                        LOBJColor.BackColor = c.Color;
                    }
                    else
                    {
                        MessageBox.Show("Unable to add color!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (p == AmbientColor)
            {
                ColorDialog c = new ColorDialog();
                if (c.ShowDialog() == DialogResult.OK)
                {
                    if (dgwAmbient.SelectedRows.Count == 1)
                    {
                        dgwAmbient.SelectedRows[0].Cells[1].Value = HexUtil.Hex8(c.Color.R);
                        dgwAmbient.SelectedRows[0].Cells[2].Value = HexUtil.Hex8(c.Color.G);
                        dgwAmbient.SelectedRows[0].Cells[3].Value = HexUtil.Hex8(c.Color.B);
                        AmbientColor.BackColor = c.Color;
                    }
                    else if (dgwAmbient.SelectedRows.Count == 0 && dgwAmbient.SelectedCells.Count == 1)
                    {
                        dgwAmbient.Rows[dgwAmbient.SelectedCells[0].RowIndex].Cells[1].Value = HexUtil.Hex8(c.Color.R);
                        dgwAmbient.Rows[dgwAmbient.SelectedCells[0].RowIndex].Cells[2].Value = HexUtil.Hex8(c.Color.G);
                        dgwAmbient.Rows[dgwAmbient.SelectedCells[0].RowIndex].Cells[3].Value = HexUtil.Hex8(c.Color.B);
                        AmbientColor.BackColor = c.Color;
                    }
                    else
                    {
                        MessageBox.Show("Unable to add color!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void ImportLOBJ_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter  = "Binary Light Object (*blobj)|*.blobj";
            if (o.ShowDialog() == DialogResult.OK)
            {
                BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(o.FileName)));
                LOBJ.Magic = Encoding.ASCII.GetString(Reader.ReadBytes(0x04)); if (LOBJ.Magic != "LOBJ") { throw new WrongMagicException(LOBJ.Magic, "LOBJ", Reader.BaseStream.Position - 4); }
                LOBJ.SectionSize = Reader.ReadUInt32(); if (LOBJ.SectionSize != 0x50) { MessageBox.Show("Please give this file to Wexos!"); }
                LOBJ.Unknown1 = Reader.ReadUInt64();
                LOBJ.Unknown2 = Reader.ReadUInt16();
                LOBJ.LightType = Reader.ReadByte();
                LOBJ.Unknown3 = Reader.ReadByte();
                LOBJ.LightID = Reader.ReadUInt16();
                LOBJ.Unknown4 = Reader.ReadUInt16();
                LOBJ.OriginVector = Reader.ReadSingles(3);
                LOBJ.DestinationVector = Reader.ReadSingles(3);
                LOBJ.Scale = Reader.ReadSingle();
                LOBJ.RGBA = Reader.ReadBytes(4);
                LOBJ.Unknown5 = Reader.ReadUInt32();
                LOBJ.Unknown6 = Reader.ReadSingle();
                LOBJ.Unknown7 = Reader.ReadSingle();
                LOBJ.Unknown8 = Reader.ReadSingle();
                LOBJ.Padding = Reader.ReadUInt64();
                Reader.Close();
                dgwLOBJ.Rows.Add(HexUtil.Hex8(Convert.ToByte(dgwLOBJ.Rows.Count)), HexUtil.Hex8(LOBJ.LightType), HexUtil.Hex8(LOBJ.Unknown3), LOBJ.OriginVector[0], LOBJ.OriginVector[1], LOBJ.OriginVector[2], LOBJ.DestinationVector[0], LOBJ.DestinationVector[1], LOBJ.DestinationVector[2], LOBJ.Scale, LOBJ.Unknown6, LOBJ.Unknown7, LOBJ.Unknown8, HexUtil.Hex16(LOBJ.LightID), HexUtil.Hex16(LOBJ.Unknown4), HexUtil.Hex32(LOBJ.Unknown5), HexUtil.Hex8(LOBJ.RGBA[0]), HexUtil.Hex8(LOBJ.RGBA[1]), HexUtil.Hex8(LOBJ.RGBA[2]), HexUtil.Hex8(LOBJ.RGBA[3]), HexUtil.Hex64(LOBJ.Unknown1), HexUtil.Hex16(LOBJ.Unknown2), HexUtil.Hex64(LOBJ.Padding));
            }
        }
        private void ImportAmbient_Click(object sender, EventArgs e)
        {
             OpenFileDialog o = new OpenFileDialog();
             o.Filter = "Binary Ambient Light (*bambl)|*.bambl";
             if (o.ShowDialog() == DialogResult.OK)
             {
                 BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(o.FileName)));
                 string Magic = Reader.ReadASCII(4); if (Magic != "BAML") { throw new WrongMagicException(Magic, "BAML", Reader.BaseStream.Position - 4); }
                 Ambient.RGBALight = Reader.ReadBytes(4);
                 Ambient.Padding = Reader.ReadUInt32();
                 Reader.Close();
                 dgwAmbient.Rows.Add(HexUtil.Hex8(Convert.ToByte(dgwAmbient.Rows.Count)), HexUtil.Hex8(Ambient.RGBALight[0]), HexUtil.Hex8(Ambient.RGBALight[1]), HexUtil.Hex8(Ambient.RGBALight[2]), HexUtil.Hex8(Ambient.RGBALight[3]), HexUtil.Hex32(Ambient.Padding));
             }
        }
        private void ExportLOBJ_Click(object sender, EventArgs e)
        {
            int Row = 0;
            if (dgwLOBJ.SelectedRows.Count == 1)
            {
                Row = dgwLOBJ.SelectedRows[0].Index;
            }
            else if (dgwLOBJ.SelectedRows.Count == 0 && dgwLOBJ.SelectedCells.Count == 1)
            {
                Row = dgwLOBJ.SelectedCells[0].RowIndex;
            }
            else
            {
                MessageBox.Show("Unable to export Light Object!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Binary Light Object (*blobj)|*.blobj";
            if (s.ShowDialog() == DialogResult.OK)
            {                
                BigEndianWriter Writer = new BigEndianWriter(File.Open(s.FileName, FileMode.Create));
                Writer.WriteChars("LOBJ".ToCharArray(), 0, 4);
                Writer.WriteUInt32(0x50);
                Writer.WriteUInt64(UInt64.Parse(dgwLOBJ.Rows[Row].Cells[20].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt16(UInt16.Parse(dgwLOBJ.Rows[Row].Cells[21].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[Row].Cells[1].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[Row].Cells[2].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt16(UInt16.Parse(dgwLOBJ.Rows[Row].Cells[13].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt16(UInt16.Parse(dgwLOBJ.Rows[Row].Cells[14].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[3].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[4].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[5].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[6].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[7].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[8].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[9].Value.ToString()));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[Row].Cells[16].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[Row].Cells[17].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[Row].Cells[18].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwLOBJ.Rows[Row].Cells[19].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt32(UInt32.Parse(dgwLOBJ.Rows[Row].Cells[15].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[10].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[11].Value.ToString()));
                Writer.WriteSingle(Convert.ToSingle(dgwLOBJ.Rows[Row].Cells[12].Value.ToString()));
                Writer.WriteUInt64(UInt64.Parse(dgwLOBJ.Rows[Row].Cells[22].Value.ToString(), NumberStyles.HexNumber));
                Writer.Close();
            }
        }
        private void ExportAmbient_Click(object sender, EventArgs e)
        {
            int Row = 0;
            if (dgwAmbient.SelectedRows.Count == 1)
            {
                Row = dgwAmbient.SelectedRows[0].Index;
            }
            else if (dgwAmbient.SelectedRows.Count == 0 && dgwAmbient.SelectedCells.Count == 1)
            {
                Row = dgwAmbient.SelectedCells[0].RowIndex;
            }
            else
            {
                MessageBox.Show("Unable to export Ambient Light!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Binary Ambient Light (*bambl)|*.bambl";
            if (s.ShowDialog() == DialogResult.OK)
            {
                BigEndianWriter Writer = new BigEndianWriter(File.Open(s.FileName, FileMode.Create));
                Writer.WriteChars("BAML".ToCharArray(), 0, 4);
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[Row].Cells[1].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[Row].Cells[2].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[Row].Cells[3].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteByte(byte.Parse(dgwAmbient.Rows[Row].Cells[4].Value.ToString(), NumberStyles.HexNumber));
                Writer.WriteUInt32(UInt32.Parse(dgwAmbient.Rows[Row].Cells[5].Value.ToString(), NumberStyles.HexNumber));
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
