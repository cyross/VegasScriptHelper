using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper.Structs
{
    public struct TrackInfo<T> where T : Track
    {
        public string Name;
        public T Track;
        public Dictionary<string, T> Tracks;
        public List<string> Names;

        public static TrackInfo<T> Create(string name, bool isUseDictionary = false)
        {
            TrackInfo<T> info = new TrackInfo<T>
            {
                Name = name
            };

            if (isUseDictionary)
            {
                info.Tracks = new Dictionary<string, T>();
                info.Names = new List<string>();
            }

            return info;
        }

        public int CountEvents()
        {
            if (Track == null) return 0;

            return Track.Events.Count;
        }
    }

    public struct TextTrackInfo
    {
        public TrackInfo<VideoTrack> Track;
        public string PresetName;
        public double Margin;
        public MediaBinInfo MediaBin;
    }

    public struct MediaInfo
    {
        public string Name;
        public Media Media;
    }

    public struct MediaBinInfo
    {
        public bool IsUse;
        public string Name;
        public MediaBin Bin;
    }

    public struct ColorInfo
    {
        public bool IsUse;
        public Color TextColor;
        public Color OutlineColor;
        public double OutlineWidth;
    }
    public struct InsertAudioInfo
    {
        // 音声なしのイベントを作るために用意
        public string[] JimakuLines;
        public TrackInfo<AudioTrack> Track;
        public string Folder;
        public float Interval;
        public double StandardSilenceTime;
        public bool IsRecursive;
        public bool IsInsertFromStartPosition;
        public MediaBinInfo MediaBin;
    }

    public struct BackgroundInfo
    {
        public TrackInfo<VideoTrack> Track;
        public bool IsCreate;
        public MediaInfo Media;
        public double Margin;
        public MediaBinInfo MediaBin;
    }

    public struct JimakuParams
    {
        public string JimakuFilePath;
        public string[] JimakuLines;
        public string[] ActorLines;
        public HashSet<string> ActorSets;

        public TextTrackInfo Jimaku;
        public TextTrackInfo Actor;

        public bool IsDeletePrefix;
        public bool IsCreateActorTrack;
        public bool isRemoveActorAttr;

        public ColorInfo JimakuColor;
        public ColorInfo ActorColor;
    }

    public struct AssignDurationInfo
    {
        public VideoTrack VideoTrack;
        public AudioTrack AudioTrack;
        public double Margin;
        public bool IsAdjustTakes;
        public bool IsGrouping;
    }

    public struct AlignmentEventInfo
    {
        public VideoTrack VideoTrack;
        public AudioTrack AudioTrack;
        public Media Media;
        public double Margin;
        public bool IsGrouping;
    }
}
