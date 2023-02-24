using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using YamlDotNet.RepresentationModel;
using VegasScriptHelper.VegasHelperYamlSpecs;
using System.Diagnostics;
using System.Dynamic;
using System.Configuration;
using System.Collections.Generic;

namespace VegasScriptHelper
{
    public class VegasScriptSettings
    {
        private readonly static VegasScriptSettings _Instance = new VegasScriptSettings();

        private Dictionary<string, dynamic> settingProperties = new Dictionary<string, dynamic>();

        public SupportedAudioFileSettings SupportedAudioFile;
        public VoiceActorColors TextColorByActor;
        public VoiceActorOutlineColors OutlineColorByActor;
        public DefaultBinNameSetting DefaultBinName;
        public DefaultTrackNameSetting DefaultTrackName;

        public static VegasScriptSettings Instance
        {
            get { return _Instance; }
        }

        public void LoadYamlFile()
        {
            SupportedAudioFile = LoadYamlFile<SupportedAudioFileSettings>("SupportedAudioFileSettings.yaml");
            TextColorByActor = LoadYamlFile<VoiceActorColors>("VoiceActorColors.yaml");
            TextColorByActor.DefaultColor = this["JimakuColor"];
            OutlineColorByActor = LoadYamlFile<VoiceActorOutlineColors>("VoiceActorOutlineColors.yaml");
            OutlineColorByActor.DefaultColor = this["JimakuOutlineColor"];
            DefaultBinName = LoadYamlFile<DefaultBinNameSetting>("DefaultBinNames.yaml");
            DefaultTrackName = LoadYamlFile<DefaultTrackNameSetting>("DefaultTrackNames.yaml");
        }

        public void Load()
        {
            Properties.Vegas.Default.Upgrade();

            foreach (SettingsProperty property in Properties.Vegas.Default.Properties)
            {
                string propertyName = property.Name;
                PropertyInfo pinfo = typeof(Properties.Vegas).GetProperty(propertyName);
                this[propertyName] = pinfo.GetValue(Properties.Vegas.Default);
            }

            LoadYamlFile();

            SetInitialBinName("AudioMediaBinName", "voiroVoice");
            SetInitialBinName("JimakuMediaBinName", "voiroJimaku");
            SetInitialBinName("ActorMediaBinName", "voiroActor");
            SetInitialBinName("JimakuBackgroundMediaBinName", "jimakuBackground");
            SetInitialBinName("ActorBackgroundMediaBinName", "actorBackground");
        }

        public void Save()
        {
            foreach (SettingsProperty property in Properties.Vegas.Default.Properties)
            {
                string propertyName = property.Name;
                PropertyInfo pinfo = typeof(Properties.Vegas).GetProperty(propertyName);
                pinfo.SetValue(Properties.Vegas.Default, this[propertyName]);
            }

            Properties.Vegas.Default.Save();
        }

        public dynamic this[string name]
        {
            get => settingProperties[name];
            set => settingProperties[name] = value;
        }

        private static T LoadYamlFile<T>(string filename) where T : class, IYamlSpec, new()
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

        private void SetInitialBinName(string settinNameKey, string yamlKey)
        {
            if (settingProperties[settinNameKey].Length > 0)
            {
                settingProperties[settinNameKey] = DefaultBinName[yamlKey];
            }
        }
    }
}
