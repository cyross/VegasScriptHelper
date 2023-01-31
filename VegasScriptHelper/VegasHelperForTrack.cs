using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;

namespace VegasScriptHelper
{
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
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public Track SelectedTrack()
        {
            return SelectedTrack(Vegas.Project);
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public Track SelectedTrack(Project project)
        {
            foreach (Track track in project.Tracks)
            {
                if (track.Selected)
                {
                    return track;
                }
            }
            throw new VegasHelperTrackUnselectedException();
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public VideoTrack SelectedVideoTrack()
        {
            return SelectedVideoTrack(Vegas.Project);
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public VideoTrack SelectedVideoTrack(Project project)
        {
            foreach (Track track in project.Tracks)
            {
                if (track.Selected && track.IsVideo())
                {
                    return (VideoTrack)track;
                }
            }
            throw new VegasHelperTrackUnselectedException();
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public AudioTrack SelectedAudioTrack()
        {
            return SelectedAudioTrack(Vegas.Project);
        }

        /// <summary>
        /// プロジェクト内で選択しているトラックがあれば、そのトラックのオブジェクトを返す。
        /// なければnullを返す
        /// </summary>
        /// <param name="project">VEGASが開いているプロジェクト</param>
        /// <returns>選択プロジェクトがあればそのTrackオブジェクト、なければnull</returns>
        public AudioTrack SelectedAudioTrack(Project project)
        {
            foreach (Track track in project.Tracks)
            {
                if (track.Selected && track.IsAudio())
                {
                    return (AudioTrack)track;
                }
            }
            throw new VegasHelperTrackUnselectedException();
        }

        public string GetTrackTitle(Track track)
        {
            return track.Name;
        }

        public string GetVideoTrackTitle()
        {
            VideoTrack track = SelectedVideoTrack();
            return GetTrackTitle(track);
        }

        public string GetAudioTrackTitle()
        {
            AudioTrack track = SelectedAudioTrack();
            return GetTrackTitle(track);
        }

        public void SetTrackTitle(Track track, string title)
        {
            track.Name = title;
        }

        public void SetVideoTrackTitle(string title)
        {
            VideoTrack track = SelectedVideoTrack();
            SetTrackTitle(track, title);
        }

        public void SetAudioTrackTitle(string title)
        {
            AudioTrack track = SelectedAudioTrack();
            SetTrackTitle(track, title);
        }

        public VideoTrack SearchVideoTrackByName(string name)
        {
            Project project = Vegas.Project;
            foreach (Track track in project.Tracks)
            {
                if (track.IsVideo() && track.Name == name)
                {
                    return (VideoTrack)track;
                }
            }
            throw new VegasHelperNotFoundTrackException();
        }

        public AudioTrack SearchAudioTrackByName(string name)
        {
            Project project = Vegas.Project;
            foreach (Track track in project.Tracks)
            {
                if (track.IsAudio() && track.Name == name)
                {
                    return (AudioTrack)track;
                }
            }
            throw new VegasHelperNotFoundTrackException();
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
