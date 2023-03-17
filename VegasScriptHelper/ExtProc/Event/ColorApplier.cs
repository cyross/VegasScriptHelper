using ScriptPortal.Vegas;
using System.Drawing;
using VegasScriptHelper.ExtProc.Jimaku;

namespace VegasScriptHelper.ExtProc.Event
{
    public class ColorApplier : BaseProc.BaseExtProc
    {
        GetPrefix getPrefix;

        public ColorApplier(VegasHelper helper) : base(helper) {
            getPrefix = new GetPrefix(helper);
        }

        public void Exec(TrackEvents events, double outlineWidth, bool withCut = true, bool throwException = true)
        {
            foreach (TrackEvent e in events)
            {
                Take firstTake = myHelper.Take.GetFirstTake(e);

                Media media = firstTake.Media;

                if (media is null) { continue; }

                OFXStringParameter ofxStringParam = myHelper.OFXParam.GetStringParam(media, throwException);

                if (ofxStringParam is null) { continue; }

                OFXRGBAParameter ofxTextRGBAParam = myHelper.OFXParam.GetTextRGBAParam(media, throwException);

                if (ofxTextRGBAParam is null) { continue; }

                OFXDoubleParameter ofxOutlineWidthParam = myHelper.OFXParam.GetOLWidthParam(media, throwException);

                if (ofxOutlineWidthParam is null) { continue; }

                OFXRGBAParameter ofxOutlineRGBAParam = myHelper.OFXParam.GetOLRGBAParam(media, throwException);

                if (ofxOutlineRGBAParam is null) { continue; }

                myHelper.Rtf.Body = myHelper.OFXParam.GetString(ofxStringParam);

                string actor_string = getPrefix.Get(withCut);
                Color textColor = myHelper.Config.ActorToTextColor[actor_string];
                Color outlineColor = myHelper.Config.ActorToOLColor[actor_string];

                myHelper.OFXParam.SetRGBAParam(ofxTextRGBAParam, textColor);
                myHelper.OFXParam.SetRGBAParam(ofxOutlineRGBAParam, outlineColor);
                myHelper.OFXParam.SetDoubleParam(ofxOutlineWidthParam, outlineWidth);
                myHelper.TextParam.SetTextFromRtfBox(ofxStringParam);
            }
        }

        public void Exec(double outlineWidth, bool withCut = true, bool throwException = true)
        {
            TrackEvents events = myHelper.VideoTrack.Events(throwException);

            if (events is null) { return; }

            Exec(events, outlineWidth, withCut, false);
        }
    }
}
