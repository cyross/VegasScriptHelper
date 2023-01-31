using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace VegasScriptHelper
{
    public class VegasScriptSettings
    {
        public static float AudioInsertInterval;
        public static string OpenDirectory;
        public static bool IsRecursive;
        public static bool StartFrom;
        public static string[] SupportedAudioFile = null;
        public readonly static Dictionary<string, Color> TextColorByActor = new Dictionary<string, Color>();
        public readonly static Dictionary<string, Color> OutlineColorByActor = new Dictionary<string, Color>();
        public static double AssignEventMargin;
        public static string TargetAssignTrackName;
        public static double JimakuOutlineWidth;
        public static double ExpandVideoEventMargin;
        public readonly static Dictionary<string, string> DefaultBinName = new Dictionary<string, string>();

        public static void Load()
        {
            Properties.Vegas.Default.Upgrade();
            Properties.SupportedAudioFileSettings.Default.Upgrade();
            Properties.VoiceActorColor.Default.Upgrade();
            Properties.DefaultBinName.Default.Upgrade();

            AudioInsertInterval = Properties.Vegas.Default.audioInsertInterval;
            OpenDirectory = Properties.Vegas.Default.openDirectory;
            IsRecursive = Properties.Vegas.Default.isRecursive;
            StartFrom = Properties.Vegas.Default.startFrom;
            AssignEventMargin = Properties.Vegas.Default.assignEventMargin;
            TargetAssignTrackName = Properties.Vegas.Default.targetAssignTrackName;
            JimakuOutlineWidth = Properties.Vegas.Default.jimakuOutlineWidth;
            ExpandVideoEventMargin = Properties.Vegas.Default.expandVideoEventMargin;

            List<string> audioFileExts = new List<string>();
            foreach (SettingsProperty property in Properties.SupportedAudioFileSettings.Default.Properties)
            {
                PropertyInfo pinfo = typeof(Properties.SupportedAudioFileSettings).GetProperty(property.Name);
                audioFileExts.Add((string)pinfo.GetValue(Properties.SupportedAudioFileSettings.Default));
            }
            SupportedAudioFile = audioFileExts.ToArray();

            TextColorByActor.Clear();
            foreach (SettingsProperty property in Properties.VoiceActorColor.Default.Properties)
            {
                PropertyInfo pinfo = typeof(Properties.VoiceActorColor).GetProperty(property.Name);
                TextColorByActor[property.Name] = (Color)pinfo.GetValue(Properties.VoiceActorColor.Default);
            }

            OutlineColorByActor.Clear();
            foreach (SettingsProperty property in Properties.VoiceActorOutlineColor.Default.Properties)
            {
                PropertyInfo pinfo = typeof(Properties.VoiceActorOutlineColor).GetProperty(property.Name);
                OutlineColorByActor[property.Name] = (Color)pinfo.GetValue(Properties.VoiceActorOutlineColor.Default);
            }

            DefaultBinName.Clear();
            foreach(SettingsProperty property in Properties.DefaultBinName.Default.Properties)
            {
                PropertyInfo pinfo = typeof(Properties.DefaultBinName).GetProperty(property.Name);
                DefaultBinName[property.Name] = (string)pinfo.GetValue(Properties.DefaultBinName.Default);
            }
        }

        public static void Save()
        {
            // VoiceActorColorはマスタ情報なので保存不要
            // SupportedAudioFileSettingはマスタ情報なので保存不要
            // DefaultBinNameはマスタ情報なので保存不要
            Properties.Vegas.Default.expandVideoEventMargin = ExpandVideoEventMargin;
            Properties.Vegas.Default.jimakuOutlineWidth = JimakuOutlineWidth;
            Properties.Vegas.Default.targetAssignTrackName = TargetAssignTrackName;
            Properties.Vegas.Default.assignEventMargin = AssignEventMargin;
            Properties.Vegas.Default.startFrom = StartFrom;
            Properties.Vegas.Default.isRecursive = IsRecursive;
            Properties.Vegas.Default.audioInsertInterval = AudioInsertInterval;
            Properties.Vegas.Default.openDirectory = OpenDirectory;
            Properties.Vegas.Default.Save();
        }

        public static string FormatKey(string org_key)
        {
            return Regex.Replace(org_key, @"[\s()\.\/:\.\[\]\\\/]+", "_");
        }
    }
}
