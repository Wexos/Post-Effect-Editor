using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.BFG;

namespace Effect_Editor
{
    public partial class BFGComponent : UserControl
    {
        public BFGComponent()
        {
            InitializeComponent();
        }

        public void AddData(BFG b)
        {
            textBox0x00.Text = HexUtil.Hex32(b.Unknown1);
            textBox0x04.Text = b.Unknown2.ToString();

            textBox0x08.Text = b.Entries[0].Distance.ToString();
            textBox0x0C.Text = HexUtil.Hex32(b.Entries[0].RGBA);
            textBox0x10.Text = HexUtil.Hex16(b.Entries[0].Unknown1);
            textBox0x12.Text = HexUtil.Hex16(b.Entries[0].Unknown2);
            textBox0x14.Text = b.Entries[0].Float1B.ToString();
            textBox0x18.Text = HexUtil.Hex32(b.Entries[0].Unknown3);
            textBox0x1C.Text = HexUtil.Hex32(b.Entries[0].Unknown4);
            textBox0x20.Text = HexUtil.Hex32(b.Entries[0].Padding);

            textBox0x24.Text = b.Entries[1].Distance.ToString();
            textBox0x28.Text = HexUtil.Hex32(b.Entries[1].RGBA);
            textBox0x2C.Text = HexUtil.Hex16(b.Entries[1].Unknown1);
            textBox0x2E.Text = HexUtil.Hex16(b.Entries[1].Unknown2);
            textBox0x30.Text = b.Entries[1].Float1B.ToString();
            textBox0x34.Text = HexUtil.Hex32(b.Entries[1].Unknown3);
            textBox0x38.Text = HexUtil.Hex32(b.Entries[1].Unknown4);
            textBox0x3C.Text = HexUtil.Hex32(b.Entries[1].Padding);

            textBox0x40.Text = b.Entries[2].Distance.ToString();
            textBox0x44.Text = HexUtil.Hex32(b.Entries[2].RGBA);
            textBox0x48.Text = HexUtil.Hex16(b.Entries[2].Unknown1);
            textBox0x4A.Text = HexUtil.Hex16(b.Entries[2].Unknown2);
            textBox0x4C.Text = b.Entries[2].Float1B.ToString();
            textBox0x50.Text = HexUtil.Hex32(b.Entries[2].Unknown3);
            textBox0x54.Text = HexUtil.Hex32(b.Entries[2].Unknown4);
            textBox0x58.Text = HexUtil.Hex32(b.Entries[2].Padding);

            textBox0x5C.Text = b.Float4A.ToString();
            textBox0x60.Text = HexUtil.Hex32(b.Bytes4A);
            textBox0x64.Text = HexUtil.Hex16(b.Unknown4A);
            textBox0x66.Text = HexUtil.Hex16(b.Unknown4B);
            textBox0x68.Text = b.Float4B.ToString();
            textBox0x6C.Text = HexUtil.Hex32(b.Unknown4C);
            }
        public BFG ReturnData()
        {
            BFG b = new BFG();
            b.Entries = new List<Entry>();
            b.Unknown1 = UInt32.Parse(textBox0x00.Text, NumberStyles.HexNumber);
            b.Unknown2 = Convert.ToSingle(textBox0x04.Text);
            b.Entries.Add(new Entry()
            {
                Distance = Convert.ToSingle(textBox0x08.Text),
                RGBA = UInt32.Parse(textBox0x0C.Text, NumberStyles.HexNumber),
                Unknown1 = UInt16.Parse(textBox0x10.Text, NumberStyles.HexNumber),
                Unknown2 = UInt16.Parse(textBox0x12.Text, NumberStyles.HexNumber),
                Float1B = Convert.ToSingle(textBox0x14.Text),
                Unknown3 = UInt32.Parse(textBox0x18.Text, NumberStyles.HexNumber),
                Unknown4 = UInt32.Parse(textBox0x1C.Text, NumberStyles.HexNumber),
                Padding = UInt32.Parse(textBox0x20.Text, NumberStyles.HexNumber)
            });
            b.Entries.Add(new Entry()
            {
                Distance = Convert.ToSingle(textBox0x24.Text),
                RGBA = UInt32.Parse(textBox0x28.Text, NumberStyles.HexNumber),
                Unknown1 = UInt16.Parse(textBox0x2C.Text, NumberStyles.HexNumber),
                Unknown2 = UInt16.Parse(textBox0x2E.Text, NumberStyles.HexNumber),
                Float1B = Convert.ToSingle(textBox0x30.Text),
                Unknown3 = UInt32.Parse(textBox0x34.Text, NumberStyles.HexNumber),
                Unknown4 = UInt32.Parse(textBox0x38.Text, NumberStyles.HexNumber),
                Padding = UInt32.Parse(textBox0x3C.Text, NumberStyles.HexNumber)
            });
            b.Entries.Add(new Entry()
            {
                Distance = Convert.ToSingle(textBox0x40.Text),
                RGBA = UInt32.Parse(textBox0x44.Text, NumberStyles.HexNumber),
                Unknown1 = UInt16.Parse(textBox0x48.Text, NumberStyles.HexNumber),
                Unknown2 = UInt16.Parse(textBox0x4A.Text, NumberStyles.HexNumber),
                Float1B = Convert.ToSingle(textBox0x4C.Text),
                Unknown3 = UInt32.Parse(textBox0x50.Text, NumberStyles.HexNumber),
                Unknown4 = UInt32.Parse(textBox0x54.Text, NumberStyles.HexNumber),
                Padding = UInt32.Parse(textBox0x58.Text, NumberStyles.HexNumber)
            });
            b.Float4A = Convert.ToSingle(textBox0x5C.Text);
            b.Bytes4A = UInt32.Parse(textBox0x60.Text, NumberStyles.HexNumber);
            b.Unknown4A = UInt16.Parse(textBox0x64.Text, NumberStyles.HexNumber);
            b.Unknown4B = UInt16.Parse(textBox0x66.Text, NumberStyles.HexNumber);
            b.Float4B = Convert.ToSingle(textBox0x68.Text);
            b.Unknown4C = UInt32.Parse(textBox0x6C.Text, NumberStyles.HexNumber);
            return b;
        }

