using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;

namespace VegasScriptHelper
{
    public class VegasHelperUtility
    {
        public static List<TrackEvent> RefillTrackEvents(TrackEvents trackEvents)
        {
            List<TrackEvent> events = new List<TrackEvent>();
            foreach (TrackEvent e in trackEvents) { events.Add(e); }
            return events;
        }
    }
}
