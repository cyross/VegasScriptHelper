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
        public void ExpandFirstVideoEvent(double margin = 0.0)
        {
            TrackEvents videoEvents = GetVideoEvents();
            TrackEvents audioEvents = GetAudioEvents();

            ExpandFirstVideoEvent(videoEvents, audioEvents, margin);
        }

        public void ExpandFirstVideoEvent(VideoTrack videoTrack, AudioTrack audioTrack, double margin = 0.0)
        {
            ExpandFirstVideoEvent(GetVideoEvents(videoTrack), GetAudioEvents(audioTrack), margin);
        }

        public void ExpandFirstVideoEvent(TrackEvents videoEvents, TrackEvents audioEvents, double margin = 0.0)
        {
            VegasDuration duration = GetDuretionFromAllEventsInTrack(audioEvents, margin);

            SetEventTime(GetFirstEvent(videoEvents), duration);
        }
    }
}
