﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace jsiFindFile
{
    public partial class MainForm : Form
    {
        //private string _textEditorPath = @"C:\Program Files\Sublime Text 3\sublime_text.exe";

        private string[] _includeFilters;
        private string[] _excludeFilters;
        private string[] _droppedFiles;
        private bool _searching;
        private SearchManager _currentSearch;
        private readonly Settings _settings = new Settings();
        public MainForm()
        {
            InitializeComponent();
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            rootFolderCombo.Text = folderBrowserDialog1.SelectedPath;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (_searching)
            {
                ToggleSearchState(false);
                return;
            }

            ToggleSearchState(true);

            SaveSearchSettings();


            _includeFilters = includeCombo.Text.ToUpperInvariant().Split('|');
            _excludeFilters = excludeTextBox.Text.ToUpperInvariant().Split('|');

            _currentSearch = new SearchManager(_includeFilters, _excludeFilters, needleCombo.Text, subFoldersCheckBox.Checked, includeFileNamesCheckbox.Checked);
            _currentSearch.FoundMatch += Search_FoundMatch;
            _currentSearch.SearchingFolder += Search_SearchingFolder;
            object haystack;

            if (usePreviousCheckBox.Checked)
            {
                haystack = GetOldFileList();
            }
            else
            {
                haystack = rootFolderCombo.Text;
            }
            lstResults.Items.Clear();
            lstLines.Items.Clear();
            _currentSearch.Search(haystack);
            
            ToggleSearchState(false);
        }

        private void Search_SearchingFolder(object sender, EventArgs e)
        {
            var f = (e as SearchingFolderEventArgs)?.Folder;
            if (!string.IsNullOrEmpty(f))
            {
                searchingLabel.Invoke((MethodInvoker) (() => searchingLabel.Text = f));
                Application.DoEvents();
            }
        }

        private void Search_FoundMatch(object sender, EventArgs m)
        {
            if (_searching) this.Cursor = Cursors.WaitCursor;

            Application.DoEvents();

            Match match = (m as MatchEventArgs)?.Match;
            if (match != null)
            {
                var fileItem = new ListViewItem();
                fileItem.Text = match.FileName;
                fileItem.SubItems.Add(match.MatchLines.Count.ToString());
                fileItem.SubItems.Add(match.FilePath);
                fileItem.ToolTipText = match.ToToolTipString();
                lstResults.Invoke((MethodInvoker) (() => lstResults.Items.Add(fileItem)));
                tabFiles.Invoke((MethodInvoker) (() => tabFiles.Text = $"Files ({lstResults.Items.Count})"));
                

                foreach (var line in match.MatchLines)
                {
                    var lineItem = new ListViewItem();
                    lineItem.Text = match.FileName;
                    lineItem.SubItems.Add(line.LineNumber.ToString());
                    lineItem.SubItems.Add(line.Line);
                    lineItem.SubItems.Add(match.FilePath);
                    lstLines.Invoke((MethodInvoker)(() => lstLines.Items.Add(lineItem)));
                    tabLines.Invoke((MethodInvoker) (() => tabLines.Text = $"Lines ({lstLines.Items.Count})"));
                }
            }
            

        }
        
        private void SaveSearchSettings()
        {
            _settings.LastNeedle = needleCombo.Text;
            _settings.LastSearchRoot = rootFolderCombo.Text;
            _settings.LastIncludeFilter = includeCombo.Text;
            _settings.ExcludeFilter = excludeTextBox.Text;
            _settings.Save();
        }

        private void ToggleSearchState(bool searching)
        {
            _searching = searching;

            if (searching)
            {
                this.Cursor = Cursors.WaitCursor;
                searchButton.Text = "Stop";
                searchingLabel.Text = "...";
            }
            else
            {
                this.Cursor = Cursors.Default;
                searchButton.Text = "Search";
                _currentSearch.Stop();
            }

            
        }

        private List<string> GetOldFileList()
        {
            var result = new List<string>();
            if (_droppedFiles != null)
            {
                return _droppedFiles.ToList();
            }

            foreach (ListViewItem item in lstResults.Items)
            {
                result.Add(Path.Combine(item.SubItems[2].Text, item.SubItems[0].Text));
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = $@"jsiFindFile {Assembly.GetExecutingAssembly().GetName().Version.Major }.{Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString().PadLeft(2, '0')}";
            LoadSearchSettings();

        }

        private void LoadSearchSettings()
        {
            needleCombo.Text = _settings.LastNeedle;
            needleCombo.Items.Clear();
            needleCombo.Items.AddRange(_settings.Needles);

            rootFolderCombo.Text = _settings.LastSearchRoot;
            rootFolderCombo.Items.Clear();
            rootFolderCombo.Items.AddRange(_settings.SearchRoots);

            includeCombo.Items.Clear();
            includeCombo.Items.AddRange(_settings.IncludeFilters);
            includeCombo.Text = _settings.LastIncludeFilter;

            excludeTextBox.Text = _settings.ExcludeFilter;
        }

        private void resultPopUp_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lvw = tabControl1.SelectedTab == tabFiles ? lstResults : lstLines;
            var editorPath = jsiFindFile.Properties.Settings.Default.textEditor;
            if (!File.Exists(editorPath))
            {
                openFileDialog1.Title = "Select your prefered text editor.";
                openFileDialog1.ShowDialog();
                editorPath = openFileDialog1.FileName;
                jsiFindFile.Properties.Settings.Default.textEditor = editorPath;
                jsiFindFile.Properties.Settings.Default.Save();
            }
            if (lvw.SelectedItems.Count > 0)
            {
                var item = lvw.SelectedItems[0];
                var fullPath = Path.Combine(item.SubItems[item.SubItems.Count -1].Text, item.SubItems[0].Text);
                Process.Start(editorPath, "\"" + fullPath + "\"");
            }
        }

        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lvw = tabControl1.SelectedTab == tabFiles ? lstResults : lstLines;
            if (lvw.SelectedItems.Count > 0)
            {
                var item = lvw.SelectedItems[0];
                
                Process.Start("explorer.exe", "\"" + item.SubItems[item.SubItems.Count-1].Text + "\"");
            }

        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lvw = tabControl1.SelectedTab == tabFiles ? lstResults : lstLines;
            if (lvw.SelectedItems.Count > 0)
            {
                var item = lvw.SelectedItems[0];
                var fullPath = Path.Combine(item.SubItems[item.SubItems.Count-1].Text, item.SubItems[0].Text);
                Clipboard.SetText(fullPath);
            }
        }

        private void copyFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lvw = tabControl1.SelectedTab == tabFiles ? lstResults : lstLines;
            if (lvw.SelectedItems.Count > 0)
            {
                var item = lvw.SelectedItems[0];
                Clipboard.SetText(item.SubItems[0].Text);
            }

        }

        private void copyFileResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            if(tabControl1.SelectedTab == tabFiles)
            {  
                foreach (ListViewItem item in lstResults.Items)
                {
                    sb.AppendLine($"{item.SubItems[2].Text}{Path.DirectorySeparatorChar}{item.SubItems[0].Text}"); 
                }
            }
            else
            {
                foreach (ListViewItem item in lstLines.Items)
                {
                    sb.AppendLine($"{item.SubItems[3].Text}{Path.DirectorySeparatorChar}{item.SubItems[0].Text}\t({item.SubItems[1].Text})\t{item.SubItems[2].Text}");
                }
            }
            Clipboard.SetText(sb.ToString());
        }

        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.Any(c => c > MaxAnsiCode);
        }
        private void clearIncludeHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ClearIncludeHistory();
            LoadSearchSettings();
        }

        private void clearNeedleHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ClearNeedleHistory();
            LoadSearchSettings();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            _droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            usePreviousCheckBox.Checked = true;
            searchButton_Click(null, null);
            _droppedFiles = null;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lstResults_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                editToolStripMenuItem_Click(sender, null);
            }
        }

    }
}
