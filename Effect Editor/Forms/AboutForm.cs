using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Effect_Editor
{
    public partial class About : Form
    {
        public About()
        {
            FormMain f = new FormMain();
            InitializeComponent();
            this.Text = f.thisName;
            textBox1.Text = "Post-Effect Editor is a program by Wexos. It allows you to edit post effects used in Mario Kart Wii (maybe other games too). " + 
            "Many values are unknown, so if you know any value, please contact Wexos. Thanks to Atlas for the Icon!";
            this.Focus();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.Items[0].Selected == true)
            {
                textBoxInfo.Text = "v0.1.0";
            }
            if (listView1.Items[1].Selected == true)
            {
                textBoxInfo.Text = "v0.1.0";
            }
            if (listView1.Items[2].Selected == true)
            {
                textBoxInfo.Text = "v0.1.0";
            }
            if (listView1.Items[3].Selected == true)
            {
                textBoxInfo.Text = "v1.0.0";
            }
            if (listView1.Items[4].Selected == true)
            {
                textBoxInfo.Text = "v1.0.0";
            }
        }
    }
}
