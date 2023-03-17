using ScriptPortal.Vegas;
using VegasScriptHelper.ExtProc.Event;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper.ExtProc
{
    public class Inserter : BaseProc.BaseExtProc
    {
        private Aligner aligner;

        public Inserter(VegasHelper helper) : base(helper) {
            aligner = new Aligner(helper);
        }

        public void Exec(in BackgroundInfo info, AudioTrack audioTrack, bool isCreateOneEventCheck, bool isGrouping = false)
        {
            if (!info.IsCreate) { return; }

            AlignmentEventInfo a_info = new AlignmentEventInfo()
            {
                VideoTrack = info.Track.Track,
                AudioTrack = audioTrack,
                Media = info.Media.Media,
                Margin = info.Margin,
                IsGrouping = isGrouping
            };

            aligner.Exec(a_info, isCreateOneEventCheck);
        }
    }
}
