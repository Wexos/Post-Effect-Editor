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
using System.BBLM;

namespace Effect_Editor
{
    public partial class BBLMComponent : UserControl
    {
        public BBLMComponent()
        {
            InitializeComponent();
        }

        public void AddData(BBLM Data)
        {
            textBox0x08.Text = HexUtil.Hex64(Data.Unknown1);
            textBox0x10.Text = Data.ScaleFactor.ToString();
            textBox0x14.Text = HexUtil.Hex32(Data.RGB);
            textBox0x18.Text = HexUtil.Hex32(Data.blurrRGB);
            textBox0x1C.Text = HexUtil.Hex16(Data.Unknown2);
            textBox0x1E.Text = HexUtil.Hex16(Data.Unknown3);

            textBox0x20.Text = Data.Entries[0].Unknown1.ToString();
            textBox0x24.Text = Data.Entries[0].Unknown2.ToString();
            textBox0x28.Text = HexUtil.Hex32(Data.Entries[0].Unknown3);
            textBox0x2C.Text = HexUtil.Hex32(Data.Entries[0].Unknown4);
            textBox0x30.Text = HexUtil.Hex32(Data.Entries[0].Unknown5);
            textBox0x34.Text = HexUtil.Hex32(Data.Entries[0].Unknown6);
            textBox0x38.Text = HexUtil.Hex32(Data.Entries[0].Unknown7);
            textBox0x3C.Text = HexUtil.Hex32(Data.Entries[0].Unknown8);

            textBox0x40.Text = Data.Entries[1].Unknown1.ToString();
            textBox0x44.Text = Data.Entries[1].Unknown2.ToString();
            textBox0x48.Text = HexUtil.Hex32(Data.Entries[1].Unknown3);
            textBox0x4C.Text = HexUtil.Hex32(Data.Entries[1].Unknown4);
            textBox0x50.Text = HexUtil.Hex32(Data.Entries[1].Unknown5);
            textBox0x54.Text = HexUtil.Hex32(Data.Entries[1].Unknown6);
            textBox0x58.Text = HexUtil.Hex32(Data.Entries[1].Unknown7);
            textBox0x5C.Text = HexUtil.Hex32(Data.Entries[1].Unknown8);

            textBox0x60.Text = Data.Entries[2].Unknown1.ToString();
            textBox0x64.Text = Data.Entries[2].Unknown2.ToString();
            textBox0x68.Text = HexUtil.Hex32(Data.Entries[2].Unknown3);
            textBox0x6C.Text = HexUtil.Hex32(Data.Entries[2].Unknown4);
            textBox0x70.Text = HexUtil.Hex32(Data.Entries[2].Unknown5);
            textBox0x74.Text = HexUtil.Hex32(Data.Entries[2].Unknown6);
            textBox0x78.Text = HexUtil.Hex32(Data.Entries[2].Unknown7);
            textBox0x7C.Text = HexUtil.Hex32(Data.Entries[2].Unknown8);

            textBox0x80.Text = HexUtil.Hex32(Data.Unknown4);
            textBox0x84.Text = HexUtil.Hex32(Data.Unknown5);
            textBox0x88.Text = HexUtil.Hex32(Data.Unknown6);
            textBox0x8C.Text = HexUtil.Hex32(Data.Unknown7);
            textBox0x90.Text = HexUtil.Hex32(Data.Unknown8);
            textBox0x94.Text = HexUtil.Hex32(Data.Unknown9);
            textBox0x98.Text = Data.float1.ToString();
            textBox0x9C.Text = Data.float2.ToString();
            textBox0xA0.Text = Data.float3.ToString();
        }
        public BBLM ReturnData()
        {
            BBLM Data = new BBLM();
            Data.Entries = new List<Entry>();
            Data.Unknown1 = UInt64.Parse(textBox0x08.Text, NumberStyles.HexNumber);
            Data.ScaleFactor = Convert.ToSingle(textBox0x10.Text);
            Data.RGB = UInt32.Parse(textBox0x14.Text, NumberStyles.HexNumber);
            Data.blurrRGB = UInt32.Parse(textBox0x18.Text, NumberStyles.HexNumber);
            Data.Unknown2 = UInt16.Parse(textBox0x1C.Text, NumberStyles.HexNumber);
            Data.Unknown3 = UInt16.Parse(textBox0x1E.Text, NumberStyles.HexNumber);
            Data.Entries.Add(new Entry()
                {
                    Unknown1 = Convert.ToSingle(textBox0x20.Text),
                    Unknown2 = Convert.ToSingle(textBox0x24.Text),
                    Unknown3 = UInt32.Parse(textBox0x28.Text, NumberStyles.HexNumber),
                    Unknown4 = UInt32.Parse(textBox0x2C.Text, NumberStyles.HexNumber),
                    Unknown5 = UInt32.Parse(textBox0x30.Text, NumberStyles.HexNumber),
                    Unknown6 = UInt32.Parse(textBox0x34.Text, NumberStyles.HexNumber),
                    Unknown7 = UInt32.Parse(textBox0x38.Text, NumberStyles.HexNumber),
                    Unknown8 = UInt32.Parse(textBox0x3C.Text, NumberStyles.HexNumber),
                });
            Data.Entries.Add(new Entry()
            {
                Unknown1 = Convert.ToSingle(textBox0x40.Text),
                Unknown2 = Convert.ToSingle(textBox0x44.Text),
                Unknown3 = UInt32.Parse(textBox0x48.Text, NumberStyles.HexNumber),
                Unknown4 = UInt32.Parse(textBox0x4C.Text, NumberStyles.HexNumber),
                Unknown5 = UInt32.Parse(textBox0x50.Text, NumberStyles.HexNumber),
                Unknown6 = UInt32.Parse(textBox0x54.Text, NumberStyles.HexNumber),
                Unknown7 = UInt32.Parse(textBox0x58.Text, NumberStyles.HexNumber),
                Unknown8 = UInt32.Parse(textBox0x5C.Text, NumberStyles.HexNumber),
            });
            Data.Entries.Add(new Entry()
            {
                Unknown1 = Convert.ToSingle(textBox0x60.Text),
                Unknown2 = Convert.ToSingle(textBox0x64.Text),
                Unknown3 = UInt32.Parse(textBox0x68.Text, NumberStyles.HexNumber),
                Unknown4 = UInt32.Parse(textBox0x6C.Text, NumberStyles.HexNumber),
                Unknown5 = UInt32.Parse(textBox0x70.Text, NumberStyles.HexNumber),
                Unknown6 = UInt32.Parse(textBox0x74.Text, NumberStyles.HexNumber),
                Unknown7 = UInt32.Parse(textBox0x78.Text, NumberStyles.HexNumber),
                Unknown8 = UInt32.Parse(textBox0x7C.Text, NumberStyles.HexNumber),
            });
            Data.Unknown4 = UInt32.Parse(textBox0x80.Text, NumberStyles.HexNumber);
            Data.Unknown5 = UInt32.Parse(textBox0x84.Text, NumberStyles.HexNumber);
            Data.Unknown6 = UInt32.Parse(textBox0x88.Text, NumberStyles.HexNumber);
            Data.Unknown7 = UInt32.Parse(textBox0x8C.Text, NumberStyles.HexNumber);
            Data.Unknown8 = UInt32.Parse(textBox0x90.Text, NumberStyles.HexNumber);
            Data.Unknown9 = UInt32.Parse(textBox0x94.Text);
            Data.float1 = Convert.ToSingle(textBox0x98.Text);
            Data.float2 = Convert.ToSingle(textBox0x9C.Text);
            Data.float3 = Convert.ToSingle(textBox0xA0.Text);

            return Data;
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
    }
}
