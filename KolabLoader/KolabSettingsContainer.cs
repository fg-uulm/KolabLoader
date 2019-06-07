using System;
using System.ComponentModel;

namespace KolabLoader
{
    public class KolabSettingsContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string _nickname { get; set; } = Environment.UserName;
        public string _institution { get; set; } = "";
        public string _session { get; set; } = "Default Room";
        public bool _useInviwoPositioning { get; set; } = false;
        public bool _rttVisualization { get; set; } = false;
        public bool _createRoomOnLoad { get; set; } = false;
        public bool _autoJoinFirstRoomOnLoad { get; set; } = true;
        public bool _externalRendererMode { get; set; } = true;
        public bool _desktopMode { get; set; } = false;
        public string _projectPath { get; set; } = "undefined";
        public string _username { get; set; } = "undefined";
        public string _password { get; set; } = "undefined";
        public string _workspacesPath { get; set; } = "undefined";
        public string _inviwoPath { get; set; } = "undefined";
        public string _megamolPath { get; set; } = "undefined";
        public string[] _collisionSN { get; set; } = new string[0];
    }
}
