using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasScriptHelper;

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
                IsUse = helper.Settings[SN.WdHyphe.Use],
                Length = helper.Settings[SN.WdHyphe.Length]
            };
        }

        private void SaveHypheInfo(VegasHelper helper, in HypheInfo info)
        {
            helper.Settings[SN.WdHyphe.Use] = info.IsUse;
            helper.Settings[SN.WdHyphe.Length] = info.Length;
        }

        private void Hyphenation(VegasHelper helper, ref JimakuParams jimakuParams, in HypheInfo info)
        {
            VideoTrack jimakuTrack = jimakuParams.Jimaku.Track.Track;

            foreach(var jimakuEvent in jimakuTrack.Events)
            {
                Take take = jimakuEvent.Takes[0];

                Media media = take.Media;

                OFXStringParameter strparam = helper.GetOFXStringParameter(media, false);

                if (strparam == null) { continue; }

                helper.SetTextToRtfBox(strparam);

                helper.RtfLines = helper.Hyphenation(helper.RtfLines, info.Length);

                helper.SetTextFromRtfBox(strparam);
            }
        }
    }
}
