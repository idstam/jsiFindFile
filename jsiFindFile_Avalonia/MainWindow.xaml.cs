using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using jsiFindFile;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

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
        private readonly TextBox _searchingLabel;
        private readonly CheckBox _subFoldersCheckBox;
        private readonly CheckBox _usePreviousCheckBox;
        private readonly CheckBox _includeFileNamesCheckbox;
        private readonly Button _searchButton;
        private readonly ObservableCollection<FileResult> _fileResults;
        private readonly ObservableCollection<LineResult> _lineResults;


        public ObservableCollection<FileResult> FileResults => _fileResults;
        public ObservableCollection<LineResult> LineResults => _lineResults;
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
            _searchingLabel = this.FindControl<TextBox>("searchingLabel");

            _subFoldersCheckBox = this.FindControl<CheckBox>("subFoldersCheckBox");
            _usePreviousCheckBox = this.FindControl<CheckBox>("usePreviousCheckBox");
            _includeFileNamesCheckbox = this.FindControl<CheckBox>("includeFileNamesCheckbox");


            _searchButton = this.FindControl<Button>("btnSearch");
            _searchButton.Click += btnSearch_OnClick;



            _fileResults = new ObservableCollection<FileResult>();
            _lineResults = new ObservableCollection<LineResult>();

            this.DataContext = this;

            LoadSearchSettings();
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


            _includeFilters = _includeCombo.Text?.ToUpperInvariant().Split('|');
            _excludeFilters = _excludeCombo.Text?.ToUpperInvariant().Split('|');

            _currentSearch = new SearchManager(_includeFilters, _excludeFilters, _needleCombo.Text, _subFoldersCheckBox.IsChecked ?? false, _includeFileNamesCheckbox.IsChecked ?? false);
            _currentSearch.FoundMatch += Search_FoundMatch;
            _currentSearch.SearchingFolder += Search_SearchingFolder;
            object haystack;

            if (_usePreviousCheckBox.IsChecked ?? false)
            {
                haystack = GetOldFileList();
            }
            else
            {
                haystack = _rootFolderCombo.Text;
            }
            FileResults.Clear();
            LineResults.Clear();
            //_filesGrid.Items = new List<FileResult>();
            //_linesGrid.Items = new List<LineResult>();

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

            foreach (FileResult item in FileResults)
            {
                result.Add(Path.Combine(item.Path, item.Name));
            }
            return result;
        }
        private void Search_SearchingFolder(object sender, EventArgs e)
        {
            var f = (e as SearchingFolderEventArgs)?.Folder;
            if (!string.IsNullOrEmpty(f))
            {
                //searchingLabel.Invoke((MethodInvoker)(() => searchingLabel.Text = f));
                //Application.DoEvents();
                _searchingLabel.Text = f;


            }
        }
        private void Search_FoundMatch(object sender, EventArgs m)
        {
            //if (_searching) this.Cursor = Avalonia.Input.Wa//Cursors.WaitCursor;

            //Application.DoEvents();

            Match match = (m as MatchEventArgs)?.Match;
            if (match != null)
            {
                var fileItem = new FileResult();
                fileItem.Name = match.FileName;
                fileItem.Matches = match.MatchLines.Count.ToString();
                fileItem.Path = match.FilePath;
                //fileItem.ToolTipText = match.ToToolTipString();

                FileResults.Add(fileItem);
                //tabFiles.Invoke((MethodInvoker)(() => tabFiles.Text = $"Files ({lstResults.Items.Count})"));


                foreach (var line in match.MatchLines)
                {
                    var lineItem = new LineResult();
                    lineItem.Name = match.FileName;
                    lineItem.Line = line.LineNumber.ToString();
                    lineItem.Text = line.Line;
                    lineItem.Path = match.FilePath;
                    LineResults.Add(lineItem);
                    //tabLines.Invoke((MethodInvoker)(() => tabLines.Text = $"Lines ({lstLines.Items.Count})"));
                }
            }


        }


        private void LoadSearchSettings()
        {
            _needleCombo.Text = _settings.LastNeedle;
            //needleCombo.Items.Clear();
            //needleCombo.Items.AddRange(_settings.Needles);

            _rootFolderCombo.Text = _settings.LastSearchRoot;
            //rootFolderCombo.Items.Clear();
            //rootFolderCombo.Items.AddRange(_settings.SearchRoots);

            //includeCombo.Items.Clear();
            //includeCombo.Items.AddRange(_settings.IncludeFilters);
            _includeCombo.Text = _settings.LastIncludeFilter;

            _excludeCombo.Text = _settings.ExcludeFilter;
        }
        private void SaveSearchSettings()
        {
            _settings.LastNeedle = _needleCombo.Text;
            _settings.LastSearchRoot = _rootFolderCombo.Text;
            _settings.LastIncludeFilter = _includeCombo.Text;
            _settings.ExcludeFilter = _excludeCombo.Text;
            _settings.Save();
        }
        private void ToggleSearchState(bool searching)
        {
            _searching = searching;

            if (searching)
            {
                //this.Cursor = Cursors.WaitCursor;
                _searchButton.Content = "Stop";
                _searchingLabel.Text = "...";
            }
            else
            {
                //this.Cursor = Cursors.Default;
                _searchButton.Content = "Search";
                _currentSearch.Stop();
            }


        }
    }
}
