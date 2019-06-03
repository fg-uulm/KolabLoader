using System.ComponentModel;

namespace KolabLoader
{
    public class KolabSettingsContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string _nickname { get; set; }
        public string _institution { get; set; }
        public string _session { get; set; }
        public bool _useInviwoPositioning { get; set; }
        public bool _rttVisualization { get; set; }
        public bool _createRoomOnLoad { get; set; }
        public bool _autoJoinFirstRoomOnLoad { get; set; }
        public bool _externalRendererMode { get; set; }
        public string _projectPath { get; set; }
        public string _username { get; set; }
        public string _password { get; set; }
        public string _workspacesPath { get; set; }
        public string _inviwoPath { get; set; }
        public string _megamolPath { get; set; }
        public string[] _collisionSN { get; set; }
    }
}
