using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace cm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
            var index = listData.SelectedIndex;
            listData.Items.Clear();
            files.ForEach(x => listData.Items.Add(x));
            if (index < listData.Items.Count)
                listData.SelectedIndex = index;
        }

        public void Select(int index)
        {
            listData.SelectedIndex = index;
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

        public string RequestTarget(string dir)
        {
            var dialog = new SaveFileDialog
            {
                Filter = @"Файлы tex|*.tex",
                InitialDirectory = dir,
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
            FilesRemoving?.Invoke(this, listData.SelectedIndex);
        }

        private void UpClick(object sender, EventArgs e)
        {
            FileUp?.Invoke(this, listData.SelectedIndex);
        }

        private void DownClick(object sender, EventArgs e)
        {
            FileDown?.Invoke(this, listData.SelectedIndex);
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
            //TODO buttons.enable = false
            _build.Enabled = false;

            Building?.Invoke(this, null);
        }

        public void ReleaseButtons()
        {
            //TODO buttons.enable = true
            _build.Enabled = true;
        }
    }
}
