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

    public struct BasicTrackStruct
    {
        public bool IsCreate;
        public TrackInfo<VideoTrack> Info;
    }

    public struct Flags
    {
        public PrefixBehaviorType Behavior;
        public bool IsRemoveActorAttr;
        public bool IsCreateOneEventCheck;
    }

    public struct BasicTrackStructs
    {
        public BasicTrackStruct Tachie;
        public BasicTrackStruct BG;
    }
}
