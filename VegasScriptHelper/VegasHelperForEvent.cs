using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public TrackEvents GetEvents(Track track, bool throwError = true)
        {
            if (throwError && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }
            return track.Events;
        }

        public TrackEvents GetVideoEvents(bool throwError = true)
        {
            VideoTrack selected = SelectedVideoTrack();
            return GetVideoEvents(selected, throwError);
        }

        public TrackEvents GetVideoEvents(VideoTrack track, bool throwError = true)
        {
            if (throwError && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }
            return track.Events;
        }

        public TrackEvents GetAudioEvents(bool throwError = true)
        {
            AudioTrack selected = SelectedAudioTrack();
            return GetAudioEvents(selected, throwError);
        }

        public TrackEvents GetAudioEvents(AudioTrack track, bool throwError = true)
        {
            if (throwError && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }
            return track.Events;
        }

        public TrackEvent GetSelectedEvent(Track track, bool throwError = true)
        {
            if (throwError && track.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }
            foreach (TrackEvent e in track.Events)
            {
                if (e.Selected)
                {
                    return e;
                }
            }
            if (throwError) { throw new VegasHelperNoneSelectedEventException(); }
            return null;
        }

        public TrackEvent GetSelectedEvent(bool throwError = true)
        {
            Track track = SelectedTrack();
            return GetSelectedEvent(track, throwError);
        }

        public TrackEvent GetSelectedVideoEvent(bool throwError = true)
        {
            Track track = SelectedVideoTrack();
            return GetSelectedEvent(track, throwError);
        }

        public TrackEvent GetSelectedAudioEvent(bool throwError = true)
        {
            Track track = SelectedAudioTrack();
            return GetSelectedEvent(track, throwError);
        }

        public Timecode GetEventStartTime(TrackEvent trackEvent)
        {
            return trackEvent.Start;
        }

        public void SetEventStartTime(TrackEvent trackEvent, Timecode start)
        {
            trackEvent.Start = start;
        }

        public Timecode GetEventLength(TrackEvent trackEvent)
        {
            return trackEvent.Length;
        }

        public void SetEventLength(TrackEvent trackEvent, Timecode length)
        {
            trackEvent.Length = length;
        }

        public VegasDuration GetEventTime(TrackEvent trackEvent)
        {
            VegasDuration duration = new VegasDuration();
            duration.StartTime = trackEvent.Start;
            duration.Length = trackEvent.Length;
            return duration;
        }

        public void SetEventTime(TrackEvent trackEvent, VegasDuration duration, double margin = 0.0f, bool adjustTakes = true)
        {
            Timecode start = duration.StartTime - new Timecode(margin);
            Timecode length = duration.Length + new Timecode(margin * 2);
            trackEvent.AdjustStartLength(start, length, adjustTakes);
        }

        public TrackEvent GetFirstEvent(TrackEvents events)
        {
            return events[0];
        }

        public TrackEvent GetLastEvent(TrackEvents events)
        {
            return events[events.Count - 1];
        }
    }
}
