using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;

namespace VegasScriptHelper
{
    public class VegasHelperUtility
    {
        public static string NanoToTimestamp(long nanos)
        {
            TimeSpan span = new TimeSpan(nanos);
            return span.ToString("g");
        }

        public static long RoundNanos(long nanos)
        {
            return nanos + 500000 / 1000000 * 1000000;
        }

        public static List<TrackEvent> RefillTrackEvents(TrackEvents trackEvents)
        {
            List<TrackEvent> events = new List<TrackEvent>();
            foreach (TrackEvent e in trackEvents) { events.Add(e); }
            return events;
        }
    }
}
