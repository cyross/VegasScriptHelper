using System.Collections.Generic;
using System.Linq;
using ScriptPortal.Vegas;
using VegasScriptHelper.Structs;
using VegasScriptHelper.Errors;

namespace VegasScriptHelper
{
    public class VHEvent
    {
        private VegasHelper myHelper;

        public VHEvent(VegasHelper helper)
        {
            myHelper = helper;
        }

        public TrackEvent Get(Track track, bool throwException = true)
        {
            if (throwException && track.Events.Count == 0) { throw new VHNoneEventsException(); }

            foreach (TrackEvent e in track.Events)
            {
                if (e.Selected) { return e; }
            }

            if (throwException) { throw new VHNoneSelectedEventException(); }

            return null;
        }

        public TrackEvent Get(bool throwException = true)
        {
            Track track = myHelper.Project.SelectedTrack(throwException);

            if (track is null) { return null; }

            return Get(track, throwException);
        }

        public Timecode GetStartTime(TrackEvent trackEvent)
        {
            return trackEvent.Start;
        }

        public void SetStartTime(TrackEvent trackEvent, Timecode start)
        {
            trackEvent.Start = start;
        }

        public Timecode GetLength(TrackEvent trackEvent)
        {
            return trackEvent.Length;
        }

        public void SetLength(TrackEvent trackEvent, Timecode length)
        {
            trackEvent.Length = length;
        }

        public VegasDuration GetDuration(TrackEvent trackEvent)
        {
            VegasDuration duration = new VegasDuration();

            duration.StartTime = trackEvent.Start;
            duration.Length = trackEvent.Length;

            return duration;
        }

        public void SetDuration(TrackEvent trackEvent, VegasDuration duration, double margin = 0.0f, bool adjustTakes = true)
        {
            Timecode start = duration.StartTime - new Timecode(margin);
            Timecode length = duration.Length + new Timecode(margin * 2);

            trackEvent.AdjustStartLength(start, length, adjustTakes);
        }

        public TrackEvent First(TrackEvents events, bool throwException = true)
        {
            if (throwException && events.Count == 0) { throw new VHNoneEventsException(); }

            return events[0];
        }

        public TrackEvent Last(TrackEvents events, bool throwException = true)
        {
            if (throwException && events.Count == 0) { throw new VHNoneEventsException(); }

            return events[events.Count - 1];
        }

        public List<TrackEvent> Range(TrackEvents events, TrackEvent first, TrackEvent last)
        {
            return events.Where(e => e.Start >= first.Start && e.Start <= last.Start).ToList();
        }

        public List<TrackEvent> Remain(TrackEvents events, TrackEvent last)
        {
            return events.Where(e => e.Start > last.Start).ToList();
        }
    }
}
