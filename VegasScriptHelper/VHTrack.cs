using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHTrack
    {
        private VegasHelper myHelper;

        public VHTrack(VegasHelper helper)
        {
            myHelper = helper;
        }

        public TrackEvents Events(Track track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VHNoneEventsException(); }

            return track.Events;
        }

        public Dictionary<string, Track> GetKV()
        {
            Dictionary<string, Track> keyValuePairs = new Dictionary<string, Track>();

            List<Track> tracks = myHelper.Project.AllTracks.ToList();

            foreach (Track track in tracks)
            {
                keyValuePairs[GetKey(track)] = track;
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

        public string GetKey(Track track)
        {
            return string.Format("[{0}]{1}", (track.Index + 1).ToString(), track.Name ?? "");
        }
    }
}
