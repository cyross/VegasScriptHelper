using ScriptPortal.Vegas;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public void DeleteJimakuPrefix()
        {
            VideoTrack track = SelectedVideoTrack();

            if (track is null) { return; }

            DeleteJimakuPrefix(track);
        }
        public void DeleteJimakuPrefix(string title)
        {
            VideoTrack track = SearchVideoTrackByName(title);

            if (track is null) { return; }

            DeleteJimakuPrefix(track);
        }

        public void DeleteJimakuPrefix(VideoTrack track)
        {
            DeleteJimakuPrefix(track.Events);
        }

        public void DeleteJimakuPrefix(TrackEvents trackEvents)
        {
            foreach (TrackEvent trackEvent in trackEvents)
            {
                DeleteJimakuPrefix(trackEvent);
            }
        }
        public void DeleteJimakuPrefixFromRtf(int pos)
        {
            rtfBox.RtfText = rtfBox.RtfText.Substring(pos + 1);
            rtfBox.Update();
        }

        public void DeleteJimakuPrefix(TrackEvent trackEvent)
        {
            Take firstTake = GetFirstTake(trackEvent);
            Media media = firstTake.Media;

            if (media is null) { return; }

            OFXStringParameter ofxStringParam = GetOFXStringParameter(media, false);

            if (ofxStringParam is null) { return; }

            rtfBox.Rtf = GetOFXParameterString(ofxStringParam);

            int pos = GetJimakuPrefixSeparatorPositionFromRtf();

            DeleteJimakuPrefixFromRtf(pos);
            SetStringIntoOFXParameter(ofxStringParam, rtfBox.Rtf);
        }
    }
}
