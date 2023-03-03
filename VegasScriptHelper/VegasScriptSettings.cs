using System.IO;
using System.Reflection;
using YamlDotNet.RepresentationModel;
using VegasScriptHelper.VegasHelperYamlSpecs;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;

namespace VegasScriptHelper
{
    public partial class VegasScriptSettings
    {
        private readonly static VegasScriptSettings _Instance = new VegasScriptSettings();

        private readonly Dictionary<string, dynamic> settingProperties = new Dictionary<string, dynamic>();

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
            SupportedAudioFile = LoadYamlFile<SupportedAudioFileSettings>(YAML_SUPORTED_AUDIO_FILE);
            TextColorByActor = LoadYamlFile<VoiceActorColors>(YAML_VOICE_ACTOR_COLOR);
            TextColorByActor.DefaultColor = this[SN.WdActor.Color];
            OutlineColorByActor = LoadYamlFile<VoiceActorOutlineColors>(YAML_ACTOR_OUTLINE_COLOR_FILE);
            OutlineColorByActor.DefaultColor = this[SN.WdJimaku.Outline.Color];
            DefaultBinName = LoadYamlFile<DefaultBinNameSetting>(YAML_DEFAULT_BIN_NAME);
            DefaultTrackName = LoadYamlFile<DefaultTrackNameSetting>(YAML_DEFAULT_TRACK_NAME);
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

            SetInitialBinName(SN.WdAudio.MediaBin.Name, DefaultBinNameSetting.voiroVoice);
            SetInitialBinName(SN.WdJimaku.MediaBin.Name, DefaultBinNameSetting.voiroJimaku);
            SetInitialBinName(SN.WdActor.MediaBin.Name, DefaultBinNameSetting.voiroActor);
            SetInitialBinName(SN.WdJimaku.BG.MediaBin.Name, DefaultBinNameSetting.jimakuBG);
            SetInitialBinName(SN.WdActor.BG.MediaBin.Name, DefaultBinNameSetting.actorBG);
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
            string execFilePath = VegasHelperUtility.GetExecFilepath(filename);

            try
            {
                var yamlStream = new StreamReader(execFilePath);

                var stream = new YamlStream();

                stream.Load(yamlStream);

                T obj = new T();

                obj.Deserialize(stream);

                return obj;
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine("[ERROR]FILE NOT FOUND: filepath");
                Debug.WriteLine("CurrentPath = " + execFilePath);
                throw ex;
            }
        }

        private void SetInitialBinName(string settingNameKey, string yamlKey)
        {
            if (settingProperties[settingNameKey].Length > 0)
            {
                settingProperties[settingNameKey] = DefaultBinName[yamlKey];
            }
        }
    }
}
