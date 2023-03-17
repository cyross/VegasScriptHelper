using System;
using System.Collections.Generic;
using System.Linq;
using ScriptPortal.Vegas;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHProject
    {
        private Project project;

        public VHProject(Vegas vegas)
        {
            project = vegas.Project;
        }

        public MediaPool MediaPool
        {
            get { return project.MediaPool; }
        }

        public MediaBin CreateMediaBin(string name)
        {
            return new MediaBin(project, name);
        }

        public void AddTrackEventGroup(params TrackEvent[] events)
        {
            // Vegas.Project.TrackEventGroups.Addメソッドを先に呼ばいないと、
            // group.Addする際に例外が発生する
            TrackEventGroup group = new TrackEventGroup(project);

            project.TrackEventGroups.Add(group);

            foreach (TrackEvent trackEvent in events)
            {
                group.Add(trackEvent);

            }
        }

        public void AddTrackGroup(List<Track> tracks, string name = null, bool isCollapse = true)
        {
            // トラックグループを作るには、まずトラックを選択する必要がある。
            UnselectAllTrack();

            foreach(var track in tracks)
            {
                track.Selected = true;
            }

            TrackGroup group = project.GroupSelectedTracks();

            if (name != null){ group.Name = name; }

            if (isCollapse) { group.CollapseTrackGroup(); }

            UnselectAllTrack();
        }

        public void UnselectAllTrack()
        {
            foreach (var track in project.Tracks)
            {
                track.Selected = false;
            }
        }

        public IEnumerable<Track> SearchTracks(Func<Track, bool> func)
        {
            return project.Tracks.Where(func);
        }

        public AudioTrack SearchAudioTrack(string name, bool throwException = true)
        {
            IEnumerable<AudioTrack> searchResult = SearchTracks(track => track.IsAudio() && track.Name == name).Cast<AudioTrack>();

            if (searchResult.Any()) { return searchResult.First(); }

            if (throwException) { throw new VHNotFoundTrackException(); }

            return null;
        }

        public VideoTrack SearchVideoTrack(string name, bool throwException = true)
        {
            IEnumerable<VideoTrack> searchResult = SearchTracks(track => track.IsVideo() && track.Name == name).Cast<VideoTrack>();

            if (searchResult.Any()) { return searchResult.First(); }

            if (throwException) { throw new VHNotFoundTrackException(); }

            return null;
        }

        public List<Track> AllTracks
        {
            get { return project.Tracks.ToList(); }
        }

        public IEnumerable<VideoTrack> AllVideoTracks
        {
            get { return SearchTracks(track => track.IsVideo()).Cast<VideoTrack>(); }
        }

        public IEnumerable<AudioTrack> AllAudioTracks
        {
            get { return SearchTracks(track => track.IsAudio()).Cast<AudioTrack>(); }
        }

        public IEnumerable<Track> SelectedTracks
        {
            get { return SearchTracks(track => track.Selected); }
        }

        public IEnumerable<VideoTrack> SelectedVideoTracks
        {
            get { return SearchTracks(track => track.Selected && track.IsVideo()).Cast<VideoTrack>(); }
        }

        public IEnumerable<AudioTrack> SelectedAudioTracks
        {
            get { return SearchTracks(track => track.Selected && track.IsAudio()).Cast<AudioTrack>(); }
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public Track SelectedTrack(bool throwException = true)
        {
            IEnumerable<Track> selected = SelectedTracks;

            if (selected.Any()) { return selected.First(); }

            if (throwException) { throw new VHNotFoundTrackException(); }

            return null;
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public AudioTrack SelectedAudioTrack(bool throwException = true)
        {
            IEnumerable<AudioTrack> selected = SelectedAudioTracks;

            if (selected.Any()) { return selected.First(); }

            if (throwException) { throw new VHNotFoundTrackException(); }

            return null;
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public VideoTrack SelectedVideoTrack(bool throwException = true)
        {
            IEnumerable<VideoTrack> selected = SelectedVideoTracks;

            if (selected.Any()) { return selected.First(); }

            if (throwException) { throw new VHNotFoundTrackException(); }

            return null;
        }

        /// <summary>
        /// トラックを作成
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <param name="useAdd">
        /// 生成したトラックをVEGAS標準の方式で挿入するかどうかのフラグ
        /// true: VEGAS標準の方式で挿入
        /// false: トラックビューの一番上に挿入
        /// 省略時は false
        /// </param>
        /// <returns>生成したトラックオブジェクト[AudioTrack]</returns>
        public AudioTrack AddAudioTrack(string trackName, bool useAdd = false)
        {
            if (useAdd)
            {
                AudioTrack t = project.AddAudioTrack();
                t.Name = trackName;
                return t;
            }

            AudioTrack track = new AudioTrack(project, 0, trackName);
            project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// トラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="useAdd">
        /// 生成したトラックをVEGAS標準の方式で挿入するかどうかのフラグ
        /// true: VEGAS標準の方式で挿入
        /// false: トラックビューの一番上に挿入
        /// 省略時は false
        /// </param>
        /// <returns>生成したトラックオブジェクト[AudioBusTrack]</returns>
        public AudioBusTrack AddAudioBusTrack(bool useAdd = false)
        {
            if (useAdd)
            {
                return project.AddAudioBusTrack();
            }

            AudioBusTrack track = new AudioBusTrack(project);
            project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// オーディオトラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="node">適応するFXプラグイン</param>
        /// <param name="useAdd">
        /// 生成したトラックをVEGAS標準の方式で挿入するかどうかのフラグ
        /// true: VEGAS標準の方式で挿入
        /// false: トラックビューの一番上に挿入
        /// 省略時は false
        /// </param>
        /// <returns>生成したトラックオブジェクト[AudioFXBusTrack]</returns>
        public AudioFXBusTrack AddAudioFXBusTrack(PlugInNode node, bool useAdd = false)
        {
            if (useAdd)
            {
                return project.AddAudioFXBusTrack(node);
            }

            AudioFXBusTrack track = new AudioFXBusTrack(project, node);
            project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// ビデオトラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <param name="useAdd">
        /// 生成したトラックをVEGAS標準の方式で挿入するかどうかのフラグ
        /// true: VEGAS標準の方式で挿入
        /// false: トラックビューの一番上に挿入
        /// 省略時は false
        /// </param>
        /// <returns>生成したトラックオブジェクト[VideoTrack]</returns>
        public VideoTrack AddVideoTrack(string trackName, bool useAdd = false)
        {
            if (useAdd)
            {
                VideoTrack t = project.AddVideoTrack();
                t.Name = trackName;
                return t;
            }

            VideoTrack track = new VideoTrack(project, 0, trackName);
            project.Tracks.Add(track);
            return track;
        }

        /// <summary>
        /// ビデオトアジャストメントラックを作成・トラックビューの一番上に挿入
        /// </summary>
        /// <param name="trackName">トラック名</param>
        /// <param name="useAdd">
        /// 生成したトラックをVEGAS標準の方式で挿入するかどうかのフラグ
        /// true: VEGAS標準の方式で挿入
        /// false: トラックビューの一番上に挿入
        /// 省略時は false
        /// </param>
        /// <returns>生成したトラックオブジェクト[VideoAdjustmentTrack]</returns>
        public VideoAdjustmentTrack AddAdjVideoTrack(string trackName, bool useAdd = false)
        {
            if (useAdd)
            {
                VideoAdjustmentTrack t = project.AddVideoAdjustmentTrack();
                t.Name = trackName;
                return t;
            }

            VideoAdjustmentTrack track = new VideoAdjustmentTrack(project, 0, trackName);
            project.Tracks.Add(track);
            return track;
        }
    }
}
