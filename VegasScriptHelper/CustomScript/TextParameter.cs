using ScriptPortal.Vegas;
using System.Drawing;

namespace VegasScriptHelper
{
    public partial class VegasHelper
    {
        public void SetText(VideoTrack track, string text, ColorInfo info, bool throwException = true)
        {
            TrackEvents events = GetEvents(track);

            foreach (TrackEvent e in events)
            {
                SetText(e, text, info);
            }
        }

        public void SetText(TrackEvent trackEvent, string text, ColorInfo info, bool throwException = true)
        {
            foreach (Take take in GetTakes(trackEvent))
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

            OFXStringParameter ofxStringParam = GetOFXStringParameter(media);

            if (ofxStringParam is null) { return; }

            rtfBox.Rtf = GetOFXParameterString(ofxStringParam);
            rtfBox.RtfText = text;

            SetStringIntoOFXParameter(ofxStringParam, rtfBox.Rtf);
        }

        public void SetTextColor(VideoTrack track, ColorInfo info, bool throwException = true)
        {
            SetTextColor(track, info.TextColor, info.OutlineColor, info.OutlineWidth);
        }

        public void SetTextColor(VideoTrack track, Color textColor, Color outlineColor, double outlineWidth, bool throwException = true)
        {
            TrackEvents events = GetEvents(track);

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
            foreach (Take take in GetTakes(trackEvent))
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

            OFXStringParameter ofxStringParam = GetOFXStringParameter(media);

            if (ofxStringParam is null) { return; }

            OFXRGBAParameter ofxTextRGBAParam = GetTextRGBAParameter(media);

            if (ofxTextRGBAParam is null) { return; }

            OFXDoubleParameter ofxOutlineWidthParam = GetOutlineWidthParameter(media);

            if (ofxOutlineWidthParam is null) { return; }

            OFXRGBAParameter ofxOutlineRGBAParam = GetOutlineRGBAParameter(media);

            if (ofxOutlineRGBAParam is null) { return; }

            SetRGBAParameter(ofxTextRGBAParam, textColor);
            SetRGBAParameter(ofxOutlineRGBAParam, outlineColor);
            SetDoubleParameter(ofxOutlineWidthParam, outlineWidth);
        }

        public void ApplyTextColorByActor(TrackEvents events, double outlineWidth, bool withCut = true, bool throwException = true)
        {
            foreach (TrackEvent e in events)
            {
                Take firstTake = GetFirstTake(e);

                Media media = firstTake.Media;

                if (media is null) { continue; }

                OFXStringParameter ofxStringParam = GetOFXStringParameter(media, throwException);

                if (ofxStringParam is null) { continue; }

                OFXRGBAParameter ofxTextRGBAParam = GetTextRGBAParameter(media, throwException);

                if (ofxTextRGBAParam is null) { continue; }

                OFXDoubleParameter ofxOutlineWidthParam = GetOutlineWidthParameter(media, throwException);

                if (ofxOutlineWidthParam is null) { continue; }

                OFXRGBAParameter ofxOutlineRGBAParam = GetOutlineRGBAParameter(media, throwException);

                if (ofxOutlineRGBAParam is null) { continue; }

                rtfBox.Rtf = GetOFXParameterString(ofxStringParam);

                string actor_string = GetJimakuPrefixFromRtf(withCut);
                Color textColor = _settings.TextColorByActor[actor_string];
                Color outlineColor = _settings.OutlineColorByActor[actor_string];

                SetRGBAParameter(ofxTextRGBAParam, textColor);
                SetDoubleParameter(ofxOutlineWidthParam, outlineWidth);
                SetRGBAParameter(ofxOutlineRGBAParam, outlineColor);
                SetStringIntoOFXParameter(ofxStringParam, rtfBox.Rtf);
            }
        }

        public void ApplyTextColorByActor(double outlineWidth, bool withCut = true, bool throwException = true)
        {
            TrackEvents events = GetVideoEvents(throwException);

            if (events is null) { return; }

            ApplyTextColorByActor(events, outlineWidth, withCut, false);
        }
    }
}