        private void GetColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TextBox t = sender as TextBox;
                t.Text = HexUtil.Hex32(GetColor(UInt32.Parse(t.Text, NumberStyles.HexNumber)));
            }

        }
        private void GetColor_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox t = sender as TextBox;
            t.Text = HexUtil.Hex32(GetColor(UInt32.Parse(t.Text, NumberStyles.HexNumber)));
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            if (p == pictureBox1)
            {
                textBox0x0C.Text = HexUtil.Hex32(GetColor(UInt32.Parse(textBox0x0C.Text, NumberStyles.HexNumber)));
            }
            else if (p == pictureBox2)
            {
                textBox0x28.Text = HexUtil.Hex32(GetColor(UInt32.Parse(textBox0x28.Text, NumberStyles.HexNumber)));
            }
            else if (p == pictureBox3)
            {
                textBox0x44.Text = HexUtil.Hex32(GetColor(UInt32.Parse(textBox0x44.Text, NumberStyles.HexNumber)));
            }
            else if (p == pictureBox4)
            {
                textBox0x60.Text = HexUtil.Hex32(GetColor(UInt32.Parse(textBox0x60.Text, NumberStyles.HexNumber)));
            }
        }
        private UInt32 GetColor(UInt32 ColorBefore)
        {
            ColorDialog c = new ColorDialog();
            c.Color = Color.FromArgb((int)(ColorBefore & 0xFF), (int)((ColorBefore >> 24) & 0xFF), (int)((ColorBefore >> 16) & 0xFF), (int)((ColorBefore >> 8) & 0xFF));
            if (c.ShowDialog() == DialogResult.OK)
            {
                return (uint)((int)c.Color.R << (int)24) | (uint)(c.Color.G << 16) | (uint)(c.Color.B << 8) | (uint)(ColorBefore & 0xFF);
            }
            else
            {
                return ColorBefore;
            }
        }

        private void hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (HexUtil.IsHex(e.KeyChar) == true)
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void decimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(".") || e.KeyChar == Convert.ToChar(",") || e.KeyChar == Convert.ToChar("-"))
            {

            }
            else if (char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void GetRGB_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.TextLength == 8)
            {
                if (t == textBox0x0C)
                {
                    pictureBox1.BackColor = Color.FromArgb(Int32.Parse(t.Text.Substring(0, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(2, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(4, 2), NumberStyles.HexNumber));
                }
                else if (t == textBox0x28)
                {
                    pictureBox2.BackColor = Color.FromArgb(Int32.Parse(t.Text.Substring(0, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(2, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(4, 2), NumberStyles.HexNumber));
                }
                else if (t == textBox0x44)
                {
                    pictureBox3.BackColor = Color.FromArgb(Int32.Parse(t.Text.Substring(0, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(2, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(4, 2), NumberStyles.HexNumber));
                }
                else if (t == textBox0x60)
                {
                    pictureBox4.BackColor = Color.FromArgb(Int32.Parse(t.Text.Substring(0, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(2, 2), NumberStyles.HexNumber), Int32.Parse(t.Text.Substring(4, 2), NumberStyles.HexNumber));
                }
            }
        }
        private void Byte_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "")
            {
                t.Text = "00";
            }
            else
            {
                t.Text = HexUtil.Hex8(byte.Parse(t.Text, NumberStyles.HexNumber));
            }
        }
        private void UInt16_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "")
            {
                t.Text = "0000";
            }
            else
            {
                t.Text = HexUtil.Hex16(UInt16.Parse(t.Text, NumberStyles.HexNumber));
            }
        }
        private void UInt32_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "")
            {
                t.Text = "00000000";
            }
            else
            {
                t.Text = HexUtil.Hex32(UInt32.Parse(t.Text, NumberStyles.HexNumber));
            }
        }
        private void UInt64_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "")
            {
                t.Text = "0000000000000000";
            }
            else
            {
                t.Text = HexUtil.Hex64(UInt64.Parse(t.Text, NumberStyles.HexNumber));
            }
        }
        private void Float_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "")
            {
                t.Text = "0";
            }
            else
            {
                try
                {
                    float f = Convert.ToSingle(t.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid value!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t.Focus();
                }
            }
        }
    }
}
