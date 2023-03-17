using ScriptPortal.Vegas;
using System.Drawing;
using VegasScriptHelper.Structs;

namespace VegasScriptHelper
{
    public class VHTextParam
    {
        private VegasHelper myHelper;

        public VHTextParam(VegasHelper helper)
        {
            myHelper = helper;
        }

        public void SetText(VideoTrack track, string text, ColorInfo info, bool throwException = true)
        {
            TrackEvents events = myHelper.Track.Events(track);

            foreach (TrackEvent e in events)
            {
                SetText(e, text, info);
            }
        }

        public void SetText(TrackEvent trackEvent, string text, ColorInfo info, bool throwException = true)
        {
            foreach (Take take in myHelper.Take.GetTakes(trackEvent))
            {
                SetText(take, text, info);
            }
        }

        public void SetText(Take take, string text, ColorInfo info, bool throwException = true)
        {
            Media media = take.Media;

            SetText(media, text, info);
        }

        public void SetText(Media media, string text, ColorInfo info, bool throwException = true)
        {
            SetText(media, text);
            SetTextColor(media, info);
        }

        public void SetText(Media media, string text, bool throwException = true)
        {
            if (media is null) { return; }

            OFXStringParameter ofxStringParam = myHelper.OFXParam.GetStringParam(media);

            if (ofxStringParam is null) { return; }

            myHelper.Rtf.Body = myHelper.OFXParam.GetString(ofxStringParam);
            myHelper.Rtf.Text = text;

            SetTextFromRtfBox(ofxStringParam);
        }

        public void SetTextToRtfBox(OFXStringParameter ofxStringParam)
        {
            myHelper.Rtf.Body = myHelper.OFXParam.GetString(ofxStringParam);
        }

        public void SetTextFromRtfBox(OFXStringParameter ofxStringParam)
        {
            myHelper.OFXParam.SetString(ofxStringParam, myHelper.Rtf.Body);
        }

        public void SetTextColor(VideoTrack track, ColorInfo info, bool throwException = true)
        {
            SetTextColor(track, info.TextColor, info.OutlineColor, info.OutlineWidth);
        }

        public void SetTextColor(VideoTrack track, Color textColor, Color outlineColor, double outlineWidth, bool throwException = true)
        {
            TrackEvents events = myHelper.Track.Events(track);

            foreach (TrackEvent e in events)
            {
                SetTextColor(e, textColor, outlineColor, outlineWidth);
            }
        }

        public void SetTextColor(TrackEvent trackEvent, ColorInfo info, bool throwException = true)
        {
            SetTextColor(trackEvent, info.TextColor, info.OutlineColor, info.OutlineWidth);
        }

        public void SetTextColor(TrackEvent trackEvent, Color textColor, Color outlineColor, double outlineWidth, bool throwException = true)
        {
            foreach (Take take in myHelper.Take.GetTakes(trackEvent))
            {
                SetTextColor(take, textColor, outlineColor, outlineWidth);
            }
        }

        public void SetTextColor(Take take, ColorInfo info, bool throwException = true)
        {
            SetTextColor(take, info.TextColor, info.OutlineColor, info.OutlineWidth);
        }

        public void SetTextColor(Take take, Color textColor, Color outlineColor, double outlineWidth, bool throwException = true)
        {
            Media media = take.Media;

            SetTextColor(media, textColor, outlineColor, outlineWidth);
        }

        public void SetTextColor(Media media, ColorInfo info, bool throwException = true)
        {
            SetTextColor(media, info.TextColor, info.OutlineColor, info.OutlineWidth);
        }

        public void SetTextColor(Media media, Color textColor, Color outlineColor, double outlineWidth, bool throwException = true)
        {
            if (media is null) { return; }

            OFXStringParameter ofxStringParam = myHelper.OFXParam.GetStringParam(media);

            if (ofxStringParam is null) { return; }

            OFXRGBAParameter ofxTextRGBAParam = myHelper.OFXParam.GetTextRGBAParam(media);

            if (ofxTextRGBAParam is null) { return; }

            OFXDoubleParameter ofxOutlineWidthParam = myHelper.OFXParam.GetOLWidthParam(media);

            if (ofxOutlineWidthParam is null) { return; }

            OFXRGBAParameter ofxOutlineRGBAParam = myHelper.OFXParam.GetOLRGBAParam(media);

            if (ofxOutlineRGBAParam is null) { return; }

            myHelper.OFXParam.SetRGBAParam(ofxTextRGBAParam, textColor);
            myHelper.OFXParam.SetRGBAParam(ofxOutlineRGBAParam, outlineColor);
            myHelper.OFXParam.SetDoubleParam(ofxOutlineWidthParam, outlineWidth);
        }
    }
}
