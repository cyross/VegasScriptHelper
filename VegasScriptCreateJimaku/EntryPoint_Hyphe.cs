using ScriptPortal.Vegas;
using VegasScriptHelper;
using VegasScriptHelper.Structs;
using VegasScriptHelper.Settings;
using VegasScriptHelper.ExtProc.Jimaku;

namespace VegasScriptCreateJimaku
{
    public struct HypheInfo
    {
        public bool IsUse;
        public int Length;
    }

    public partial class EntryPoint
    {
        private HypheInfo CreateHypheInfo(VegasHelper helper)
        {
            return new HypheInfo()
            {
                IsUse = helper.Config[Names.WdHyphe.Use],
                Length = helper.Config[Names.WdHyphe.Length]
            };
        }

        private void SaveHypheInfo(VegasHelper helper, in HypheInfo info)
        {
            helper.Config[Names.WdHyphe.Use] = info.IsUse;
            helper.Config[Names.WdHyphe.Length] = info.Length;
        }

        private void Hyphenation(VegasHelper helper, ref JimakuParams jimakuParams, in HypheInfo info)
        {
            Hyphenazer hyphenazer = new Hyphenazer(helper);

            VideoTrack jimakuTrack = jimakuParams.Jimaku.Track.Track;

            foreach(var jimakuEvent in jimakuTrack.Events)
            {
                Take take = jimakuEvent.Takes[0];

                Media media = take.Media;

                OFXStringParameter strparam = helper.OFXParam.GetStringParam(media, false);

                if (strparam == null) { continue; }

                helper.TextParam.SetTextToRtfBox(strparam);

                helper.Rtf.Text = hyphenazer.Get(helper.Rtf.Text, info.Length);

                helper.TextParam.SetTextFromRtfBox(strparam);
            }
        }
    }
}
