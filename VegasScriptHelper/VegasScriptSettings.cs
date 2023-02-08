using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using YamlDotNet.RepresentationModel;
using VegasScriptHelper.VegasHelperYamlSpecs;
using System.Diagnostics;

namespace VegasScriptHelper
{
    public class VegasScriptSettings
    {
        public static float AudioInsertInterval;
        public static string OpenDirectory;
        public static bool IsRecursive;
        public static bool StartFrom;
        public static double AssignEventMargin;
        public static string TargetAssignTrackName;
        public static double JimakuOutlineWidth;
        public static double ExpandVideoEventMargin;
        public static Color JimakuColor;
        public static Color OutlineColor;
        public static SupportedAudioFileSettings SupportedAudioFile;
        public static VoiceActorColors TextColorByActor;
        public static VoiceActorOutlineColors OutlineColorByActor;
        public static DefaultBinNameSetting DefaultBinName;

        private static T LoadYamlFile<T>(string filename) where T: class, IYamlSpec, new()
        {
            string execDir = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

            try
            {
                var yamlStream = new StreamReader(Path.Combine(execDir, filename));

                var stream = new YamlStream();

                stream.Load(yamlStream);

                T obj = new T();

                obj.Deserialize(stream);

                return obj;
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine("[ERROR]FILE NOT FOUND: filepath");
                Debug.WriteLine("CurrentPath = " + execDir);
                throw ex;
            }
        }

        public static void LoadYamlFile()
        {
            SupportedAudioFile = LoadYamlFile<SupportedAudioFileSettings>("SupportedAudioFileSettings.yaml");
            TextColorByActor = LoadYamlFile<VoiceActorColors>("VoiceActorColors.yaml");
            OutlineColorByActor = LoadYamlFile<VoiceActorOutlineColors>("VoiceActorOutlineColors.yaml");
            DefaultBinName = LoadYamlFile<DefaultBinNameSetting>("DefaultBinNames.yaml");
        }

        public static void Load()
        {
            Properties.Vegas.Default.Upgrade();

            AudioInsertInterval = Properties.Vegas.Default.audioInsertInterval;
            OpenDirectory = Properties.Vegas.Default.openDirectory;
            IsRecursive = Properties.Vegas.Default.isRecursive;
            StartFrom = Properties.Vegas.Default.startFrom;
            AssignEventMargin = Properties.Vegas.Default.assignEventMargin;
            TargetAssignTrackName = Properties.Vegas.Default.targetAssignTrackName;
            JimakuOutlineWidth = Properties.Vegas.Default.jimakuOutlineWidth;
            ExpandVideoEventMargin = Properties.Vegas.Default.expandVideoEventMargin;
            JimakuColor = Properties.Vegas.Default.jimakuColor;
            OutlineColor = Properties.Vegas.Default.outlineColor;

            LoadYamlFile();
        }

        public static void Save()
        {
            Properties.Vegas.Default.expandVideoEventMargin = ExpandVideoEventMargin;
            Properties.Vegas.Default.jimakuOutlineWidth = JimakuOutlineWidth;
            Properties.Vegas.Default.targetAssignTrackName = TargetAssignTrackName;
            Properties.Vegas.Default.assignEventMargin = AssignEventMargin;
            Properties.Vegas.Default.startFrom = StartFrom;
            Properties.Vegas.Default.isRecursive = IsRecursive;
            Properties.Vegas.Default.audioInsertInterval = AudioInsertInterval;
            Properties.Vegas.Default.openDirectory = OpenDirectory;
            Properties.Vegas.Default.jimakuColor = JimakuColor;
            Properties.Vegas.Default.outlineColor = OutlineColor;
            Properties.Vegas.Default.Save();
        }

        public static string FormatKey(string org_key)
        {
            return Regex.Replace(org_key, @"[\s()\.\/:\.\[\]\\\/]+", "_");
        }
    }
}
