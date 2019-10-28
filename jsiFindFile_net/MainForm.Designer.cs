namespace jsiFindFile
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
            this.openFolderButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.needlePopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearNeedleHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.includePopUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearIncludeHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.tabLines = new System.Windows.Forms.TabPage();
            this.lstLines = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.subFoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.includeCombo = new System.Windows.Forms.ComboBox();
            this.needleCombo = new System.Windows.Forms.ComboBox();
            this.rootFolderCombo = new System.Windows.Forms.ComboBox();
            this.includeFileNamesCheckbox = new System.Windows.Forms.CheckBox();
            this.needlePopUp.SuspendLayout();
            this.resultPopUp.SuspendLayout();
            this.includePopUp.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tabLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Searching:";
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
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search for:";
            this.toolTip1.SetToolTip(this.label2, "There\'s a context menue here. Try to right click.");
            // 
            // needlePopUp
            // 
            this.needlePopUp.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.needlePopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearNeedleHistoryToolStripMenuItem});
            this.needlePopUp.Name = "needlePopUp";
            this.needlePopUp.Size = new System.Drawing.Size(186, 34);
            // 
            // clearNeedleHistoryToolStripMenuItem
            // 
            this.clearNeedleHistoryToolStripMenuItem.Name = "clearNeedleHistoryToolStripMenuItem";
            this.clearNeedleHistoryToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.clearNeedleHistoryToolStripMenuItem.Text = "Clear History";
            this.clearNeedleHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearNeedleHistoryToolStripMenuItem_Click);
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
            this.lstResults.Size = new System.Drawing.Size(955, 224);
            this.lstResults.TabIndex = 5;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            this.lstResults.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstResults_KeyUp);
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
            this.resultPopUp.Size = new System.Drawing.Size(275, 154);
            this.resultPopUp.Opening += new System.ComponentModel.CancelEventHandler(this.resultPopUp_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // openContainingFolderToolStripMenuItem
            // 
            this.openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
            this.openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.openContainingFolderToolStripMenuItem.Text = "Open Containing Folder";
            this.openContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.openContainingFolderToolStripMenuItem_Click);
            // 
            // copyFullPathToolStripMenuItem
            // 
            this.copyFullPathToolStripMenuItem.Name = "copyFullPathToolStripMenuItem";
            this.copyFullPathToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.copyFullPathToolStripMenuItem.Text = "Copy Full Path";
            this.copyFullPathToolStripMenuItem.Click += new System.EventHandler(this.copyFullPathToolStripMenuItem_Click);
            // 
            // copyFilenameToolStripMenuItem
            // 
            this.copyFilenameToolStripMenuItem.Name = "copyFilenameToolStripMenuItem";
            this.copyFilenameToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
            this.copyFilenameToolStripMenuItem.Text = "Copy Filename";
            this.copyFilenameToolStripMenuItem.Click += new System.EventHandler(this.copyFilenameToolStripMenuItem_Click);
            // 
            // copyFileResultToolStripMenuItem
            // 
            this.copyFileResultToolStripMenuItem.Name = "copyFileResultToolStripMenuItem";
            this.copyFileResultToolStripMenuItem.Size = new System.Drawing.Size(274, 30);
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
            this.searchButton.TabIndex = 13;
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
            this.usePreviousCheckBox.Size = new System.Drawing.Size(331, 29);
            this.usePreviousCheckBox.TabIndex = 10;
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
            this.searchingLabel.TabIndex = 12;
            this.searchingLabel.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search in:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ContextMenuStrip = this.includePopUp;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Include filetypes:";
            this.toolTip1.SetToolTip(this.label4, "Pipe separated list of file types to include in the search. Example: *.bas|*.vb|*" +
        ".frm|*.cls|*.cs|*.sql");
            // 
            // includePopUp
            // 
            this.includePopUp.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.includePopUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearIncludeHistoryToolStripMenuItem});
            this.includePopUp.Name = "needlePopUp";
            this.includePopUp.Size = new System.Drawing.Size(186, 34);
            // 
            // clearIncludeHistoryToolStripMenuItem
            // 
            this.clearIncludeHistoryToolStripMenuItem.Name = "clearIncludeHistoryToolStripMenuItem";
            this.clearIncludeHistoryToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.clearIncludeHistoryToolStripMenuItem.Text = "Clear History";
            this.clearIncludeHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearIncludeHistoryToolStripMenuItem_Click);
            // 
            // excludeTextBox
            // 
            this.excludeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excludeTextBox.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excludeTextBox.Location = new System.Drawing.Point(114, 112);
            this.excludeTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excludeTextBox.Name = "excludeTextBox";
            this.excludeTextBox.Size = new System.Drawing.Size(819, 32);
            this.excludeTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 7;
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
            this.tabFiles.Location = new System.Drawing.Point(4, 33);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(961, 230);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.Text = "Files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // tabLines
            // 
            this.tabLines.Controls.Add(this.lstLines);
            this.tabLines.Location = new System.Drawing.Point(4, 29);
            this.tabLines.Name = "tabLines";
            this.tabLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabLines.Size = new System.Drawing.Size(961, 234);
            this.tabLines.TabIndex = 1;
            this.tabLines.Text = "Lines";
            this.tabLines.UseVisualStyleBackColor = true;
            // 
            // lstLines
            // 
            this.lstLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lstLines.ContextMenuStrip = this.resultPopUp;
            this.lstLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLines.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLines.FullRowSelect = true;
            this.lstLines.Location = new System.Drawing.Point(3, 3);
            this.lstLines.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstLines.Name = "lstLines";
            this.lstLines.ShowItemToolTips = true;
            this.lstLines.Size = new System.Drawing.Size(955, 228);
            this.lstLines.TabIndex = 6;
            this.lstLines.UseCompatibleStateImageBehavior = false;
            this.lstLines.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Line";
            this.columnHeader2.Width = 52;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Text";
            this.columnHeader4.Width = 618;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Path";
            this.columnHeader3.Width = 100;
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
            this.subFoldersCheckBox.Size = new System.Drawing.Size(236, 29);
            this.subFoldersCheckBox.TabIndex = 9;
            this.subFoldersCheckBox.Text = "Search in sub folders";
            this.subFoldersCheckBox.UseVisualStyleBackColor = true;
            // 
            // includeCombo
            // 
            this.includeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.includeCombo.FormattingEnabled = true;
            this.includeCombo.Location = new System.Drawing.Point(114, 78);
            this.includeCombo.Name = "includeCombo";
            this.includeCombo.Size = new System.Drawing.Size(819, 32);
            this.includeCombo.TabIndex = 6;
            // 
            // needleCombo
            // 
            this.needleCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.needleCombo.FormattingEnabled = true;
            this.needleCombo.Location = new System.Drawing.Point(114, 43);
            this.needleCombo.Name = "needleCombo";
            this.needleCombo.Size = new System.Drawing.Size(819, 32);
            this.needleCombo.TabIndex = 4;
            // 
            // rootFolderCombo
            // 
            this.rootFolderCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootFolderCombo.FormattingEnabled = true;
            this.rootFolderCombo.Location = new System.Drawing.Point(114, 10);
            this.rootFolderCombo.Name = "rootFolderCombo";
            this.rootFolderCombo.Size = new System.Drawing.Size(819, 32);
            this.rootFolderCombo.TabIndex = 15;
            // 
            // includeFileNamesCheckbox
            // 
            this.includeFileNamesCheckbox.AutoSize = true;
            this.includeFileNamesCheckbox.Checked = true;
            this.includeFileNamesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.includeFileNamesCheckbox.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.includeFileNamesCheckbox.Location = new System.Drawing.Point(493, 144);
            this.includeFileNamesCheckbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.includeFileNamesCheckbox.Name = "includeFileNamesCheckbox";
            this.includeFileNamesCheckbox.Size = new System.Drawing.Size(211, 29);
            this.includeFileNamesCheckbox.TabIndex = 16;
            this.includeFileNamesCheckbox.Text = "Include file names";
            this.includeFileNamesCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 483);
            this.Controls.Add(this.includeFileNamesCheckbox);
            this.Controls.Add(this.rootFolderCombo);
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
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "jsiFindFile";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.needlePopUp.ResumeLayout(false);
            this.resultPopUp.ResumeLayout(false);
            this.includePopUp.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.tabLines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.ListView lstLines;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox rootFolderCombo;
        private System.Windows.Forms.CheckBox includeFileNamesCheckbox;
    }
}

