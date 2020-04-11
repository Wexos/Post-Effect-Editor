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

namespace Effect_Editor
{
    public partial class FormMain : Form
    {
        const string ProgramVersion = "v0.1.0"; public string thisName = "Post-Effect Editor | " + ProgramVersion + " | By Wexos";
        public FormMain()
        {
            InitializeComponent();
            this.Text = thisName;
        }
        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenEffect.ShowDialog() == DialogResult.OK)
            {
                ReadFile(OpenEffect.FileName);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wiki.tockdom.com/wiki/Post-Effect_Editor");
        }

        public void ReadFile(string FilePath)
        {
            try
            {
                BigEndianReader Reader = new BigEndianReader(new MemoryStream(File.ReadAllBytes(FilePath)));
                string Magic = Reader.ReadASCII(4);
                if (Magic == "PBLM")
                {
                    BBLMEditor BBLMEditor = new BBLMEditor();
                    BBLMEditor.ReadBBLM(FilePath);
                }
                else if (Magic == "PDOF")
                {
                    BDOFEditor BDOFEditor = new BDOFEditor();
                    BDOFEditor.ReadBDOF(FilePath);
                }
                else if (Magic == "LGHT")
                {
                    BLIGHTEditor BLIGHTEditor = new BLIGHTEditor();
                    BLIGHTEditor.ReadBLIGHT(FilePath);
                }
                else if (Magic == "LMAP")
                {
                    BLMAPEditor BLMAPEditor = new BLMAPEditor();
                    BLMAPEditor.ReadBLMAP(FilePath);
                }
                else if (new FileInfo(FilePath).Length == 0x70)
                {
                    BFGEditor BFGEditor = new BFGEditor();
                    BFGEditor.ReadBFG(FilePath);
                }
                else
                {
                    throw new Exception("The file is invalid!");
                }
            }
            catch (Exception Ex)
            {
                this.Text = thisName;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Ex, true);
                throw new Exception(Ex.Message + Environment.NewLine +  "Class Name: " + trace.GetFrame(0).GetMethod().ReflectedType.FullName + " Line: " + trace.GetFrame(0).GetFileLineNumber() + " Column: " + trace.GetFrame(0).GetFileColumnNumber());
            }
        }
        #region NewFile
        private void bBLMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewBBLM();
        }
        private void bDOFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewBDOF();
        }
        private void bFGToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            NewBFG();
        }
        private void bLIGHTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewBLIGHT();
        }
        private void bLMAPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewBLMAP();
        }
        public void NewBBLM()
        {
            BBLMEditor BBLMEditor = new BBLMEditor();
            BBLMEditor.NewBBLM();
        }
        public void NewBDOF()
        {
            BDOFEditor BDOFEditor = new BDOFEditor();
            BDOFEditor.NewBDOF();
        }
        public void NewBFG()
        {
            BFGEditor BFGEditor = new BFGEditor();
            BFGEditor.NewBFG();
        }
        public void NewBLIGHT()
        {
            BLIGHTEditor BLIGHTEditor = new BLIGHTEditor();
            BLIGHTEditor.NewBLIGHT();
        }
        public void NewBLMAP()
        {
            BLMAPEditor BLMAPEditor = new BLMAPEditor();
            BLMAPEditor.NewBLMAP();
        }
        #endregion        

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (FileList != null)
            {
                ReadFile(FileList[0]);
            }
        }
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            int FormCount = 0;
            foreach (Form frm in fc)
            {
                FormCount++;
            }
            //if (e.CloseReason == CloseReason.WindowsShutDown)
            //{
            //
            //}
            //else if(e.CloseReason == CloseReason.FormOwnerClosing)
            //{
            //
            //}
            if (fc.Count > 1)
            {
                DialogResult d = MessageBox.Show("There are forms that are not closed and may conatin unsaved data, are you sure you want to exit? Every form will be closed without saving!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (d)
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        return;
                }
            }
        }
    }
}
