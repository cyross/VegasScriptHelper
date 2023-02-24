using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public Timecode GetLengthFromAllEventsInTrack(bool throwException = true)
        {
            Track selected = SelectedTrack(throwException);

            if (selected is null) { return null; }

            return GetLengthFromAllEventsInTrack(selected, throwException);
        }

        public Timecode GetLengthFromAllEventsInTrack(Track track, bool throwException = true)
        {
            VegasDuration duration = GetDuretionFromAllEventsInTrack(track, throwException: throwException);

            return duration.Length;
        }
    }
}
