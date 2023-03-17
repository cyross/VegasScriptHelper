using ScriptPortal.Vegas;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc.Duration
{
    public class Length : BaseProc.BaseExtProc
    {
        private Getter getter;

        public Length(VegasHelper helper) : base(helper) {
            getter = new Getter(helper);
        }

        public Timecode Get(bool throwException = true)
        {
            Track selected = myHelper.Project.SelectedTrack(throwException);

            if (selected is null) { return null; }

            return Get(selected, throwException);
        }

        public Timecode Get(Track track, bool throwException = true)
        {
            VegasDuration duration = getter.Get(track, throwException: throwException);

            return duration.Length;
        }
    }
}
