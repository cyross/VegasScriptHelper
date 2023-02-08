using ScriptPortal.Vegas;
using System.Drawing;

namespace VegasScriptHelper
{
    /// <summary>
    /// フォーム処理を伴うヘルパメソッド群はこちらに実装
    /// </summary>
    public partial class VegasHelper
    {
        private static readonly RichTextViewForm rtfBox = new RichTextViewForm();

        public int GetJimakuPrefixSeparatorPositionFromRtf(bool throwException = true)
        {
            int pos = rtfBox.RtfBox.Find(":");

            if (pos == -1 && throwException) { throw new VegasHelperNotFoundJimakuPrefixException(); }

            return pos;
        }

        public string GetJimakuPrefixFromRtf()
        {
            int pos = GetJimakuPrefixSeparatorPositionFromRtf();

            return GetJimakuPrefixFromRtf(pos);
        }

        public string GetJimakuPrefixFromRtf(int pos)
        {
            if(pos == -1) { return ""; }

            return rtfBox.RtfText.Substring(0, pos);
        }

        public string GetJimakuPrefixFromRtf(bool withCut = true)
        {
            int pos = GetJimakuPrefixSeparatorPositionFromRtf();
            string actor_name = GetJimakuPrefixFromRtf(pos);

            if (actor_name != "" && withCut)
            {
                DeleteJimakuPrefixFromRtf(pos);
            }

            return actor_name;
        }

        public void DeleteJimakuPrefixFromRtf(int pos)
        {
            rtfBox.RtfText = rtfBox.RtfText.Substring(pos + 1);
            rtfBox.Update();
        }

        public void SetColorIntoAllRtfText(Color textColor)
        {
            rtfBox.RtfBox.SelectAll();
            rtfBox.RtfBox.SelectionColor = textColor;
        }

        public void SetTextColorByActor(string actor_name)
        {
            string actor_name_key = VegasScriptSettings.FormatKey(actor_name);
            Color actor_color = GetTextColorByActor(actor_name_key);

            SetColorIntoAllRtfText(actor_color);
        }

        public Color GetTextColorByActor(string actor_name)
        {
            string actor_name_key = VegasScriptSettings.FormatKey(actor_name);

            if (!VegasScriptSettings.TextColorByActor.Contains(actor_name_key))
            {
                return Color.White;
            }

            return VegasScriptSettings.TextColorByActor[actor_name_key];
        }

        public Color GetOutlineColorByActor(string actor_name)
        {
            string actor_name_key = VegasScriptSettings.FormatKey(actor_name);

            if (!VegasScriptSettings.OutlineColorByActor.Contains(actor_name_key))
            {
                return Color.Black;
            }

            return VegasScriptSettings.OutlineColorByActor[actor_name_key];
        }

        public void SetRGBAParameter(OFXRGBAParameter param, Color color)
        {
            OFXColor ofxColor = new OFXColor(
                (double)color.R / 255.0,
                (double)color.G / 255.0,
                (double)color.B / 255.0,
                (double)color.A / 255.0
            );

            param.SetValueAtTime(new Timecode(0), ofxColor);
        }

        public void ApplyTextColorByActor(TrackEvents events, double outlineWidth, bool withCut = true)
        {
            foreach (TrackEvent e in events)
            {
                Take firstTake = GetFirstTake(e);

                Media media = firstTake.Media;

                if(media is null) { continue; }

                OFXStringParameter ofxStringParam = GetOFXStringParameter(media, false);

                if (ofxStringParam is null) { continue; }

                OFXRGBAParameter ofxTextRGBAParam = GetTextRGBAParameter(media, false);

                if (ofxTextRGBAParam is null) { continue; }

                OFXDoubleParameter ofxOutlineWidthParam = GetOutlineWidthParameter(media, false);

                if (ofxOutlineWidthParam is null) { continue; }

                OFXRGBAParameter ofxOutlineRGBAParam = GetOutlineRGBAParameter(media, false);

                if (ofxOutlineRGBAParam is null) { continue; }

                rtfBox.Rtf = GetOFXParameterString(ofxStringParam);

                string actor_string = GetJimakuPrefixFromRtf(withCut);
                Color textColor = GetTextColorByActor(actor_string);
                Color outlineColor = GetOutlineColorByActor(actor_string);

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

            ApplyTextColorByActor(events, outlineWidth, withCut);
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
