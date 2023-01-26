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
            if (throwError && selected.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }
            return selected.Events;
        }

        public TrackEvents GetAudioEvents(bool throwError = true)
        {
            AudioTrack selected = SelectedAudioTrack();
            if (throwError && selected.Events.Count == 0) { throw new VegasHelperNoneEventsException(); }
            return selected.Events;
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

        public long GetEventStartTime(TrackEvent trackEvent)
        {
            return trackEvent.Start.Nanos;
        }

        public void SetEventStartTime(TrackEvent trackEvent, long nanos)
        {
            trackEvent.Start = new Timecode(nanos);
        }

        public long GetEventLength(TrackEvent trackEvent)
        {
            return trackEvent.Length.Nanos;
        }

        public void SetEventLength(TrackEvent trackEvent, long nanos)
        {
            trackEvent.Length = new Timecode(nanos);
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
