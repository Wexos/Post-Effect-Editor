using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.BDOF;

namespace Effect_Editor
{
    public partial class BDOFComponent : UserControl
    {
        public BDOFComponent()
        {
            InitializeComponent();
        }

        public void AddData(BDOF b)
        {
            textBox0x08.Text = HexUtil.Hex64(b.Unknown1);
            textBox0x10.Text = HexUtil.Hex16(b.Activator);
            textBox0x12.Text = HexUtil.Hex16(b.Unknown2);
            textBox0x14.Text = HexUtil.Hex32(b.Unknown3);
            textBoxPadding1.Text = HexUtil.Hex64(b.Padding[0]);
            textBoxPadding2.Text = HexUtil.Hex64(b.Padding[1]);
            textBoxFloat1.Text = b.FloatValues[0].ToString();
            textBoxFloat2.Text = b.FloatValues[1].ToString();
            textBoxFloat3.Text = b.FloatValues[2].ToString();
            textBoxFloat4.Text = b.FloatValues[3].ToString();
            textBoxFloat5.Text = b.FloatValues[4].ToString();
            textBoxFloat6.Text = b.FloatValues[5].ToString();
            textBoxFloat7.Text = b.FloatValues[6].ToString();
            textBoxFloat8.Text = b.FloatValues[7].ToString();
            textBoxFloat9.Text = b.FloatValues[8].ToString();
            textBoxFloat10.Text = b.FloatValues[9].ToString();
        }
        public BDOF ReturnData()
        {
            return new BDOF() {
                Unknown1 = UInt64.Parse(textBox0x08.Text, NumberStyles.HexNumber),
                Activator = UInt16.Parse(textBox0x10.Text, NumberStyles.HexNumber),
                Unknown2 = UInt16.Parse(textBox0x12.Text, NumberStyles.HexNumber),
                Unknown3 = UInt32.Parse(textBox0x14.Text, NumberStyles.HexNumber),
                FloatValues = new float[10] { 
                    Convert.ToSingle(textBoxFloat1.Text), Convert.ToSingle(textBoxFloat2.Text), 
                    Convert.ToSingle(textBoxFloat3.Text), Convert.ToSingle(textBoxFloat4.Text), Convert.ToSingle(textBoxFloat5.Text), 
                    Convert.ToSingle(textBoxFloat6.Text), Convert.ToSingle(textBoxFloat7.Text), Convert.ToSingle(textBoxFloat8.Text),
                    Convert.ToSingle(textBoxFloat9.Text), Convert.ToSingle(textBoxFloat10.Text)
                },
                Padding = new UInt64[2] { UInt64.Parse(textBoxPadding1.Text, NumberStyles.HexNumber), UInt64.Parse(textBoxPadding2.Text, NumberStyles.HexNumber)}
            };
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
    }
}
