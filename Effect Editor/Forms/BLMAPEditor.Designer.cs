namespace Effect_Editor
{
    partial class BLMAPEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("BLMAP");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BLMAPEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bBLMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bDOFToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bFGToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bLIGHTToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bLMAPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lTEXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lTEXEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightTextureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBLMAP = new System.Windows.Forms.SaveFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lmapComponent1 = new Effect_Editor.LMAPComponent();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ltexComponent1 = new Effect_Editor.LTEXComponent();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgwEntries = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Float = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEntries)).BeginInit();
            this.cmsDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bBLMToolStripMenuItem1,
            this.bDOFToolStripMenuItem1,
            this.bFGToolStripMenuItem2,
            this.bLIGHTToolStripMenuItem1,
            this.bLMAPToolStripMenuItem1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem1.Text = "New";
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lTEXToolStripMenuItem,
            this.lTEXEntryToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // lTEXToolStripMenuItem
            // 
            this.lTEXToolStripMenuItem.Name = "lTEXToolStripMenuItem";
            this.lTEXToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.lTEXToolStripMenuItem.Text = "LTEX";
            this.lTEXToolStripMenuItem.Click += new System.EventHandler(this.AddLTEX);
            // 
            // lTEXEntryToolStripMenuItem
            // 
            this.lTEXEntryToolStripMenuItem.Name = "lTEXEntryToolStripMenuItem";
            this.lTEXEntryToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.lTEXEntryToolStripMenuItem.Text = "LTEX Entry";
            this.lTEXEntryToolStripMenuItem.Click += new System.EventHandler(this.AddLTEXEntry_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightTextureToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // lightTextureToolStripMenuItem
            // 
            this.lightTextureToolStripMenuItem.Name = "lightTextureToolStripMenuItem";
            this.lightTextureToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.lightTextureToolStripMenuItem.Text = "Light Texture";
            this.lightTextureToolStripMenuItem.Click += new System.EventHandler(this.ImportLTEX_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightTextureToolStripMenuItem1});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // lightTextureToolStripMenuItem1
            // 
            this.lightTextureToolStripMenuItem1.Name = "lightTextureToolStripMenuItem1";
            this.lightTextureToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.lightTextureToolStripMenuItem1.Text = "Light Texture";
            this.lightTextureToolStripMenuItem1.Click += new System.EventHandler(this.ExportLTEX_Click);
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
            // saveBLMAP
            // 
            this.saveBLMAP.Filter = "Binary Light MAP Files (*.blmap)|*.blmap";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 27);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "BLMAP";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(136, 223);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(154, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 223);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lmapComponent1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(507, 197);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Header";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lmapComponent1
            // 
            this.lmapComponent1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lmapComponent1.Location = new System.Drawing.Point(6, 6);
            this.lmapComponent1.Name = "lmapComponent1";
            this.lmapComponent1.Size = new System.Drawing.Size(495, 185);
            this.lmapComponent1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ltexComponent1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(507, 197);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LTEX Header";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ltexComponent1
            // 
            this.ltexComponent1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltexComponent1.Location = new System.Drawing.Point(6, 6);
            this.ltexComponent1.Name = "ltexComponent1";
            this.ltexComponent1.Size = new System.Drawing.Size(495, 185);
            this.ltexComponent1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgwEntries);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(507, 197);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "LTEX";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgwEntries
            // 
            this.dgwEntries.AllowUserToAddRows = false;
            this.dgwEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwEntries.ColumnHeadersHeight = 21;
            this.dgwEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgwEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Float,
            this.Column1});
            this.dgwEntries.Location = new System.Drawing.Point(6, 6);
            this.dgwEntries.Name = "dgwEntries";
            this.dgwEntries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgwEntries.Size = new System.Drawing.Size(495, 185);
            this.dgwEntries.TabIndex = 4;
            this.dgwEntries.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgwEntries_CellBeginEdit);
            this.dgwEntries.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dgwEntries.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_EditingControlShowing);
            this.dgwEntries.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgwEntries_RowsRemoved);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MaxInputLength = 2;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ID.Width = 30;
            // 
            // Float
            // 
            this.Float.HeaderText = "??";
            this.Float.Name = "Float";
            this.Float.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Float.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Float.Width = 70;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "??";
            this.Column1.MaxInputLength = 8;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 65;
            // 
            // cmsDelete
            // 
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // BLMAPEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 262);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "BLMAPEditor";
            this.Text = "BLMAP Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BLMAPEditor_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEntries)).EndInit();
            this.cmsDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveBLMAP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bBLMToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bDOFToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bFGToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bLIGHTToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bLMAPToolStripMenuItem1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgwEntries;
        private LTEXComponent ltexComponent1;
        private LMAPComponent lmapComponent1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lTEXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lTEXEntryToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Float;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightTextureToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsDelete;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}