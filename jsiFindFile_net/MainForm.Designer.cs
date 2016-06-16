namespace jsiGrepWinForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.rootFolderTextBox = new System.Windows.Forms.TextBox();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.matchesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resultPopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFullPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFileResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchButton = new System.Windows.Forms.Button();
            this.usePreviousCheckBox = new System.Windows.Forms.CheckBox();
            this.searchingLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.excludeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.tabLines = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.subFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.includeCombo = new System.Windows.Forms.ComboBox();
            this.needleCombo = new System.Windows.Forms.ComboBox();
            this.needlePopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearNeedleHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includePopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearIncludeHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultPopUp.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.needlePopUp.SuspendLayout();
            this.includePopUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searching:";
            // 
            // rootFolderTextBox
            // 
            this.rootFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootFolderTextBox.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootFolderTextBox.Location = new System.Drawing.Point(114, 8);
            this.rootFolderTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rootFolderTextBox.Name = "rootFolderTextBox";
            this.rootFolderTextBox.Size = new System.Drawing.Size(819, 24);
            this.rootFolderTextBox.TabIndex = 1;
            // 
            // openFolderButton
            // 
            this.openFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFolderButton.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFolderButton.Location = new System.Drawing.Point(939, 6);
            this.openFolderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(34, 31);
            this.openFolderButton.TabIndex = 2;
            this.openFolderButton.Text = "...";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ContextMenuStrip = this.needlePopUp;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search for:";
            // 
            // lstResults
            // 
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.matchesColumnHeader,
            this.pathColumnHeader});
            this.lstResults.ContextMenuStrip = this.resultPopUp;
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FullRowSelect = true;
            this.lstResults.Location = new System.Drawing.Point(3, 3);
            this.lstResults.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstResults.Name = "lstResults";
            this.lstResults.ShowItemToolTips = true;
            this.lstResults.Size = new System.Drawing.Size(955, 231);
            this.lstResults.TabIndex = 5;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 148;
            // 
            // matchesColumnHeader
            // 
            this.matchesColumnHeader.Text = "Matches";
            this.matchesColumnHeader.Width = 80;
            // 
            // pathColumnHeader
            // 
            this.pathColumnHeader.Text = "Path";
            this.pathColumnHeader.Width = 677;
            // 
            // resultPopUp
            // 
            this.resultPopUp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resultPopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.openContainingFolderToolStripMenuItem,
            this.copyFullPathToolStripMenuItem,
            this.copyFilenameToolStripMenuItem,
            this.copyFileResultToolStripMenuItem});
            this.resultPopUp.Name = "resultPopUp";
            this.resultPopUp.Size = new System.Drawing.Size(202, 114);
            this.resultPopUp.Opening += new System.ComponentModel.CancelEventHandler(this.resultPopUp_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // openContainingFolderToolStripMenuItem
            // 
            this.openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
            this.openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openContainingFolderToolStripMenuItem.Text = "Open Containing Folder";
            this.openContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.openContainingFolderToolStripMenuItem_Click);
            // 
            // copyFullPathToolStripMenuItem
            // 
            this.copyFullPathToolStripMenuItem.Name = "copyFullPathToolStripMenuItem";
            this.copyFullPathToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyFullPathToolStripMenuItem.Text = "Copy Full Path";
            this.copyFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem_Click);
            // 
            // copyFilenameToolStripMenuItem
            // 
            this.copyFilenameToolStripMenuItem.Name = "copyFilenameToolStripMenuItem";
            this.copyFilenameToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyFilenameToolStripMenuItem.Text = "Copy Filename";
            this.copyFilenameToolStripMenuItem.Click += new System.EventHandler(this.copyFilenameToolStripMenuItem_Click);
            // 
            // copyFileResultToolStripMenuItem
            // 
            this.copyFileResultToolStripMenuItem.Name = "copyFileResultToolStripMenuItem";
            this.copyFileResultToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyFileResultToolStripMenuItem.Text = "Copy All";
            this.copyFileResultToolStripMenuItem.Click += new System.EventHandler(this.copyFileResultToolStripMenuItem_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(890, 180);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(83, 31);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // usePreviousCheckBox
            // 
            this.usePreviousCheckBox.AutoSize = true;
            this.usePreviousCheckBox.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usePreviousCheckBox.Location = new System.Drawing.Point(273, 144);
            this.usePreviousCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usePreviousCheckBox.Name = "usePreviousCheckBox";
            this.usePreviousCheckBox.Size = new System.Drawing.Size(214, 21);
            this.usePreviousCheckBox.TabIndex = 7;
            this.usePreviousCheckBox.Text = "Search in previously found files";
            this.usePreviousCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchingLabel
            // 
            this.searchingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchingLabel.AutoEllipsis = true;
            this.searchingLabel.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchingLabel.Location = new System.Drawing.Point(90, 187);
            this.searchingLabel.Name = "searchingLabel";
            this.searchingLabel.Size = new System.Drawing.Size(794, 18);
            this.searchingLabel.TabIndex = 8;
            this.searchingLabel.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search in:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ContextMenuStrip = this.includePopUp;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Include filetypes:";
            this.toolTip1.SetToolTip(this.label4, "Pipe separated list of file types to include in the search. Example: *.bas|*.vb|*" +
        ".frm|*.cls|*.cs|*.sql");
            // 
            // excludeTextBox
            // 
            this.excludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excludeTextBox.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excludeTextBox.Location = new System.Drawing.Point(114, 109);
            this.excludeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excludeTextBox.Name = "excludeTextBox";
            this.excludeTextBox.Size = new System.Drawing.Size(819, 24);
            this.excludeTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Exclude folders:";
            this.toolTip1.SetToolTip(this.label5, "Pipe separated list of folders to ignore while searching. Example .git|bin|obj");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabFiles);
            this.tabControl1.Controls.Add(this.tabLines);
            this.tabControl1.Location = new System.Drawing.Point(4, 212);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 267);
            this.tabControl1.TabIndex = 14;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.lstResults);
            this.tabFiles.Location = new System.Drawing.Point(4, 26);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(961, 237);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.Text = "Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // tabLines
            // 
            this.tabLines.Location = new System.Drawing.Point(4, 26);
            this.tabLines.Name = "tabLines";
            this.tabLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabLines.Size = new System.Drawing.Size(961, 237);
            this.tabLines.TabIndex = 1;
            this.tabLines.Text = "Lines";
            this.tabLines.UseVisualStyleBackColor = true;
            // 
            // subFoldersCheckBox
            // 
            this.subFoldersCheckBox.AutoSize = true;
            this.subFoldersCheckBox.Checked = true;
            this.subFoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.subFoldersCheckBox.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subFoldersCheckBox.Location = new System.Drawing.Point(114, 144);
            this.subFoldersCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subFoldersCheckBox.Name = "subFoldersCheckBox";
            this.subFoldersCheckBox.Size = new System.Drawing.Size(153, 21);
            this.subFoldersCheckBox.TabIndex = 15;
            this.subFoldersCheckBox.Text = "Search in sub folders";
            this.subFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeCombo
            // 
            this.includeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.includeCombo.FormattingEnabled = true;
            this.includeCombo.Location = new System.Drawing.Point(114, 75);
            this.includeCombo.Name = "includeCombo";
            this.includeCombo.Size = new System.Drawing.Size(819, 25);
            this.includeCombo.TabIndex = 16;
            // 
            // needleCombo
            // 
            this.needleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.needleCombo.FormattingEnabled = true;
            this.needleCombo.Location = new System.Drawing.Point(114, 41);
            this.needleCombo.Name = "needleCombo";
            this.needleCombo.Size = new System.Drawing.Size(819, 25);
            this.needleCombo.TabIndex = 17;
            // 
            // needlePopUp
            // 
            this.needlePopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearNeedleHistoryToolStripMenuItem});
            this.needlePopUp.Name = "needlePopUp";
            this.needlePopUp.Size = new System.Drawing.Size(143, 26);
            // 
            // clearNeedleHistoryToolStripMenuItem
            // 
            this.clearNeedleHistoryToolStripMenuItem.Name = "clearNeedleHistoryToolStripMenuItem";
            this.clearNeedleHistoryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearNeedleHistoryToolStripMenuItem.Text = "Clear History";
            this.clearNeedleHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearNeedleHistoryToolStripMenuItem_Click);
            // 
            // includePopUp
            // 
            this.includePopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearIncludeHistoryToolStripMenuItem});
            this.includePopUp.Name = "needlePopUp";
            this.includePopUp.Size = new System.Drawing.Size(143, 26);
            // 
            // clearIncludeHistoryToolStripMenuItem
            // 
            this.clearIncludeHistoryToolStripMenuItem.Name = "clearIncludeHistoryToolStripMenuItem";
            this.clearIncludeHistoryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearIncludeHistoryToolStripMenuItem.Text = "Clear History";
            this.clearIncludeHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearIncludeHistoryToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 483);
            this.Controls.Add(this.needleCombo);
            this.Controls.Add(this.includeCombo);
            this.Controls.Add(this.subFoldersCheckBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.excludeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchingLabel);
            this.Controls.Add(this.usePreviousCheckBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.rootFolderTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "jsiGrep";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.resultPopUp.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.needlePopUp.ResumeLayout(false);
            this.includePopUp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rootFolderTextBox;
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstResults;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader matchesColumnHeader;
        private System.Windows.Forms.ColumnHeader pathColumnHeader;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.CheckBox usePreviousCheckBox;
        private System.Windows.Forms.Label searchingLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox excludeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip resultPopUp;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openContainingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFullPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilenameToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.TabPage tabLines;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox subFoldersCheckBox;
        private System.Windows.Forms.ToolStripMenuItem copyFileResultToolStripMenuItem;
        private System.Windows.Forms.ComboBox includeCombo;
        private System.Windows.Forms.ComboBox needleCombo;
        private System.Windows.Forms.ContextMenuStrip needlePopUp;
        private System.Windows.Forms.ToolStripMenuItem clearNeedleHistoryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip includePopUp;
        private System.Windows.Forms.ToolStripMenuItem clearIncludeHistoryToolStripMenuItem;
    }
}

