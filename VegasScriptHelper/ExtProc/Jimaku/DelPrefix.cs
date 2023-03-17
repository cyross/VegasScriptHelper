using ScriptPortal.Vegas;

namespace VegasScriptHelper.ExtProc.Jimaku
{ 
    public class DelPrefix : BaseProc.BaseExtProc
    {
        private PrefixPos prefixPos;

        public DelPrefix(VegasHelper helper) : base(helper) {
            prefixPos = new PrefixPos(helper);
        }

        public override void Exec()
        {
            VideoTrack track = myHelper.Project.SelectedVideoTrack();

            if (track is null) { return; }

            Exec(track);
        }

        public void Exec(string title)
        {
            VideoTrack track = myHelper.Project.SearchVideoTrack(title);

            if (track is null) { return; }

            Exec(track);
        }

        public void Exec(VideoTrack track)
        {
            Exec(track.Events);
        }

        public void Exec(TrackEvents trackEvents)
        {
            foreach (TrackEvent trackEvent in trackEvents)
            {
                Exec(trackEvent);
            }
        }
        public void Exec(int pos)
        {
            myHelper.Rtf.Text = myHelper.Rtf.Text.Substring(pos + 1);
            myHelper.Rtf.Update();
        }

        public void Exec(TrackEvent trackEvent)
        {
            Take firstTake = myHelper.Take.GetFirstTake(trackEvent);
            Media media = firstTake.Media;

            if (media is null) { return; }

            OFXStringParameter ofxStringParam = myHelper.OFXParam.GetStringParam(media, false);

            if (ofxStringParam is null) { return; }

            myHelper.TextParam.SetTextToRtfBox(ofxStringParam);

            Exec(prefixPos.Get());

            myHelper.TextParam.SetTextFromRtfBox(ofxStringParam);
        }
    }
}
