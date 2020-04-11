namespace Effect_Editor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.OpenEffect = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bBLMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bDOFToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bFGToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bLIGHTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bLMAPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenEffect
            // 
            this.OpenEffect.Filter = resources.GetString("OpenEffect.Filter");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(340, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bBLMToolStripMenuItem1,
            this.bDOFToolStripMenuItem1,
            this.bFGToolStripMenuItem2,
            this.bLIGHTToolStripMenuItem1,
            this.bLMAPToolStripMenuItem1});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // bBLMToolStripMenuItem1
            // 
            this.bBLMToolStripMenuItem1.Enabled = false;
            this.bBLMToolStripMenuItem1.Name = "bBLMToolStripMenuItem1";
            this.bBLMToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.bBLMToolStripMenuItem1.Text = "BBLM";
            this.bBLMToolStripMenuItem1.Click += new System.EventHandler(this.bBLMToolStripMenuItem1_Click);
            // 
            // bDOFToolStripMenuItem1
            // 
            this.bDOFToolStripMenuItem1.Enabled = false;
            this.bDOFToolStripMenuItem1.Name = "bDOFToolStripMenuItem1";
            this.bDOFToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.bDOFToolStripMenuItem1.Text = "BDOF";
            this.bDOFToolStripMenuItem1.Click += new System.EventHandler(this.bDOFToolStripMenuItem1_Click);
            // 
            // bFGToolStripMenuItem2
            // 
            this.bFGToolStripMenuItem2.Enabled = false;
            this.bFGToolStripMenuItem2.Name = "bFGToolStripMenuItem2";
            this.bFGToolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
            this.bFGToolStripMenuItem2.Text = "BFG";
            this.bFGToolStripMenuItem2.Click += new System.EventHandler(this.bFGToolStripMenuItem2_Click);
            // 
            // bLIGHTToolStripMenuItem1
            // 
            this.bLIGHTToolStripMenuItem1.Name = "bLIGHTToolStripMenuItem1";
            this.bLIGHTToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.bLIGHTToolStripMenuItem1.Text = "BLIGHT";
            this.bLIGHTToolStripMenuItem1.Click += new System.EventHandler(this.bLIGHTToolStripMenuItem1_Click);
            // 
            // bLMAPToolStripMenuItem1
            // 
            this.bLMAPToolStripMenuItem1.Name = "bLMAPToolStripMenuItem1";
            this.bLMAPToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.bLMAPToolStripMenuItem1.Text = "BLMAP";
            this.bLMAPToolStripMenuItem1.Click += new System.EventHandler(this.bLMAPToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Effect_Editor.Properties.Resources.PE;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(316, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 300);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(356, 338);
            this.MinimumSize = new System.Drawing.Size(356, 338);
            this.Name = "FormMain";
            this.Text = "Post-Effect Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.OpenFileDialog OpenEffect;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bBLMToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bDOFToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bFGToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bLIGHTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bLMAPToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

