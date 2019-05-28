using Newtonsoft.Json;
using System;
using System.IO;

namespace KolabLoader
{
    public class KolabSettingsContainer
    {
        public bool _useInviwoPositioning { get; set; }
        public bool _rttVisualization { get; set; }
        public bool _createRoomOnLoad { get; set; }
        public bool _autoJoinFirstRoomOnLoad { get; set; }
        public bool _externalRendererMode { get; set; }
        public string _projectPath { get; set; }
        public string _workspacesPath { get; set; }
        public string _inviwoPath { get; set; }
        public string _megamolPath { get; set; }
        public string[] _collisionSN { get; set; }        
    }
}
