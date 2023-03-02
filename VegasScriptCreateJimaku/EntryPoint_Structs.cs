using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

namespace VegasScriptCreateJimaku
{
    public struct DialogBGInfo
    {
        public bool createBG;
        public string trackName;
        public string mediaName;
        public double margin;
        public bool useMediaBin;
        public string mediaBinName;
    }

    public struct DialogTrackInfo
    {
        public string trackName;
        public string presetName;
        public bool useMediaBin;
        public string mediaBinName;
    }

    public class KeyListInfo
    {
        private readonly List<string> _Keys;
        private readonly string _SettingName;
        private readonly string _FirstKey;

        public List<string> Keys
        {
            get { return _Keys; }
        }

        public string SettingName
        {
            get { return _SettingName; }
        }

        public string FirstKey
        {
            get { return _FirstKey; }
        }

        public KeyListInfo(VegasHelper helper, List<string> keys, string settingName)
        {
            _Keys = keys;
            _SettingName = settingName;
            _FirstKey = GetFirstKey(_Keys, helper.Settings[_SettingName]);
        }

        public static KeyListInfo Instance<T>(VegasHelper helper, Dictionary<string, T> dict, string settingName)
        {
            return new KeyListInfo(helper, dict.Keys.ToList(), settingName);
        }

        private static string GetFirstKey(List<string> list, string name)
        {
            if (name.Length > 0) { return name; }
            if (list.Count > 0) { return list.First(); }
            return "";
        }
    }

    public struct BasicTrackStruct<T>
    {
        public bool IsCreate;
        public TrackInfo<T> Info;

        public static BasicTrackStruct<T> Create(bool isCreate, string name, bool isUseDictionary)
        {
            BasicTrackStruct<T> info = new BasicTrackStruct<T>
            {
                IsCreate = isCreate
            };

            info.Info = TrackInfo<T>.Create(name, isUseDictionary);

            return info;
        }
    }

    public struct Flags
    {
        public PrefixBehaviorType Behavior;
        public bool IsRemoveActorAttr;
        public bool IsCreateOneEventCheck;
        public bool IsCollapseTrackGroup;
        public bool IsDivideTracks;
    }

    public struct BasicTrackStructs
    {
        public BasicTrackStruct<VideoTrack> Tachie;
        public BasicTrackStruct<VideoTrack> BG;
        public BasicTrackStruct<VideoTrack> FG;
        public BasicTrackStruct<AudioTrack> BGM;

        public static BasicTrackStructs Create(VegasScriptSettings settings)
        {
            return new BasicTrackStructs
            {
                Tachie = BasicTrackStruct<VideoTrack>.Create(settings["UseTachie"], settings["TachieTrackName"], true),
                BG = BasicTrackStruct<VideoTrack>.Create(settings["UseBG"], settings["BGTrackName"], false),
                FG = BasicTrackStruct<VideoTrack>.Create(settings["UseFG"], settings["FGTrackName"], false),
                BGM = BasicTrackStruct<AudioTrack>.Create(settings["UseBGM"], settings["BGMTrackName"], false)
            };
        }
    }
}
