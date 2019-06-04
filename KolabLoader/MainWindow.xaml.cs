﻿using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;

namespace KolabLoader
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected KolabSettingsContainer runtimeSettings;
        private string[] words;
        private static Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();

            //Read JSON
            readFromJSON("C:/Users/flo/AppData/LocalLow/UlmUniversity/BaseSpoutInteropsettings.json", ref runtimeSettings);
            runtimeSettings.PropertyChanged += RuntimeSettings_PropertyChanged;

            //Read Wordlist
            words = File.ReadAllLines("out.txt");

            this.DataContext = runtimeSettings;
        }

        private void RuntimeSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("Change: "+e.PropertyName);
        }

        public static bool readFromJSON(string path, ref KolabSettingsContainer target)
        {
            try
            {
                using (var sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    target = JsonConvert.DeserializeObject<KolabSettingsContainer>(sr.ReadToEnd());
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to read serialized settings: " + e.Message);
                return false;
            }

        }

        public static bool writeToJSON(string path, ref KolabSettingsContainer target)
        {
            try
            {
                using (var sw = new StreamWriter(new FileStream(path, FileMode.Truncate, FileAccess.Write)))
                {
                    string outStr = JsonConvert.SerializeObject(target,Formatting.Indented);
                    sw.WriteLine(outStr);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to write serialized settings: " + e.Message);
                return false;
            }

        }


        private void GenerateSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            //Select three random words, fill in
            string w1 = words.ElementAt(rand.Next(words.Count()));
            string w2 = words.ElementAt(rand.Next(words.Count()));
            string w3 = words.ElementAt(rand.Next(words.Count()));

            //Form update
            runtimeSettings._session = w1 + "-" + w2 + "-" + w3;
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void KolabWeb_Btn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://platform.kolab.org");
        }

        private void StartSession_Btn_Click(object sender, RoutedEventArgs e)
        {
            //todo - fire up unity
            Process.Start(runtimeSettings._projectPath+"\\bin\\BaseSpoutInterop.exe");
        }

        private void InviwoExeChoose_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Inviwo Installation Folder (containing inviwo.exe)";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = false;

                DialogResult result = fbd.ShowDialog();

                if (runtimeSettings._inviwoPath.Length > 0 && File.Exists(runtimeSettings._inviwoPath)) fbd.SelectedPath = runtimeSettings._inviwoPath;

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    runtimeSettings._inviwoPath = fbd.SelectedPath + "\\inviwo.exe";
                }
            }
        }

        private void MegamolExeChoose_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Megamol Installation Folder (containing megamol.exe)";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = false;

                DialogResult result = fbd.ShowDialog();

                if (runtimeSettings._megamolPath.Length > 0 && File.Exists(runtimeSettings._megamolPath)) fbd.SelectedPath = runtimeSettings._megamolPath;

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    runtimeSettings._megamolPath = fbd.SelectedPath + "\\megamol.exe";
                }
            }
        }

        private void WorkDirectoryChoose_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Workspaces Folder (containing megamol/inviwo scenes)";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = false;

                DialogResult result = fbd.ShowDialog();

                if (runtimeSettings._workspacesPath.Length > 0 && File.Exists(runtimeSettings._workspacesPath)) fbd.SelectedPath = runtimeSettings._workspacesPath;

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    runtimeSettings._workspacesPath = fbd.SelectedPath;
                }
            }
        }

        private void UnityExeChoose_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select Unity/KoLAB Installation Folder (containing kolab.exe)";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = false;

                DialogResult result = fbd.ShowDialog();

                if (runtimeSettings._projectPath.Length > 0 && File.Exists(runtimeSettings._projectPath)) fbd.SelectedPath = runtimeSettings._projectPath;

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    runtimeSettings._projectPath = fbd.SelectedPath;
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            writeToJSON("C:/Users/flo/AppData/LocalLow/UlmUniversity/BaseSpoutInteropsettings.json", ref runtimeSettings);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            writeToJSON("C:/Users/flo/AppData/LocalLow/UlmUniversity/BaseSpoutInteropsettings.json", ref runtimeSettings);
        }
    }
}