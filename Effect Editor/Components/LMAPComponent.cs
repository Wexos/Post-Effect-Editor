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
    public partial class LMAPComponent : UserControl
    {
        public LMAPComponent()
        {
            InitializeComponent();
        }
        public void AddData(BLMAP b)
        {
            if (b != null)
            {
                Unknown1.Text = HexUtil.Hex32(b.Unknown1);
                Unknown2.Text = HexUtil.Hex32(b.Unknown2);
                Unknown3.Text = HexUtil.Hex16(b.Unknown3);
                Unknown4.Text = HexUtil.Hex32(b.Unknown4);
                Unknown5.Text = HexUtil.Hex32(b.Unknown5);
                Unknown6.Text = HexUtil.Hex32(b.Unknown6);
            }
            else
            {
                Unknown1.Text = "";
                Unknown2.Text = "";
                Unknown3.Text = "";
                Unknown4.Text = "";
                Unknown5.Text = "";
                Unknown6.Text = "";
            }
        }
        public BLMAP ReturnData()
        {
            return new BLMAP()
            {
                Unknown1 = UInt32.Parse(Unknown1.Text, NumberStyles.HexNumber),
                Unknown2 = UInt32.Parse(Unknown2.Text, NumberStyles.HexNumber),
                Unknown3 = UInt16.Parse(Unknown3.Text, NumberStyles.HexNumber),
                Unknown4 = UInt32.Parse(Unknown4.Text, NumberStyles.HexNumber),
                Unknown5 = UInt32.Parse(Unknown5.Text, NumberStyles.HexNumber),
                Unknown6 = UInt32.Parse(Unknown6.Text, NumberStyles.HexNumber)
            };
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
