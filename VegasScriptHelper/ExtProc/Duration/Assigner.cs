using ScriptPortal.Vegas;
using System.Collections.Generic;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Duration
{
    public class Assigner: BaseProc.BaseExtProc
    {
        public Assigner(VegasHelper helper): base(helper) { }

        public void Exec(in AssignDurationInfo info)
        {
            TrackEvents videoEvents = info.VideoTrack.Events;
            TrackEvents audioEvents = info.AudioTrack.Events;

            if (videoEvents.Count != audioEvents.Count) { return; }

            // TrackEventsのまま処理をするとリストの内容が勝手に入れ替わって不具合の原因になるため、
            // 別のListを作ってそこにTrackEventを挿入する
            List<TrackEvent> tmpVideoEvents = VHUtility.RefillTrackEvents(videoEvents);
            List<TrackEvent> tmpAudioEvents = VHUtility.RefillTrackEvents(audioEvents);

            for (int i = 0; i < videoEvents.Count; i++)
            {
                VegasDuration duration = myHelper.Event.GetDuration(audioEvents[i]);

                myHelper.Event.SetDuration(tmpVideoEvents[i], duration, info.Margin, info.IsAdjustTakes);

                if (info.IsGrouping) { myHelper.Project.AddTrackEventGroup(tmpAudioEvents[i], tmpVideoEvents[i]); }
            }
        }

        public void Exec(double margin = 0, bool adjustTakes = true, bool group = true, bool isThrow = false)
        {
            Exec(null, margin, adjustTakes, group, isThrow);
        }

        public void Exec(string trackName, double margin = 0, bool adjustTakes = true, bool group = true, bool isThrow = false)
        {
            AssignDurationInfo info = new AssignDurationInfo()
            {
                VideoTrack = GetVideoTrack(trackName, isThrow),
                AudioTrack = GetAudioTrack(trackName, isThrow),
                Margin = margin,
                IsAdjustTakes = adjustTakes,
                IsGrouping = group
            };

            if (info.VideoTrack is null || info.AudioTrack is null) { return; }

            Exec(info);
        }

        private VideoTrack GetVideoTrack(string name, bool isThrow = false)
        {
            if(name == null) { return myHelper.Project.SelectedVideoTrack(isThrow); }

            return myHelper.Project.SearchVideoTrack(name, isThrow);
        }

        private AudioTrack GetAudioTrack(string name, bool isThrow = false)
        {
            if (name == null) { return myHelper.Project.SelectedAudioTrack(isThrow); }

            return myHelper.Project.SearchAudioTrack(name, isThrow);
        }
    }
}
