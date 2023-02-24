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
        /// <summary>
        /// 選択したトラック内のイベントの開始位置と流さを求める。
        /// 最初のイベントの開始位置から最後のイベントの終点までをその長さとする。
        /// また、引数としてマージンもセット可能
        /// </summary>
        /// <param name="margin">設定するマージン。初期値は0.0</param>
        /// <returns></returns>
        public VegasDuration GetDuretionFromAllEventsInTrack(double margin = 0.0f, bool throwException = true)
        {
            Track selected = SelectedTrack(throwException);

            if (selected is null) { return new VegasDuration(new Timecode(0), new Timecode(0)); }

            return GetDuretionFromAllEventsInTrack(selected, margin, throwException);
        }

        public VegasDuration GetDuretionFromAllEventsInTrack(Track track, double margin = 0.0f, bool throwException = true)
        {
            TrackEvents events = GetEvents(track, throwException);

            if (events is null) { return new VegasDuration(new Timecode(0), new Timecode(0)); }

            return GetDuretionFromAllEventsInTrack(events, margin, throwException);
        }

        public VegasDuration GetDuretionFromAllEventsInTrack(TrackEvents events, double margin = 0.0f, bool throwException = true)
        {
            TrackEvent firstEvent = GetFirstEvent(events, throwException);
            TrackEvent lastEvent = GetLastEvent(events, throwException);

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
    }
}
