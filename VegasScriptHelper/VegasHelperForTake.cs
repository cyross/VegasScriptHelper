using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public Take[] GetFirstTakes(Track track)
        {
            return GetFirstTakes(track.Events);
        }

        public Take[] GetFirstTakes(TrackEvents events)
        {
            IEnumerable<Take> takes = events.Select(e => GetFirstTake(e));
            return takes.ToArray();
        }

        public Take[] GetLastTakes(Track track)
        {
            return GetLastTakes(track.Events);
        }

        public Take[] GetLastTakes(TrackEvents events)
        {
            IEnumerable<Take> takes = events.Select(e => GetLastTake(e));
            return takes.ToArray();
        }

        public Takes GetTakes(TrackEvent trackEvent)
        {
            return trackEvent.Takes;
        }

        public Take GetFirstTake(TrackEvent trackEvent)
        {
            return trackEvent.Takes[0];
        }

        public Take GetLastTake(TrackEvent trackEvent)
        {
            return trackEvent.Takes[trackEvent.Takes.Count - 1];
        }

        public Take[] GetVideoTakes()
        {
            VideoTrack selected = SelectedVideoTrack();
            return GetFirstTakes(selected.Events);
        }

        public Take[] GetAudioTakes()
        {
            AudioTrack selected = SelectedAudioTrack();
            return GetFirstTakes(selected.Events);
        }

    }
}
