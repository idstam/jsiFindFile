using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jsiGrepWinForm
{
    public partial class MainForm : Form
    {
        //private string _textEditorPath = @"C:\Program Files\Sublime Text 3\sublime_text.exe";

        private string[] _includeFilters;
        private string[] _excludeFilters;
        private bool _stop = false;
        private bool _searching = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            rootFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
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


            _includeFilters = includeTextBox.Text.ToUpperInvariant().Split('|');
            _excludeFilters = excludeTextBox.Text.ToUpperInvariant().Split('|');

            var fileList = usePreviousCheckBox.Checked ? GetOldFileList() : GetNewFileList();

            lstResults.Items.Clear();

            foreach (var f in fileList)
            {
                if (_stop) return;
                if (!IncludeFile(f)) continue;
                if (ExcludePathContaining(f)) continue;

                var matches = SearchFile(f);
                if (matches.Count > 0) AddMatches(f, matches);
            }
            ToggleSearchState(false);
        }

        private void SaveSearchSettings()
        {
            Properties.Settings.Default.lastNeedle = needleTextBox.Text;
            Properties.Settings.Default.lastRoot = rootFolderTextBox.Text;
            Properties.Settings.Default.lastInclude = includeTextBox.Text;
            Properties.Settings.Default.lastExclude = excludeTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void ToggleSearchState(bool searching)
        {
            _searching = searching;

            if (searching)
            {
                Cursor.Current = Cursors.WaitCursor;
                searchButton.Text = "Stop";
                _stop = false;
                searchingLabel.Text = "...";
            }
            else
            {
                Cursor.Current = Cursors.Default;
                searchButton.Text = "Search";
                _stop = true;
            }

            
        }

        private bool IncludeFile(string filename)
        {
            if (string.IsNullOrEmpty(includeTextBox.Text)) return true;

            foreach (var filter in _includeFilters)
            {
                if (filename.ToUpperInvariant().Like(filter)) return true;
            }
            return false;
        }

        private bool ExcludePathContaining(string filename)
        {
            if (string.IsNullOrEmpty(excludeTextBox.Text)) return false;

            foreach (var filter in _excludeFilters)
            {
                if (filename.ToUpperInvariant().Contains(filter))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddMatches(string fileName, List<string> matches)
        {
            var fileMatch = lstResults.Items.Add(Path.GetFileName(fileName));
            fileMatch.SubItems.Add(matches.Count().ToString());
            fileMatch.SubItems.Add(Path.GetDirectoryName(fileName));
            Application.DoEvents();

            foreach (var line in matches)
            {
                
            }

        }
        private List<string> GetNewFileList()
        {

            return Directory.GetFiles(rootFolderTextBox.Text, "*.*", SearchOption.AllDirectories).ToList();
        }

        private List<string> GetOldFileList()
        {
            var result = new List<string>();
            foreach (ListViewItem item in lstResults.Items)
            {
                result.Add(Path.Combine(item.SubItems[2].Text, item.SubItems[0].Text));
            }

            return result;
        }

        private List<string> SearchFile(string fileName)
        {
            var needle = needleTextBox.Text.ToUpperInvariant();
            searchingLabel.Text = fileName;
            Application.DoEvents();
            
            return File.ReadLines(fileName).Where(line => line.ToUpperInvariant().Contains(needle)).ToList();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _stop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSearchSettings();
        }

        private void LoadSearchSettings()
        {
            needleTextBox.Text = Properties.Settings.Default.lastNeedle;
            rootFolderTextBox.Text = Properties.Settings.Default.lastRoot;
            includeTextBox.Text = Properties.Settings.Default.lastInclude;
            excludeTextBox.Text = Properties.Settings.Default.lastExclude;
        }

        private void resultPopUp_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var editorPath = Properties.Settings.Default.textEditor;
            if (!File.Exists(editorPath))
            {
                openFileDialog1.Title = "Select your prefered text editor.";
                openFileDialog1.ShowDialog();
                editorPath = openFileDialog1.FileName;
                Properties.Settings.Default.textEditor = editorPath;
                Properties.Settings.Default.Save();
            }
            if (lstResults.SelectedItems.Count > 0)
            {
                var item = lstResults.SelectedItems[0];
                var fullPath = Path.Combine(item.SubItems[2].Text, item.SubItems[0].Text);
                Process.Start(editorPath, "\"" + fullPath + "\"");
            }
        }

        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItems.Count > 0)
            {
                var item = lstResults.SelectedItems[0];
                
                Process.Start("explorer.exe", "\"" + item.SubItems[2].Text + "\"");
            }

        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItems.Count > 0)
            {
                var item = lstResults.SelectedItems[0];
                var fullPath = Path.Combine(item.SubItems[2].Text, item.SubItems[0].Text);
                Clipboard.SetText(fullPath);
            }
        }

        private void copyFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItems.Count > 0)
            {
                var item = lstResults.SelectedItems[0];
                Clipboard.SetText(item.SubItems[0].Text);
            }

        }
    }
}
