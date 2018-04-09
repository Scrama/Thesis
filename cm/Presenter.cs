using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cm
{
    internal class Presenter
    {
        private string _path;

        private readonly IView _view;

        private readonly Model _model = new Model();

        public Presenter(IView view)
        {
            _view = view;

            _view.FilesAdding += AddFiles;
            _view.FilesRemoving += RemoveFile;
            _view.FileUp += FileUp;
            _view.FileDown += FileDown;
            _view.FilesSorting += FilesSorting;
            _view.HeaderBrowsing += HeaderBrowsing;
            _view.TargetBrowsing += TargetBrowsing;
            _view.Building += StartBuilding;

            _view.Load += (sender, args) => LoadSettings();
            _view.Closed += (sender, args) => SaveSettings();
        }

        private void StartBuilding(object sender, EventArgs e)
        {
            //TODO check conditions
            // non-existing files etc
            var header = _view.Header;
            var target = _view.Target;

            Task.Factory
                .StartNew(() => _model.Build(header, target))
                .ContinueWith(success => _view.ReleaseButtons(success.Result, Log.Filename));
        }

        private void HeaderBrowsing(object sender, EventArgs e)
        {
            var header = _view.RequestHeader(_path);
            _view.Header = header;
            _path = Path.GetDirectoryName(header);
        }

        private void TargetBrowsing(object sender, EventArgs e)
        {
            var target = _view.RequestTarget(_path, _model.DefaultTarget);
            _view.Target = target;
            _path = Path.GetDirectoryName(target);
        }

        private void FilesSorting(object sender, EventArgs e)
        {
            _model.Sort();
            _view.SetFiles(_model.Files);
            _view.Select(-1);
        }

        private void FileDown(object sender, int index)
        {
            if (index < 0 || index > _model.Files.Count - 2)
                return;

            var item = _model.Files[index];
            _model.Files[index] = _model.Files[index + 1];
            _model.Files[index + 1] = item;

            _view.SetFiles(_model.Files);
            _view.Select(index + 1);
        }

        private void FileUp(object sender, int index)
        {
            if (index < 1 || index >= _model.Files.Count)
                return;

            var item = _model.Files[index];
            _model.Files[index] = _model.Files[index - 1];
            _model.Files[index - 1] = item;

            _view.SetFiles(_model.Files);
            _view.Select(index - 1);
        }

        private void RemoveFile(object sender, int index)
        {
            if (index < 0 || index >= _model.Files.Count)
                return;

            _model.Files.RemoveAt(index);
            _view.SetFiles(_model.Files);
        }

        private void AddFiles(object sender, EventArgs e)
        {
            var files = _view.GetFiles(_path);

            if (files == null || files.Length == 0)
                return;

            _path = Path.GetDirectoryName(files.Last());

            _model.Files.AddRange(files);

            _view.SetFiles(_model.Files);
        }

        #region . settings .

        private void LoadSettings()
        {
            _path = ConfigurationManager.AppSettings.Get(nameof(_path));
            _view.Header = ConfigurationManager.AppSettings.Get(nameof(_view.Header));
            _view.Target = ConfigurationManager.AppSettings.Get(nameof(_view.Target));
            var files = ConfigurationManager.AppSettings.Get(nameof(_model.Files));

            if (string.IsNullOrEmpty(_path))
                _path = Application.StartupPath;

            if (!string.IsNullOrEmpty(files))
            {
                _model.Files.AddRange(files.Split('*'));
                _view.SetFiles(_model.Files);
            }
        }

        public void SaveSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            settings
                .Set(nameof(_path), _path)
                .Set(nameof(_view.Header), _view.Header)
                .Set(nameof(_view.Target), _view.Target)
                .Set(nameof(_model.Files), string.Join("*", _model.Files));

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        #endregion
    }

    public static class SettingsExtension
    {
        public static KeyValueConfigurationCollection Set(this KeyValueConfigurationCollection settings, string name, string value)
        {
            if (settings[name] == null)
                settings.Add(name, value);
            else
                settings[name].Value = value;

            return settings;
        }
    }


}
