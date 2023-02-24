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
        public void AssignAudioTrackDurationToVideoTrack(VideoTrack videoTrack, AudioTrack audioTrack, double margin = 0.0f, bool adjustTakes = true, bool group = true)
        {
            TrackEvents videoEvents = videoTrack.Events;
            TrackEvents audioEvents = audioTrack.Events;

            if (videoEvents.Count != audioEvents.Count) { return; }

            // TrackEventsのまま処理をするとリストの内容が勝手に入れ替わって不具合の原因になるため、
            // 別のListを作ってそこにTrackEventを挿入する
            List<TrackEvent> tmpVideoEvents = VegasHelperUtility.RefillTrackEvents(videoEvents);
            List<TrackEvent> tmpAudioEvents = VegasHelperUtility.RefillTrackEvents(audioEvents);

            for (int i = 0; i < videoEvents.Count; i++)
            {
                VegasDuration duration = GetEventTime(audioEvents[i]);

                SetEventTime(tmpVideoEvents[i], duration, margin, adjustTakes);

                if (group) { AddTrackEventGroup(tmpAudioEvents[i], tmpVideoEvents[i]); }
            }
        }

        public void AssignAudioTrackDurationToVideoTrack(string trackName, double margin = 0, bool adjustTakes = true, bool group = true)
        {
            VideoTrack videoTrack = SearchVideoTrackByName(trackName);

            if (videoTrack is null) { return; }

            AudioTrack audioTrack = SearchAudioTrackByName(trackName);

            if (audioTrack is null) { return; }

            AssignAudioTrackDurationToVideoTrack(videoTrack, audioTrack, margin, adjustTakes, group);
        }

        public void AssignAudioTrackDurationToVideoTrack(double margin = 0, bool adjustTakes = true, bool group = true)
        {
            VideoTrack videoTrack = SelectedVideoTrack();

            if (videoTrack is null) { return; }

            AudioTrack audioTrack = SelectedAudioTrack();

            if (audioTrack is null) { return; }

            AssignAudioTrackDurationToVideoTrack(videoTrack, audioTrack, margin, adjustTakes, group);
        }
    }
}
