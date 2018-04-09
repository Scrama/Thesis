﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _buttonUp.Enabled = false;
            _buttonDown.Enabled = false;
            _buttonRemove.Enabled = false;
            _buttonSort.Enabled = false;
            _build.Enabled = false;

            _listData.SelectedIndexChanged += (sender, args) => ValidateButtons();

            _header.TextChanged += (sender, args) => ValidateButtons();
            _target.TextChanged += (sender, args) => ValidateButtons();

            BindButtons();
        }

        private void BindButtons()
        {
            _buttonAdd.Click += AddClick;
            _buttonUp.Click += UpClick;
            _buttonDown.Click += DownClick;
            _buttonSort.Click += SortClick;
            _buttonRemove.Click += RemoveClick;
            _browseHeader.Click += HeaderBrowseClick;
            _browseTarget.Click += TargetBrowseClick;
            _build.Click += BuildClick;
        }

        private bool _building;

        private void ValidateButtons()
        {
            _buttonUp.Enabled = _listData.SelectedIndex > 0;
            _buttonDown.Enabled = _listData.SelectedIndex > -1 && _listData.SelectedIndex < _listData.Items.Count - 1;
            _buttonRemove.Enabled = _listData.SelectedIndex > -1 && _listData.SelectedIndex < _listData.Items.Count;
            _buttonSort.Enabled = _listData.Items.Count > 0;

            _build.Enabled = !_building
                             && !string.IsNullOrEmpty(_header.Text)
                             && !string.IsNullOrEmpty(_target.Text)
                             && _listData.Items.Count > 0;
        }

        private void AddClick(object sender, EventArgs e)
        {
            FilesAdding?.Invoke(this, null);
        }

        public event EventHandler FilesAdding;

        public event EventHandler<int> FilesRemoving;

        public event EventHandler<int> FileUp;

        public event EventHandler<int> FileDown;

        public event EventHandler HeaderBrowsing;

        public event EventHandler TargetBrowsing;

        public event EventHandler Building;

        public event EventHandler FilesSorting;

        public string[] GetFiles(string dir)
        {
            var dialog = new OpenFileDialog
            {
                Title = @"Укажите исходные файлы",
                Filter = @"Файлы tex|*.tex",
                InitialDirectory = dir,
                Multiselect = true,
                DefaultExt = ".tex"
            };
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileNames : null;
        }

        public void SetFiles(List<string> files)
        {
            var index = _listData.SelectedIndex;
            _listData.Items.Clear();
            files.ForEach(x => _listData.Items.Add(x));
            if (index < _listData.Items.Count)
                _listData.SelectedIndex = index;
            ValidateButtons();
        }

        public void Select(int index)
        {
            _listData.SelectedIndex = index;
        }

        public string RequestHeader(string dir)
        {
            var dialog = new OpenFileDialog
            {
                Filter = @"Файлы tex|*.tex",
                InitialDirectory = dir,
                DefaultExt = ".tex",
                CheckFileExists = true,
                Title = @"Укажите файл заголовка"
            };
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
        }

        public string Header
        {
            get => _header.Text;
            set => _header.Text = value;
        }

        public string RequestTarget(string dir, string filename)
        {
            var dialog = new SaveFileDialog
            {
                Filter = @"Файлы tex|*.tex",
                InitialDirectory = dir,
                FileName = filename,
                DefaultExt = ".tex",
                Title = @"Выберите результирующий файл"
            };
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
        }

        public string Target
        {
            get => _target.Text;
            set => _target.Text = value;
        }

        private void RemoveClick(object sender, EventArgs e)
        {
            FilesRemoving?.Invoke(this, _listData.SelectedIndex);
        }

        private void UpClick(object sender, EventArgs e)
        {
            FileUp?.Invoke(this, _listData.SelectedIndex);
        }

        private void DownClick(object sender, EventArgs e)
        {
            FileDown?.Invoke(this, _listData.SelectedIndex);
        }

        private void SortClick(object sender, EventArgs e)
        {
            FilesSorting?.Invoke(this, null);
        }

        private void HeaderBrowseClick(object sender, EventArgs e)
        {
            HeaderBrowsing?.Invoke(this, null);
        }

        private void TargetBrowseClick(object sender, EventArgs e)
        {
            TargetBrowsing?.Invoke(this, null);
        }

        private void BuildClick(object sender, EventArgs e)
        {
            _building = true;
            ValidateButtons();

            Building?.Invoke(this, null);
        }

        public void ReleaseButtons()
        {
            _building = false;
            ValidateButtons();
        }

        private void AboutClick(object sender, EventArgs e)
        {
            MessageBox.Show(this, @"Текст о программе", @"О программе");
        }
    }
}
