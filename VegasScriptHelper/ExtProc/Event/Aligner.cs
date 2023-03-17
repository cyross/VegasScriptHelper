using ScriptPortal.Vegas;
using System.Linq;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Event
{
    public class Aligner : BaseProc.BaseExtProc
    {
        public Aligner(VegasHelper helper) : base(helper) { }

        public void Exec(in AlignmentEventInfo info, bool full = false)
        {
            if (info.Media == null) return;

            TrackEvents audioEvents = info.AudioTrack.Events;

            if (audioEvents.Count == 0) { return; }

            if (full)
            {
                Full(info, audioEvents);

                return;
            }

            for (int i = 0; i < audioEvents.Count; i++)
            {
                TrackEvent videoEvent = myHelper.VideoEvent.Create(info.VideoTrack, info.Media, audioEvents[i].Start, audioEvents[i].Length, info.Margin);

                if (info.IsGrouping) { myHelper.Project.AddTrackEventGroup(audioEvents[i], videoEvent); }
            }
        }

        private void Full(in AlignmentEventInfo info, TrackEvents audioEvents)
        {
            TrackEvent first = audioEvents.First();
            TrackEvent last = audioEvents.Last();

            Timecode length = last.Start + last.Length - first.Start;

            myHelper.VideoEvent.Create(info.VideoTrack, info.Media, first.Start, length, info.Margin);
        }
    }
}
