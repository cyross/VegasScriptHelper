using ScriptPortal.Vegas;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Event
{
    public class Expander : BaseProc.BaseExtProc
    {
        private readonly Duration.Getter getter;

        public Expander(VegasHelper helper) : base(helper) {
            getter = new Duration.Getter(helper);
        }

        public void Exec(double margin = 0.0)
        {
            TrackEvents videoEvents = myHelper.VideoTrack.Events();
            TrackEvents audioEvents = myHelper.AudioTrack.Events();

            Exec(videoEvents, audioEvents, margin);
        }

        public void Exec(VideoTrack videoTrack, AudioTrack audioTrack, double margin = 0.0)
        {
            Exec(myHelper.VideoTrack.Events(videoTrack), myHelper.AudioTrack.Events(audioTrack), margin);
        }

        public void Exec(TrackEvents videoEvents, TrackEvents audioEvents, double margin = 0.0)
        {
            VegasDuration duration = getter.Get(audioEvents, margin);

            myHelper.Event.SetDuration(myHelper.Event.First(videoEvents), duration);
        }
    }
}
