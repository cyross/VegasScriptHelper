using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using VegasScriptHelper;
using VegasScriptHelper.Structs;
using VegasScriptHelper.Settings;

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
            _FirstKey = GetFirstKey(_Keys, helper.Config[_SettingName]);
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

    public struct BasicTrackStruct<T> where T: Track
    {
        public bool IsCreate;
        public TrackInfo<T> Info;

        public static BasicTrackStruct<T> Create(bool isCreate, string name, bool isUseDictionary)
        {
            BasicTrackStruct<T> info = new BasicTrackStruct<T>
            {
                IsCreate = isCreate,
                Info = TrackInfo<T>.Create(name, isUseDictionary)
            };

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

        public static BasicTrackStructs Create(Config config)
        {
            return new BasicTrackStructs
            {
                Tachie = BasicTrackStruct<VideoTrack>.Create(config[Names.WdTachie.Use], config[Names.WdTachie.Track.Name], true),
                BG = BasicTrackStruct<VideoTrack>.Create(config[Names.WdBG.Use], config[Names.WdBG.Track.Name], false),
                FG = BasicTrackStruct<VideoTrack>.Create(config[Names.WdFG.Use], config[Names.WdFG.Track.Name], false),
                BGM = BasicTrackStruct<AudioTrack>.Create(config[Names.WdBGM.Use], config[Names.WdBGM.Track.Name], false)
            };
        }
    }
}
