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
        public void CreateVideoEventWithAudioTrack(VideoTrack videoTrack, AudioTrack audioTrack, Media videoMedia, double margin = 0.0f, bool group = true)
        {
            TrackEvents audioEvents = audioTrack.Events;

            for (int i = 0; i < audioEvents.Count; i++)
            {
                TrackEvent videoEvent = CreateVideoEvent(videoTrack, videoMedia, audioEvents[i].Start, audioEvents[i].Length, margin);

                if (group) { AddTrackEventGroup(audioEvents[i], videoEvent); }
            }
        }

        public void CreateFullSizeVideoEventWithAudioTrack(VideoTrack videoTrack, AudioTrack audioTrack, Media videoMedia, double margin = 0.0f)
        {
            TrackEvents audioEvents = audioTrack.Events;

            if(audioEvents.Count == 0) { return; }

            TrackEvent first = audioEvents.First();
            TrackEvent last = audioEvents.Last();

            Timecode length = last.Start + last.Length - first.Start;

            CreateVideoEvent(videoTrack, videoMedia, first.Start, length, margin);
        }
    }
}
