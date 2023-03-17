using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHVideoTrack
    {
        private VegasHelper myHelper;

        public VHVideoTrack(VegasHelper helper)
        {
            myHelper = helper;
        }

        public TrackEvents Events(bool throwException = true)
        {
            VideoTrack selected = myHelper.Project.SelectedVideoTrack(throwException);

            if (selected is null) { return null; }

            return Events(selected, throwException);
        }

        public TrackEvents Events(VideoTrack track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VHNoneEventsException(); }

            return track.Events;
        }

        public string GetTitle(bool throwException = true)
        {
            VideoTrack track = myHelper.Project.SelectedVideoTrack(throwException);

            if (track is null) { return null; }

            return track.Name;
        }

        public void SetTitle(string title, bool throwException = true)
        {
            VideoTrack track = myHelper.Project.SelectedVideoTrack(throwException);

            if (track is null) { return; }

            track.Name = title;
        }

        public Dictionary<string, VideoTrack> GetKV
        {
            get
            {
                Dictionary<string, VideoTrack> keyValuePairs = new Dictionary<string, VideoTrack>();

                List<VideoTrack> tracks = myHelper.Project.AllVideoTracks.ToList();

                foreach (VideoTrack track in tracks)
                {
                    keyValuePairs[myHelper.Track.GetKey(track)] = track;
                }

                return keyValuePairs;
            }
        }
    }
}
