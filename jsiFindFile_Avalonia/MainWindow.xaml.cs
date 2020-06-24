using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using jsiFindFile;
using System;

namespace jsiFindFile_Avalonia
{
    public class MainWindow : Window
    {
        private string[] _includeFilters;
        private string[] _excludeFilters;
        private string[] _droppedFiles;
        private bool _searching;
        private SearchManager _currentSearch;
        private readonly Settings _settings = new Settings();

        private readonly TextBox _rootFolderCombo;
        private readonly TextBox _needleCombo;
        private readonly TextBox _includeCombo;
        private readonly TextBox _excludeCombo;
        private readonly CheckBox _subFoldersCheckBox;
        private readonly CheckBox _usePreviousCheckBox;
        private readonly CheckBox _includeFileNamesCheckbox;
        private readonly Button _searchButton;
        private readonly DataGrid _filesGrid;
        private readonly DataGrid _linesGrid;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            _rootFolderCombo = this.FindControl<TextBox>("rootFolderCombo");
            _needleCombo = this.FindControl<TextBox>("needleCombo");
            _includeCombo = this.FindControl<TextBox>("includeCombo");
            _excludeCombo = this.FindControl<TextBox>("excludeCombo");

            _subFoldersCheckBox = this.FindControl<CheckBox>("subFoldersCheckBox");
            _usePreviousCheckBox = this.FindControl<CheckBox>("usePreviousCheckBox");
            _includeFileNamesCheckbox = this.FindControl<CheckBox>("includeFileNamesCheckbox");


            _searchButton = this.FindControl<Button>("btnSearch");
            _searchButton.Click += btnSearch_OnClick;


            _filesGrid = this.FindControl<DataGrid>("FilesGrid");
            _filesGrid.Columns.Add(new DataGridTextColumn() { Header = new DataGridColumnHeader() {Content="Name" } });
            _filesGrid.Columns.Add(new DataGridTextColumn() { Header = new DataGridColumnHeader() { Content = "Matches" } });
            _filesGrid.Columns.Add(new DataGridTextColumn() { Header = new DataGridColumnHeader() { Content = "Path" } });


            _linesGrid = this.FindControl<DataGrid>("LinesGrid");

        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            
        }

        private void btnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            if (_searching)
            {
                ToggleSearchState(false);
                return;
            }

            ToggleSearchState(true);

            SaveSearchSettings();


            _includeFilters = _includeCombo.Text.ToUpperInvariant().Split('|');
            _excludeFilters = _excludeCombo.Text.ToUpperInvariant().Split('|');

            _currentSearch = new SearchManager(_includeFilters, _excludeFilters, _needleCombo.Text, _subFoldersCheckBox.IsChecked??false, _includeFileNamesCheckbox.IsChecked??false);
            _currentSearch.FoundMatch += Search_FoundMatch;
            _currentSearch.SearchingFolder += Search_SearchingFolder;
            object haystack;

            if (_usePreviousCheckBox.IsChecked??false)
            {
                haystack = GetOldFileList();
            }
            else
            {
                haystack = _rootFolderCombo.Text;
            }
            lstResults.Items.Clear();
            lstLines.Items.Clear();
            _currentSearch.Search(haystack);

            ToggleSearchState(false);
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
        private void Search_SearchingFolder(object sender, EventArgs e)
        {
            var f = (e as SearchingFolderEventArgs)?.Folder;
            if (!string.IsNullOrEmpty(f))
            {
                searchingLabel.Invoke((MethodInvoker)(() => searchingLabel.Text = f));
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
                lstResults.Invoke((MethodInvoker)(() => lstResults.Items.Add(fileItem)));
                tabFiles.Invoke((MethodInvoker)(() => tabFiles.Text = $"Files ({lstResults.Items.Count})"));


                foreach (var line in match.MatchLines)
                {
                    var lineItem = new ListViewItem();
                    lineItem.Text = match.FileName;
                    lineItem.SubItems.Add(line.LineNumber.ToString());
                    lineItem.SubItems.Add(line.Line);
                    lineItem.SubItems.Add(match.FilePath);
                    lstLines.Invoke((MethodInvoker)(() => lstLines.Items.Add(lineItem)));
                    tabLines.Invoke((MethodInvoker)(() => tabLines.Text = $"Lines ({lstLines.Items.Count})"));
                }
            }


        }
        private void SaveSearchSettings()
        {
            _settings.LastNeedle = _needleCombo.Text;
            _settings.LastSearchRoot = _rootFolderCombo.Text;
            _settings.LastIncludeFilter = _includeCombo.Text;
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
    }
}
