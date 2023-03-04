using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public class SettingName
    {
        private static readonly SettingName all = new SettingName("All");
        private static readonly SettingName jimaku = new SettingName("Jimaku");
        private static readonly SettingName actor = new SettingName("Actor");
        private static readonly SettingName audio = new SettingName("Audio");
        private static readonly SettingName video = new SettingName("Video");
        private static readonly SettingName tachie = new SettingName("Tachie");
        private static readonly SettingName bg = new SettingName("BG");
        private static readonly SettingName fg = new SettingName("FG");
        private static readonly SettingName bgm = new SettingName("BGM");
        private static readonly SettingName time = new SettingName("Time");
        private readonly string str;

        public SettingName(string value)
        {
            this.str = value;
        }

        public SettingName Pre(string v)
        {
            return new SettingName(v + str);
        }

        public SettingName Post(string v)
        {
            return new SettingName(str + v);
        }

        public static implicit operator string(SettingName sn)
        {
            return sn.ToString();
        }

        public override string ToString()
        {
            return str;
        }

        public static SettingName WdAll { get { return all; } }
        public static SettingName WdJimaku { get { return jimaku; } }
        public static SettingName WdActor { get { return actor; } }
        public static SettingName WdAudio { get { return audio; } }
        public static SettingName WdVideo { get { return video; } }
        public static SettingName WdTachie { get { return tachie; } }
        public static SettingName WdBG { get { return bg; } }
        public static SettingName WdFG { get { return fg; } }
        public static SettingName WdBGM { get { return bgm; } }
        public static SettingName WdTime { get { return time; } }
        public SettingName Create { get { return Pre("Create"); } }
        public SettingName Use { get { return Pre("Use"); } }
        public SettingName Is { get { return Pre("Is"); } }
        public SettingName Expand { get { return Pre("Expand"); } }
        public SettingName Remove { get { return Pre("Remove"); } }
        public SettingName Divide { get { return Pre("Divide"); } }
        public SettingName BG { get { return Post("BG"); } }
        public SettingName Media { get { return Post("Media"); } }
        public SettingName Bin { get { return Post("Bin"); } }
        public SettingName MediaBin { get { return Post("MediaBin"); } }
        public SettingName Name { get { return Post("Name"); } }
        public SettingName Track { get { return Post("Track"); } }
        public SettingName Tracks { get { return Post("Tracks"); } }
        public SettingName Preset { get { return Post("Preset"); } }
        public SettingName Margin { get { return Post("Margin"); } }
        public SettingName Setting { get { return Post("Setting"); } }
        public SettingName Settings { get { return Post("Settings"); } }
        public SettingName Color { get { return Post("Color"); } }
        public SettingName Outline { get { return Post("Outline"); } }
        public SettingName Width { get { return Post("Width"); } }
        public SettingName File { get { return Post("File"); } }
        public SettingName Folder { get { return Post("Folder"); } }
        public SettingName Path { get { return Post("Path"); } }
        public SettingName Insert { get { return Post("Insert"); } }
        public SettingName Interval { get { return Post("Interval"); } }
        public SettingName Recursive { get { return Post("Recursive"); } }
        public SettingName Check { get { return Post("Check"); } }
        public SettingName Group { get { return Post("Group"); } }
        public SettingName From { get { return Post("From"); } }
        public SettingName Start { get { return Post("Start"); } }
        public SettingName Position { get { return Post("Position"); } }
        public SettingName Event { get { return Post("Event"); } }
        public SettingName Serifu { get { return Post("Serifu"); } }
        public SettingName One { get { return Post("One"); } }
        public SettingName Collapse { get { return Post("Collapse"); } }
        public SettingName Silence { get { return Post("Silence"); } }
        public SettingName Standard { get { return Post("Standard"); } }
        public SettingName Time { get { return Post("Time"); } }
        public SettingName Attribute { get { return Post("Attribute"); } }
        public SettingName Prefix { get { return Post("Prefix"); } }
        public SettingName Behavior { get { return Post("Behavior"); } }
        public SettingName Ruler { get { return Post("Ruler"); } }
        public SettingName Format { get { return Post("Format"); } }
    }

    public class SN: SettingName
    {
        public SN(string value): base(value) { }
    };

    public partial class VegasScriptSettings
    {
        public const string YAML_SUPORTED_AUDIO_FILE = "SupportedAudioFileSettings.yaml";
        public const string YAML_VOICE_ACTOR_COLOR = "VoiceActorColors.yaml";
        public const string YAML_ACTOR_OUTLINE_COLOR_FILE = "VoiceActorOutlineColors.yaml";
        public const string YAML_DEFAULT_BIN_NAME = "DefaultBinNames.yaml";
        public const string YAML_DEFAULT_TRACK_NAME = "DefaultTrackNames.yaml";
    }
}
