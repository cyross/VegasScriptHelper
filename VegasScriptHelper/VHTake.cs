using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;

namespace VegasScriptHelper
{
    public class VHTake
    {
        private VegasHelper myHelper;

        public VHTake(VegasHelper helper)
        {
            myHelper = helper;
        }

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

        public Take[] GetTakes(Track track)
        {
            return GetFirstTakes(track.Events);
        }

        public Take[] GetVideoTakes(bool throwException = true)
        {
            VideoTrack selected = myHelper.Project.SelectedVideoTrack(throwException);

            if (selected is null) { return null; }

            return GetFirstTakes(selected);
        }

        public Take[] GetAudioTakes(bool throwException = true)
        {
            AudioTrack selected = myHelper.Project.SelectedAudioTrack(throwException);

            if (selected is null) { return null; }

            return GetFirstTakes(selected);
        }

    }
}
