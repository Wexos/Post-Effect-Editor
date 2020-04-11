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
using System.BLMAP;

namespace Effect_Editor
{
    public partial class LTEXComponent : UserControl
    {
        public LTEXComponent()
        {
            InitializeComponent();
        }

        public void AddData(BLMAPLTEX l)
        {
            if (l != null)
            {
                Unknown1.Text = HexUtil.Hex32(l.Padding);
                Unknown2.Text = HexUtil.Hex32(l.Unknown);
                Unknown3.Text = HexUtil.Hex16(l.Unknown1);
                Texture.Text = l.Texture;
                Unknown4.Text = HexUtil.Hex32(l.Unknown2);
                Unknown5.Text = HexUtil.Hex32(l.Unknown3);
                Unknown6.Text = HexUtil.Hex32(l.Unknown4);
                Unknown7.Text = HexUtil.Hex32(l.Unknown5);
                Unknown8.Text = HexUtil.Hex32(l.Unknown6);
                Unknown9.Text = HexUtil.Hex32(l.Unknown7);
                Unknown10.Text = HexUtil.Hex32(l.Unknown8);
                Unknown11.Text = HexUtil.Hex32(l.Unknown9);
            }
            else
            {
                Unknown1.Text = "";
                Unknown2.Text = "";
                Unknown3.Text = "";
                Texture.Text = "";
                Unknown4.Text = "";
                Unknown5.Text = "";
                Unknown6.Text = "";
                Unknown7.Text = "";
                Unknown8.Text = "";
                Unknown9.Text = "";
                Unknown10.Text = "";
                Unknown11.Text = "";
            }
        }
        public BLMAPLTEX ReturnData()
        {
            if (Unknown1.Text != "" && Unknown2.Text != "" && Unknown3.Text != "" && Texture.Text != "" && Unknown4.Text != "" && Unknown5.Text != "" && Unknown6.Text != "" && Unknown7.Text != "" && Unknown8.Text != "" && Unknown9.Text != "" && Unknown10.Text != "" && Unknown11.Text != "")
            {
                return new BLMAPLTEX()
                {
                    Padding = UInt32.Parse(Unknown1.Text, NumberStyles.HexNumber),
                    Unknown = UInt32.Parse(Unknown2.Text, NumberStyles.HexNumber),
                    Unknown1 = UInt16.Parse(Unknown3.Text, NumberStyles.HexNumber),
                    Texture = Texture.Text,
                    Unknown2 = UInt32.Parse(Unknown4.Text, NumberStyles.HexNumber),
                    Unknown3 = UInt32.Parse(Unknown5.Text, NumberStyles.HexNumber),
                    Unknown4 = UInt32.Parse(Unknown6.Text, NumberStyles.HexNumber),
                    Unknown5 = UInt32.Parse(Unknown7.Text, NumberStyles.HexNumber),
                    Unknown6 = UInt32.Parse(Unknown8.Text, NumberStyles.HexNumber),
                    Unknown7 = UInt32.Parse(Unknown9.Text, NumberStyles.HexNumber),
                    Unknown8 = UInt32.Parse(Unknown10.Text, NumberStyles.HexNumber),
                    Unknown9 = UInt32.Parse(Unknown11.Text, NumberStyles.HexNumber)
                };
            }
            else
            {
                return null;
            }
        }

        private void Hex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (HexUtil.IsHex(e.KeyChar) == true)
            {

            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }
        private void Decimal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t == Unknown3)
            {
                if (t.Text == null || t.Text == "")
                {
                    t.Text = "0000";
                }
                else
                {
                    t.Text = HexUtil.Hex16(UInt16.Parse(t.Text, NumberStyles.HexNumber));
                }
            }
            else if (t == Texture)
            {
                if (t.Text.Length != 4)
                {
                    MessageBox.Show("The length of the texture must be 4!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    t.Focus();
                }
            }
            else
            {
                if (t.Text == null || t.Text == "")
                {
                    t.Text = "00000000";
                }
                else
                {
                    t.Text = HexUtil.Hex32(UInt32.Parse(t.Text, NumberStyles.HexNumber));
                }
            }
        }
    }
}
