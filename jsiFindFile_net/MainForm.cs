using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using jsiFindFile;

namespace jsiGrepWinForm
{
    public partial class MainForm : Form
    {
        //private string _textEditorPath = @"C:\Program Files\Sublime Text 3\sublime_text.exe";

        private string[] _includeFilters;
        private string[] _excludeFilters;
        private bool _stop = false;
        private bool _searching = false;
        private SearchManager _currentSearch = null;
        private Settings _settings = new Settings();
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

            _currentSearch = new SearchManager(_includeFilters, _excludeFilters, needleTextBox.Text, subFoldersCheckBox.Checked);
            _currentSearch.FoundMatch += Search_FoundMatch;
            _currentSearch.SearchingFolder += Search_SearchingFolder;
            object haystack;
            var matches = new List<Match>();
            if (usePreviousCheckBox.Checked)
            {
                haystack = GetOldFileList();
            }
            else
            {
                haystack = rootFolderTextBox.Text;
            }
            lstResults.Items.Clear();
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
            Match match = (m as MatchEventArgs)?.Match;
            if (match != null)
            {
                var fileItem = new ListViewItem();
                fileItem.Text = match.FileName;
                fileItem.SubItems.Add(match.MatchLines.Count.ToString());
                fileItem.SubItems.Add(match.FilePath);
                fileItem.ToolTipText = match.ToToolTipString();
                lstResults.Invoke((MethodInvoker) (() => lstResults.Items.Add(fileItem)));
                Application.DoEvents();
                
            }
            

        }
        
        private void SaveSearchSettings()
        {
            _settings.Needle = needleTextBox.Text;
            _settings.SearchRoot = rootFolderTextBox.Text;
            _settings.IncludeFilter = includeTextBox.Text;
            _settings.ExcludeFilter = excludeTextBox.Text;
            _settings.Save();
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
                _currentSearch.Stop();
            }

            
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


        private void StopButton_Click(object sender, EventArgs e)
        {
            _stop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "jsiFindFile " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor;
            LoadSearchSettings();

        }

        private void LoadSearchSettings()
        {
            needleTextBox.Text = _settings.Needle;
            rootFolderTextBox.Text = _settings.SearchRoot;
            includeTextBox.Text = _settings.IncludeFilter;
            excludeTextBox.Text = _settings.ExcludeFilter;
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
