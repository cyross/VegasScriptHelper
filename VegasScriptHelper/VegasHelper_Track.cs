using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VegasScriptHelper
{
    public struct TrackInfo<T>
    {
        public string Name;
        public T Track;
        public Dictionary<string, T> Tracks;
        public List<string> Names;

        public static TrackInfo<T> Create(string name, bool isUseDictionary　= false)
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
    }

    public struct TextTrackInfo
    {
        public TrackInfo<VideoTrack> Track;
        public string PresetName;
        public double Margin;
        public MediaBinInfo MediaBin;
    }

    public partial class VegasHelper
    {
        public IEnumerable<Track> SelectedTracks {
            get { return Vegas.Project.Tracks.Where(track => track.Selected); }
        }

        public IEnumerable<VideoTrack> AllVideoTracks
        {
            get { return Vegas.Project.Tracks.Where(track => track.IsVideo()).Cast<VideoTrack>(); }
        }

        public IEnumerable<AudioTrack> AllAudioTracks
        {
            get { return Vegas.Project.Tracks.Where(track => track.IsAudio()).Cast<AudioTrack>(); }
        }

        /// <summary>
        /// オーディオトラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <returns>生成したトラックオブジェクト[AudioTrack]</returns>
        public AudioTrack CreateAudioTrack(string trackName)
        {
            AudioTrack track = new AudioTrack(Vegas.Project, 0, trackName);
            Vegas.Project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// ビデオトラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <returns>生成したトラックオブジェクト[VideoTrack]</returns>
        public VideoTrack CreateVideoTrack(string trackName)
        {
            VideoTrack track = new VideoTrack(Vegas.Project, 0, trackName);
            Vegas.Project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// ビデオトアジャストメントラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <returns>生成したトラックオブジェクト[VideoAdjustmentTrack]</returns>
        public VideoAdjustmentTrack CreateAdjustmentVideoTrack(string trackName)
        {
            VideoAdjustmentTrack track = new VideoAdjustmentTrack(Vegas.Project, 0, trackName);
            Vegas.Project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// オーディオトラックを作成・VEGAS標準の方法で挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <returns>生成したトラックオブジェクト[AudioTrack]</returns>
        public AudioTrack CreateAudioTrackStandardInsert(string trackName)
        {
            AudioTrack track = Vegas.Project.AddAudioTrack();
            track.Name = trackName;
            return track;
        }

        /// <summary>
        /// オーディオバストラックを作成・VEGAS標準の方法で挿入
        /// </summary>
        /// <returns>生成したトラックオブジェクト[AudioBusTrack]</returns>
        public AudioBusTrack CreateAudioBusTrackStandardInsert()
        {
            return Vegas.Project.AddAudioBusTrack();
        }

        /// <summary>
        /// オーディオFXトラックを作成・VEGAS標準の方法で挿入
        /// </summary>
        /// <param name="node">FXプラグインを示すPluginNodeオブジェクト</param>
        /// <returns>生成したトラックオブジェクト[AudioFXBusTrack]</returns>
        public AudioFXBusTrack CreateAudioFXBusTrackStandardInsert(PlugInNode node)
        {
            return Vegas.Project.AddAudioFXBusTrack(node);
        }

        /// <summary>
        /// ビデオトラックを作成・VEGAS標準の方法で挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <returns>生成したトラックオブジェクト[VideoTrack]</returns>
        public VideoTrack CreateVideoTrackStandardInsert(string trackName)
        {
            VideoTrack track = Vegas.Project.AddVideoTrack();
            track.Name = trackName;
            return track;
        }

        /// <summary>
        /// ビデオトアジャストメントラックを作成・VEGAS標準の方法で挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <returns>生成したトラックオブジェクト[VideoAdjustmentTrack]</returns>
        public VideoAdjustmentTrack CreateVideoAdjustmentTrackStandardInsert(string trackName)
        {
            VideoAdjustmentTrack track = Vegas.Project.AddVideoAdjustmentTrack();
            track.Name = trackName;
            return track;
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public Track SelectedTrack(bool throwException = true)
        {
            return SelectedTrack(Vegas.Project, throwException);
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public Track SelectedTrack(Project project, bool throwException = true)
        {
            foreach (Track track in project.Tracks)
            {
                if (track.Selected){ return track; }
            }

            if (throwException) { throw new VegasHelperTrackUnselectedException(); }

            return null;
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public VideoTrack SelectedVideoTrack(bool throwException = true)
        {
            return SelectedVideoTrack(Vegas.Project, throwException);
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public VideoTrack SelectedVideoTrack(Project project, bool throwException = true)
        {
            foreach (Track track in project.Tracks)
            {
                if (track.Selected && track.IsVideo()){ return (VideoTrack)track; }
            }

            if (throwException) { throw new VegasHelperTrackUnselectedException(); }

            return null;
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public AudioTrack SelectedAudioTrack(bool throwException = true)
        {
            return SelectedAudioTrack(Vegas.Project, throwException);
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public AudioTrack SelectedAudioTrack(Project project, bool throwException = true)
        {
            foreach (Track track in project.Tracks)
            {
                if (track.Selected && track.IsAudio()){ return (AudioTrack)track; }
            }

            if (throwException) { throw new VegasHelperTrackUnselectedException(); }

            return null;
        }

        public string GetTrackTitle(Track track)
        {
            return track.Name;
        }

        public string GetVideoTrackTitle(bool throwException = true)
        {
            VideoTrack track = SelectedVideoTrack(throwException);

            if (track is null) { return null; }

            return GetTrackTitle(track);
        }

        public string GetAudioTrackTitle(bool throwException = true)
        {
            AudioTrack track = SelectedAudioTrack(throwException);

            if (track is null) { return null; }

            return GetTrackTitle(track);
        }

        public void SetTrackTitle(Track track, string title)
        {
            track.Name = title;
        }

        public void SetVideoTrackTitle(string title, bool throwException = true)
        {
            VideoTrack track = SelectedVideoTrack(throwException);

            if (track is null) { return; }

            SetTrackTitle(track, title);
        }

        public void SetAudioTrackTitle(string title, bool throwException = true)
        {
            AudioTrack track = SelectedAudioTrack(throwException);

            if (track is null) { return; }

            SetTrackTitle(track, title);
        }

        public VideoTrack SearchVideoTrackByName(string name, bool throwException = true)
        {
            Project project = Vegas.Project;

            IEnumerable<VideoTrack> searchResult = project.Tracks.Where(track => track.IsVideo() && track.Name == name).Cast<VideoTrack>();

            if (searchResult.Any()) { return searchResult.ToList()[0]; }

            if (throwException) { throw new VegasHelperNotFoundTrackException(); }

            return null;
        }

        public AudioTrack SearchAudioTrackByName(string name, bool throwException = true)
        {
            Project project = Vegas.Project;

            IEnumerable<AudioTrack> searchResult = project.Tracks.Where(track => track.IsAudio() && track.Name == name).Cast<AudioTrack>();

            if (searchResult.Any()) { return searchResult.ToList()[0]; }

            if (throwException) { throw new VegasHelperNotFoundTrackException(); }

            return null;
        }

        public Dictionary<string, VideoTrack> GetVideoKeyValuePairs()
        {
            List<VideoTrack> videoTracks = AllVideoTracks.ToList();

            return GetVideoKeyValuePairs(videoTracks);
        }

        public Dictionary<string, VideoTrack> GetVideoKeyValuePairs(List<VideoTrack> tracks)
        {
            Dictionary<string, VideoTrack> keyValuePairs = new Dictionary<string, VideoTrack>();

            foreach (VideoTrack track in tracks)
            {
                keyValuePairs[GetTrackKey(track)] = track;
            }

            return keyValuePairs;
        }

        public Dictionary<string, AudioTrack> GetAudioKeyValuePairs()
        {
            List<AudioTrack> tracks = AllAudioTracks.ToList();

            return GetAudioKeyValuePairs(tracks);
        }

        public Dictionary<string, AudioTrack> GetAudioKeyValuePairs(List<AudioTrack> tracks)
        {
            Dictionary<string, AudioTrack> keyValuePairs = new Dictionary<string, AudioTrack>();

            foreach (AudioTrack track in tracks)
            {
                keyValuePairs[GetTrackKey(track)] = track;
            }

            return keyValuePairs;
        }

        public Dictionary<string, Track> GetKeyValuePairs()
        {
            List<Track> tracks = Project.Tracks.ToList();

            return GetKeyValuePairs(tracks);
        }

        public Dictionary<string, Track> GetKeyValuePairs(List<Track> tracks)
        {
            Dictionary<string, Track> keyValuePairs = new Dictionary<string, Track>();

            foreach (Track track in tracks)
            {
                keyValuePairs[GetTrackKey(track)] = track;
            }

            return keyValuePairs;
        }

        /// <summary>
        /// 引数で指定したトラックがビデオトラックかどうかを調べる
        /// </summary>
        /// <param name="track">対象のトラックオブジェクト</param>
        /// <returns>ビデオトラックの場合はTrue、それ以外のときはFalseを返す</returns>
        public bool IsVideoTrack(Track track)
        {
            return track.IsVideo();
        }

        /// <summary>
        /// 引数で指定したトラックがオーディオトラックかどうかを調べる
        /// </summary>
        /// <param name="track">対象のトラックオブジェクト</param>
        /// <returns>オーディオトラックの場合はTrue、それ以外のときはFalseを返す</returns>
        public bool IsAudioTrack(Track track)
        {
            return track.IsAudio();
        }

        public string GetTrackKey(Track track)
        {
            return string.Format("[{0}]{1}", (track.Index + 1).ToString(), track.Name ?? "");
        }
    }
}
