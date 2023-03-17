using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace VegasScriptHelper
{
    public class VHUtility
    {
        public static List<TrackEvent> RefillTrackEvents(TrackEvents trackEvents)
        {
            List<TrackEvent> events = new List<TrackEvent>();

            foreach (TrackEvent e in trackEvents) { events.Add(e); }

            return events;
        }

        public static string GetExecDirectory()
        {
            return Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        }

        public static string GetExecFilepath(string fileName)
        {
            return Path.Combine(GetExecDirectory(), fileName);
        }
    }
}
