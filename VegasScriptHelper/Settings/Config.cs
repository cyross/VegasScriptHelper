using System.IO;
using System.Reflection;
using YamlDotNet.RepresentationModel;
using VegasScriptHelper.VegasHelperYamlSpecs;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;

namespace VegasScriptHelper.Settings
{
    public class Config
    {
        public const string YAML_SUPORTED_AUDIO_FILE = "SupportedAudioFileSettings.yaml";
        public const string YAML_VOICE_ACTOR_COLOR = "VoiceActorColors.yaml";
        public const string YAML_ACTOR_OUTLINE_COLOR_FILE = "VoiceActorOutlineColors.yaml";
        public const string YAML_DEFAULT_BIN_NAME = "DefaultBinNames.yaml";
        public const string YAML_DEFAULT_TRACK_NAME = "DefaultTrackNames.yaml";

        private readonly static Config _Instance = new Config();

        private readonly Dictionary<string, dynamic> props = new Dictionary<string, dynamic>();

        private SupportedAudioFile audioExts;
        private VoiceActorColors a2tc;
        private VoiceActorOutlineColors a2oc;
        private DefaultBinName defBinNames;
        private DefaultTrackName defTrackNames;

        public static Config Instance
        {
            get { return _Instance; }
        }

        public SupportedAudioFile AudioFileExts
        {
            get { return audioExts; }
        }

        public VoiceActorColors ActorToTextColor
        {
            get { return a2tc; }
        }

        public VoiceActorOutlineColors ActorToOLColor
        {
            get { return a2oc; }
        }

        public DefaultBinName DefBinName
        {
            get { return defBinNames; }
        }

        public DefaultTrackName DefTrackName
        {
            get { return defTrackNames; }
        }

        public void LoadYamlFile()
        {
            audioExts = LoadYamlFile<SupportedAudioFile>(YAML_SUPORTED_AUDIO_FILE);
            a2tc = LoadYamlFile<VoiceActorColors>(YAML_VOICE_ACTOR_COLOR);
            a2tc.Default = this[Names.WdActor.Color];
            a2oc = LoadYamlFile<VoiceActorOutlineColors>(YAML_ACTOR_OUTLINE_COLOR_FILE);
            a2oc.Default = this[Names.WdJimaku.Outline.Color];
            defBinNames = LoadYamlFile<DefaultBinName>(YAML_DEFAULT_BIN_NAME);
            defTrackNames = LoadYamlFile<DefaultTrackName>(YAML_DEFAULT_TRACK_NAME);
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

            SetInitialBinName(Names.WdAudio.MediaBin.Name, DefaultBinName.voiroVoice);
            SetInitialBinName(Names.WdJimaku.MediaBin.Name, DefaultBinName.voiroJimaku);
            SetInitialBinName(Names.WdActor.MediaBin.Name, DefaultBinName.voiroActor);
            SetInitialBinName(Names.WdJimaku.BG.MediaBin.Name, DefaultBinName.jimakuBG);
            SetInitialBinName(Names.WdActor.BG.MediaBin.Name, DefaultBinName.actorBG);
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
            get => props[name];
            set => props[name] = value;
        }

        private static T LoadYamlFile<T>(string filename) where T : class, Interfaces.IYamlSpec, new()
        {
            string execFilePath = VHUtility.GetExecFilepath(filename);

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

        private void SetInitialBinName(string nameKey, string yamlKey)
        {
            if (props[nameKey].Length == 0) { return; }

            props[nameKey] = defBinNames[yamlKey];
        }
    }
}
