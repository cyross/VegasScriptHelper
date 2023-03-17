using ScriptPortal.Vegas;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Duration
{
    public class Getter : BaseProc.BaseExtProc
    {
        public Getter(VegasHelper helper) : base(helper) { }

        public VegasDuration Get(TrackEvents events, double margin = 0.0f, bool throwException = true)
        {
            TrackEvent firstEvent = myHelper.Event.First(events, throwException);
            TrackEvent lastEvent = myHelper.Event.Last(events, throwException);

            if (firstEvent is null || lastEvent is null)
            {
                return new VegasDuration(new Timecode(0), new Timecode(0));
            }

            Timecode singleMaraginTimecode = new Timecode(margin);
            Timecode doubleMaraginTimecode = new Timecode(margin * 2);

            VegasDuration duration = new VegasDuration()
            {
                StartTime = firstEvent.Start - singleMaraginTimecode,
                Length = lastEvent.Start + lastEvent.Length - firstEvent.Start + doubleMaraginTimecode
            };

            return duration;
        }

        /// <summary>
        /// 選択したトラック内のイベントの開始位置と流さを求める。
        /// 最初のイベントの開始位置から最後のイベントの終点までをその長さとする。
        /// また、引数としてマージンもセット可能
        /// </summary>
        /// <param name="margin">設定するマージン。初期値は0.0</param>
        /// <returns></returns>
        public VegasDuration Get(double margin = 0.0f, bool throwException = true)
        {
            Track selected = myHelper.Project.SelectedTrack(throwException);

            if (selected is null) { return new VegasDuration(new Timecode(0), new Timecode(0)); }

            return Get(selected, margin, throwException);
        }

        public VegasDuration Get(Track track, double margin = 0.0f, bool throwException = true)
        {
            TrackEvents events = myHelper.Track.Events(track, throwException);

            if (events is null) { return new VegasDuration(new Timecode(0), new Timecode(0)); }

            return Get(events, margin, throwException);
        }
    }
}
